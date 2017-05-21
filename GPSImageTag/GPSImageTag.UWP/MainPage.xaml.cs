namespace GPSImageTag.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("INSERT_MAP_KEY_HERE");
            LoadApplication(new GPSImageTag.App());
        }

    }
}
