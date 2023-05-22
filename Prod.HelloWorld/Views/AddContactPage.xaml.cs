using Prod.HelloWorld.Models;

namespace Prod.HelloWorld.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtrl_Onsave(object sender, EventArgs e)
    {
        ContactRepository.AddContact(new Models.Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Phone = contactCtrl.Phone,
            Address = contactCtrl.Address
        });

        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}