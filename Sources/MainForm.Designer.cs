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
			this.textLog = new System.Windows.Forms.TextBox();
			this.dropletConvertPicturesToXml = new FB2Formatter.Droplet();
			this.dropletExtractPicturesToFiles = new FB2Formatter.Droplet();
			this.dropletExtractPicturesToXml = new FB2Formatter.Droplet();
			this.dropletFormatBookPictures = new FB2Formatter.Droplet();
			this.SuspendLayout();
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
			// dropletConvertPicturesToXml
			// 
			this.dropletConvertPicturesToXml.BackColor = System.Drawing.Color.Silver;
			this.dropletConvertPicturesToXml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dropletConvertPicturesToXml.Info = "Drop a bunch of picture files here to assemble them into an xml file.\r\nAlternativ" +
    "ely you can drop folders with pictures. In this case a separate file will be cre" +
    "ated for each folder.";
			this.dropletConvertPicturesToXml.Location = new System.Drawing.Point(12, 288);
			this.dropletConvertPicturesToXml.Name = "dropletConvertPicturesToXml";
			this.dropletConvertPicturesToXml.Size = new System.Drawing.Size(602, 86);
			this.dropletConvertPicturesToXml.TabIndex = 9;
			this.dropletConvertPicturesToXml.Title = "Convert Pictures To XML";
			this.dropletConvertPicturesToXml.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropletConvertPicturesToXml_DragDrop);
			this.dropletConvertPicturesToXml.DragEnter += new System.Windows.Forms.DragEventHandler(this.droplet_DragEnter);
			// 
			// dropletExtractPicturesToFiles
			// 
			this.dropletExtractPicturesToFiles.BackColor = System.Drawing.Color.Silver;
			this.dropletExtractPicturesToFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dropletExtractPicturesToFiles.Info = "Drop books here to extract pictures into folders (separate folder is created for " +
    "each book).";
			this.dropletExtractPicturesToFiles.Location = new System.Drawing.Point(12, 196);
			this.dropletExtractPicturesToFiles.Name = "dropletExtractPicturesToFiles";
			this.dropletExtractPicturesToFiles.Size = new System.Drawing.Size(602, 86);
			this.dropletExtractPicturesToFiles.TabIndex = 8;
			this.dropletExtractPicturesToFiles.Title = "Extract Book Pictures To Files";
			this.dropletExtractPicturesToFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropletExtractPicturesToFiles_DragDrop);
			this.dropletExtractPicturesToFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.droplet_DragEnter);
			// 
			// dropletExtractPicturesToXml
			// 
			this.dropletExtractPicturesToXml.BackColor = System.Drawing.Color.Silver;
			this.dropletExtractPicturesToXml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dropletExtractPicturesToXml.Info = "Drop books here to create xml files with formatted images.";
			this.dropletExtractPicturesToXml.Location = new System.Drawing.Point(12, 104);
			this.dropletExtractPicturesToXml.Name = "dropletExtractPicturesToXml";
			this.dropletExtractPicturesToXml.Size = new System.Drawing.Size(602, 86);
			this.dropletExtractPicturesToXml.TabIndex = 7;
			this.dropletExtractPicturesToXml.Title = "Extract Book Pictures To XML";
			this.dropletExtractPicturesToXml.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropletExtractPicturesToXml_DragDrop);
			this.dropletExtractPicturesToXml.DragEnter += new System.Windows.Forms.DragEventHandler(this.droplet_DragEnter);
			// 
			// dropletFormatBookPictures
			// 
			this.dropletFormatBookPictures.BackColor = System.Drawing.Color.Silver;
			this.dropletFormatBookPictures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dropletFormatBookPictures.Info = "Drop books here to create copies with formatted images.\r\nOriginal book files will" +
    " not change.";
			this.dropletFormatBookPictures.Location = new System.Drawing.Point(12, 12);
			this.dropletFormatBookPictures.Name = "dropletFormatBookPictures";
			this.dropletFormatBookPictures.Size = new System.Drawing.Size(602, 86);
			this.dropletFormatBookPictures.TabIndex = 6;
			this.dropletFormatBookPictures.Title = "Format Book Pictures";
			this.dropletFormatBookPictures.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropletFormatBookPictures_DragDrop);
			this.dropletFormatBookPictures.DragEnter += new System.Windows.Forms.DragEventHandler(this.droplet_DragEnter);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(626, 567);
			this.Controls.Add(this.dropletConvertPicturesToXml);
			this.Controls.Add(this.dropletExtractPicturesToFiles);
			this.Controls.Add(this.dropletExtractPicturesToXml);
			this.Controls.Add(this.dropletFormatBookPictures);
			this.Controls.Add(this.textLog);
			this.Name = "MainForm";
			this.Text = "FB2 Formatter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textLog;
		private Droplet dropletFormatBookPictures;
		private Droplet dropletExtractPicturesToXml;
		private Droplet dropletExtractPicturesToFiles;
		private Droplet dropletConvertPicturesToXml;
	}
}

