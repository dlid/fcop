using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fcop.Core.Extensions;

namespace Fcop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = new Core.Entities.FcopDefinition();
            d.Save(@"C:\temp\fcop-test.fcop");

            using (var dlg = new Forms.FcopDefinitionEditor(d))
            {
                dlg.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var d = new List<string>
            {
                "apa",
                "kossa"
            };
           // MessageBox.Show(d.Serialize());
        }
    }
}
