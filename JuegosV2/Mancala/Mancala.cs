using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosV2.Mancala
{

    public class MancalaClass
    {
        public int turno;
        public int[] tablero = new int[12];

        public MancalaClass()
        {
            turno = 0;
            for (int i = 0; i < 12; i++)
            {
                if (i == 10 || i == 11)
                    tablero[i] = 0;
                else
                    tablero[i] = 4;
            }
        }

        public int mover(int origen)
        {
            //Si el origen Kalaha o no tiene fichas, no se puede mover
            if (origen == 10 || origen == 11 || tablero[origen] == 0)
            {
                return 1;
            }
            //Fichas del tablero de origen
            int fichas = tablero[origen];
            //Elimino las fichas de origen
            tablero[origen] = 0;
            //Posicion del ultimo movimiento
            int final = 0;
            //Movemos las fichas por todo el tablero

            //Si es J1
            int pos = 0;
            if (origen == 1)
            {
                pos = 11;
            }
            else if ((origen % 2) == 0)
            {
                pos = origen + 2;
            }
            else
            {
                pos = origen - 2;
            }

            while (fichas > 0)
            {
                fichas--;
                if (fichas == 0)
                    final = pos;
                if ((pos % 2) == 0)
                {
                    tablero[pos] += 1;
                    pos += 2;

                }
                else
                {
                    tablero[pos] += 1;
                    if (pos == 11)
                        pos = 0;
                    else
                        pos -= 2;
                }
                if (pos == 12)
                {
                    pos = 9;
                }
                if (pos == -1)
                {
                    pos = 11;
                }

            }

            //Si J2 termina en kalaha repite turno
            if (final == 11 && turno == 1)
            {
                return 0;
            }
            //Si J1 termina en kalaha repite turno
            if (final == 10 && turno == 0)
            {
                return 0;
            }
            //Posibilidad de comer


            if (turno == 0)
            {
                if (tablero[final] == 1 && !(final == 11 || final == 10))
                {
                    if (final % 2 == 0)
                    {
                        tablero[10] += tablero[final + 1];//Al kalaha las del lado contrario
                        tablero[final + 1] = 0;
                    }
                }
            }

            if (turno == 1)
            {
                if (tablero[final] == 1 && !(final == 11 || final == 10))
                {
                    if (final % 2 != 0)
                    {
                        tablero[11] += tablero[final - 1];
                        tablero[final - 1] = 0;
                    }
                }
            }



            //Cambio de turno
            if (turno == 0)
                turno = 1;
            else turno = 0;

            return 0;
        }
        //Devuelve 0 si la partida ha terminado
        public int fin_partida()
        {
            int j = 0;
            int k = 0;
            for (int i = 1; i < 10; i = i + 2)
                if (tablero[i] != 0)
                    j++;

            for (int i = 0; i < 9; i = i + 2)
                if (tablero[i] != 0)
                    k++;
            if (j == 0 || k == 0)
                return 0;
            return 1;

        }
        public int puntosj1()
        {
            return tablero[0] + tablero[2] + tablero[4] + tablero[6] + tablero[8] + tablero[10];
        }

        public int puntosj2()
        {
            return tablero[1] + tablero[3] + tablero[5] + tablero[7] + tablero[9] + tablero[11];
        }
        public int ganador()
        {
            if (puntosj1() < puntosj2())
                return 1;
            else if (puntosj2() < puntosj1())
                return 0;
            else return -1;

        }
        public int getFichas(int casilla)
        {
            return tablero[casilla];
        }
        public int mediumIA(MancalaClass actual)
        {
            MancalaClass aux = new MancalaClass();
            for(int i = 0; i < 12; i++)
            {
                aux.tablero[i] = actual.tablero[i];
            }
            List<int> lista = new List<int>();
            lista.Add(1);
            lista.Add(3);
            lista.Add(5);
            lista.Add(7);
            lista.Add(9);
            Hashtable hashtable = new Hashtable();
            int max = 1;
            int num_max = 0;
            foreach (int i in lista){
                if (aux.tablero[i] != 0)
                {
                    aux.mover(i);
                    if (aux.getFichas(11) > num_max)
                    {
                        max = i;
                        num_max = aux.getFichas(11);
                    }

                    for (int e = 0; e < 12; e++)
                    {
                        aux.tablero[e] = actual.tablero[e];
                    }
                }
            }
            
            return max;
        }
    }

}
