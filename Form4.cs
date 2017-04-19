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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                var username = textBox1.Text;
                var user = User.GetUserFromScreenName(username);
                var timelineTweets = Timeline.GetUserTimeline(user);

                if (listBox1.Items.Count > 0)
                {
                    listBox1.Items.Clear();
                }

                foreach (var timelineTweet in timelineTweets)
                {
                    listBox1.Items.Add(timelineTweet);
                }
            }else
            {
                MessageBox.Show("Enter Username");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;
            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();
            var username = textBox1.Text;
            var useris = User.GetUserFromScreenName(username);
            
            var timelineTweets = Timeline.GetUserTimeline(useris);


            if (listView1.Items.Count > 0)
            {
                listView1.Items.Clear();
            }

            foreach (var timelineTweet in timelineTweets)
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var checkedItems = listView1.SelectedItems;
            long a = (long) listView1.SelectedItems[0].Tag;
            Console.WriteLine(checkedItems[0].Tag + "bla");
            Console.WriteLine("Veikia");

            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            var timelineTweets = Timeline.GetUserTimeline(user);
            var retweet = Tweet.PublishRetweet(a);
            MessageBox.Show("Retweet was successfull");
            listView1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var checkedItems = listView1.SelectedItems;
            long a = (long)listView1.SelectedItems[0].Tag;
            Console.WriteLine(checkedItems[0].Tag + "bla");
            Console.WriteLine("Veikia");

            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            var timelineTweets = Timeline.GetUserTimeline(user);
            var success = Tweet.FavoriteTweet(a);
            MessageBox.Show("Favorite was successfull");
            listView1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var checkedItems = listView1.SelectedItems;
            long a = (long)listView1.SelectedItems[0].Tag;
            Console.WriteLine(checkedItems[0].Tag + "bla");
            Console.WriteLine("Veikia");

            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            var username = textBox1.Text;
            var useris = User.GetUserFromScreenName(username);
            var timelineTweets = Timeline.GetUserTimeline(useris);
            var tweetToReplyTo = Tweet.GetTweet(a);
            var textToPublish = string.Format("@{0} {1}", tweetToReplyTo.CreatedBy.ScreenName, textBox2.Text);
            var tweet = Tweet.PublishTweetInReplyTo(textToPublish, a);
            Console.WriteLine("Publish success? {0}", tweet != null);
            MessageBox.Show("Reply was successfull");
            listView1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();
            var username = textBox1.Text;
            var useris = User.GetUserFromScreenName(username);
            user.FollowUser(useris);
           
        }
    }
}
