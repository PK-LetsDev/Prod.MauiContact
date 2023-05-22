namespace Prod.HelloWorld.Views.Controls;

public partial class ContactControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> Onsave; 
    public event EventHandler<EventArgs> Oncancel; 
	public ContactControl()
	{
		InitializeComponent();
	}

    public string Name
    {
        get
        {
            return entryName.Text;
        }
        set
        {
            entryName.Text = value;
        }
    }

    public string Email
    {
        get
        {
            return entryEmail.Text;
        }
        set
        {
            entryEmail.Text = value;
        }
    }

    public string Phone
    {
        get
        {
            return entryPhone.Text;
        }
        set
        {
            entryPhone.Text = value;
        }
    }

    public string Address
    {
        get
        {
            return entryAddress.Text;
        }
        set
        {
            entryAddress.Text = value;
        }
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender,"Name is required.");
            return;
        }

        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
                OnError?.Invoke(sender, error.ToString());
            }
            return;

        }
        Onsave?.Invoke(sender,e);

    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Oncancel?.Invoke(sender,e);
    }
}