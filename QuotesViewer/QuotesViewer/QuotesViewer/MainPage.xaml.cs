using System;
using Xamarin.Forms;

namespace QuotesViewer
{
    public partial class MainPage : ContentPage
	{
        private string[] _quotes = new string[]
           {
                "To be or not to be.",
                "Touch the point between Art and Science, and experience the real beauty", 
                "be positive.",
                "Life is like riding a bicycle. To keep your balance, you must keep moving.",
                "You can't blame gravity for falling in love.",
                "Look deep into nature, and then you will understand everything better."
           };

        private int _index = 0;

        public MainPage()
		{
			InitializeComponent();
            currentQuotes.Text = _quotes[_index];
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            _index++;
            _index = _index % _quotes.Length;
            currentQuotes.Text = _quotes[_index];
        }
    }
}
