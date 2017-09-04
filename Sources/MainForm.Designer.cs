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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.dropletConvertPicturesToXml = new FB2Formatter.Droplet();
			this.dropletExtractPicturesToFiles = new FB2Formatter.Droplet();
			this.dropletExtractPicturesToXml = new FB2Formatter.Droplet();
			this.dropletFormatBooks = new FB2Formatter.Droplet();
			this.dropletFormatBookPictures = new FB2Formatter.Droplet();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textLog
			// 
			this.textLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLog.Location = new System.Drawing.Point(12, 497);
			this.textLog.Multiline = true;
			this.textLog.Name = "textLog";
			this.textLog.ReadOnly = true;
			this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textLog.Size = new System.Drawing.Size(602, 84);
			this.textLog.TabIndex = 5;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(626, 24);
			this.menuStrip1.TabIndex = 10;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptions});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// menuOptions
			// 
			this.menuOptions.Name = "menuOptions";
			this.menuOptions.Size = new System.Drawing.Size(123, 22);
			this.menuOptions.Text = "&Options...";
			this.menuOptions.Click += new System.EventHandler(this.menuOptions_Click);
			// 
			// menuExit
			// 
			this.menuExit.Name = "menuExit";
			this.menuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.menuExit.Size = new System.Drawing.Size(132, 22);
			this.menuExit.Text = "E&xit";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// dropletConvertPicturesToXml
			// 
			this.dropletConvertPicturesToXml.AllowDrop = true;
			this.dropletConvertPicturesToXml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dropletConvertPicturesToXml.BackColor = System.Drawing.Color.Silver;
			this.dropletConvertPicturesToXml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dropletConvertPicturesToXml.Info = "Drop a bunch of picture files here to assemble them into an xml file.\r\nAlternativ" +
    "ely you can drop folders with pictures. In this case a separate file will be cre" +
    "ated for each folder.";
			this.dropletConvertPicturesToXml.Location = new System.Drawing.Point(12, 395);
			this.dropletConvertPicturesToXml.Name = "dropletConvertPicturesToXml";
			this.dropletConvertPicturesToXml.Size = new System.Drawing.Size(602, 86);
			this.dropletConvertPicturesToXml.TabIndex = 9;
			this.dropletConvertPicturesToXml.Title = "Convert Pictures To XML";
			this.dropletConvertPicturesToXml.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropletConvertPicturesToXml_DragDrop);
			this.dropletConvertPicturesToXml.DragEnter += new System.Windows.Forms.DragEventHandler(this.droplet_DragEnter);
			// 
			// dropletExtractPicturesToFiles
			// 
			this.dropletExtractPicturesToFiles.AllowDrop = true;
			this.dropletExtractPicturesToFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dropletExtractPicturesToFiles.BackColor = System.Drawing.Color.Silver;
			this.dropletExtractPicturesToFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dropletExtractPicturesToFiles.Info = "Drop books here to extract pictures into folders (separate folder is created for " +
    "each book).";
			this.dropletExtractPicturesToFiles.Location = new System.Drawing.Point(12, 303);
			this.dropletExtractPicturesToFiles.Name = "dropletExtractPicturesToFiles";
			this.dropletExtractPicturesToFiles.Size = new System.Drawing.Size(602, 86);
			this.dropletExtractPicturesToFiles.TabIndex = 8;
			this.dropletExtractPicturesToFiles.Title = "Extract Book Pictures To Files";
			this.dropletExtractPicturesToFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropletExtractPicturesToFiles_DragDrop);
			this.dropletExtractPicturesToFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.droplet_DragEnter);
			// 
			// dropletExtractPicturesToXml
			// 
			this.dropletExtractPicturesToXml.AllowDrop = true;
			this.dropletExtractPicturesToXml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dropletExtractPicturesToXml.BackColor = System.Drawing.Color.Silver;
			this.dropletExtractPicturesToXml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dropletExtractPicturesToXml.Info = "Drop books here to create xml files with formatted images.";
			this.dropletExtractPicturesToXml.Location = new System.Drawing.Point(12, 211);
			this.dropletExtractPicturesToXml.Name = "dropletExtractPicturesToXml";
			this.dropletExtractPicturesToXml.Size = new System.Drawing.Size(602, 86);
			this.dropletExtractPicturesToXml.TabIndex = 7;
			this.dropletExtractPicturesToXml.Title = "Extract Book Pictures To XML";
			this.dropletExtractPicturesToXml.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropletExtractPicturesToXml_DragDrop);
			this.dropletExtractPicturesToXml.DragEnter += new System.Windows.Forms.DragEventHandler(this.droplet_DragEnter);
			// 
			// dropletFormatBooks
			// 
			this.dropletFormatBooks.AllowDrop = true;
			this.dropletFormatBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dropletFormatBooks.BackColor = System.Drawing.Color.Silver;
			this.dropletFormatBooks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dropletFormatBooks.Info = "Drop books here to create formatted copies.\r\nOriginal book files will not change." +
    "";
			this.dropletFormatBooks.Location = new System.Drawing.Point(12, 27);
			this.dropletFormatBooks.Name = "dropletFormatBooks";
			this.dropletFormatBooks.Size = new System.Drawing.Size(602, 86);
			this.dropletFormatBooks.TabIndex = 6;
			this.dropletFormatBooks.Title = "Format Books";
			this.dropletFormatBooks.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropletFormatBooks_DragDrop);
			this.dropletFormatBooks.DragEnter += new System.Windows.Forms.DragEventHandler(this.droplet_DragEnter);
			// 
			// dropletFormatBookPictures
			// 
			this.dropletFormatBookPictures.AllowDrop = true;
			this.dropletFormatBookPictures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dropletFormatBookPictures.BackColor = System.Drawing.Color.Silver;
			this.dropletFormatBookPictures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dropletFormatBookPictures.Info = "Drop books here to create copies with formatted images.\r\nOriginal book files will" +
    " not change.";
			this.dropletFormatBookPictures.Location = new System.Drawing.Point(12, 119);
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
			this.ClientSize = new System.Drawing.Size(626, 593);
			this.Controls.Add(this.dropletConvertPicturesToXml);
			this.Controls.Add(this.dropletExtractPicturesToFiles);
			this.Controls.Add(this.dropletExtractPicturesToXml);
			this.Controls.Add(this.dropletFormatBooks);
			this.Controls.Add(this.dropletFormatBookPictures);
			this.Controls.Add(this.textLog);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "FB2 Formatter";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textLog;
		private Droplet dropletFormatBookPictures;
		private Droplet dropletExtractPicturesToXml;
		private Droplet dropletExtractPicturesToFiles;
		private Droplet dropletConvertPicturesToXml;
		private Droplet dropletFormatBooks;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuExit;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuOptions;
	}
}

