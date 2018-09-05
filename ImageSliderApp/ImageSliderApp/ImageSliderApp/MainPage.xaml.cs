using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ImageSliderApp
{ 
	public partial class MainPage : ContentPage
	{
        private int _id = 1;

        public MainPage()
        {
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage()
        {
            image.Source = new UriImageSource
            {
                Uri = new Uri($"http://lorempixel.com/1920/1080/city/{_id}"),
                CachingEnabled = false
            };
        }

        private void Button_Clicked_Left(object sender, EventArgs e)
        {
            _id--;
            if (_id < 1)
                _id = 10;

            LoadImage();
        }

        private void Button_Clicked_Right(object sender, EventArgs e)
        {
            _id++;
            if (_id > 10)
                _id = 1;

            LoadImage();
        }
    }
}
