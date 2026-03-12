using Microsoft.Maui.Controls.Shapes;

namespace naidis_TARpe24SavvaSmirnyagin;

public partial class TripsTrapsTrull : ContentPage
{
    Grid gr4x1, gr3x3;
    Picker picker;
    Image img;
    Switch s_pilt, s_grid;
    Random rnd = new Random();
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


        s_pilt = new Switch
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            IsToggled = true,
            IsEnabled = true
        };
        s_pilt.Toggled += (sender, e) =>
        {
            if (e.Value)
            {
                img.IsVisible = true;
            }
            else
            {
                img.IsVisible = false;
            }
        };

        s_grid = new Switch
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            IsToggled = false,
            IsEnabled = true
        };
        s_grid.Toggled += (sender, e) =>
        {
            if (e.Value)
            {
                gr3x3 = Taida_gr3x3();

                gr4x1.Add(gr3x3, 0, 2);
                gr4x1.SetColumnSpan(gr3x3, 2);
            }
            else
            {
                gr4x1.RemoveAt(4);
            }
        };

        gr4x1.Add(s_grid, 1, 3);
        Content = gr4x1;
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
                    kast.BackgroundColor = Colors.Green;
                    //await DisplayAlertAsync("Koordinaadid", $"Vajutasid lahtrisse: \nRida: {rida}\nVeerg: {veerg}", "Selge");
                };
                kast.GestureRecognizers.Add(tap);
            }
        }
        return gr3x3;
    }
}