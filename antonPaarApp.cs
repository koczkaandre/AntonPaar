using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntonPaar
{
    public partial class antonPaarApp : Form
    {
        private String toBeProcessed;
        private readonly BackgroundWorker processWorker;
        private Boolean cancelTask = false;

        // Initialize the Form
        public antonPaarApp()
        {
            InitializeComponent();

            resultList.Columns.Add("Word", 140);
            resultList.Columns.Add("Occurance", 140);
            resultList.GridLines = true;
            resultList.View = View.Details;
            resultList.MultiSelect = true;
            resultList.FullRowSelect = true;

            processWorker = new BackgroundWorker();
            processWorker.WorkerSupportsCancellation = true; 
            processWorker.DoWork +=
               new DoWorkEventHandler(processFile);
            processWorker.RunWorkerCompleted += completed;
            processWorker.WorkerReportsProgress = true;

            countButton.Enabled = false;
        }

        // This function handles the selection of the file, and is triggerd by the "browse file" button
        private async void browse_file(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            String path = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                status_label.Text = "Parsing File, please wait";

                path = openFileDialog.FileName;
                pathLabel.Text = path;
            }
            else return;

            cancelTask = false;
           
            Task<string> readText = ReadTextAsync(path);
            await readText;
          
            status_label.Text = "Parsing complete, please click COUNT";
            toBeProcessed = readText.Result;
            countButton.Enabled = true;


        }

        // This function parses the selected file, and is an async function, so nothing is blocked by this process
        public async Task<string> ReadTextAsync(string path)
        {
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            var reader = new StreamReader(stream);

            var readTask = reader.ReadToEndAsync();

            MethodInvoker invThread = delegate
            {
                progressBar.Maximum = (int)stream.Length;
            };
            this.Invoke(invThread);

            // The progress bar is an async task, so that it can progress while the parsing is happening
            // it uses the position of the stream to show an accurate progress of the parsing
            var progressTask = Task.Run(async () => 
            {
                while (stream.Position < stream.Length)
                {
                    if(cancelTask)
                    {
                        break;
                    }
                    invThread = delegate
                    {
                        progressBar.Value = (int)stream.Position;
                    };
                    this.Invoke(invThread);
                }
            });

            if (cancelTask) return "";

            // wait on async tasks
            await Task.WhenAll(readTask, progressTask); 

            invThread = delegate
            {
                progressBar.Value = (int)stream.Length;
            };
            this.Invoke(invThread);

            reader.Dispose();
            stream.Dispose();

            return readTask.Result;
        }

        // The count_button function triggers the processing of the parsed file
        private void count_button(object sender, EventArgs e)
        {
            if (!processWorker.IsBusy)
            {
                processWorker.RunWorkerAsync();
            }
        }


        // The processFile function does the main analysis on the parsed text.
        private void processFile(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            MethodInvoker invThread = delegate
            {
                this.status_label.Text = "Counting words, please wait...";
            };
            this.Invoke(invThread);

            String[] words = Regex.Split(toBeProcessed, "[\n\\s]").Where(str => str != String.Empty).ToArray<String>();
 
            var wordsDicFinal = words
               .GroupBy(p => p)
               .ToDictionary(p => p.Key, q => q.Count());

            var result = wordsDicFinal.OrderByDescending(p => p.Value);

            invThread = delegate
            {
                resultList.Visible = false;
            };
            this.Invoke(invThread);

            foreach (var res in result)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    String[] newItem = new string[]{ res.Key , res.Value.ToString() };
                    invThread = delegate
                    {
                        resultList.Items.Add(new ListViewItem(newItem));
                    };
                    this.Invoke(invThread);
                }
            }
            invThread = delegate
            {
                resultList.Visible = true;
                status_label.Text = "Done";
            };
            this.Invoke(invThread);
        }

        // After completion of the processFile function, the "cancel" button is turned into a "reset" button for clarity
        private void completed(object sender, RunWorkerCompletedEventArgs e)
        {
            cancelButton.Text = "RESET";
        }

        // The "cancel" button cancels any running task, and resets the program to the default values.
        // The "cancel" button can also function as a "reset" button. 
        private void cancel(object sender, EventArgs e)
        {
            if (processWorker.WorkerSupportsCancellation == true)
            {
                processWorker.CancelAsync();
            }
            
            cancelTask = true;
            status_label.ResetText();
            pathLabel.ResetText();
            progressBar.Value=0;
            status_label.Text = "Canceled";
            resultList.Items.Clear(); //reset list
            cancelButton.Text = "CANCEL";
            countButton.Enabled = false;
        }
    }
}
