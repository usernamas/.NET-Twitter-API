using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace TikiuosVeiks
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String textas = textBox1.Text;
            var tweet = Tweet.PublishTweet(textas);
            //tweet.PublishRetweet();
            MessageBox.Show("Tweet was successfully posted");
            textBox1.Text = String.Empty;
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String textas = textBox1.Text;
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                String filePath = fileDialog.FileName;
                byte[] file = File.ReadAllBytes(filePath);
                var media = Upload.UploadImage(file);

                var tweet = Tweet.PublishTweet(textBox1.Text, new PublishTweetOptionalParameters
                {
                    Medias = new List<IMedia> { media }
                });
            }

            MessageBox.Show("Tweet with image was successfully posted");
            textBox1.Text = String.Empty;

            //var imageURL = tweet.Entities.Medias.First().MediaURL;

        }
    }
}
