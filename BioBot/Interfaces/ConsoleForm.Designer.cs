namespace BioBot.Interfaces
{
    partial class ConsoleForm
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
            this.btClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClear
            // 
            this.btClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClear.Location = new System.Drawing.Point(12, 228);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(227, 23);
            this.btClear.TabIndex = 0;
            this.btClear.Text = "Nettoyer";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtLog);
            this.groupBox1.Location = new System.Drawing.Point(1, -13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 234);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rtLog
            // 
            this.rtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtLog.Location = new System.Drawing.Point(3, 16);
            this.rtLog.Name = "rtLog";
            this.rtLog.Size = new System.Drawing.Size(494, 215);
            this.rtLog.TabIndex = 0;
            this.rtLog.Text = "";
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(262, 228);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(227, 23);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "Cacher";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 262);
            this.ControlBox = false;
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btClear);
            this.MaximumSize = new System.Drawing.Size(517, 301);
            this.MinimumSize = new System.Drawing.Size(517, 301);
            this.Name = "ConsoleForm";
            this.Text = "Console";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtLog;
        private System.Windows.Forms.Button btClose;
    }
}