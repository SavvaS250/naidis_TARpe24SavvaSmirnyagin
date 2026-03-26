namespace naidis_TARpe24SavvaSmirnyagin;

public partial class Table_Page : ContentPage
{
    TableView tableview;
    SwitchCell sc;
    ImageCell ic;
    TableSection fotosection;
    EntryCell phone1;
    EntryCell email1;
    Button saadasms;
    Button saadaemail;
    public Table_Page()
    {
        sc = new SwitchCell { Text = "Näita veel" };
        sc.OnChanged += Sc_OnChanged;

        ic = new ImageCell
        {
            ImageSource = ImageSource.FromFile("dotnet_bot.png"),
            Text = "Foto nimetus",
            Detail = "Foto kirjeldus"
        };

        phone1 = new EntryCell
        {
            Label = "Telefon",
            Placeholder = "Kirjuta oma telefon",
            Keyboard = Keyboard.Telephone
        };

        saadasms = new Button
        {
            Text = "Saada SMS"
        };

        saadaemail = new Button
        {
            Text = "Saada Emaili sõnum"
        };

        email1 = new EntryCell
        {
            Label = "Email",
            Placeholder = "Sisesta email",
            Keyboard = Keyboard.Email
        };

        fotosection = new TableSection();

        var contactSection = new TableSection("Kontaktandmed:")
        {
            new EntryCell
            {
                Label = "Nimi",
                Placeholder = "Sisesta nimi",
                Keyboard = Keyboard.Text
            },
            new EntryCell
            {
                Label = "Telefon",
                Placeholder = "Sisesta tel. number",
                Keyboard = Keyboard.Telephone
            },
            email1,
            //new ImageCell
            //{
            //    ImageSource = ImageSource.FromFile("dotnet_bot.png"),
            //    Text = "Foto nimetus",
            //    Detail = "Foto kirjeldus"
            //},
            new EntryCell
            {
                Label = "Kirjeldus",
                Placeholder = "Sisesta kirjeldus",
                Keyboard = Keyboard.Text
            },
            phone1
        };
        string email = email1.Text;
        saadasms.Clicked += Saada_sms_Clicked;
        saadaemail.Clicked += Saada_email_Clicked;

        tableview = new TableView
        {
            Intent = TableIntent.Form,
            Root = new TableRoot
            {
                contactSection,
                fotosection
            }
        };

        //Content = tableview;

        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Padding = new Thickness(0, 50, 0, 0),
            Children = {    tableview, saadasms, saadaemail }
        };
    }

    private void Sc_OnChanged(object? sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            fotosection.Title = "Foto:";
            if (!fotosection.Contains(ic))
                fotosection.Add(ic);

            sc.Text = "Peida";
        }
        else
        {
            fotosection.Remove(ic);
            fotosection.Title = "";
            sc.Text = "Näita veel";
        }
    }

    private async void Saada_sms_Clicked(object? sender, EventArgs e)
    {
        string phone = phone1.Text;

        if (string.IsNullOrWhiteSpace(phone))
        {
            await DisplayAlert("Viga", "Sisesta telefoninumber", "OK");
            return;
        }

        if (!phone.StartsWith("+"))
        {
            phone = "+372" + phone;
        }

        var message = "Tere tulemast! Saadan sõnumi";
        SmsMessage sms = new SmsMessage(message, phone);

        try
        {
            if (Sms.Default.IsComposeSupported)
            {
                await Sms.Default.ComposeAsync(sms);
            }
            else
            {
                await DisplayAlert("Viga", "SMS ei ole toetatud", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Viga", ex.Message, "OK");
        }
    }

    private async void Saada_email_Clicked(object? sender, EventArgs e)
    {
        string email = email1.Text;

        // Check if empty
        if (string.IsNullOrWhiteSpace(email))
        {
            await DisplayAlert("Viga", "Sisesta email", "OK");
            return;
        }

        var message = new EmailMessage
        {
            Subject = "Tervitus",
            Body = "Tere tulemast! Saadan emaili.",
            BodyFormat = EmailBodyFormat.PlainText,
            To = new List<string> { email }
        };

        try
        {
            if (Email.Default.IsComposeSupported)
            {
                await Email.Default.ComposeAsync(message);
            }
            else
            {
                await DisplayAlert("Viga", "Email ei ole toetatud selles seadmes", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Viga", ex.Message, "OK");
        }
    }

}