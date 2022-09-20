using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projeto_2tri_pkm.Logica_batalha;

namespace Projeto_2tri_pkm
{
    
    internal class Bot// versao boa BOraaaaaa
    {
        public static List<int> Id_pkm_Time_Bot=new List<int>();
        public static int Move_bot_log;

        public static void Time_Bot(char inimigo)
        {
            int members,Quant_pkmInimigos;
            if (inimigo == 'X')
                Quant_pkmInimigos = 1;
            else
                Quant_pkmInimigos = 3;
            for (int i=0; i < Quant_pkmInimigos;)
            {
                Random rnd1 = new Random();
                members=rnd1.Next(0, PokeBank.pkms.Length);
                if (!Id_pkm_Time_Bot.Contains(members))
                {

                    Id_pkm_Time_Bot.Add(members);
                    i++;
                       
                } 
                
            }     
        }
        public static int Move_Bot(int Pkm_Bot_ativo,int Pkm_Jogador_ativo)
        {
            double temp;
            int[] TypesDefensor = { Convert.ToInt32(PokeBank.pkmTipo[Pkm_Jogador_ativo, 0]), Convert.ToInt32(PokeBank.pkmTipo[Pkm_Jogador_ativo, 1]) };
            int[] MovesType = new int[4];
            int[] Golpes1X = new int[4];
            int k = -1, Move;

            for (int i = 0; i < MovesType.Length; i++)
            {
                MovesType[i] = Convert.ToInt32(PokeBank.danoTipo[Pkm_Bot_ativo, i]);

            }


            for (int i = 0; i < MovesType.Length; i++)// escolhendo o golpe + analizando possíveis golpes 
            {
              temp = 1.0;
                for ( int j = 0; j < TypesDefensor.Length; j++)
                    temp *= Logica_batalha.Efetividade[MovesType[i], TypesDefensor[j]];
                
                if (temp >= 2.0)
                    return i;
         
                if (temp >= 1.0)
                {
                    k++;
                    Golpes1X[k] = i;
                    
                }
            }
            for (int i = 0; i <k; i++)// caso nenhum golpe seja 1x ele irá trocar.
            {
                if (MovesType[Golpes1X[i]] != 18)
                {
                    Random rnd1 = new Random();
                    Move = rnd1.Next(0,k-1);
                    return Golpes1X[Move];
                }
            }
            return -1;
        }
        public static void Vidas_temp_Bot()
        {
            for (int i = 0; i < Id_pkm_Time_Bot.Count; i++)
            {
                Interface_battle.vidas_bot.Add(PokeBank.stats[Id_pkm_Time_Bot[i], 0]);
            }



        }
        public static void Stats_Pkm_ativo()
        {
            int j = 1;
            for (int i = 0; i <5; i++)
            {
                Interface_battle.Todos_Stats[1,i] = PokeBank.stats[Id_pkm_Time_Bot[0], j];
                j++;
            }
        }
        public static bool Troca_bot()// looping em um pkm aleatório dentro do padrão
        { 
            int PkmAtivo= Id_pkm_Time_Bot[0];
            int PkmAtual,temp;
            if (Interface_battle.vidas_bot.Count!=0)
            {
                int max = Interface_battle.vidas_bot.Count;
                do
                {
                    Random rnd1 = new Random();
                    PkmAtual = rnd1.Next(0, max);

                }while (Id_pkm_Time_Bot.Count< PkmAtual || PkmAtivo == PkmAtual);

                temp = Interface_battle.vidas_bot[0];
                Interface_battle.vidas_bot[0] = Interface_battle.vidas_bot[PkmAtual];
                Interface_battle.vidas_bot[PkmAtual] = temp;

                temp = Id_pkm_Time_Bot[0];
                Id_pkm_Time_Bot[0] = Id_pkm_Time_Bot[PkmAtual];
                Id_pkm_Time_Bot[PkmAtual] = temp;
                return true;

            }
            else
                return false;
        }
        public static bool Morte_bot()
        {
            if (Interface_battle.vidas_bot.Count==0)
            {
                Console.Clear();
                Console.WriteLine("\t\tParabens, você ganhou!");
                Console.Read();
                return true;
            }
            return false;
        }
    }
}
