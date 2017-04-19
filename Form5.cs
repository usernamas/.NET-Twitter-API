using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;

namespace TikiuosVeiks
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();
            var search = textBox1.Text;
            var searchWord = User.GetUserFromScreenName(search);

            //var timelineTweets = Timeline.GetUserTimeline(useris);
            var tweets = Search.SearchTweets(search);


            if (listView1.Items.Count > 0)
            {
                listView1.Items.Clear();
            }

            foreach (var timelineTweet in tweets)
            {
                ListViewItem listItem = new ListViewItem(timelineTweet.Text);
                listItem.SubItems.Add(timelineTweet.CreatedBy.ToString());
                listItem.SubItems.Add(timelineTweet.Id.ToString());
                listItem.SubItems.Add(timelineTweet.CreatedAt.ToString());
                listItem.SubItems.Add(timelineTweet.FavoriteCount.ToString());
                listItem.SubItems.Add(timelineTweet.RetweetCount.ToString());
                listView1.Items.Add(listItem);
                listView1.Items[x].Tag = timelineTweet.Id;
                x++;
                //list.Add(timelineTweet.Id, timelineTweet);
                //timelineTweet.PublishRetweet();
            }

            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Veikia");
        }
    }
}
