using ContactBook.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailPage : ContentPage
	{
        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;
        private SQLiteAsyncConnection _db; 
		public ContactDetailPage (Contact contact)
		{
            if (contact == null)
                throw new ArgumentNullException(nameof(Contact));

			InitializeComponent ();

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyContacts.db");
            _db = new SQLiteAsyncConnection(databasePath);

            BindingContext = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked
            };
		}

        private async void OnSaved(object sender, EventArgs e)
        {
            var contact = BindingContext as Contact;

            if (String.IsNullOrWhiteSpace(contact.Name))
            {
                await DisplayAlert("Error", "Please enter the name", "Ok");
                return; 
            }

            if (contact.Id == 0)
            {
                await _db.InsertAsync(contact);
                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                await _db.UpdateAsync(contact);
                ContactUpdated?.Invoke(this, contact);
            }
            
            await Navigation.PopAsync();
        }
    }
}