using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fcop.Forms
{
    public partial class CommandEditor : Form
    {
        public CommandEditor()
        {
            InitializeComponent();
        }

        private void CommandEditor_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.FromHandle(Properties.Resources.Serial_Tasks_16px.GetHicon());
            imageListMainTree.Images.Add("filescan", Properties.Resources.View_File_16px);


            var node = new TreeNode();
            node.Text = "File scan";
            node.ImageKey = "filescan";
            node.SelectedImageKey = node.ImageKey;

            treeViewMain.Nodes.Add(node);



        }
    }
}
