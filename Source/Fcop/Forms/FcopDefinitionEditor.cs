using Fcop.Core;
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
using Fcop.Core.Entities;

namespace Fcop.Forms
{
    public partial class FcopDefinitionEditor : Form
    {
        FcopDefinition _definition;

        public FcopDefinitionEditor(FcopDefinition Definition)
        {
            InitializeComponent();
            _definition = Definition;
        }

        private void FcopDefinitionEditor_Load(object sender, EventArgs e)
        {
            var sp = TargetManager.GetScanProcessors();
            var targets = TargetManager.GetTargets();


            comboBoxTargetType.Items.Clear();
            foreach (var target in targets)
                comboBoxTargetType.Items.Add(target.Name);

            if (comboBoxTargetType.Items.Count > 0)
                comboBoxTargetType.SelectedIndex = 0;

            foreach (Control ctrl in panel_ActivePanelContainer.Controls)
                if (ctrl is Panel)
                {
                    ctrl.Dock = DockStyle.Fill;
                    ctrl.Visible = false;
                }

            imageListMainTree.Images.Add("commands", Properties.Resources.Serial_Tasks_32px);
            imageListMainTree.Images.Add("target", Properties.Resources.Upload_To_FTP_32px);
            imageListMainTree.Images.Add("source", Properties.Resources.Open_Folder_32px);
            imageListMainTree.Images.Add("filescan", Properties.Resources.SSD_32px);
            treeViewMain.ImageList = imageListMainTree;

            var node = new TreeNode();
            node.Text = "Source";
            node.ImageKey = "source";
            node.Tag = panel_PageSource;
            node.SelectedImageKey = node.ImageKey;
            treeViewMain.Nodes.Add(node);

            node = new TreeNode();
            node.Text = "Target";
            node.ImageKey = "target";
            node.SelectedImageKey = node.ImageKey;
            node.Tag = panel_PageTarget;
            treeViewMain.Nodes.Add(node);

            node = new TreeNode();
            node.Text = "Files";
            node.ImageKey = "filescan";
            node.SelectedImageKey = node.ImageKey;
            node.Tag = panel_PageCommands;
            treeViewMain.Nodes.Add(node);

            node = new TreeNode();
            node.Text = "Deploy Sequence";
            node.ImageKey = "commands";
            node.SelectedImageKey = node.ImageKey;
            node.Tag = panel_PageCommands;
            treeViewMain.Nodes.Add(node);

        }

        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {

            foreach (Control ctrl in panel_ActivePanelContainer.Controls)
                if (ctrl is Panel)
                    ctrl.Visible = false;


            if (sender is TreeView)
            {
                var tree = sender as TreeView;
                if (e.Node.Tag != null && e.Node.Tag is Panel)
                {
                    (e.Node.Tag as Panel).Visible = true;
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxTargetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var targets = TargetManager.GetTargets();

            var selectedIndex = (sender as ComboBox).SelectedIndex;

            if (targets.Count > selectedIndex) {
                var tt = targets[selectedIndex].GetType();

                var cmds = TargetManager.GetCommands(tt);
                toolStripDropDownButtonAddCommand.DropDownItems.Clear();

                var n = new ToolStripMenuItem
                {
                    Text = "Add File Scan",
                    ToolTipText = "",
                    Image = Properties.Resources.View_File_16px
                };
                toolStripDropDownButtonAddCommand.DropDownItems.Add(n);

                foreach (var cmd in cmds)
                {
                    n = new ToolStripMenuItem
                    {
                        Text = "Add '" + cmd.Name + "' "+ (cmd is Fcop.Core.FileCommandBase ? "File Processor " : "") + "Command",
                        ToolTipText = cmd.Description,
                        Image = (cmd is Fcop.Core.FileCommandBase ? Properties.Resources.Repeat_16px : null),
                        Enabled = (cmd is Fcop.Core.FileCommandBase ? false : true)
                    };
                    n.Click += N_Click;
                        toolStripDropDownButtonAddCommand.DropDownItems.Add(n);
                }
            }
          //  MessageBox.Show( _definition.Serialize() );

        }

        private void N_Click(object sender, EventArgs e)
        {
            using(var d = new Forms.CommandEditor())
            {
                d.ShowDialog();
            }
        }
    }
}
