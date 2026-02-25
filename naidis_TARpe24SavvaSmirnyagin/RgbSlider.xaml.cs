
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace naidis_TARpe24SavvaSmirnyagin;

public partial class RgbSlider : ContentPage
{
    Label labelRed;
    Label labelBlue;
    Label labelGreen;
    Label label;
    BoxView box;
    Slider sliderRed;
    Slider sliderBlue;
    Slider sliderGreen;
    AbsoluteLayout al1;
    AbsoluteLayout al2;
    VerticalStackLayout vs;
    Rect rect;
    public RgbSlider()
	{
        box = new BoxView
        {
            WidthRequest = 400,
            HeightRequest = 400,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Colors.Black
        };

        labelRed = new Label
        {
            Text = "Red = ",
            TextColor = Colors.Red
        };

        labelGreen = new Label
        {
            Text = "Green = ",
            TextColor = Colors.Green
        };

        labelBlue = new Label
        {
            Text = "Blue = ",
            TextColor = Colors.Blue
        };

        sliderRed = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Colors.Red,
            MaximumTrackColor = Colors.Red,
            ThumbColor = Colors.Red,
            WidthRequest = 300
        };

        sliderGreen = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Colors.Green,
            MaximumTrackColor = Colors.Green,
            ThumbColor = Colors.Green,
            WidthRequest = 300
        };

        sliderBlue = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Colors.Blue,
            MaximumTrackColor = Colors.Blue,
            ThumbColor = Colors.Blue,
            WidthRequest = 300
        };


        sliderRed.ValueChanged += OnSliderValueChanged;
        sliderGreen.ValueChanged += OnSliderValueChanged;
        sliderBlue.ValueChanged += OnSliderValueChanged;
        vs = new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            Children = { box, sliderRed, labelRed, sliderGreen, labelGreen, sliderBlue, labelBlue }
        };
        List<View> controls = new List<View> { box, sliderRed, labelRed, sliderGreen, labelGreen, sliderBlue, labelBlue };
        for (int i = 0; i < controls.Count; i++)
        {
            double yKoht = 0.2 + i * 0.1;
            AbsoluteLayout.SetLayoutBounds(controls[i], new Rect(0.5, yKoht, 200, 400));
            AbsoluteLayout.SetLayoutFlags(controls[i], AbsoluteLayoutFlags.PositionProportional);
        }
        Content = vs;
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (sender == sliderRed)
        {
            labelRed.Text = String.Format("Red = {0:X2}", (int)e.NewValue); 
        }
        else if (sender == sliderGreen)
        {
            labelGreen.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
        }
        else if (sender == sliderBlue)
        {
            labelBlue.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
        }

        box.BackgroundColor = Color.FromRgb((byte)sliderRed.Value,
                                              (byte)sliderGreen.Value,
                                              (byte)sliderBlue.Value);
    }
}