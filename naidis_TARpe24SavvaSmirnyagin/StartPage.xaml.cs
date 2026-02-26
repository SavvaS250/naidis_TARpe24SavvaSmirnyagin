namespace naidis_TARpe24SavvaSmirnyagin;

public partial class StartPage : ContentPage
{
    VerticalStackLayout vst;
    ScrollView sv;
    public List<ContentPage> Lehed = new List<ContentPage>() { new TextPage(), new FigurePage(), new ValgusFoor(), new DateTime_Page()
        , new StepperSliderPage(), new RgbSlider(), new LumememmPage() };
    public List<string> LeheNimed = new List<string>() { "Tekst", "Kujund", "Valgusfoor", "DateTime", "Slider/Stepper", "Rgb slider", "Lumememm" };
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
        sv = new ScrollView { Content = vst };
        Content = sv;
    }
}