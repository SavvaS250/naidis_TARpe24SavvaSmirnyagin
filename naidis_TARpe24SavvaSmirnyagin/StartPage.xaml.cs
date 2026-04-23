using Microsoft.Maui.Storage;
namespace naidis_TARpe24SavvaSmirnyagin;

public partial class StartPage : ContentPage
{
    VerticalStackLayout vst;
    ScrollView sv;
    public List<ContentPage> Lehed = new List<ContentPage>() { new TextPage(), new FigurePage(), new ValgusFoor(), new DateTime_Page()
        , new StepperSliderPage(), new RgbSlider(), new LumememmPage(), new Pop_Up_Page(), new PopUp_MoistatusedPage(), new PickerImageGrid()
        , new TripsTrapsTrull(), new Table_Page(), new List_Page(), new Euroopa_Page()};
    public List<string> LeheNimed = new List<string>() { "Tekst", "Kujund", "Valgusfoor", "DateTime", "Slider/Stepper", "Rgb slider", "Lumememm", "Pop up",
          "Mõistatuste leht", "Picker image grid", "Trips-Traps-Trull", "Table page", "List page", "Euroopa riikide rakendus"};
    public StartPage()
    {
        //Title = "Avaleht";
        vst = new VerticalStackLayout { Padding = 20, Spacing = 15 };
        for (int i = 0; i < Lehed.Count; i++)
        {
            Button nupp = new Button
            {
                Text = LeheNimed[i],
                FontSize = 30,
                FontFamily = "Times new roman",
                BackgroundColor = Colors.LightGray,
                TextColor = Colors.Black,
                CornerRadius = 10,
                HeightRequest = 60,
                ZIndex = i
            };
            vst.Add(nupp);
            nupp.Clicked += (sender, e) =>
            {
                var valik = Lehed[nupp.ZIndex];
                Navigation.PushAsync(valik);
            };

            
        }
        Button nulliNupp = new Button
        {
            Text = "Nulli seaded (Testimiseks)",
            BackgroundColor = Colors.Red,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 50,
            Margin = new Thickness(0, 30, 0, 0)
        };

        nulliNupp.Clicked += async (sender, e) =>
        {
            Preferences.Default.Remove("EsimeneKäivitamine");

            await DisplayAlertAsync("Edukalt nullitud", "Mälu on tühjendatud.", "OK");
        };
        vst.Add(nulliNupp);
        sv = new ScrollView { Content = vst };
        Content = sv;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        bool onEsimeneStart = Preferences.Default.Get("EsimeneKäivitamine", true);

        if (onEsimeneStart)
        {
            bool vastus = await DisplayAlertAsync("Tere tulemast!", "Tundub, et avasid selle rakenduse esimest korda. Kas soovid näha juhendid?",
                "Jah, palun", "Ei, saan ise hakkama");

            if (vastus)
            {
                await DisplayAlertAsync("Juhend", "Siin on sinu lühike juhend: vali menüüst sobiv teema ja uuri, kuidas elemendid töötavad!", "Selge");
            }

            Preferences.Default.Set("EsimeneKäivitamine", false);
        }
    }
}