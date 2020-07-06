using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestSkiaSharp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            Console.WriteLine("Constructing AboutPage");
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Console.WriteLine("AboutPage Appearing");

            base.OnAppearing();
        }
    }
}