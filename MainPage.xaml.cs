using Microsoft.Maui.Controls;
namespace HexColorGenerator
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            gemStones.BackgroundColor = HexColor;
        }

        string hexColor, red, green, blue;

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            HexColor = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);
            gemStones.BackgroundColor = HexColor;
            hexColor = HexColor.ToHex();
            hexLabel.Text = hexColor;

        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            HexColor = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);
            gemStones.BackgroundColor = HexColor;
            hexColor = HexColor.ToHex();
            hexLabel.Text = hexColor;
        }

        private async void copy_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexColor);
            await DisplayAlert("Copied", $"{hexColor} was Copied to Clipboard", "Ok");
        }

        Color HexColor = Color.FromRgb(0, 0, 0);

        private void random_Clicked(object sender, EventArgs e)
        {
            var rndColor = RandomColor();
            redSlider.Value = Convert.ToInt32(Math.Round(rndColor.Red * 255));
            greenSlider.Value = Convert.ToInt32(Math.Round(rndColor.Green * 255));
            blueSlider.Value = Convert.ToInt32(Math.Round(rndColor.Blue * 255));
        }

        private Color RandomColor()
        {
            var rnd = new Random();
            return Color.FromRgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
        }
    }

}
