using Microsoft.Maui.Controls.Shapes;

namespace naidis_TARpe24SavvaSmirnyagin;

public partial class TripsTrapsTrull : ContentPage
{
    Grid gr4x1, gr3x3;
    Random rnd = new Random();
    Button sinine;
    Button roheline;
    Button uuesti;
    Button playerValik;
    Label label;
    string player = "";
    string voitja1 = "";
    string[,] ruut = new string[3, 3];
    int kaik = 0;
    public TripsTrapsTrull()
	{
        gr4x1 = new Grid
        {
            RowDefinitions =
            {
                 new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}, 
                 new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}, 
                 new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
            },
        };

        label = new Label
        {
            Text = "Alustuseks vali kes alustab!",
            FontSize = 28,
            FontFamily = "Times new roman",
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center
        };

        uuesti = new Button
        {
            Text = "Alusta uuesti",
            BackgroundColor = Colors.Red,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        uuesti.Clicked += Uuesti_Clicked;

        playerValik = new Button
        {
            Text = "Vali kes alustab",
            BackgroundColor = Colors.Black,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        playerValik.Clicked += PlayerValik_Clicked;

        HorizontalStackLayout nupud = new HorizontalStackLayout
        {
            Spacing = 10,
            Children = { uuesti, playerValik }
        };
        gr3x3 = Taida_gr3x3();
        gr3x3.WidthRequest = 350;
        gr3x3.HorizontalOptions = LayoutOptions.Center;
        gr3x3.Margin = new Thickness(210, 0, 0, 0);


        gr4x1.Add(uuesti, 0, 0);   
        gr4x1.Add(playerValik, 1, 0);   
        gr4x1.Add(gr3x3, 0, 1);  
        gr4x1.Add(label, 0, 2);   
        Content = gr4x1;
    }

    private void PlayerValik_Clicked(object? sender, EventArgs e)
    {
        int playerNum = rnd.Next(2);

        if (playerNum == 0)
        {
            player = "Roheline";
        }
        else
        {
            player = "Sinine";
        }

        label.Text = $"{player} alustab";

        playerValik.IsEnabled = false;
        playerValik.IsVisible = false;
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
        ruut = new string[3, 3];
        label.Text = "Vali kes alustab!";
        gr3x3.IsEnabled = true;
        kaik = 0;
        player = "";
        playerValik.IsEnabled = true;
        playerValik.IsVisible = true;
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
                tap.Tapped += async (s, args) =>
                {
                    
                    if (kast.BackgroundColor == Colors.White)
                    {
                        if (player == "Roheline")
                        {
                            kast.BackgroundColor = Colors.Green;
                            ruut[rida, veerg] = "R";
                            label.Text = "Sinise kord";
                            player = "Sinine";
                            voitja1 = "Roheline";
                            kaik++;
                        }
                        else if (player == "Sinine")
                        {
                            kast.BackgroundColor = Colors.Blue;
                            ruut[rida, veerg] = "S";
                            player = "Roheline";
                            label.Text = "Rohelise kord";
                            voitja1 = "Sinine";
                            kaik++;
                        }
                    }
                    string voitja = VıiduKontroll();

                    if (voitja != null)
                    {
                        await DisplayAlertAsync("Vıitja", $"{voitja1} on vıitja!", "OK");
                        gr3x3.IsEnabled = false;
                        kaik = 0;
                        label.Text = "Vajuta nuppu ¥Alusta uuesti¥!";
                    }
                   
                    if (kaik == 9)
                    {
                        await DisplayAlertAsync("Viik", $"M‰ng on j‰‰nud viiki!", "OK");
                        kaik = 0;
                        label.Text = "Vajuta nuppu ¥Alusta uuesti¥!";
                    }

                };
                kast.GestureRecognizers.Add(tap);
            }
        }
        return gr3x3;
    }

    private string VıiduKontroll()
    {
        for (int i = 0; i < 3; i++)
        {
            if (ruut[i, 0] == ruut[i, 1] &&
                ruut[i, 1] == ruut[i, 2] &&
                ruut[i, 0] != null)
            {
                return ruut[i, 0];
            }
        }
        

        for (int i = 0; i < 3; i++)
        {
            if (ruut[0, i] == ruut[1, i] &&
                ruut[1, i] == ruut[2, i] &&
                ruut[0, i] != null)
            {
                return ruut[0, i];
            }
        }
        
        if (ruut[2, 0] == ruut[1, 1] &&
            ruut[1, 1] == ruut[0, 2] &&
            ruut[2, 0] != null)
        {
            return ruut[2, 0];
        }

        if (ruut[0, 0] == ruut[1, 1] &&
            ruut[1, 1] == ruut[2, 2] &&
            ruut[0, 0] != null)
        {
            return ruut[0, 0];
        }

        return null;
    } 
}