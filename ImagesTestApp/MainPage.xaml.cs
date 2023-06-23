using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Diagnostics;
using Microsoft.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ImagesTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ImageLoaded(object sender, RoutedEventArgs e)
        {
            HandleImageEvent(sender as Image, e, true);
            //System.Diagnostics.Debug.WriteLine($"Image loaded - {((sender as Image)!.Source as BitmapImage)?.UriSource}");
        }

        private void ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            HandleImageEvent(sender as Image, e, false);
            //System.Diagnostics.Debug.WriteLine($"Image failed to load - {((sender as Image)!.Source as BitmapImage)?.UriSource}");
        }

        private void HandleImageEvent(Image sender, RoutedEventArgs e, bool success)
        {
            var tagBits = (sender.Tag as string).Split(',');
            var originalSource = tagBits[0];
            var shouldLoad = bool.Parse(tagBits[1]);
            if (shouldLoad != success)
            {
                System.Diagnostics.Debug.WriteLine($"Image {(shouldLoad ? "SHOULD" : "should NOT")} load but {(success ? "DID" : "did NOT")} load - "+
                    $"Original Source '{originalSource}' Actual Source '{((sender as Image)!.Source as BitmapImage)?.UriSource}'");

            }
        }

    }
}
