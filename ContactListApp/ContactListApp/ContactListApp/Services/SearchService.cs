using ContactListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactListApp.Services
{
    public class SearchService
    {
        private  List<Search> _searches = new List<Search>
        {
            new Search{
                Id = 1,
                Location = "West Hollywood, CA, United States",
                CheckIn = new DateTime(2018, 03, 16),
                CheckOut = new DateTime(2018, 04, 16)
            },
            new Search{
                Id = 2,
                Location = "Santa Monica, CA, United States",
                CheckIn = new DateTime(2017, 03, 16),
                CheckOut = new DateTime(2017, 04, 16)
            },
            new Search{
                Id = 3,
                Location = "Luxia, CMR, Cameroon",
                CheckIn = new DateTime(2016, 03, 16),
                CheckOut = new DateTime(2016, 04, 16)
            },

        };

        public IEnumerable<Search> GetRecentSearches(string filter = null)
        {
            if (String.IsNullOrWhiteSpace(filter))
                return _searches;

            return _searches.Where(s => s.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }

        public void DeleteSearch(int searchId)
        {
            _searches.Remove(_searches.Single(s => s.Id == searchId));
        }

    }
}
