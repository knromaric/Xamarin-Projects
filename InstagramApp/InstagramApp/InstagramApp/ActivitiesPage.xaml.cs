using InstagramApp.Models;
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
	public partial class ActivitiesPage : ContentPage
	{
        private ActivityService _activityService;
        public ActivitiesPage ()
		{
            _activityService = new ActivityService();

            InitializeComponent();

            listActivities.ItemsSource = _activityService.GetActivities();
        }

        private void OnActivitySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var activity = e.SelectedItem as Activity;
            listActivities.SelectedItem = null;
            Navigation.PushAsync(new MyProfilePage(activity.UserId));   

        }
    }
}