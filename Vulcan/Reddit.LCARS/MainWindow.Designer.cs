using Samples.RedditBayes;

namespace Samples.RedditLCARS
{
    partial class MainWindow
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
            this.ListOfPosts = new System.Windows.Forms.ListBox();
            this.PostDisplay = new System.Windows.Forms.WebBrowser();
            this.LikePost = new System.Windows.Forms.Button();
            this.DislikePost = new System.Windows.Forms.Button();
            this.postBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ListOfPosts
            // 
            this.ListOfPosts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListOfPosts.DisplayMember = "DisplayTitle";
            this.ListOfPosts.FormattingEnabled = true;
            this.ListOfPosts.Location = new System.Drawing.Point(13, 13);
            this.ListOfPosts.Name = "ListOfPosts";
            this.ListOfPosts.Size = new System.Drawing.Size(285, 641);
            this.ListOfPosts.TabIndex = 0;
            this.ListOfPosts.SelectedIndexChanged += new System.EventHandler(this.ListOfPosts_SelectedIndexChanged);
            // 
            // PostDisplay
            // 
            this.PostDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PostDisplay.Location = new System.Drawing.Point(304, 13);
            this.PostDisplay.MinimumSize = new System.Drawing.Size(20, 20);
            this.PostDisplay.Name = "PostDisplay";
            this.PostDisplay.ScriptErrorsSuppressed = true;
            this.PostDisplay.Size = new System.Drawing.Size(658, 595);
            this.PostDisplay.TabIndex = 1;
            this.PostDisplay.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.PostDisplay_Navigated);
            // 
            // LikePost
            // 
            this.LikePost.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LikePost.Location = new System.Drawing.Point(421, 630);
            this.LikePost.Name = "LikePost";
            this.LikePost.Size = new System.Drawing.Size(75, 23);
            this.LikePost.TabIndex = 2;
            this.LikePost.Text = "Like";
            this.LikePost.UseVisualStyleBackColor = true;
            this.LikePost.Click += new System.EventHandler(this.LikePost_Click);
            // 
            // DislikePost
            // 
            this.DislikePost.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DislikePost.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.postBindingSource, "ID", true));
            this.DislikePost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.postBindingSource, "Title", true));
            this.DislikePost.Location = new System.Drawing.Point(566, 629);
            this.DislikePost.Name = "DislikePost";
            this.DislikePost.Size = new System.Drawing.Size(75, 23);
            this.DislikePost.TabIndex = 3;
            this.DislikePost.Text = "Dislike";
            this.DislikePost.UseVisualStyleBackColor = true;
            this.DislikePost.Click += new System.EventHandler(this.DislikePost_Click);
            // 
            // postBindingSource
            // 
            this.postBindingSource.DataSource = typeof(Samples.RedditBayes.Post);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 672);
            this.Controls.Add(this.DislikePost);
            this.Controls.Add(this.LikePost);
            this.Controls.Add(this.PostDisplay);
            this.Controls.Add(this.ListOfPosts);
            this.Name = "MainWindow";
            this.Text = "Reddit Likealizer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListOfPosts;
        private System.Windows.Forms.WebBrowser PostDisplay;
        private System.Windows.Forms.Button LikePost;
        private System.Windows.Forms.Button DislikePost;
        private System.Windows.Forms.BindingSource postBindingSource;
    }
}

