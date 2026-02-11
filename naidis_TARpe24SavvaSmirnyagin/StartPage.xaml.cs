namespace naidis_TARpe24SavvaSmirnyagin;

public partial class StartPage : ContentPage
{
    public List<ContentPage> lehed = new List<ContentPage>() { new TextPage(), new FigurePage() };
    public List<string> leheNimed = new List<string>() { "Tekst", "Kujund"};

    ScrollView sv;
    VerticalStackLayout vst;
	public StartPage()
    {
        //InitializeComponent();
        Title = "Avaleht";
        vst = new VerticalStackLayout { Padding = 20, Spacing = 15 };
        for (int i = 0; i < lehed.Count; i++)
        {
            Button nupp = new Button
            {
                Text = leheNimed[i],
                FontSize = 36,
                FontFamily = "Luffio",
                BackgroundColor = Colors.LightGray,
                TextColor = Colors.Black,
                CornerRadius = 10,
                HeightRequest = 60,
                ZIndex = i
            };
            vst.Add(nupp);
            nupp.Clicked += (sender, e) =>
            {
                var valik = lehed[nupp.ZIndex];
                Navigation.PushAsync(valik);
            };
        }
        sv = new ScrollView { Content = vst };
        Content = sv;
    }
}