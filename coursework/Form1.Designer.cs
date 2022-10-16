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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Favourites");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("History");
            this.searchbar = new System.Windows.Forms.TextBox();
            this.searchbarButton = new System.Windows.Forms.Button();
            this.OutputDataBox = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.ssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bookmarks = new System.Windows.Forms.TreeView();
            this.btnBookmarsAddFavourite = new System.Windows.Forms.Button();
            this.btnBookmarksDelete = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchbar
            // 
            this.searchbar.Location = new System.Drawing.Point(18, 18);
            this.searchbar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchbar.Name = "searchbar";
            this.searchbar.Size = new System.Drawing.Size(1166, 26);
            this.searchbar.TabIndex = 0;
            this.searchbar.TextChanged += new System.EventHandler(this.Searchbar_TextChanged);
            // 
            // searchbarButton
            // 
            this.searchbarButton.Location = new System.Drawing.Point(1196, 17);
            this.searchbarButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchbarButton.Name = "searchbarButton";
            this.searchbarButton.Size = new System.Drawing.Size(112, 32);
            this.searchbarButton.TabIndex = 2;
            this.searchbarButton.Text = "search";
            this.searchbarButton.UseVisualStyleBackColor = true;
            this.searchbarButton.Click += new System.EventHandler(this.SearchbarButton_Click);
            // 
            // OutputDataBox
            // 
            this.OutputDataBox.AcceptsReturn = true;
            this.OutputDataBox.AcceptsTab = true;
            this.OutputDataBox.Location = new System.Drawing.Point(285, 52);
            this.OutputDataBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OutputDataBox.Multiline = true;
            this.OutputDataBox.Name = "OutputDataBox";
            this.OutputDataBox.ReadOnly = true;
            this.OutputDataBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputDataBox.Size = new System.Drawing.Size(1023, 687);
            this.OutputDataBox.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 1139);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1326, 32);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // ssStatus
            // 
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(81, 25);
            this.ssStatus.Text = "200 (OK)";
            // 
            // bookmarks
            // 
            this.bookmarks.Location = new System.Drawing.Point(18, 52);
            this.bookmarks.Name = "bookmarks";
            treeNode3.Name = "";
            treeNode3.Text = "Favourites";
            treeNode4.Name = "";
            treeNode4.Text = "History";
            this.bookmarks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.bookmarks.Size = new System.Drawing.Size(249, 498);
            this.bookmarks.TabIndex = 5;
            this.bookmarks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.bookmarks_AfterSelect);
            this.bookmarks.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.bookmarks_NodeMouseDoubleClick);
            // 
            // btnBookmarsAddFavourite
            // 
            this.btnBookmarsAddFavourite.Location = new System.Drawing.Point(18, 556);
            this.btnBookmarsAddFavourite.Name = "btnBookmarsAddFavourite";
            this.btnBookmarsAddFavourite.Size = new System.Drawing.Size(75, 33);
            this.btnBookmarsAddFavourite.TabIndex = 6;
            this.btnBookmarsAddFavourite.Text = "ATF";
            this.btnBookmarsAddFavourite.UseVisualStyleBackColor = true;
            this.btnBookmarsAddFavourite.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBookmarsAddFavourite_MouseUp);
            // 
            // btnBookmarksDelete
            // 
            this.btnBookmarksDelete.Location = new System.Drawing.Point(100, 556);
            this.btnBookmarksDelete.Name = "btnBookmarksDelete";
            this.btnBookmarksDelete.Size = new System.Drawing.Size(75, 32);
            this.btnBookmarksDelete.TabIndex = 7;
            this.btnBookmarksDelete.Text = "Del";
            this.btnBookmarksDelete.UseVisualStyleBackColor = true;
            this.btnBookmarksDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBookmarksDelete_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 1171);
            this.Controls.Add(this.btnBookmarksDelete);
            this.Controls.Add(this.btnBookmarsAddFavourite);
            this.Controls.Add(this.bookmarks);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.OutputDataBox);
            this.Controls.Add(this.searchbarButton);
            this.Controls.Add(this.searchbar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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
    }
}

