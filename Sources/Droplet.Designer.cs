namespace FB2Formatter
{
	partial class Droplet
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelInfo = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelInfo
			// 
			this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelInfo.Location = new System.Drawing.Point(3, 38);
			this.labelInfo.Margin = new System.Windows.Forms.Padding(3);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(194, 157);
			this.labelInfo.TabIndex = 2;
			this.labelInfo.Text = "<Information>";
			// 
			// labelTitle
			// 
			this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTitle.Location = new System.Drawing.Point(3, 10);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(3);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(194, 22);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "<Title>";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Droplet
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.labelInfo);
			this.Controls.Add(this.labelTitle);
			this.Name = "Droplet";
			this.Size = new System.Drawing.Size(200, 200);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelInfo;
		private System.Windows.Forms.Label labelTitle;
	}
}
