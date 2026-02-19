
namespace naidis_TARpe24SavvaSmirnyagin;

public partial class StepperSliderPage : ContentPage
{
	Label label;
	Stepper stepper;
	Slider slider;
	AbsoluteLayout al;
	public StepperSliderPage()
	{
		label = new Label
		{
			Text = "...",
			BackgroundColor = Colors.LightGray
		};

		stepper = new Stepper
		{
			Minimum = 0,
			Maximum = 360,
			Increment = 5,
			Value = 50,
			HorizontalOptions = LayoutOptions.Center
		};
		stepper.ValueChanged += Stepper_Slider_ValueChanged;

		slider = new Slider
		{
			Minimum = 0,
			Maximum = 360,
			Value = 50,
			HorizontalOptions = LayoutOptions.Center,
			MinimumTrackColor = Colors.LightGray,
			MaximumTrackColor = Colors.DarkGray,
			ThumbColor = Colors.Gray,
			WidthRequest = 300
		};
		slider.ValueChanged += Stepper_Slider_ValueChanged;
		al = new AbsoluteLayout { Children = { label, stepper, slider } };
		List<View> controls = new List<View> { label, stepper, slider };

	}

    private void Stepper_Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        throw new NotImplementedException();
    }
}