
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace naidis_TARpe24SavvaSmirnyagin;

public partial class LumememmPage : ContentPage
{
	VerticalStackLayout vsl;
	Label label;
	Label label1;
	Picker picker;
	BoxView amber;
	Ellipse ellipse1;
	Ellipse ellipse2;
	Ellipse ellipse3;
    Random rnd = new Random();
    public LumememmPage()
	{
        

        ellipse1 = new Ellipse
		{
            WidthRequest = 100,
            HeightRequest = 100,
            Stroke = Colors.Black,
            Fill = new SolidColorBrush(Colors.White),
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };

        ellipse2 = new Ellipse
        {
            WidthRequest = 150,
            HeightRequest = 150,
            Stroke = Colors.Black,
            Fill = new SolidColorBrush(Colors.White),
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };

        ellipse3 = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Stroke = Colors.Black,
            Fill = new SolidColorBrush(Colors.White),
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };


        amber = new BoxView
		{
			WidthRequest = 40,
			HeightRequest = 45
		};

        label1 = new Label
        {
            Text = "",
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 20
        };

        label = new Label
        {
            Text = "",
            HorizontalOptions = LayoutOptions.Center
        };
        var tegevusedList = new List<string>();
		tegevusedList.Add("Peida lumememm");
		tegevusedList.Add("Näita lumememm");
		tegevusedList.Add("Muuda värv");
		tegevusedList.Add("Valge lumememm");
		tegevusedList.Add("Sulata");
		tegevusedList.Add("Tantsi");

		picker = new Picker
		{
			Title = "Vali tegevus",
            HorizontalOptions = LayoutOptions.Center
		};
		picker.ItemsSource = tegevusedList;
        picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;

        //label = new Label();
        //label.SetBinding(Label.TextProperty, Binding.Create(static (Picker picker) => picker.SelectedItem, source: picker));

        vsl = new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            Children = { amber, ellipse1, ellipse2, ellipse3, label, picker, label1}
        };
        Content = vsl;
    }

    async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        int r = rnd.Next(256);
        int g = rnd.Next(256);
        int b = rnd.Next(256);
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex == 0)
        {
            label1.Text = "Lumememm on peidetud";
            ellipse1.Opacity = 0;
            ellipse2.Opacity = 0;
            ellipse3.Opacity = 0;
            amber.BackgroundColor = Colors.White;
        }
        else if (selectedIndex == 1)
        {
            label1.Text = "Lumememm on nähtav";
            ellipse1.Opacity = 1;
            ellipse2.Opacity = 1;
            ellipse3.Opacity = 1;
            amber.BackgroundColor = Colors.Black;
        }
        else if (selectedIndex == 2)
        {
            label1.Text = "Värv on muudetud juhuslikuks";
            ellipse1.Fill = Color.FromRgb(r, g, b);
            ellipse2.Fill = Color.FromRgb(g, b, r);
            ellipse3.Fill = Color.FromRgb(b, r, g);
        }
        else if (selectedIndex == 3)
        {
            label1.Text = "Lumememm on valge";
            ellipse1.Fill = Colors.White;
            ellipse2.Fill = Colors.White;
            ellipse3.Fill = Colors.White;
        }
        else if (selectedIndex == 4)
        {
            await SulataLumememm();
        }
    }

    async Task SulataLumememm()
    {
        await Task.WhenAll(
            ellipse1.ScaleTo(0, 3000),
            ellipse2.ScaleTo(0, 3000),
            ellipse3.ScaleTo(0, 3000),
            ellipse1.FadeTo(0, 3000),
            ellipse2.FadeTo(0, 3000),
            ellipse3.FadeTo(0, 3000),
            amber.TranslateTo(0, 500, 1000)
        );
    }
}