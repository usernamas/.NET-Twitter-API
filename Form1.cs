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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();
            
            Console.WriteLine(user);
            var tweet = Tweet.PublishTweet("Zjbs veikia is Visual Studio forma 3");
            //var timelineTweets = Timeline.GetUserTimeline(user, 5);
            var timelineTweets = Timeline.GetHomeTimeline();
            Console.WriteLine("--------------------------------------Newest--------------------------------------");
            
            foreach (var timelineTweet in timelineTweets)
            {
                Console.WriteLine(timelineTweet);
            }

            Console.WriteLine("--------------------------------------Oldest--------------------------------------");
            //Console.ReadKey();

            pictureBox1.ImageLocation = user.ProfileImageUrlFullSize;
            //label1.Text = "Username: " + user.Name;
            //label2.Text = "Favourites: " + user.FavouritesCount;
            //label3.Text = "Followers: " + user.FollowersCount;
            //label4.Text = "Friends: " + user.FriendsCount;
            //label5.Text = "Created at: \n" + user.CreatedAt;
            Console.WriteLine("Created at: " + user.CreatedAt);
            //Console.WriteLine(user.Description);
            //Console.WriteLine(user.Email);
            Console.WriteLine("Favourites: " + user.FavouritesCount);
            Console.WriteLine("Followers: " + user.FollowersCount);
            Console.WriteLine("Friends: " + user.FriendsCount);
            Console.WriteLine("Username: " + user.Name);
            //Console.WriteLine(user.Location);

            button14.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var tweet = Tweet.PublishTweet("Eik sau rimtai veikia froma 3");
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String textas = textBox1.Text;
            var tweet = Tweet.PublishTweet(textas);
            //tweet.PublishRetweet();
            MessageBox.Show("Tweet was successfully posted");
            textBox1.Text = String.Empty;
            //this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
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
            }else
            {
                MessageBox.Show("Enter Text");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //int x = 0;
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
                //listItem.SubItems.Add(timelineTweet.Id.ToString());
                listItem.SubItems.Add(timelineTweet.CreatedAt.ToString());
                listItem.SubItems.Add(timelineTweet.FavoriteCount.ToString());
                listItem.SubItems.Add(timelineTweet.RetweetCount.ToString());
                listView1.Items.Add(listItem);
                listItem.Tag = timelineTweet.Id;
                //listView1.Items[x].Tag = timelineTweet.Id;
                //x++;
                //list.Add(timelineTweet.Id, timelineTweet);
                //timelineTweet.PublishRetweet();
            }

            button14.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var checkedItems = listView1.SelectedItems;
            long a = (long)listView1.SelectedItems[0].Tag;

            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            //var timelineTweets = Timeline.GetUserTimeline(user);
            var retweet = Tweet.PublishRetweet(a);
            MessageBox.Show("Retweet was successfull");
            listView1.Items.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var checkedItems = listView1.SelectedItems;
            long a = (long)listView1.SelectedItems[0].Tag;

            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            //var timelineTweets = Timeline.GetUserTimeline(user);
            var success = Tweet.FavoriteTweet(a);
            MessageBox.Show("Favorite was successfull");
            listView1.Items.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var checkedItems = listView1.SelectedItems;
            long a = (long)listView1.SelectedItems[0].Tag;

            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            //var timelineTweets = Timeline.GetUserTimeline(user);
            var tweetToReplyTo = Tweet.GetTweet(a);
            var textToPublish = string.Format("@{0} {1}", tweetToReplyTo.CreatedBy.ScreenName, textBox1.Text);
            var tweet = Tweet.PublishTweetInReplyTo(textToPublish, a);
            Console.WriteLine("Publish success? {0}", tweet != null);
            MessageBox.Show("Reply was successfull");
            listView1.Items.Clear();
            textBox1.Text = String.Empty;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var checkedItems = listView1.SelectedItems;
            long a = (long)listView1.SelectedItems[0].Tag;

            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            //var timelineTweets = Timeline.GetUserTimeline(user);
            var success = Tweet.DestroyTweet(a);
            MessageBox.Show("Delete was successfull");
            listView1.Items.Clear();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();
            var username = textBox2.Text;
            var useris = User.GetUserFromScreenName(username);
            user.FollowUser(useris);

            if(useris.Following == true){
                user.UnFollowUser(useris);
            }

            MessageBox.Show("Follow is successfull");
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x = 0;
            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();
            var username = textBox2.Text;
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
                //listItem.SubItems.Add(timelineTweet.Id.ToString());
                listItem.SubItems.Add(timelineTweet.CreatedAt.ToString());
                listItem.SubItems.Add(timelineTweet.FavoriteCount.ToString());
                listItem.SubItems.Add(timelineTweet.RetweetCount.ToString());
                listView1.Items.Add(listItem);
                listView1.Items[x].Tag = timelineTweet.Id;
                x++;
                //list.Add(timelineTweet.Id, timelineTweet);
                //timelineTweet.PublishRetweet();
            }

            button14.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x = 0;
            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();

            var timelineTweets = Timeline.GetHomeTimeline();

            if (listView1.Items.Count > 0)
            {
                listView1.Items.Clear();
            }

            foreach (var timelineTweet in timelineTweets)
            {
                ListViewItem listItem = new ListViewItem(timelineTweet.Text);
                listItem.SubItems.Add(timelineTweet.CreatedBy.ToString());
                //listItem.SubItems.Add(timelineTweet.Id.ToString());
                listItem.SubItems.Add(timelineTweet.CreatedAt.ToString());
                listItem.SubItems.Add(timelineTweet.FavoriteCount.ToString());
                listItem.SubItems.Add(timelineTweet.RetweetCount.ToString());
                listView1.Items.Add(listItem);
                listView1.Items[x].Tag = timelineTweet.Id;
                x++;
                //list.Add(timelineTweet.Id, timelineTweet);
                //timelineTweet.PublishRetweet();
            }

            button14.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int x = 0;
            Auth.SetUserCredentials("fztyetNG4qG27vhoMz57snthx", "7MiCC2JGwkPPrtpUlUldkAQaZ3TM71SKFOZdnwLX8G9yvf7lK0", "803690404357046272-HV8uU8BI5pIicUbr1T7EMu1YXidd3VI", "iDiMHxfhIy0t9JlE12h8l9XjyytcrgeJAaz3PjTbpKmhl");
            var user = User.GetAuthenticatedUser();
            var search = textBox2.Text;
            //var searchWord = User.GetUserFromScreenName(search);

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
                //listItem.SubItems.Add(timelineTweet.Id.ToString());
                listItem.SubItems.Add(timelineTweet.CreatedAt.ToString());
                listItem.SubItems.Add(timelineTweet.FavoriteCount.ToString());
                listItem.SubItems.Add(timelineTweet.RetweetCount.ToString());
                listView1.Items.Add(listItem);
                listView1.Items[x].Tag = timelineTweet.Id;
                x++;
                //list.Add(timelineTweet.Id, timelineTweet);
                //timelineTweet.PublishRetweet();
            }

            button14.Enabled = false;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
