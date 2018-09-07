using ContactBook.Models;
using ContactBook.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactBook
{
	public partial class MainPage : ContentPage
	{
        private ContactService _contactService = new ContactService();
		public MainPage()
		{
			InitializeComponent();

            contactList.ItemsSource = _contactService.GetContacts();
		}

        private async void OnAddedContact(object sender, EventArgs e)
        {
            var page = new ContactDetailPage(new Contact());

            page.ContactAdded += (source, contact) =>
            {
                _contactService.AddContact(contact);
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
                _contactService.DeleteContact(contact);
                
        }
    }
}
