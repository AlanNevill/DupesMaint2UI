namespace DupesMaint2UI
{
    partial class DisplayPhotos4SHA
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbPhoto1 = new System.Windows.Forms.TextBox();
            this.tbPhoto2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePhoto1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePhoto2 = new System.Windows.Forms.DateTimePicker();
            this.cbPhoto2 = new System.Windows.Forms.CheckBox();
            this.cbPhoto1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbPhoto1Size = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPhoto2Size = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(98, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(388, 72);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(267, 250);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // tbPhoto1
            // 
            this.tbPhoto1.Enabled = false;
            this.tbPhoto1.Font = new System.Drawing.Font("Source Code Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhoto1.Location = new System.Drawing.Point(98, 328);
            this.tbPhoto1.Multiline = true;
            this.tbPhoto1.Name = "tbPhoto1";
            this.tbPhoto1.Size = new System.Drawing.Size(267, 73);
            this.tbPhoto1.TabIndex = 2;
            // 
            // tbPhoto2
            // 
            this.tbPhoto2.Enabled = false;
            this.tbPhoto2.Font = new System.Drawing.Font("Source Code Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhoto2.Location = new System.Drawing.Point(388, 328);
            this.tbPhoto2.Multiline = true;
            this.tbPhoto2.Name = "tbPhoto2";
            this.tbPhoto2.Size = new System.Drawing.Size(267, 73);
            this.tbPhoto2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Full file name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Creation date";
            // 
            // dateTimePhoto1
            // 
            this.dateTimePhoto1.Enabled = false;
            this.dateTimePhoto1.Location = new System.Drawing.Point(98, 12);
            this.dateTimePhoto1.Name = "dateTimePhoto1";
            this.dateTimePhoto1.Size = new System.Drawing.Size(267, 20);
            this.dateTimePhoto1.TabIndex = 6;
            // 
            // dateTimePhoto2
            // 
            this.dateTimePhoto2.Enabled = false;
            this.dateTimePhoto2.Location = new System.Drawing.Point(388, 12);
            this.dateTimePhoto2.Name = "dateTimePhoto2";
            this.dateTimePhoto2.Size = new System.Drawing.Size(267, 20);
            this.dateTimePhoto2.TabIndex = 7;
            // 
            // cbPhoto2
            // 
            this.cbPhoto2.AutoSize = true;
            this.cbPhoto2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbPhoto2.Location = new System.Drawing.Point(476, 407);
            this.cbPhoto2.Name = "cbPhoto2";
            this.cbPhoto2.Size = new System.Drawing.Size(102, 17);
            this.cbPhoto2.TabIndex = 9;
            this.cbPhoto2.Text = "Remove photo2";
            this.cbPhoto2.UseVisualStyleBackColor = true;
            this.cbPhoto2.CheckedChanged += new System.EventHandler(this.cbPhoto2_CheckedChanged);
            // 
            // cbPhoto1
            // 
            this.cbPhoto1.AutoSize = true;
            this.cbPhoto1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbPhoto1.Location = new System.Drawing.Point(182, 407);
            this.cbPhoto1.Name = "cbPhoto1";
            this.cbPhoto1.Size = new System.Drawing.Size(102, 17);
            this.cbPhoto1.TabIndex = 10;
            this.cbPhoto1.Text = "Remove photo1";
            this.cbPhoto1.UseVisualStyleBackColor = true;
            this.cbPhoto1.CheckedChanged += new System.EventHandler(this.cbPhoto1_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(702, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // tbPhoto1Size
            // 
            this.tbPhoto1Size.Location = new System.Drawing.Point(98, 39);
            this.tbPhoto1Size.Name = "tbPhoto1Size";
            this.tbPhoto1Size.Size = new System.Drawing.Size(100, 20);
            this.tbPhoto1Size.TabIndex = 12;
            this.tbPhoto1Size.Text = "Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Size KB";
            // 
            // tbPhoto2Size
            // 
            this.tbPhoto2Size.Location = new System.Drawing.Point(388, 39);
            this.tbPhoto2Size.Name = "tbPhoto2Size";
            this.tbPhoto2Size.Size = new System.Drawing.Size(100, 20);
            this.tbPhoto2Size.TabIndex = 14;
            this.tbPhoto2Size.Text = "Size";
            // 
            // DisplayPhotos4SHA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 449);
            this.Controls.Add(this.tbPhoto2Size);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPhoto1Size);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbPhoto1);
            this.Controls.Add(this.cbPhoto2);
            this.Controls.Add(this.dateTimePhoto2);
            this.Controls.Add(this.dateTimePhoto1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPhoto2);
            this.Controls.Add(this.tbPhoto1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DisplayPhotos4SHA";
            this.Text = "DisplayPhotos4SHA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisplayPhotos4SHA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbPhoto1;
        private System.Windows.Forms.TextBox tbPhoto2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePhoto1;
        private System.Windows.Forms.DateTimePicker dateTimePhoto2;
        private System.Windows.Forms.CheckBox cbPhoto2;
        private System.Windows.Forms.CheckBox cbPhoto1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TextBox tbPhoto1Size;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPhoto2Size;
    }
}