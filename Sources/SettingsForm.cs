using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FB2Formatter
{
	public partial class SettingsForm : Form
	{
		private Config localConfig;


		public SettingsForm()
		{
			InitializeComponent();
		}


		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			localConfig = Config.Main.Clone();
			propertyGrid.SelectedObject = localConfig;
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			if (DialogResult == DialogResult.OK)
			{
				Config.SetMain(localConfig);
			}
		}
	}
}
