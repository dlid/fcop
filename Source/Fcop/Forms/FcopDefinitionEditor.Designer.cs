namespace Fcop.Forms
{
    partial class FcopDefinitionEditor
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.imageListMainTree = new System.Windows.Forms.ImageList(this.components);
            this.panel_ActivePanelContainer = new System.Windows.Forms.Panel();
            this.panel_ActiveTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_PageSource = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_PageTarget = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBoxTargetType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.panel_PageCommands = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStripDropDownButtonAddCommand = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.buttonBrowseSourceFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_ActivePanelContainer.SuspendLayout();
            this.panel_ActiveTitle.SuspendLayout();
            this.panel_PageSource.SuspendLayout();
            this.panel_PageTarget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.panel_PageCommands.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1129, 41);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 479);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 32);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel_ActivePanelContainer);
            this.splitContainer1.Panel2.Controls.Add(this.panel_ActiveTitle);
            this.splitContainer1.Size = new System.Drawing.Size(1129, 438);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeViewMain
            // 
            this.treeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMain.FullRowSelect = true;
            this.treeViewMain.HideSelection = false;
            this.treeViewMain.Location = new System.Drawing.Point(0, 0);
            this.treeViewMain.Name = "treeViewMain";
            this.treeViewMain.ShowLines = false;
            this.treeViewMain.ShowPlusMinus = false;
            this.treeViewMain.ShowRootLines = false;
            this.treeViewMain.Size = new System.Drawing.Size(231, 276);
            this.treeViewMain.TabIndex = 0;
            this.treeViewMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMain_AfterSelect);
            // 
            // imageListMainTree
            // 
            this.imageListMainTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListMainTree.ImageSize = new System.Drawing.Size(32, 32);
            this.imageListMainTree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel_ActivePanelContainer
            // 
            this.panel_ActivePanelContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_ActivePanelContainer.Controls.Add(this.panel_PageTarget);
            this.panel_ActivePanelContainer.Controls.Add(this.panel_PageCommands);
            this.panel_ActivePanelContainer.Controls.Add(this.panel_PageSource);
            this.panel_ActivePanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ActivePanelContainer.Location = new System.Drawing.Point(0, 60);
            this.panel_ActivePanelContainer.Name = "panel_ActivePanelContainer";
            this.panel_ActivePanelContainer.Size = new System.Drawing.Size(894, 378);
            this.panel_ActivePanelContainer.TabIndex = 0;
            // 
            // panel_ActiveTitle
            // 
            this.panel_ActiveTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel_ActiveTitle.Controls.Add(this.label1);
            this.panel_ActiveTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ActiveTitle.Location = new System.Drawing.Point(0, 0);
            this.panel_ActiveTitle.Name = "panel_ActiveTitle";
            this.panel_ActiveTitle.Size = new System.Drawing.Size(894, 60);
            this.panel_ActiveTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel_PageSource
            // 
            this.panel_PageSource.Controls.Add(this.buttonBrowseSourceFolder);
            this.panel_PageSource.Controls.Add(this.label2);
            this.panel_PageSource.Controls.Add(this.textBox1);
            this.panel_PageSource.Location = new System.Drawing.Point(561, 48);
            this.panel_PageSource.Name = "panel_PageSource";
            this.panel_PageSource.Size = new System.Drawing.Size(247, 121);
            this.panel_PageSource.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(119, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 27);
            this.textBox1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Source folder:";
            // 
            // panel_PageTarget
            // 
            this.panel_PageTarget.Controls.Add(this.label7);
            this.panel_PageTarget.Controls.Add(this.textBox3);
            this.panel_PageTarget.Controls.Add(this.label6);
            this.panel_PageTarget.Controls.Add(this.label4);
            this.panel_PageTarget.Controls.Add(this.comboBoxTargetType);
            this.panel_PageTarget.Controls.Add(this.button1);
            this.panel_PageTarget.Controls.Add(this.label5);
            this.panel_PageTarget.Controls.Add(this.textBox2);
            this.panel_PageTarget.Location = new System.Drawing.Point(166, 4);
            this.panel_PageTarget.Name = "panel_PageTarget";
            this.panel_PageTarget.Size = new System.Drawing.Size(642, 270);
            this.panel_PageTarget.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Target type:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(167, 113);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(455, 27);
            this.textBox2.TabIndex = 0;
            // 
            // comboBoxTargetType
            // 
            this.comboBoxTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTargetType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTargetType.FormattingEnabled = true;
            this.comboBoxTargetType.Items.AddRange(new object[] {
            "FTP",
            "Filesystem"});
            this.comboBoxTargetType.Location = new System.Drawing.Point(169, 17);
            this.comboBoxTargetType.Name = "comboBoxTargetType";
            this.comboBoxTargetType.Size = new System.Drawing.Size(453, 28);
            this.comboBoxTargetType.TabIndex = 5;
            this.comboBoxTargetType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTargetType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "FTP root folder:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Username:";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(169, 54);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(455, 27);
            this.textBox3.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(169, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(455, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Password will";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeViewMain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(6);
            this.splitContainer2.Size = new System.Drawing.Size(231, 438);
            this.splitContainer2.SplitterDistance = 276;
            this.splitContainer2.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(219, 146);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "hej hej";
            // 
            // objectListView1
            // 
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.Location = new System.Drawing.Point(0, 25);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(719, 299);
            this.objectListView1.TabIndex = 8;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // panel_PageCommands
            // 
            this.panel_PageCommands.Controls.Add(this.objectListView1);
            this.panel_PageCommands.Controls.Add(this.toolStrip1);
            this.panel_PageCommands.Location = new System.Drawing.Point(22, 31);
            this.panel_PageCommands.Name = "panel_PageCommands";
            this.panel_PageCommands.Size = new System.Drawing.Size(719, 324);
            this.panel_PageCommands.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonAddCommand,
            this.toolStripButton4,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(719, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Fcop.Properties.Resources.FTP_16px;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(541, 209);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(83, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "&Browse";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // toolStripDropDownButtonAddCommand
            // 
            this.toolStripDropDownButtonAddCommand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonAddCommand.Image = global::Fcop.Properties.Resources.Plus_16px;
            this.toolStripDropDownButtonAddCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonAddCommand.Name = "toolStripDropDownButtonAddCommand";
            this.toolStripDropDownButtonAddCommand.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonAddCommand.Text = "toolStripDropDownButton1";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Enabled = false;
            this.toolStripButton4.Image = global::Fcop.Properties.Resources.Minus_16px;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = global::Fcop.Properties.Resources.Pencil_Tip_16px;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = global::Fcop.Properties.Resources.Sort_Up_16px;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = global::Fcop.Properties.Resources.Sort_Down_16px;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // buttonBrowseSourceFolder
            // 
            this.buttonBrowseSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseSourceFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowseSourceFolder.Image = global::Fcop.Properties.Resources.Open_Folder_16px_1;
            this.buttonBrowseSourceFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBrowseSourceFolder.Location = new System.Drawing.Point(144, 46);
            this.buttonBrowseSourceFolder.Name = "buttonBrowseSourceFolder";
            this.buttonBrowseSourceFolder.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.buttonBrowseSourceFolder.Size = new System.Drawing.Size(83, 37);
            this.buttonBrowseSourceFolder.TabIndex = 4;
            this.buttonBrowseSourceFolder.Text = "&Browse";
            this.buttonBrowseSourceFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonBrowseSourceFolder.UseVisualStyleBackColor = true;
            // 
            // FcopDefinitionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 511);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FcopDefinitionEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FcopDefinitionEditor";
            this.Load += new System.EventHandler(this.FcopDefinitionEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel_ActivePanelContainer.ResumeLayout(false);
            this.panel_ActiveTitle.ResumeLayout(false);
            this.panel_ActiveTitle.PerformLayout();
            this.panel_PageSource.ResumeLayout(false);
            this.panel_PageSource.PerformLayout();
            this.panel_PageTarget.ResumeLayout(false);
            this.panel_PageTarget.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.panel_PageCommands.ResumeLayout(false);
            this.panel_PageCommands.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewMain;
        private System.Windows.Forms.ImageList imageListMainTree;
        private System.Windows.Forms.Panel panel_ActivePanelContainer;
        private System.Windows.Forms.Panel panel_PageSource;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel_ActiveTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBrowseSourceFolder;
        private System.Windows.Forms.Panel panel_PageTarget;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTargetType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel_PageCommands;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonAddCommand;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}