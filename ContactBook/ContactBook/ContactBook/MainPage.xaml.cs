using ContactBook.Models;
using ContactBook.Services;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactBook
{
    public partial class MainPage : ContentPage
	{
        private ContactService _contactService = new ContactService();
        private ObservableCollection<Contact> _ObservableContacts; 
        private SQLiteAsyncConnection _db;
        private bool _isDataLoaded = false;

		public MainPage()
		{
			InitializeComponent();
            CreateDatabase();
		}

        private void CreateDatabase()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyContacts.db");
            _db = new SQLiteAsyncConnection(databasePath);   
        }
        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            await LoadData();
            base.OnAppearing(); 
        }

        private async Task LoadData()
        {
            await _db.CreateTableAsync<Contact>();
            var contacts = await _db.Table<Contact>().ToListAsync();
            _ObservableContacts = new ObservableCollection<Contact>(contacts);
            contactList.ItemsSource = _ObservableContacts;
        }
        private async void OnAddedContact(object sender, EventArgs e)
        {
            var page = new ContactDetailPage(new Contact());

            page.ContactAdded += (source, contact) =>
            {
                _ObservableContacts.Add(contact);
            };

            await Navigation.PushAsync(page);
        }

        private async void OnSelectedContact(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;
   
            contactList.SelectedItem = null;

            var page = new ContactDetailPage(selectedContact);

            page.ContactUpdated += (source, contact) =>
            {
                selectedContact.Id = contact.Id;
                selectedContact.FirstName = contact.FirstName;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.IsBlocked = contact.IsBlocked;
            };

            await Navigation.PushAsync(page);
        }

        private async void OnDeleteContact(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.Name}", "Yes", "No"))
            {
                _ObservableContacts.Remove(contact);
                await _db.DeleteAsync(contact);
            }
                
                
        }
    }
}
