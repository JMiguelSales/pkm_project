using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projeto_2tri_pkm.Logica_batalha;
using static Projeto_2tri_pkm.PokeBank;

namespace Projeto_2tri_pkm
{
    internal class Jogador
    {
        public static int[] Move(int x, int y, char Move)
        {

            switch (Move)
            {
                case 'w': y--; break;
                case 's': y++; break;
                case 'a': x--; break;
                case 'd': x++; break;
                default: break;
            }
            if (y == 0)
                y++;
            else if (y == 14)
                y--;
            if (x == 0)
                x++;
            else if (x == 19)
                x--;
            Interface_map.PrintMapa(x, y);

            int[] temp = { x, y };
            return temp;
        }

        public static List<int> Id_pkm_Time = new List<int>();
        public static void Vidas_temp_Player()
        {
            for (int i = 0; i < Id_pkm_Time.Count; i++)
                Interface_battle.vidas_player.Add(PokeBank.stats[Id_pkm_Time[i],0]);
        }
        public static void Stats_Pkm_ativo(int PkmAtivo)
        {
           
            int z= 0;
            for(int i = 0; i <5; i++)
            {
                z++;
                Interface_battle.Todos_Stats[0,i] = PokeBank.stats[PkmAtivo, z];
            
            }

        }
        public static int  Switch_Pkm(int PKmativo)
        {
            int ChosenPkm;
            do
            {
                Console.Clear();
                ChosenPkm = Design.Troca();

            } while (!Jogador.Id_pkm_Time.Contains(Id_pkm_Time[ChosenPkm]));
            return ChosenPkm;

        }
        public static bool Morte_player()
        {
            if (Interface_battle.vidas_player.Count == Interface_battle.Mortos_Player.Count)
            {
                Console.Clear();
                Console.WriteLine("\t\tMuito ruim kk, perdeu");
                Console.Read();
                return true;
            }
            return false;
        }
    }
}

/*                      LEGENDA DOS ATAQUES

        -1= cura, 
        -2= proteger,
         1= spd Buff;
         2= df Buff; 
         3 = atackBuff;
         4 =spd Buff;
         5= spe Buff;
        0= explosion;
*/

