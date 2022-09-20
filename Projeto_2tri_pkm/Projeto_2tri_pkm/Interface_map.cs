using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_2tri_pkm
{
    internal class Interface_map
    {
        static readonly char[,] mapa = {
        { '|', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
        { '|', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '|' },};

        static readonly char[,] TextBox = {
        { '*', '*', '*', '*', '*', '*', ' ', 'T', 'E', 'X', 'T', 'O', ' ', '*', '*', '*', '*', '*', '*', '*', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*'},
        { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},};

       public static readonly int COLUMN = 20, ROW = 15;
       public static readonly int ENTITY = 8;
       public static readonly int TColumn = 21, TRow = 15;

        public static void PrintMapa(int x, int y)
        {
            int tempU=0,tempI=0;
            Console.Clear();
            for ( int i = 0; i < ROW; i++)
            {
                for ( int u = 0; u < COLUMN; u++)
                {
                    if (i == y && u == x)
                    {
                        if (mapa[y, x] == 'X')
                        {
                            Interface_battle.Frase('X');
                            tempU = u;
                            tempI = i;
                        }

                        else
                            TextClean();
                        Console.Write("O");
                    }
                    else
                        Console.Write(mapa[i, u]);

                    if (i==y && mapa[i, u] == 'N')
                    {
                        Interface_battle.Frase('N');
                        tempU = u;
                        tempI = i;
                    }

                }

                Console.Write("\t\t");
                for (int u = 0; u < TColumn ; u++)
                {
                    Console.Write(TextBox[i, u]);
                }
                Console.WriteLine();
            }
            if (tempI == y && tempU == x)
            {
                if (mapa[y, x] == 'X')
                {
                    Console.ReadLine();
                    Interface_battle.Desing('X');
                    mapa[y, x] = ' ';
                
                }

            }
            if (tempI == y && mapa[tempI, tempU] == 'N')
            {
                Console.ReadLine();
                Interface_battle.Desing('N');
                mapa[tempI, tempU] = ' ';
            }

        }

        public static int[] PrintObjs()
        {
            int[] positions = new int[2];
            while (true)
            {
                for(int i = 0; i < ENTITY;)
                {
                     Random rnd1 = new Random();
                     positions[0] = rnd1.Next(1, 19);//coluna
                     Random rnd2 = new Random();
                     positions[1] = rnd2.Next(1, 13);//linha

                     if (mapa[positions[1],positions[0]] == ' ' && i<6)
                    {
                        mapa[positions[1], positions[0]] = 'X';
                        i++;
                    }
                    if (mapa[positions[1], positions[0]] == ' ' && i >= 6 && positions[0]!=18 && positions[1]!=12)
                    {
                        mapa[positions[1], positions[0]] = 'N';
                        i++;
                    }
                }
                return positions;
            }
        }
        public static void TextWrite(string txt)
        {
            int j = 1, i = 1;
            char temp;
            for(int z = 0; z<txt.Length; z++)
            {
                temp = Convert.ToChar(txt[z]);

                TextBox[j, i] = temp;
                if (i == 19)
                {
                    j++;
                    i = 0;
                }
                i++;
            }
           
        }
        public static void TextClean()
        {
            for(int r = 1; r < 14; r++)
            {
                for(int c = 1; c < 20; c++)
                {
                    TextBox[r, c] =' ';
                }
            }


                    //21, TRow = 15
        }
    }
}
