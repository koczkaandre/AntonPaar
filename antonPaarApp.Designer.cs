namespace AntonPaar
{
    partial class antonPaarApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(antonPaarApp));
            this.browse_fille = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.status_label = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.countButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.resultList = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // browse_fille
            // 
            this.browse_fille.Location = new System.Drawing.Point(14, 34);
            this.browse_fille.Name = "browse_fille";
            this.browse_fille.Size = new System.Drawing.Size(75, 23);
            this.browse_fille.TabIndex = 0;
            this.browse_fille.Text = "Browse file";
            this.browse_fille.UseVisualStyleBackColor = true;
            this.browse_fille.Click += new System.EventHandler(this.browse_file);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(11, 91);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(0, 13);
            this.pathLabel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Path:";
            // 
            // status_label
            // 
            this.status_label.AutoSize = true;
            this.status_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.status_label.Location = new System.Drawing.Point(62, 199);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(0, 13);
            this.status_label.TabIndex = 7;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(183, 31);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(114, 54);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancel);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Step 1: select file";
            // 
            // countButton
            // 
            this.countButton.Location = new System.Drawing.Point(15, 164);
            this.countButton.Name = "countButton";
            this.countButton.Size = new System.Drawing.Size(282, 32);
            this.countButton.TabIndex = 4;
            this.countButton.Text = "COUNT";
            this.countButton.UseVisualStyleBackColor = true;
            this.countButton.Click += new System.EventHandler(this.count_button);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 107);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(282, 32);
            this.progressBar.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Step 2: click COUNT to get word occurances";
            // 
            // resultList
            // 
            this.resultList.FullRowSelect = true;
            this.resultList.HideSelection = false;
            this.resultList.Location = new System.Drawing.Point(16, 224);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(281, 480);
            this.resultList.TabIndex = 16;
            this.resultList.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(16, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 716);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultList);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.countButton);
            this.Controls.Add(this.browse_fille);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(328, 755);
            this.MinimumSize = new System.Drawing.Size(328, 755);
            this.Name = "Form1";
            this.Text = "AntonPaar Word Counter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browse_fille;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button countButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView resultList;
        private System.Windows.Forms.Label label3;
    }
}

