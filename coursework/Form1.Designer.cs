namespace coursework
{
    partial class Form1
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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Favourites");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("History");
            this.searchbar = new System.Windows.Forms.TextBox();
            this.searchbarButton = new System.Windows.Forms.Button();
            this.OutputDataBox = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.ssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bookmarks = new System.Windows.Forms.TreeView();
            this.btnBookmarsAddFavourite = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteNode = new System.Windows.Forms.ToolStripMenuItem();
            this.setHomeNode = new System.Windows.Forms.ToolStripMenuItem();
            this.addFavouriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBatch = new System.Windows.Forms.OpenFileDialog();
            this.btnBatchDownload = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssHome = new System.Windows.Forms.ToolStripStatusLabel();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.nodeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchbar
            // 
            this.searchbar.Location = new System.Drawing.Point(190, 12);
            this.searchbar.Name = "searchbar";
            this.searchbar.Size = new System.Drawing.Size(566, 20);
            this.searchbar.TabIndex = 0;
            this.searchbar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchbar_KeyUp);
            // 
            // searchbarButton
            // 
            this.searchbarButton.Location = new System.Drawing.Point(797, 11);
            this.searchbarButton.Name = "searchbarButton";
            this.searchbarButton.Size = new System.Drawing.Size(75, 21);
            this.searchbarButton.TabIndex = 2;
            this.searchbarButton.Text = "search";
            this.searchbarButton.UseVisualStyleBackColor = true;
            this.searchbarButton.Click += new System.EventHandler(this.SearchbarButton_Click);
            // 
            // OutputDataBox
            // 
            this.OutputDataBox.AcceptsReturn = true;
            this.OutputDataBox.AcceptsTab = true;
            this.OutputDataBox.Location = new System.Drawing.Point(190, 34);
            this.OutputDataBox.Multiline = true;
            this.OutputDataBox.Name = "OutputDataBox";
            this.OutputDataBox.ReadOnly = true;
            this.OutputDataBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputDataBox.Size = new System.Drawing.Size(683, 448);
            this.OutputDataBox.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssStatus,
            this.toolStripStatusLabel1,
            this.ssHome});
            this.statusStrip.Location = new System.Drawing.Point(0, 493);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(884, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_ItemClicked);
            // 
            // ssStatus
            // 
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(52, 17);
            this.ssStatus.Text = "200 (OK)";
            // 
            // bookmarks
            // 
            this.bookmarks.HideSelection = false;
            this.bookmarks.Location = new System.Drawing.Point(12, 34);
            this.bookmarks.Margin = new System.Windows.Forms.Padding(2);
            this.bookmarks.Name = "bookmarks";
            treeNode7.Name = "";
            treeNode7.Text = "Favourites";
            treeNode8.Name = "";
            treeNode8.Text = "History";
            this.bookmarks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.bookmarks.Size = new System.Drawing.Size(167, 325);
            this.bookmarks.TabIndex = 5;
            this.bookmarks.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.bookmarks_NodeMouseDoubleClick);
            this.bookmarks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bookmarks_MouseClick);
            // 
            // btnBookmarsAddFavourite
            // 
            this.btnBookmarsAddFavourite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookmarsAddFavourite.Location = new System.Drawing.Point(761, 11);
            this.btnBookmarsAddFavourite.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookmarsAddFavourite.Name = "btnBookmarsAddFavourite";
            this.btnBookmarsAddFavourite.Size = new System.Drawing.Size(31, 21);
            this.btnBookmarsAddFavourite.TabIndex = 6;
            this.btnBookmarsAddFavourite.Text = "*";
            this.btnBookmarsAddFavourite.UseVisualStyleBackColor = true;
            this.btnBookmarsAddFavourite.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBookmarsAddFavourite_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 20);
            this.button1.TabIndex = 8;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nodeMenu
            // 
            this.nodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteNode,
            this.setHomeNode,
            this.addFavouriteToolStripMenuItem,
            this.renameToolStripMenuItem});
            this.nodeMenu.Name = "nodeMenu";
            this.nodeMenu.Size = new System.Drawing.Size(181, 114);
            // 
            // deleteNode
            // 
            this.deleteNode.Name = "deleteNode";
            this.deleteNode.Size = new System.Drawing.Size(148, 22);
            this.deleteNode.Text = "Delete";
            this.deleteNode.Click += new System.EventHandler(this.deleteNode_Click);
            // 
            // setHomeNode
            // 
            this.setHomeNode.Name = "setHomeNode";
            this.setHomeNode.Size = new System.Drawing.Size(148, 22);
            this.setHomeNode.Text = "Set Home";
            this.setHomeNode.Click += new System.EventHandler(this.setHomeNode_Click);
            // 
            // addFavouriteToolStripMenuItem
            // 
            this.addFavouriteToolStripMenuItem.Name = "addFavouriteToolStripMenuItem";
            this.addFavouriteToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addFavouriteToolStripMenuItem.Text = "Add Favourite";
            this.addFavouriteToolStripMenuItem.Click += new System.EventHandler(this.addFavouriteToolStripMenuItem_Click);
            // 
            // openBatch
            // 
            this.openBatch.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnBatchDownload
            // 
            this.btnBatchDownload.Location = new System.Drawing.Point(12, 364);
            this.btnBatchDownload.Name = "btnBatchDownload";
            this.btnBatchDownload.Size = new System.Drawing.Size(167, 23);
            this.btnBatchDownload.TabIndex = 9;
            this.btnBatchDownload.Text = "Batch Download";
            this.btnBatchDownload.UseVisualStyleBackColor = true;
            this.btnBatchDownload.Click += new System.EventHandler(this.btnBatchDownload_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(50, 20);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "<-";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(68, 12);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(50, 20);
            this.btnForward.TabIndex = 11;
            this.btnForward.Text = "->";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // ssHome
            // 
            this.ssHome.Name = "ssHome";
            this.ssHome.Size = new System.Drawing.Size(65, 17);
            this.ssHome.Text = "Set Home: ";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripMenuItem1});
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            //this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            //this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Rename";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 515);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnBatchDownload);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBookmarsAddFavourite);
            this.Controls.Add(this.bookmarks);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.OutputDataBox);
            this.Controls.Add(this.searchbarButton);
            this.Controls.Add(this.searchbar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.nodeMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchbar;
        private System.Windows.Forms.Button searchbarButton;
        private System.Windows.Forms.TextBox OutputDataBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ssStatus;
        private System.Windows.Forms.TreeView bookmarks;
        private System.Windows.Forms.Button btnBookmarsAddFavourite;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip nodeMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteNode;
        private System.Windows.Forms.ToolStripMenuItem setHomeNode;
        private System.Windows.Forms.ToolStripMenuItem addFavouriteToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openBatch;
        private System.Windows.Forms.Button btnBatchDownload;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ssHome;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

