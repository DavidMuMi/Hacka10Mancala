using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace JuegosV2
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class mancalasetapi : Page
    {
        public mancalasetapi()
        {
            this.InitializeComponent();
        }

        private async void nuevo_Click(object sender, RoutedEventArgs e)
        {


            var uri = new Uri($"http://mancalaapi.azurewebsites.net/api/tableros/new/0/4/4/4/4/4/4/4/4/4/4/4/4");

            var httpClient = new Windows.Web.Http.HttpClient();

            try
            {
                var result = await httpClient.GetAsync(uri);

                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(int));
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result.Content.ToString()));
                int id = (int)js.ReadObject(stream);

                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(mancalap1api), id);
            }
            catch
            {
            }


        }
    }
}
