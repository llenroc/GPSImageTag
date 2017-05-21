using GPSImageTag.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GPSImageTag
{
    public partial class MapPage : ContentPage
    {
        PhotosPageViewModel vm;
 
        public MapPage()
        {
            InitializeComponent();

            vm = new PhotosPageViewModel();

            BindingContext = vm;

            Device.BeginInvokeOnMainThread(() =>
            {
                PhotoMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.463734, -108.086924), Distance.FromMiles(1000.0)));
            });




        }

  
        private async void btnMapPhotos_Clicked(object sender, EventArgs e)
        {
            await vm.GetPhotos();

            bool IsMapCentered=false;

            if (vm.Photos != null && vm.Photos.Count > 0)
            {
                foreach (var photo in vm.Photos)
                {
                    if (photo.Latitude != null)
                    {
                        if (!IsMapCentered)
                        {

                            PhotoMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(double.Parse(photo.Latitude), double.Parse(photo.Longitude)), Distance.FromMiles(1000.0)));

                        }
                        var pin = new Pin
                        {

                            Type = PinType.Place,

                            Position = new Position(double.Parse(photo.Latitude), double.Parse(photo.Longitude)),

                            Label = photo.Name

                        };

                        PhotoMap.Pins.Add(pin);
                    }
                }
            }
        }
    }
}
