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
using JuegosV2.Mancala;
using Windows.UI.Xaml.Shapes;
using System.Threading.Tasks;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace JuegosV2
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class mancala2 : Page
    {
        MancalaClass mancala;
        List<TextBlock> textblocks;
        public mancala2()
        {
            this.InitializeComponent();
            textblocks = new List<TextBlock>();
            textblocks.Add(t_0);
            textblocks.Add(t_1);
            textblocks.Add(t_2);
            textblocks.Add(t_3);
            textblocks.Add(t_4);
            textblocks.Add(t_5);
            textblocks.Add(t_6);
            textblocks.Add(t_7);
            textblocks.Add(t_8);
            textblocks.Add(t_9);
            textblocks.Add(t_10);
            textblocks.Add(t_11);
            mancala = new MancalaClass();
            this.actualizaTablero();
            textoTurno.Text = "Turno Jugador 1";
        }
        private async void Rectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            int numero = Int32.Parse(((Rectangle)sender).Name.Substring(2, 2));

            if (mancala.turno == 0 && numero % 2 != 0)
            {
                var notification = new Windows.UI.Popups.MessageDialog("No puedes mover ahí");
                await notification.ShowAsync();
            }
            else if (mancala.turno == 1 && numero % 2 == 0)
            {
                var notification = new Windows.UI.Popups.MessageDialog("No puedes mover ahí");
                await notification.ShowAsync();
            }
            else if (mancala.mover(numero) == 1)
            {
                var notification = new Windows.UI.Popups.MessageDialog("No puedes mover ahí");
                await notification.ShowAsync();
            }
            this.actualizaTablero();
            if (mancala.turno == 0)
            {
                textoTurno.Text = "Turno Jugador 1";
            }
            else
            {
                textoTurno.Text = "Turno Jugador 2";
            }
            if (mancala.fin_partida() == 0)
            {
                int gana = mancala.ganador();
                if (gana == 1)
                {
                    var notification = new Windows.UI.Popups.MessageDialog("JUGADOR 2 GANA!!");
                    await notification.ShowAsync();
                }
                else if (gana == 0)
                {
                    var notification = new Windows.UI.Popups.MessageDialog("JUGADOR 1 GANA!!");
                    await notification.ShowAsync();
                }
                else
                {
                    var notification = new Windows.UI.Popups.MessageDialog("EMPATE!!");
                    await notification.ShowAsync();
                }
            }
            while (1==1)
            {
                if (mancala.turno == 0)
                {
                    textoTurno.Text = "Turno Jugador 1";
                    return;
                }
                else
                {
                    int i = RandomNumberOdd(1, 9);
                    if (mancala.tablero[i] == 0)
                        continue;
                    else
                    {
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        mancala.mover(i);
                        actualizaTablero();
                        if (mancala.fin_partida() == 0)
                        {
                            int gana = mancala.ganador();
                            if (gana == 1)
                            {
                                var notification = new Windows.UI.Popups.MessageDialog("JUGADOR 2 GANA!!");
                                await notification.ShowAsync();
                            }
                            else if (gana == 0)
                            {
                                var notification = new Windows.UI.Popups.MessageDialog("JUGADOR 1 GANA!!");
                                await notification.ShowAsync();
                            }
                            else
                            {
                                var notification = new Windows.UI.Popups.MessageDialog("EMPATE!!");
                                await notification.ShowAsync();
                            }
                            if (mancala.turno == 0)
                            {
                                textoTurno.Text = "Turno Jugador 1";
                            }
                            else
                            {
                                textoTurno.Text = "Turno Jugador 2";
                            }
                        }
                    }
                }

            }


        }
        private void actualizaTablero()
        {
            int pos = 0;
            foreach (TextBlock t in textblocks)
            {
                textblocks[pos].Text = mancala.getFichas(pos).ToString();
                pos++;
            }
        }
        private static int RandomNumberOdd(int min, int max)
        {
            Random random = new Random();
            int ans = random.Next(min, max);
            if (ans % 2 == 1) return ans;
            else
            {
                if (ans + 1 <= max)
                    return ans + 1;
                else if (ans - 1 >= min)
                    return ans - 1;
                else return 0;
            }
        }
    }
}
