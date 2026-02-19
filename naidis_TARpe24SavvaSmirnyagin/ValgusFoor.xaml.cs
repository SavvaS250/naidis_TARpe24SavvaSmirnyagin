using Microsoft.Maui.Controls.Shapes;

namespace naidis_TARpe24SavvaSmirnyagin;

public partial class ValgusFoor : ContentPage
{
    BoxView boxView;
    Ellipse pall1;
    Ellipse pall2;
    Ellipse pall3;
    Label label;
    HorizontalStackLayout hsl;
    HorizontalStackLayout hsl2;
    List<string> nupud = new List<string>() { "Tagasi", "Avaleht", "Edasi" };
    List<string> nupud2 = new List<string>() { "Sisse/Välja" };
    VerticalStackLayout vsl;
    bool isOn = false;
    public ValgusFoor()
	{
        TapGestureRecognizer tap = new TapGestureRecognizer();
        label = new Label
        {
            Text = "Valgusfoor",
            FontSize = 24,
            FontFamily = "Times new roman",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center

        };

        pall1 = new Ellipse
        {

            WidthRequest = 200,
            HeightRequest = 200,
            Stroke = Colors.Black,//äärise värv
            Fill = new SolidColorBrush(Colors.Gray),
            StrokeThickness = 5, //äärise paksus
            HorizontalOptions = LayoutOptions.Center
        };

        pall2 = new Ellipse
        {

            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Colors.Gray),//kujundi värv brush'i abil
            Stroke = Colors.Black,//äärise värv
            StrokeThickness = 5, //äärise paksus
            HorizontalOptions = LayoutOptions.Center
        };

        pall3 = new Ellipse
        {

            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Colors.Gray),//kujundi värv brush'i abil
            Stroke = Colors.Black,//äärise värv
            StrokeThickness = 5, //äärise paksus
            HorizontalOptions = LayoutOptions.Center
        };

        tap.Tapped += (sender, e) => {
            Ellipse vajutatudpall = (Ellipse)sender;
            Naita_Tekst(vajutatudpall);
        };
        pall1.GestureRecognizers.Add(tap);
        pall2.GestureRecognizers.Add(tap);
        pall3.GestureRecognizers.Add(tap);

        hsl2 = new HorizontalStackLayout { Spacing = 20, HorizontalOptions = LayoutOptions.Center };
        Button sisse = new Button
        {
            Text = "Sisse",
            FontFamily = "Times new roman",
            FontSize = 32,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        sisse.Clicked += Sisse_Clicked;

        Button valja = new Button
        {
            Text = "Välja",
            FontFamily = "Times new roman",
            FontSize = 32,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };
        valja.Clicked += Valja_Clicked;
        hsl2.Add(sisse);
        hsl2.Add(valja);

        Content = vsl;



        hsl = new HorizontalStackLayout { Spacing = 20, HorizontalOptions = LayoutOptions.Center };


        for (int j = 0; j < nupud.Count; j++)
        {
            Button nupp = new Button
            {
                Text = nupud[j],
                FontSize = 20,
                FontFamily = "Times new roman",
                TextColor = Colors.Black,
                BackgroundColor = Colors.White,
                CornerRadius = 10,
                HeightRequest = 50,
                ZIndex = j
            };
            hsl.Add(nupp);
            nupp.Clicked += Liikumine;
        }
        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = { label, boxView, pall1, pall2, pall3, hsl2 },
            HorizontalOptions = LayoutOptions.Center
        };
        Content = vsl;
    }

    private void Valja_Clicked(object? sender, EventArgs e)
    {
        isOn = false;

        pall1.Fill = Colors.Gray;
        pall2.Fill = Colors.Gray;
        pall3.Fill = Colors.Gray;
        label.Text = "Valgusfoor on välja lülitatud";
    }

    private void Sisse_Clicked(object? sender, EventArgs e)
    {
        isOn = true;
        pall1.Fill = Colors.Red;
        pall2.Fill = Colors.Yellow;
        pall3.Fill = Colors.Green;
        label.Text = "Valgusfoor on sisse lülitatud";
    }
    public void Naita_Tekst(Ellipse vajutatudpall)
    {
        if (!isOn)
        {
            label.Text = "Valgusfoor on vaja sisse panna";
            return;
        }


        if (vajutatudpall == pall1)
        {
            label.Text = "Seisa!";
        }
        else if (vajutatudpall == pall2)
        {
            label.Text = "Valmistu!";
        }
        else if (vajutatudpall == pall3)
        {
            label.Text = "Sõida!";
        }
    }

    private void Liikumine(object? sender, EventArgs e)
    {
        Button nupp = sender as Button;
        if (nupp.ZIndex == 0)
        {
            Navigation.PushAsync(new TextPage());
        }
        else if (nupp.ZIndex == 1)
        {
            Navigation.PopToRootAsync();
        }
        else if (nupp.ZIndex == 2)
        {
            Navigation.PushAsync(new FigurePage());//siia lisame uue lehe, et saaks edasi liikuda
        }
        else if (nupp.ZIndex == 3)
        {
            Navigation.PushAsync(new ValgusFoor());//siia lisame uue lehe, et saaks edasi liikuda
        }
    }
}
