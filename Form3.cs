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
    public partial class Form3 : Form
    {
        Dictionary<long, object> list = new Dictionary<long, object>();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var twt = listBox1.SelectedItem;
            Console.WriteLine(twt);

            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            var timelineTweets = Timeline.GetUserTimeline(user);
            foreach (var listas in list)
            {
                if (twt.Equals(listas.Value))
                {
                    var retweet = Tweet.PublishRetweet(listas.Key);
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            var timelineTweets = Timeline.GetUserTimeline(user);


            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }

            foreach (var timelineTweet in timelineTweets)
            {
                listBox1.Items.Add(timelineTweet);
                //list.Add(timelineTweet.Id, timelineTweet);
                //timelineTweet.PublishRetweet();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;
            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            var timelineTweets = Timeline.GetUserTimeline(user);


            if (listView1.Items.Count > 0)
            {
                listView1.Items.Clear();
            }

            foreach (var timelineTweet in timelineTweets)
            {
                ListViewItem listItem = new ListViewItem(timelineTweet.Text);
                listItem.SubItems.Add(timelineTweet.CreatedBy.ToString());
                listItem.SubItems.Add(timelineTweet.Id.ToString());
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
            /*
            foreach (ListViewItem item in checkedItems)
            {
                var x = item.Tag;
                Console.WriteLine(x + "ha");
                Console.WriteLine("Veikia 2");
                //var retweet = Tweet.PublishRetweet(item.Tag);

                foreach (var listas in list)
                {
                    if (x == listas.Value)
                    {
                        Console.WriteLine(listas.Key);
                        var retweet = Tweet.PublishRetweet(listas.Key);
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        break;
                    }
                }
            }*/

           // var retweet = Tweet.PublishRetweet(selected);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
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

            var timelineTweets = Timeline.GetUserTimeline(user);
            var success = Tweet.DestroyTweet(a);
            MessageBox.Show("Delete was successfull");
            listView1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var checkedItems = listView1.SelectedItems;
            long a = (long)listView1.SelectedItems[0].Tag;
            Console.WriteLine(checkedItems[0].Tag + "bla");
            Console.WriteLine("Veikia");

            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            var timelineTweets = Timeline.GetUserTimeline(user);
            var tweetToReplyTo = Tweet.GetTweet(a);
            var textToPublish = string.Format("@{0} {1}", tweetToReplyTo.CreatedBy.ScreenName, textBox1.Text);
            var tweet = Tweet.PublishTweetInReplyTo(textToPublish, a);
            Console.WriteLine("Publish success? {0}", tweet != null);
            MessageBox.Show("Reply was successfull");
            listView1.Items.Clear();
        }
    }
}
