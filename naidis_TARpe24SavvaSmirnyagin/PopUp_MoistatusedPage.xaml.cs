
namespace naidis_TARpe24SavvaSmirnyagin;

public partial class PopUp_MoistatusedPage : ContentPage
{
	Label pealkiri;
    VerticalStackLayout vsl;
    Label nimelabel;
    string nimi;
    string valik;
    Button esimene;
    Label esimenelabel;
	public PopUp_MoistatusedPage()
	{

        pealkiri = new Label
		{
			Text = "Mıistatuste leht. \nVasta mıistatustele all!",
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

        Button nulliNupp = new Button
        {
            Text = "Nulli seaded (Testimiseks)",
            BackgroundColor = Colors.Red,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 50,
            Margin = new Thickness(0, 30, 0, 0)
        };

        Button algusnupp = new Button
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
            Text = "Esimene mıistatus",
            BackgroundColor = Colors.Black,
            TextColor = Colors.White,
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center,
            IsVisible = false
        };
        esimene.Clicked += Esimene_Clicked;


        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = 
            { 
                pealkiri, algusnupp, nimelabel, esimene, esimenelabel 
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
        }
        else
        {
            nimelabel.Text = "Alustuseks sisesta oma nimi!";
        }
    }

    private async void Esimene_Clicked(object? sender, EventArgs e)
    {
        valik = await DisplayActionSheet("’ues m‰ena, toas veena?", "Loobu", null, "Lumi", "J‰‰", "Vesi");

        if (valik != null && valik != "Loobu" && valik == "Lumi")
        {
            await DisplayAlertAsync("Vastus", "Valisid ıige vastuse!", "OK");
            esimene.IsEnabled = false;
            esimenelabel.Text = "’ige!";
        }
        else if (valik != null && valik != "Loobu" && valik != "Lumi")
        {
            await DisplayAlertAsync("Vastus", "Valisid vale vastuse!", "OK");
            esimene.IsEnabled = false;
            esimenelabel.Text = "Vale!";
        }
    }
}