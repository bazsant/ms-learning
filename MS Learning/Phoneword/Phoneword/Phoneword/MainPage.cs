using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Phoneword
{
    class MainPage : ContentPage
    {
        string translatedNumber;
        public MainPage()
        {
            Padding = new Thickness(20);

            Entry phoneNumberText;
            Button translateButton;
            Button callButton;

            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };

            panel.Children.Add(new Label
            {
                Text = "Escreva o phoneword",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "11WWWLURTA"
            });

            panel.Children.Add(translateButton = new Button
            {
                Text = "Traduzir"
            });

            panel.Children.Add(callButton = new Button
            {
                Text = "Ligar",
                IsEnabled = false
            });


            translateButton.Clicked += (object sender, EventArgs e) =>
            {
                string enteredNumber = phoneNumberText.Text;
                translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);

                if (!string.IsNullOrEmpty(translatedNumber))
                {
                    callButton.IsEnabled = true;
                    callButton.Text = "Ligar para " + translatedNumber;
                }
                else
                {
                    callButton.IsEnabled = false;
                    callButton.Text = "Ligar";
                }
            };

            callButton.Clicked += async (object sender, EventArgs e) =>
            {
                if (await this.DisplayAlert("Discar número", "Gostaria de ligar para " + translatedNumber + "?", "Sim", "Não"))
                {
                    try
                    {
                        PhoneDialer.Open(translatedNumber);
                    }
                    catch (ArgumentNullException)
                    {
                        await DisplayAlert("Não é possivel discar", "Telefone não é válido.", "OK");
                    }
                    catch (FeatureNotSupportedException)
                    {
                        await DisplayAlert("Não é possivel discar", "Discagem não é suportada.", "OK");
                    }
                    catch (Exception)
                    {
                        // Other error has occurred.
                        await DisplayAlert("Não é possivel discar", "Discagem falhou.", "OK");
                    }
                }
            };

            Content = panel;

        }

    }
}
