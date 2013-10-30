using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Lottoshaker.Resources;

namespace Lottoshaker
{
    public partial class MainPage : PhoneApplicationPage
    {
        int lottoChosen;
        public enum Lottery { None, Lottario, Lotto649, Ontario49, Powerball, Sweet, NYLotto };
        public static Lottery chosenLottery;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NumberSelection.xaml", UriKind.Relative));
        }

        private void Lottario_Click(object sender, RoutedEventArgs e)
        {
            chosenLottery = Lottery.Lottario;
            if (chosenLottery == Lottery.Lottario)
            {
                lottoChosen = 1;
                NavigationService.Navigate(new Uri("/NumberSelection.xaml", UriKind.Relative));
            }
        }

        private void Lotto649_Click(object sender, RoutedEventArgs e)
        {
            chosenLottery = Lottery.Lotto649;
            if (chosenLottery == Lottery.Lotto649)
            {
                lottoChosen = 2;
                NavigationService.Navigate(new Uri("/NumberSelection.xaml", UriKind.Relative));
            }
        }

        private void Ontario49_Click(object sender, RoutedEventArgs e)
        {
            chosenLottery = Lottery.Ontario49;
            if (chosenLottery == Lottery.Ontario49)
            {
                lottoChosen = 3;
                NavigationService.Navigate(new Uri("/NumberSelection.xaml", UriKind.Relative));
            }
        }

        private void Powerball_Click(object sender, RoutedEventArgs e)
        {
            chosenLottery = Lottery.Powerball;
            if (chosenLottery == Lottery.Powerball)
            {
                lottoChosen = 4;
                NavigationService.Navigate(new Uri("/NumberSelection.xaml", UriKind.Relative));
            }
        }

        private void Sweet_Click(object sender, RoutedEventArgs e)
        {
            chosenLottery = Lottery.Sweet;
            if (chosenLottery == Lottery.Sweet)
            {
                lottoChosen = 5;
                NavigationService.Navigate(new Uri("/NumberSelection.xaml", UriKind.Relative));
            }
        }

        private void NYLotto_Click(object sender, RoutedEventArgs e)
        {
            chosenLottery = Lottery.NYLotto;
            if (chosenLottery == Lottery.NYLotto)
            {
                lottoChosen = 6;
                NavigationService.Navigate(new Uri("/NumberSelection.xaml", UriKind.Relative));
            }
        }

       
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}