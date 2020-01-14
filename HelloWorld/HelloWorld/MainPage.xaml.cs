using System;
using System.ComponentModel;
using HelloWorld.Layouts;
using Xamarin.Forms;

namespace HelloWorld
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
        }
        
        public void Handle_Clicked(object sender, EventArgs e)
        {
            count++;
            var r = new Random();
            ((Button)sender).Text = $"You clicked { count } times.";
            ((Button)sender).BackgroundColor = Color.FromRgb(r.Next(0,255), r.Next(0, 255), r.Next(0, 255));
        }
        private void nav(Page p)
        {
            Navigation.PushAsync(p);
        }

        public void Handle_NextPage(object sender, EventArgs e)
        {
            nav(new Page1());
        }

        public void Handle_Carousel(object sender, EventArgs e)
        {
            nav(new CarouselPageExample());
        }

        public void Handle_NoteMultipage(object sender, EventArgs e)
        {
            nav(new NotesMultipage());
        }

        public void Handle_Layouts(object sender, EventArgs e)
        {
            nav(new Layouts.Addresses());
        }
        public void Handle_Addresses(object sender, EventArgs e)
        {
            nav(new Addresses.AddressesList());
        }
        public void Handle_Maps(object sender, EventArgs e)
        {
            //nav();
        }
    }
}
