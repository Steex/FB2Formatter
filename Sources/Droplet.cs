using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;

namespace FB2Formatter
{
	public partial class Droplet : UserControl
	{
		[Category("Appearance")]
		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		public string Title
		{
			get
			{
				return labelTitle.Text;
			}
			set
			{
				labelTitle.Text = value;
			}
		}

		[Category("Appearance")]
		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		public string Info
		{
			get
			{
				return labelInfo.Text;
			}
			set
			{
				labelInfo.Text = value;
			}
		}


		public Droplet()
		{
			InitializeComponent();
		}
	}
}
