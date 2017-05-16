using Project3.Models;
using Project3.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Project3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MovieDetails : Page
    {
        public MovieDetails()
        {
            this.InitializeComponent();
            //SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (!string.IsNullOrEmpty(App.movieId))
            {
                var movieId = App.movieId;
                MovieDetailsViewModel vm = new MovieDetailsViewModel(movieId);
                this.DataContext = vm;
            }
        }

        private void NavigateToMovieDetails(object sender, ItemClickEventArgs e)
        {
            var movie = (Movie)e.ClickedItem;
            App.movieId = movie.id;
            Frame.Navigate(typeof(MovieDetails));
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {         
            TrailerPopup.IsOpen = false;
        }

        private void TrailerBtn_Click(object sender, RoutedEventArgs e)
        {
            TrailerPopup.IsOpen = true;
            var vm = (MovieDetailsViewModel)this.DataContext;
            PopupTitle.Text = vm.movieDetails.title;
            TrailerPopup.HorizontalOffset = 400;
            TrailerPopup.VerticalOffset = 200;
        }

        
    }
}
