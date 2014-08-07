using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Samples.RedditBayes;

namespace Samples.RedditLCARS
{
    public partial class MainWindow : Form
    {
        private const string BayesiannetworkBin = "BayesianNetwork.bin";
        private const int NumberOfPosts = 100;
        private Reddit _reddit;


        public MainWindow()
        {
            InitializeComponent();
            Load();
            UpdatePosts();
        }

        private void UpdatePosts()
        {
            var answer = _reddit.GetPosts().Where(p => !p.Seen).OrderByDescending(p => p.Likeability).ToList();
            Save();
            ListOfPosts.DataSource = answer;
        }

        private void ListOfPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contract.Assume(ListOfPosts.SelectedItem is Post);
            var selected = ListOfPosts.SelectedItem as Post;
            PostDisplay.Url = new Uri(selected.URL);
        }

        private void PostDisplay_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            PostDisplay.Focus();
        }

        private void LikePost_Click(object sender, EventArgs e)
        {
            UpdateLikeability(_reddit.Like); 
        }

        private void DislikePost_Click(object sender, EventArgs e)
        {
            UpdateLikeability(_reddit.Dislike);
        }

        private void UpdateLikeability(Action<Post> updateLikeabilityFunction)
        {
            updateLikeabilityFunction(ListOfPosts.SelectedItem as Post);
            UpdatePosts();
        }

        private void Save()
        {
            try
            {
                var storage = IsolatedStorageFile.GetUserStoreForAssembly();
                using (var file = new IsolatedStorageFileStream(BayesiannetworkBin, FileMode.Create, FileAccess.Write, storage))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(file, _reddit);
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Couldn't save the bayesian network: {0}", ex.Message)); 
            }
            
        }

        private void Load()
        {
            try
	        {
		        // Get the isolated store for this assembly
		        IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();

	            if (storage.FileExists(BayesiannetworkBin))
	            {
                    // Open the settings file
	                using (var file = new IsolatedStorageFileStream(BayesiannetworkBin, FileMode.Open, FileAccess.Read, storage) )
	                {

                        // Deserialize the XML to an object
                        var formatter = new BinaryFormatter();
                        _reddit = (Reddit)formatter.Deserialize(file);
                        file.Close();
	                }
	            }
	            else
	            {
                    _reddit = new Reddit("programming", NumberOfPosts);
	            }
                
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(String.Format("Couldn't load the bayesian network: {0}", ex.Message)); 
	        }
        }
    }
}
