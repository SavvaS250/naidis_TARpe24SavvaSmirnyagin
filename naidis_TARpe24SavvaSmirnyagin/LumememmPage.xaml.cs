
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace naidis_TARpe24SavvaSmirnyagin;

public partial class LumememmPage : ContentPage
{
	VerticalStackLayout vsl;
	Label label;
	Label label1;
	Label label2;
	Picker picker;
	BoxView amber;
	Ellipse ellipse1;
	Ellipse ellipse2;
	Ellipse ellipse3;
    Random rnd = new Random();
    Slider slider;
    Stepper stepper;
    uint kiirus;
    public LumememmPage()
	{
        kiirus = 2000;

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

        slider = new Slider
        {
            Minimum = 0.0,
            Maximum = 1.0,
            Value = 1.0,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Colors.Black,
            MaximumTrackColor = Colors.Black,
            ThumbColor = Colors.Black,
            WidthRequest = 300
        };
        slider.ValueChanged += Slider_ValueChanged;

        stepper = new Stepper
        {
            Minimum = 1000,
            Maximum = 7000,
            Increment = 100,
            Value = 1000,
            HorizontalOptions = LayoutOptions.Center
        };
        stepper.ValueChanged += Stepper_ValueChanged;

        amber = new BoxView
		{
			WidthRequest = 40,
			HeightRequest = 45
		};

        label1 = new Label
        {
            Text = "Muuda lumememme l‰bipaistvust",
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 20
        };

        label2 = new Label
        {
            Text = "Muuda sulamise kiirst",
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
		tegevusedList.Add("N‰ita lumememm");
		tegevusedList.Add("Muuda v‰rv");
		tegevusedList.Add("Valge lumememm");
		tegevusedList.Add("Sulata");
		tegevusedList.Add("Lumememm tagasi");
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
            Children = { amber, ellipse1, ellipse2, ellipse3, label, picker, slider, label1, stepper, label2}
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
            label1.Text = "Lumememm on n‰htav";
            ellipse1.Opacity = 1;
            ellipse2.Opacity = 1;
            ellipse3.Opacity = 1;
            amber.BackgroundColor = Colors.Black;
        }
        else if (selectedIndex == 2)
        {
            label1.Text = "V‰rv on muudetud juhuslikuks";
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
        else if (selectedIndex == 5)
        {
            ellipse1.Opacity = 1;
            ellipse2.Opacity = 1;
            ellipse3.Opacity = 1;
            amber.Opacity = 1;

            ellipse1.Scale = 1;
            ellipse2.Scale = 1;
            ellipse3.Scale = 1;
            amber.Scale = 1;
        }
        else if (selectedIndex == 6)
        {
            await Tantsi1();
            await Tantsi2();
            await Tantsi3();
            await Tantsi4();
            await Tantsi5();
            await Tantsi3();
        }
    }

    async Task SulataLumememm()
    {
        await Task.WhenAll(
            ellipse1.ScaleTo(0, 1000),
            ellipse2.ScaleTo(0, 2000),
            ellipse3.ScaleTo(0, 3000),
            amber.ScaleTo(0, 1000),
            ellipse1.FadeTo(0, kiirus),
            ellipse2.FadeTo(0, kiirus),
            ellipse3.FadeTo(0, kiirus),
            amber.FadeTo(0, kiirus)
        );
    }

    async Task Tantsi1()
    {
        await Task.WhenAll(
            ellipse1.TranslateTo(200, 0, 700),
            ellipse2.TranslateTo(200, 0, 700),
            ellipse3.TranslateTo(200, 0, 700),
            amber.TranslateTo(200, 0, 700)
        );
    }

    async Task Tantsi2()
    {
        await Task.WhenAll(
            ellipse1.TranslateTo(-200, 0, 700),
            ellipse2.TranslateTo(-200, 0, 700),
            ellipse3.TranslateTo(-200, 0, 700),
            amber.TranslateTo(-200, 0, 700)
        );
    }

    async Task Tantsi3()
    {
        await Task.WhenAll(
            ellipse1.TranslateTo(0, 0, 700),
            ellipse2.TranslateTo(0, 0, 700),
            ellipse3.TranslateTo(0, 0, 700),
            amber.TranslateTo(0, 0, 700)
        );
    }

    async Task Tantsi4()
    {
        await Task.WhenAll(
            ellipse1.TranslateTo(-200, 0, 700),
            ellipse2.TranslateTo(200, 0, 700),
            ellipse3.TranslateTo(-200, 0, 700),
            amber.TranslateTo(200, 0, 700)
        );
    }

    async Task Tantsi5()
    {
        await Task.WhenAll(
            ellipse1.TranslateTo(200, 0, 700),
            ellipse2.TranslateTo(-200, 0, 700),
            ellipse3.TranslateTo(200, 0, 700),
            amber.TranslateTo(-200, 0, 700)
        );
    }

    private void Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        double opacityValue = e.NewValue;

       
        ellipse1.Opacity = opacityValue;
        ellipse2.Opacity = opacityValue;
        ellipse3.Opacity = opacityValue;
        amber.Opacity = opacityValue;

        label1.Text = $"Slideri v‰‰rtus: {e.NewValue:F1}";
    }

    private void Stepper_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        kiirus = (uint)e.NewValue;  
        label2.Text = $"Stepperi v‰‰rtus: {kiirus}";
    }
}