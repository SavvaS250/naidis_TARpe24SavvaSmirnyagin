
using Microsoft.Maui.Layouts;

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
			BackgroundColor = Colors.Gray
		};

		stepper = new Stepper
		{
			Minimum = 0,
			Maximum = 360,
			Increment = 5,
			Value = 0,
			HorizontalOptions = LayoutOptions.Center
		};
		stepper.ValueChanged += Stepper_Slider_ValueChanged;

		slider = new Slider
		{
			Minimum = 0,
			Maximum = 360,
			Value = 0,
			HorizontalOptions = LayoutOptions.Center,
			MinimumTrackColor = Colors.Black,
			MaximumTrackColor = Colors.Black,
			ThumbColor = Colors.Red,
			WidthRequest = 300
		};
		slider.ValueChanged += Stepper_Slider_ValueChanged;
		al = new AbsoluteLayout { Children = { label, stepper, slider } };
		List<View> controls = new List<View> { label, stepper, slider };
		for (int i = 0; i < controls.Count; i++)
		{
			double yKoht = 0.2 + i * 0.2;
			AbsoluteLayout.SetLayoutBounds(controls[i], new Rect(0.5, yKoht, 300, 100));
			AbsoluteLayout.SetLayoutFlags(controls[i], AbsoluteLayoutFlags.PositionProportional);
		}
		Content = al;
	}

    private void Stepper_Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
		label.Text = $"Stepperi/Slideri väärtus: {e.NewValue:F0}";
		label.FontSize = 18 + e.NewValue / 4; //Suurendab fonti suurust väärtuse kasvades
		label.BackgroundColor = Color.FromRgb((int)(e.NewValue * 2.55), (int)(255 - e.NewValue * 2.55), 128); // Värv muutub roosast siniseks, väärtuse muutumisel
		label.TextColor = Color.FromRgb((int)(255 - e.NewValue * 2.55), (int)(e.NewValue * 2.55), 128); // tekstivärv muutub roosast siniseks, väärtuse muutumisel
		label.Rotation = e.NewValue;
    }
}