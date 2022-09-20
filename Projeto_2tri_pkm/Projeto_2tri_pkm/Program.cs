using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_2tri_pkm
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int x = 9, y = 13;
            char move;// player position
            int[] temp = new int[2];
            Design.Escolha_time();
            Interface_map.PrintObjs();
            Interface_map.PrintMapa(x,y);
            

            while (true)
            {
                move=Convert.ToChar(Console.Read());
                temp= Jogador.Move(x, y, move);
                x = temp[0];
                y = temp[1];
                
            }
            //versão final aaaaaaa
            
        }
    }
}
