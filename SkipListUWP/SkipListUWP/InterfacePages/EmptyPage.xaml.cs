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
using Windows.UI.Popups;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SkipListUWP.InterfacePages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmptyPage : Page
    {
        public EmptyPage()
        {
            this.InitializeComponent();
        }

        private async void emptyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.skiplist.empty();

                var MessageB = new MessageDialog("Success! ");
                MessageB.Commands.Add(new UICommand("OK"));
                await MessageB.ShowAsync();
                MainPage.mainpage.OutputText.Text = App.skiplist.display();
            }
            catch (Exception ex)
            {
                var MessageA = new MessageDialog(ex.Message);//test
                MessageA.Commands.Add(new UICommand("OK"));
                await MessageA.ShowAsync();
            }
        }
    }
}
