using ContactListApp.Models;
using ContactListApp.Services;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ContactListApp
{
    public partial class MainPage : ContentPage
	{
        private SearchService _searchService;
        private List<SearchGroup> _searchGroups;

        public MainPage()
        {
            _searchService = new SearchService();

            InitializeComponent();

            PopulateListView(_searchService.GetRecentSearches());
        }

        private void PopulateListView(IEnumerable<Search> searches)
        {
            _searchGroups = new List<SearchGroup>
            {
                new SearchGroup("Recent Searches", searches)
            };

            listView.ItemsSource = _searchGroups;
        }

        private void OnSearchTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            PopulateListView(_searchService.GetRecentSearches(e.NewTextValue));
        }

        private void OnDeleteClicked(object sender, System.EventArgs e)
        {
            var search = (sender as MenuItem).CommandParameter as Search;
            _searchGroups[0].Remove(search);
            _searchService.DeleteSearch(search.Id);
        }

        private void OnRefreshing(object sender, System.EventArgs e)
        {
            PopulateListView(_searchService.GetRecentSearches(searchBar.Text));

            listView.EndRefresh();
        }

        private void OnSearchSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Selected", search.Location, "OK");
        }
    }
}
