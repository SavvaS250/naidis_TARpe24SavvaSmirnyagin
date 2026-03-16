using Microsoft.Maui.Controls.Shapes;

namespace naidis_TARpe24SavvaSmirnyagin;

public partial class TripsTrapsTrull : ContentPage
{
    Grid gr4x1, gr3x3;
    Random rnd = new Random();
    Button sinine;
    Button roheline;
    Button uuesti;
    Label label;
    string player = "Roheline";
    public TripsTrapsTrull()
	{
        gr4x1 = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                new RowDefinition { Height = new GridLength(3, GridUnitType.Star)},
                new RowDefinition { Height = new GridLength(3, GridUnitType.Star)},
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
            },
        };

        label = new Label
        {
            Text = ""
        };


        uuesti = new Button
        {
            Text = "Alusta uuesti",
            BackgroundColor = Colors.Red
        };
        uuesti.Clicked += Uuesti_Clicked;
   
        
        gr3x3 = Taida_gr3x3();

        gr4x1.Add(gr3x3, 0, 2);
        gr4x1.SetColumnSpan(gr3x3, 2);
        gr4x1.Add(label, 1, 3);
        gr4x1.Add(uuesti, 0, 1);
        Content = gr4x1;
    }

    private void Uuesti_Clicked(object? sender, EventArgs e)
    {
        foreach (var child in gr3x3.Children)
        {
            if (child is Border border && border.Content is BoxView kast)
            {
                kast.BackgroundColor = Colors.White;
            }
        }

        label.Text = "";
    }


    private Grid Taida_gr3x3()
    {
        gr3x3 = new Grid();

        for (int i = 0; i < 3; i++)
        {
            gr3x3.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gr3x3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }

        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                BoxView kast = new BoxView
                {
                    BackgroundColor = Colors.White
                };
                Border border = new Border
                {
                    Stroke = Colors.Black,
                    StrokeThickness = 2,
                    Content = kast
                };
                gr3x3.Add(border, c, r);
                int rida = r;
                int veerg = c;
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += (s, args) =>
                {
                    if (kast.BackgroundColor == Colors.White)
                    {
                        if (player == "Roheline")
                        {
                            kast.BackgroundColor = Colors.Green;
                            player = "Sinine";
                            label.Text = "Sinise kord";
                        }
                        else if (player == "Sinine")
                        {
                            kast.BackgroundColor = Colors.Blue;
                            player = "Roheline";
                            label.Text = "Rohelise kord";
                        }
                    }
                    

                };
                kast.GestureRecognizers.Add(tap);
            }
        }
        return gr3x3;
    }
}