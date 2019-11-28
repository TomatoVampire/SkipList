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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SkipListUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage mainpage;

        public MainPage()
        {
            this.InitializeComponent();
            InputFrame.Navigate(typeof(WelcomePage));
            mainpage = this;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            InputFrame.Navigate(typeof(CreatePage));
        }

        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            InputFrame.Navigate(typeof(InsertPage));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            InputFrame.Navigate(typeof(SearchPage));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            InputFrame.Navigate(typeof(InterfacePages.DeletePage));
        }

        private void EmptyButton_Click(object sender, RoutedEventArgs e)
        {
            InputFrame.Navigate(typeof(InterfacePages.EmptyPage));
        }
    }
}
