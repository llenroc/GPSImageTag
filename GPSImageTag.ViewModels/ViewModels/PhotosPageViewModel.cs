﻿using GPSImageTag.Core.Helpers;
using GPSImageTag.Core.Interfaces;
using GPSImageTag.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GPSImageTag.ViewModels
{
    public class PhotosPageViewModel : BaseViewModel
    {
        private IAzureService mobileService;
        private IDialogService dialogService;
        private ObservableCollection<Photo> photos;
        public ObservableCollection<Photo> Photos
        {
            get { return photos; }
            set
            {
                photos = value; OnPropertyChanged("Photos");
            }
        }

        public Command GetPhotosCommand { get; set; }

        public PhotosPageViewModel()
        {
            Title = "Photo List";
            photos = new ObservableCollection<Photo>();
            GetPhotosCommand = new Command(
                async () => await GetPhotos(),
                () => !IsBusy);

            dialogService = ServiceManager.GetObject<IDialogService>();
            mobileService = ServiceManager.GetObject<IAzureService>();
        }

        public async Task GetPhotos()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {

                IsBusy = true;
                var items = await mobileService.GetPhotos();
                Photos.Clear();
                foreach (var item in items)
                {
                    item.Uri = ResizePhoto(item.Uri);
                    Photos.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                dialogService.ShowError("Error! " + error.Message + " OK");
        }


        private string ResizePhoto(string url)
        {
            var azureFunction = "<Azure Function url goes here>";

            var returnpos = url.LastIndexOf("/") + 1;

            var imagename = url.Substring(returnpos, (url.Length - returnpos));

            string thumburl = $"{azureFunction}{imagename}/";


            return thumburl;

        }
    }
}
