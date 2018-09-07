using InstagramApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyProfilePage : ContentPage
	{
        private UserService _userService; 
		public MyProfilePage (int id)
		{
            _userService = new UserService();

            BindingContext = _userService.GetUser(id);

            InitializeComponent ();

            
		}
	}
}