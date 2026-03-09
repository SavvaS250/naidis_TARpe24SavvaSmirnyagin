
namespace naidis_TARpe24SavvaSmirnyagin;

public partial class PopUp_MoistatusedPage : ContentPage
{
	Label pealkiri;
    VerticalStackLayout vsl;
    Label nimelabel;
    string nimi;
    string valik;
    Button algusnupp;
    Button esimene;
    Button teine;
    Button kolmas;
    Button neljas;
    Button loppbutton;
    Label esimenelabel;
    Label teinelabel;
    Label kolmaslabel;
    Label neljaslabel;
    int count;
	public PopUp_MoistatusedPage()
	{

        pealkiri = new Label
		{
			Text = "Mõistatuste leht. \nVasta mõistatustele all!",
			FontSize = 28,
			FontFamily = "Times new roman",
			TextColor = Colors.Black,
			HorizontalOptions = LayoutOptions.Center,
            FontAttributes = FontAttributes.Bold
        };

        nimelabel = new Label
        {
            Text = "",
            FontSize = 16,
            FontFamily = "Times new roman",
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center
        };

        esimenelabel = new Label
        {
            Text = "",
            FontSize = 16,
            FontFamily = "Times new roman",
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center
        };

        teinelabel = new Label
        {
            Text = "",
            FontSize = 16,
            FontFamily = "Times new roman",
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center
        };

        kolmaslabel = new Label
        {
            Text = "",
            FontSize = 16,
            FontFamily = "Times new roman",
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center
        };

        neljaslabel = new Label
        {
            Text = "",
            FontSize = 16,
            FontFamily = "Times new roman",
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center
        };


        Button nulliNupp = new Button
        {
            Text = "Nulli seaded (Testimiseks)",
            BackgroundColor = Colors.Red,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 50,
            Margin = new Thickness(0, 30, 0, 0)
        };

        algusnupp = new Button
        {
            Text = "Alustuseks",
            BackgroundColor = Colors.Black,
            TextColor = Colors.White,
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };
        algusnupp.Clicked += AlgusNupp_Cliked;

        esimene = new Button
        {
            Text = "Esimene mõistatus",
            BackgroundColor = Colors.Black,
            TextColor = Colors.White,
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center,
            IsVisible = false
        };
        esimene.Clicked += Esimene_Clicked;

        teine = new Button
        {
            Text = "Teine mõistatus",
            BackgroundColor = Colors.Black,
            TextColor = Colors.White,
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center,
            IsVisible = false
        };
        teine.Clicked += Teine_Clicked;

        kolmas = new Button
        {
            Text = "Kolmas mõistatus",
            BackgroundColor = Colors.Black,
            TextColor = Colors.White,
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center,
            IsVisible = false
        };
        kolmas.Clicked += Kolmas_Clicked;

        neljas = new Button
        {
            Text = "Neljas mõistatus",
            BackgroundColor = Colors.Black,
            TextColor = Colors.White,
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center,
            IsVisible = false
        };
        neljas.Clicked += Neljas_Clicked;

        loppbutton = new Button
        {
            Text = "Lõpetuseks",
            BackgroundColor = Colors.Black,
            TextColor = Colors.White,
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center,
            IsVisible = false
        };
        loppbutton.Clicked += Lopp_Clicked;


        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = 
            { 
                pealkiri, algusnupp, nimelabel, esimene, esimenelabel, teine, teinelabel, kolmas, kolmaslabel, neljas, neljaslabel, loppbutton 
            },
            HorizontalOptions = LayoutOptions.Center
        };
        Content = vsl;
    }

    private async void AlgusNupp_Cliked(object? sender, EventArgs e)
    {
        nimi = await DisplayPromptAsync("Tere!", "Mis on sinu nimi?");

        if (!string.IsNullOrWhiteSpace(nimi))
        {
            nimelabel.Text = $"Tere, {nimi}!";
            esimene.IsVisible = true;
            algusnupp.IsEnabled = false;
        }
        else
        {
            nimelabel.Text = "Alustuseks sisesta oma nimi!";
        }
    }

    private async void Esimene_Clicked(object? sender, EventArgs e)
    {
        valik = await DisplayActionSheet("Õues mäena, toas veena?", "Loobu", null, "Lumi", "Jää", "Vesi");

        if (valik != null && valik != "Loobu" && valik == "Lumi")
        {
            await DisplayAlertAsync("Kontroll", "Valisid õige vastuse!", "OK");
            esimene.IsEnabled = false;
            esimenelabel.Text = "Õige!";
            teine.IsVisible = true;
            count++;
        }
        else if (valik != null && valik != "Loobu" && valik != "Lumi")
        {
            await DisplayAlertAsync("Kontroll", "Valisid vale vastuse!", "OK");
            esimene.IsEnabled = false;
            esimenelabel.Text = "Vale!";
            teine.IsVisible = true;
        }
    }

    private async void Teine_Clicked(object? sender, EventArgs e)
    {
        valik = await DisplayActionSheet("Hommikul sünnib, õhtul sureb.", "Loobu", null, "Inimene", "Päike", "Lumi");

        if (valik != null && valik != "Loobu" && valik == "Päike")
        {
            await DisplayAlertAsync("Kontroll", "Valisid õige vastuse!", "OK");
            teine.IsEnabled = false;
            teinelabel.Text = "Õige!";
            kolmas.IsVisible = true;
            count++;
        }
        else if (valik != null && valik != "Loobu" && valik != "Päike")
        {
            await DisplayAlertAsync("Kontroll", "Valisid vale vastuse!", "OK");
            teine.IsEnabled = false;
            teinelabel.Text = "Vale!";
            kolmas.IsVisible = true;
        }
    }

    private async void Kolmas_Clicked(object? sender, EventArgs e)
    {
        valik = await DisplayActionSheet("Ilma jaluta käib, ilma tiivuta lendab.", "Loobu", null, "Lind", "Pilv", "Lennuk");

        if (valik != null && valik != "Loobu" && valik == "Pilv")
        {
            await DisplayAlertAsync("Kontroll", "Valisid õige vastuse!", "OK");
            kolmas.IsEnabled = false;
            kolmaslabel.Text = "Õige!";
            neljas.IsVisible = true;
            count++;
        }
        else if (valik != null && valik != "Loobu" && valik != "Pilv")
        {
            await DisplayAlertAsync("Kontroll", "Valisid vale vastuse!", "OK");
            kolmas.IsEnabled = false;
            kolmaslabel.Text = "Vale!";
            neljas.IsVisible = true;
        }
    }

    private async void Neljas_Clicked(object? sender, EventArgs e)
    {
        valik = await DisplayPromptAsync("Neljas mõistatus", "Ei ole toas ega õues?");

        if (valik != null && valik != "Loobu" && valik == "aken" || valik == "Aken")
        {
            await DisplayAlertAsync("Kontroll", "Valisid õige vastuse!", "OK");
            neljas.IsEnabled = false;
            neljaslabel.Text = "Õige!";
            count++;
            loppbutton.IsVisible = true;
        }
        else if (valik != null && valik != "Loobu" && valik != "Pilv")
        {
            await DisplayAlertAsync("Kontroll", "Valisid vale vastuse!", "OK");
            neljas.IsEnabled = false;
            neljaslabel.Text = "Vale!";
            loppbutton.IsVisible = true;
        }
    }

    private async void Lopp_Clicked(object? sender, EventArgs e)
    {
        await DisplayAlertAsync("Tulemused", $"Vastasid {count}/4 mõistatusele õigesti!", "OK");
    }
}