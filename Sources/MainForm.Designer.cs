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
			this.panelFormatPicturesDroplet = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panelExtractPicturesDroplet = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panelComposePicturesDroplet = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textLog = new System.Windows.Forms.TextBox();
			this.panelFormatPicturesDroplet.SuspendLayout();
			this.panelExtractPicturesDroplet.SuspendLayout();
			this.panelComposePicturesDroplet.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelFormatPicturesDroplet
			// 
			this.panelFormatPicturesDroplet.AllowDrop = true;
			this.panelFormatPicturesDroplet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelFormatPicturesDroplet.BackColor = System.Drawing.Color.Silver;
			this.panelFormatPicturesDroplet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelFormatPicturesDroplet.Controls.Add(this.label2);
			this.panelFormatPicturesDroplet.Controls.Add(this.label1);
			this.panelFormatPicturesDroplet.Location = new System.Drawing.Point(12, 12);
			this.panelFormatPicturesDroplet.Name = "panelFormatPicturesDroplet";
			this.panelFormatPicturesDroplet.Size = new System.Drawing.Size(602, 86);
			this.panelFormatPicturesDroplet.TabIndex = 4;
			this.panelFormatPicturesDroplet.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelFormatPicturesDroplet_DragDrop);
			this.panelFormatPicturesDroplet.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelFormatPicturesDroplet_DragEnter);
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
			this.label1.Text = "Format Book Pictures";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panelExtractPicturesDroplet
			// 
			this.panelExtractPicturesDroplet.AllowDrop = true;
			this.panelExtractPicturesDroplet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelExtractPicturesDroplet.BackColor = System.Drawing.Color.Silver;
			this.panelExtractPicturesDroplet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelExtractPicturesDroplet.Controls.Add(this.label3);
			this.panelExtractPicturesDroplet.Controls.Add(this.label4);
			this.panelExtractPicturesDroplet.Location = new System.Drawing.Point(12, 104);
			this.panelExtractPicturesDroplet.Name = "panelExtractPicturesDroplet";
			this.panelExtractPicturesDroplet.Size = new System.Drawing.Size(602, 86);
			this.panelExtractPicturesDroplet.TabIndex = 4;
			this.panelExtractPicturesDroplet.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelExtractPicturesDroplet_DragDrop);
			this.panelExtractPicturesDroplet.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelExtractPicturesDroplet_DragEnter);
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
			this.label4.Text = "Extract Book Pictures";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panelComposePicturesDroplet
			// 
			this.panelComposePicturesDroplet.AllowDrop = true;
			this.panelComposePicturesDroplet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelComposePicturesDroplet.BackColor = System.Drawing.Color.Silver;
			this.panelComposePicturesDroplet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelComposePicturesDroplet.Controls.Add(this.label5);
			this.panelComposePicturesDroplet.Controls.Add(this.label6);
			this.panelComposePicturesDroplet.Location = new System.Drawing.Point(12, 196);
			this.panelComposePicturesDroplet.Name = "panelComposePicturesDroplet";
			this.panelComposePicturesDroplet.Size = new System.Drawing.Size(602, 86);
			this.panelComposePicturesDroplet.TabIndex = 4;
			this.panelComposePicturesDroplet.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelComposePicturesDroplet_DragDrop);
			this.panelComposePicturesDroplet.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelComposePicturesDroplet_DragEnter);
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
			this.label6.Text = "Compose Pictures";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textLog
			// 
			this.textLog.Location = new System.Drawing.Point(12, 302);
			this.textLog.Multiline = true;
			this.textLog.Name = "textLog";
			this.textLog.ReadOnly = true;
			this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textLog.Size = new System.Drawing.Size(602, 155);
			this.textLog.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(626, 469);
			this.Controls.Add(this.textLog);
			this.Controls.Add(this.panelComposePicturesDroplet);
			this.Controls.Add(this.panelExtractPicturesDroplet);
			this.Controls.Add(this.panelFormatPicturesDroplet);
			this.Name = "MainForm";
			this.Text = "FB2 Formatter";
			this.panelFormatPicturesDroplet.ResumeLayout(false);
			this.panelExtractPicturesDroplet.ResumeLayout(false);
			this.panelComposePicturesDroplet.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panelFormatPicturesDroplet;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelExtractPicturesDroplet;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panelComposePicturesDroplet;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textLog;
	}
}

