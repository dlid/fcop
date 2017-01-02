namespace Fcop.Forms
{
    partial class CommandEditor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel_ActivePanelContainer = new System.Windows.Forms.Panel();
            this.panel_ActiveTitle = new System.Windows.Forms.Panel();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.imageListMainTree = new System.Windows.Forms.ImageList(this.components);
            this.panel_Copy = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.objectListView2 = new BrightIdeasSoftware.ObjectListView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_ActivePanelContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_Copy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel_ActivePanelContainer);
            this.splitContainer1.Panel2.Controls.Add(this.panel_ActiveTitle);
            this.splitContainer1.Size = new System.Drawing.Size(852, 496);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel_ActivePanelContainer
            // 
            this.panel_ActivePanelContainer.AutoScroll = true;
            this.panel_ActivePanelContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_ActivePanelContainer.Controls.Add(this.panel_Copy);
            this.panel_ActivePanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ActivePanelContainer.Location = new System.Drawing.Point(0, 33);
            this.panel_ActivePanelContainer.Name = "panel_ActivePanelContainer";
            this.panel_ActivePanelContainer.Size = new System.Drawing.Size(724, 463);
            this.panel_ActivePanelContainer.TabIndex = 0;
            // 
            // panel_ActiveTitle
            // 
            this.panel_ActiveTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel_ActiveTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ActiveTitle.Location = new System.Drawing.Point(0, 0);
            this.panel_ActiveTitle.Name = "panel_ActiveTitle";
            this.panel_ActiveTitle.Size = new System.Drawing.Size(724, 33);
            this.panel_ActiveTitle.TabIndex = 1;
            // 
            // treeViewMain
            // 
            this.treeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewMain.FullRowSelect = true;
            this.treeViewMain.HideSelection = false;
            this.treeViewMain.ItemHeight = 26;
            this.treeViewMain.Location = new System.Drawing.Point(0, 0);
            this.treeViewMain.Name = "treeViewMain";
            this.treeViewMain.ShowLines = false;
            this.treeViewMain.ShowPlusMinus = false;
            this.treeViewMain.ShowRootLines = false;
            this.treeViewMain.Size = new System.Drawing.Size(124, 496);
            this.treeViewMain.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 49);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(757, 6);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(83, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "&OK";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(668, 6);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(83, 37);
            this.button2.TabIndex = 6;
            this.button2.Text = "&Cancel";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // imageListMainTree
            // 
            this.imageListMainTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListMainTree.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListMainTree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel_Copy
            // 
            this.panel_Copy.Controls.Add(this.label3);
            this.panel_Copy.Controls.Add(this.label2);
            this.panel_Copy.Controls.Add(this.objectListView2);
            this.panel_Copy.Controls.Add(this.label1);
            this.panel_Copy.Controls.Add(this.objectListView1);
            this.panel_Copy.Controls.Add(this.button3);
            this.panel_Copy.Controls.Add(this.textBox3);
            this.panel_Copy.Controls.Add(this.label6);
            this.panel_Copy.Controls.Add(this.label4);
            this.panel_Copy.Controls.Add(this.textBox2);
            this.panel_Copy.Location = new System.Drawing.Point(3, 4);
            this.panel_Copy.Name = "panel_Copy";
            this.panel_Copy.Size = new System.Drawing.Size(662, 445);
            this.panel_Copy.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(140, 45);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(451, 27);
            this.textBox3.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Source Path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Target path:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(140, 78);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(493, 27);
            this.textBox2.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(603, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // objectListView1
            // 
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Location = new System.Drawing.Point(24, 148);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(609, 97);
            this.objectListView1.TabIndex = 17;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ignore files:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Rename files:";
            // 
            // objectListView2
            // 
            this.objectListView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView2.CellEditUseWholeCell = false;
            this.objectListView2.Location = new System.Drawing.Point(24, 287);
            this.objectListView2.Name = "objectListView2";
            this.objectListView2.Size = new System.Drawing.Size(609, 97);
            this.objectListView2.TabIndex = 19;
            this.objectListView2.UseCompatibleStateImageBehavior = false;
            this.objectListView2.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(475, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "This command will run for each new, updated or deleted file in the source";
            // 
            // CommandEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 545);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommandEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CommandEditor";
            this.Load += new System.EventHandler(this.CommandEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel_ActivePanelContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_Copy.ResumeLayout(false);
            this.panel_Copy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewMain;
        private System.Windows.Forms.Panel panel_ActivePanelContainer;
        private System.Windows.Forms.Panel panel_ActiveTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageListMainTree;
        private System.Windows.Forms.Panel panel_Copy;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private BrightIdeasSoftware.ObjectListView objectListView2;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
    }
}