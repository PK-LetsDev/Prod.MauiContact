using Android.Views;
using Prod.HelloWorld.Models;
using Contact = Prod.HelloWorld.Models.Contact;

namespace Prod.HelloWorld.Views;

[QueryProperty(nameof(Id),"Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

    public string Id
    {
        set
        {
            contact = ContactRepository.GetContactsById(int.Parse(value));
            if (contact != null)
            {
                contactCtrl.Name = contact.Name;
                contactCtrl.Email = contact.Email;
                contactCtrl.Phone = contact.Phone;
                contactCtrl.Address = contact.Address;
            }
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        contact.Name = contactCtrl.Name;
        contact.Email = contactCtrl.Email;
        contact.Phone = contactCtrl.Phone;
        contact.Address = contactCtrl.Address;
        ContactRepository.UpdateContact(contact.Id,contact);
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}