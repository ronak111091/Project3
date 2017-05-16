using Project3.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Project3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //BackButton.Visibility = Visibility.Collapsed;
            MainContent.Navigate(typeof(Home));
            
            Loaded += (s, e) =>
            {
                //write logic here
                HomeItem.IsSelected = true;
            };
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            HamburgerSplitView.IsPaneOpen = !HamburgerSplitView.IsPaneOpen;
        }

        private void HamburgerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeItem.IsSelected)
            {
                MainContent.Navigate(typeof(Home));
                //BackButton.Visibility = Visibility.Collapsed;

            }
            else if (MoviesItem.IsSelected)
            {
                MainContent.Navigate(typeof(Movies));
                //BackButton.Visibility = Visibility.Collapsed;

            }
            else if (TVShowsItem.IsSelected)
            {
                MainContent.Navigate(typeof(TVShows));
                //BackButton.Visibility = Visibility.Collapsed;

            }
        }

        //private void BackButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (MainContent.CanGoBack)
        //    {
        //        MainContent.GoBack();
        //        //BackButton.Visibility = Visibility.Collapsed;
        //    }
        //}
    }
}
