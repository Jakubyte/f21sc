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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Favourites");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("History");
            this.searchbar = new System.Windows.Forms.TextBox();
            this.searchbarButton = new System.Windows.Forms.Button();
            this.OutputDataBox = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.ssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bookmarks = new System.Windows.Forms.TreeView();
            this.btnBookmarsAddFavourite = new System.Windows.Forms.Button();
            this.btnBookmarksDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteNode = new System.Windows.Forms.ToolStripMenuItem();
            this.setHomeNode = new System.Windows.Forms.ToolStripMenuItem();
            this.addFavouriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.nodeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchbar
            // 
            this.searchbar.Location = new System.Drawing.Point(67, 12);
            this.searchbar.Name = "searchbar";
            this.searchbar.Size = new System.Drawing.Size(724, 20);
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
            this.ssStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 668);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(884, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // ssStatus
            // 
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(52, 17);
            this.ssStatus.Text = "200 (OK)";
            // 
            // bookmarks
            // 
            this.bookmarks.Location = new System.Drawing.Point(12, 34);
            this.bookmarks.Margin = new System.Windows.Forms.Padding(2);
            this.bookmarks.Name = "bookmarks";
            treeNode1.Name = "";
            treeNode1.Text = "Favourites";
            treeNode2.Name = "";
            treeNode2.Text = "History";
            this.bookmarks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.bookmarks.Size = new System.Drawing.Size(167, 325);
            this.bookmarks.TabIndex = 5;
            this.bookmarks.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.bookmarks_NodeMouseDoubleClick);
            this.bookmarks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bookmarks_MouseClick);
            // 
            // btnBookmarsAddFavourite
            // 
            this.btnBookmarsAddFavourite.Location = new System.Drawing.Point(12, 361);
            this.btnBookmarsAddFavourite.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookmarsAddFavourite.Name = "btnBookmarsAddFavourite";
            this.btnBookmarsAddFavourite.Size = new System.Drawing.Size(50, 21);
            this.btnBookmarsAddFavourite.TabIndex = 6;
            this.btnBookmarsAddFavourite.Text = "ATF";
            this.btnBookmarsAddFavourite.UseVisualStyleBackColor = true;
            this.btnBookmarsAddFavourite.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBookmarsAddFavourite_MouseUp);
            // 
            // btnBookmarksDelete
            // 
            this.btnBookmarksDelete.Location = new System.Drawing.Point(67, 361);
            this.btnBookmarksDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookmarksDelete.Name = "btnBookmarksDelete";
            this.btnBookmarksDelete.Size = new System.Drawing.Size(50, 21);
            this.btnBookmarksDelete.TabIndex = 7;
            this.btnBookmarksDelete.Text = "Del";
            this.btnBookmarksDelete.UseVisualStyleBackColor = true;
            this.btnBookmarksDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBookmarksDelete_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 20);
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
            this.addFavouriteToolStripMenuItem});
            this.nodeMenu.Name = "nodeMenu";
            this.nodeMenu.Size = new System.Drawing.Size(149, 70);
            this.nodeMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.nodeMenu_ItemClicked);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 690);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBookmarksDelete);
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
        private System.Windows.Forms.Button btnBookmarksDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip nodeMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteNode;
        private System.Windows.Forms.ToolStripMenuItem setHomeNode;
        private System.Windows.Forms.ToolStripMenuItem addFavouriteToolStripMenuItem;
    }
}

