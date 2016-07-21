namespace FB2Formatter
{
	partial class MainForm
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
			this.panelExtractPicturesToXmlDroplet = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panelExtractPicturesToFilesDroplet = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panelConvertPicturesToXmlDroplet = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textLog = new System.Windows.Forms.TextBox();
			this.panelFormatBookPicturesDroplet = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.panelExtractPicturesToXmlDroplet.SuspendLayout();
			this.panelExtractPicturesToFilesDroplet.SuspendLayout();
			this.panelConvertPicturesToXmlDroplet.SuspendLayout();
			this.panelFormatBookPicturesDroplet.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelExtractPicturesToXmlDroplet
			// 
			this.panelExtractPicturesToXmlDroplet.AllowDrop = true;
			this.panelExtractPicturesToXmlDroplet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelExtractPicturesToXmlDroplet.BackColor = System.Drawing.Color.Silver;
			this.panelExtractPicturesToXmlDroplet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelExtractPicturesToXmlDroplet.Controls.Add(this.label2);
			this.panelExtractPicturesToXmlDroplet.Controls.Add(this.label1);
			this.panelExtractPicturesToXmlDroplet.Location = new System.Drawing.Point(12, 104);
			this.panelExtractPicturesToXmlDroplet.Name = "panelExtractPicturesToXmlDroplet";
			this.panelExtractPicturesToXmlDroplet.Size = new System.Drawing.Size(602, 86);
			this.panelExtractPicturesToXmlDroplet.TabIndex = 4;
			this.panelExtractPicturesToXmlDroplet.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelExtractPicturesToXmlDroplet_DragDrop);
			this.panelExtractPicturesToXmlDroplet.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelExtractPicturesToXmlDroplet_DragEnter);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(3, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(616, 46);
			this.label2.TabIndex = 0;
			this.label2.Text = "Drop books here to create xml files with formatted images.";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(616, 22);
			this.label1.TabIndex = 0;
			this.label1.Text = "Extract Book Pictures To XML";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panelExtractPicturesToFilesDroplet
			// 
			this.panelExtractPicturesToFilesDroplet.AllowDrop = true;
			this.panelExtractPicturesToFilesDroplet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelExtractPicturesToFilesDroplet.BackColor = System.Drawing.Color.Silver;
			this.panelExtractPicturesToFilesDroplet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelExtractPicturesToFilesDroplet.Controls.Add(this.label3);
			this.panelExtractPicturesToFilesDroplet.Controls.Add(this.label4);
			this.panelExtractPicturesToFilesDroplet.Location = new System.Drawing.Point(12, 196);
			this.panelExtractPicturesToFilesDroplet.Name = "panelExtractPicturesToFilesDroplet";
			this.panelExtractPicturesToFilesDroplet.Size = new System.Drawing.Size(602, 86);
			this.panelExtractPicturesToFilesDroplet.TabIndex = 4;
			this.panelExtractPicturesToFilesDroplet.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelExtractPicturesToFilesDroplet_DragDrop);
			this.panelExtractPicturesToFilesDroplet.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelExtractPicturesToFilesDroplet_DragEnter);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(3, 38);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(616, 46);
			this.label3.TabIndex = 0;
			this.label3.Text = "Drop books here to extract pictures into folders (separate folder is created for " +
    "each book).";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(3, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(616, 22);
			this.label4.TabIndex = 0;
			this.label4.Text = "Extract Book Pictures To Files";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panelConvertPicturesToXmlDroplet
			// 
			this.panelConvertPicturesToXmlDroplet.AllowDrop = true;
			this.panelConvertPicturesToXmlDroplet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelConvertPicturesToXmlDroplet.BackColor = System.Drawing.Color.Silver;
			this.panelConvertPicturesToXmlDroplet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelConvertPicturesToXmlDroplet.Controls.Add(this.label5);
			this.panelConvertPicturesToXmlDroplet.Controls.Add(this.label6);
			this.panelConvertPicturesToXmlDroplet.Location = new System.Drawing.Point(12, 288);
			this.panelConvertPicturesToXmlDroplet.Name = "panelConvertPicturesToXmlDroplet";
			this.panelConvertPicturesToXmlDroplet.Size = new System.Drawing.Size(602, 86);
			this.panelConvertPicturesToXmlDroplet.TabIndex = 4;
			this.panelConvertPicturesToXmlDroplet.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelConvertPicturesToXmlDroplet_DragDrop);
			this.panelConvertPicturesToXmlDroplet.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelConvertPicturesToXmlDroplet_DragEnter);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(3, 38);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(616, 46);
			this.label5.TabIndex = 0;
			this.label5.Text = "Drop a bunch of picture files here to assemble them into an xml file.\r\nAlternativ" +
    "ely you can drop folders with pictures. In this case a separate file will be cre" +
    "ated for each folder.";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(3, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(616, 22);
			this.label6.TabIndex = 0;
			this.label6.Text = "Convert Pictures To XML";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textLog
			// 
			this.textLog.Location = new System.Drawing.Point(12, 400);
			this.textLog.Multiline = true;
			this.textLog.Name = "textLog";
			this.textLog.ReadOnly = true;
			this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textLog.Size = new System.Drawing.Size(602, 155);
			this.textLog.TabIndex = 5;
			// 
			// panelFormatBookPicturesDroplet
			// 
			this.panelFormatBookPicturesDroplet.AllowDrop = true;
			this.panelFormatBookPicturesDroplet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelFormatBookPicturesDroplet.BackColor = System.Drawing.Color.Silver;
			this.panelFormatBookPicturesDroplet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelFormatBookPicturesDroplet.Controls.Add(this.label7);
			this.panelFormatBookPicturesDroplet.Controls.Add(this.label8);
			this.panelFormatBookPicturesDroplet.Location = new System.Drawing.Point(12, 12);
			this.panelFormatBookPicturesDroplet.Name = "panelFormatBookPicturesDroplet";
			this.panelFormatBookPicturesDroplet.Size = new System.Drawing.Size(602, 86);
			this.panelFormatBookPicturesDroplet.TabIndex = 4;
			this.panelFormatBookPicturesDroplet.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelFormatBookPicturesDroplet_DragDrop);
			this.panelFormatBookPicturesDroplet.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelFormatBookPicturesDroplet_DragEnter);
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Location = new System.Drawing.Point(3, 38);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(616, 46);
			this.label7.TabIndex = 0;
			this.label7.Text = "Drop books here to create copies with formatted images.\r\nOriginal book files will" +
    " not change.";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.Location = new System.Drawing.Point(3, 10);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(616, 22);
			this.label8.TabIndex = 0;
			this.label8.Text = "Format Book Pictures";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(626, 567);
			this.Controls.Add(this.textLog);
			this.Controls.Add(this.panelFormatBookPicturesDroplet);
			this.Controls.Add(this.panelConvertPicturesToXmlDroplet);
			this.Controls.Add(this.panelExtractPicturesToFilesDroplet);
			this.Controls.Add(this.panelExtractPicturesToXmlDroplet);
			this.Name = "MainForm";
			this.Text = "FB2 Formatter";
			this.panelExtractPicturesToXmlDroplet.ResumeLayout(false);
			this.panelExtractPicturesToFilesDroplet.ResumeLayout(false);
			this.panelConvertPicturesToXmlDroplet.ResumeLayout(false);
			this.panelFormatBookPicturesDroplet.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panelExtractPicturesToXmlDroplet;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelExtractPicturesToFilesDroplet;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panelConvertPicturesToXmlDroplet;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textLog;
		private System.Windows.Forms.Panel panelFormatBookPicturesDroplet;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
	}
}

