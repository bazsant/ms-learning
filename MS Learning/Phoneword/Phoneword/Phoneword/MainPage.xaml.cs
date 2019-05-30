using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phoneword
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };

            layout.Children.Add(new Label { Text = "Enter name" });
            layout.Children.Add(new Entry());
            layout.Children.Add(new Button { Text = "OK" });

            this.Content = layout;
            
        }
    }
}
