using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_2tri_pkm
{
    internal class Design
    {
        public static int gambiarra=10;
        public static int Molde_batalha(int Pkm_Jogador_ativo, int ArrayAtivoPlyer)
        {
            int esco;
            do
            {
                Console.Clear();
                Console.WriteLine("==========================================\n\tPokemon {0} Vida {1} \n==========================================\n", PokeBank.pkms[Bot.Id_pkm_Time_Bot[0]], Interface_battle.vidas_bot[0]);
                Console.WriteLine("\tLog de Batalha");
                for (int i = 0; i <8; i++)
                {
                    Console.Write("\t");
                    for (int j = 0; j <= 40; j++)
                    {
                        if (i == 0 || i == 7)
                            Console.Write("*");
                        if (i == 1 && j==0 && gambiarra!=10)
                            Log_batalha();
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("\n==========================================\n\tPokemon {0}  Vida {1} \n==========================================", PokeBank.pkms[Pkm_Jogador_ativo], Interface_battle.vidas_player[ArrayAtivoPlyer]);// ESTOU PUXANDO UM NUMERO DO MEU VETOR TIME E NÃO A POSIÇÃO
                Console.WriteLine("\t(1)Lutar\t(2)trocar\n\t(3)mochila\t(4)Fugir");
                esco = Convert.ToInt32(Console.ReadLine());
            } while (esco < 1 && esco > 4);
            gambiarra = 1;
            return esco;
        }

        public static int Molde_Menu_Moves(int Pkm_Jogador_ativo)
        {
            int ChosenMove, i = 1;

            Console.WriteLine("\t* * * Golpes * * *\n");
            for (int j = 0; j < 4; j++)
            {
                if (j == 2)
                    Console.WriteLine();
                Console.Write("\t({0}){1}", i, PokeBank.golpes[Pkm_Jogador_ativo, j]);
                i++;
            }
            return ChosenMove = Convert.ToInt32(Console.ReadLine()) - 1;
        }
        public static int Troca()
        {
            int switch_pkm,j=1;
            Console.WriteLine("\t* * * Troca * * *\t\n");
            for(int i = 0; i < Jogador.Id_pkm_Time.Count; i++)
            {
                Console.WriteLine("({0}) {1} {2} ",j,PokeBank.pkms[Jogador.Id_pkm_Time[i]],Interface_battle.vidas_player[i]);
                j++;
            }


            return switch_pkm = Convert.ToInt32(Console.ReadLine())-1;
        }
        public static void Log_batalha()
        {
            if (Bot.Move_bot_log >=0)
                Console.Write("O pokemon Adversário usou: {0}", PokeBank.golpes[Bot.Id_pkm_Time_Bot[0], Bot.Move_bot_log]);
            if(Bot.Move_bot_log == -1)
                Console.Write("O adversário trocou");
        }
        public static void Escolha_time()
        {
            int cont=0,temp;
            Console.WriteLine("Bem vindo treinador, escolha seu time! (todos estão lvl 100)\n\n");
            for(int j = 0; j < PokeBank.pkms.Length; j++)
            {
                Console.WriteLine("\n({0})Pokemon: {1},Tipos: {2} {3}\n",j+1,PokeBank.pkms[j],PokeBank.pkmTipo[j,0], PokeBank.pkmTipo[j, 1]);
                for(int i = 0; i <6; i++)
                {
                    Console.Write("Status: {0}", PokeBank.stats[j, i]);
                    if (i % 2 == 0)
                        Console.Write(" ");
                    else
                        Console.Write("\n");
                }
                Console.WriteLine();
                Console.Write("Golpes, Dano\n");
                for (int k = 0; k < 4; k++)
                {
                    Console.Write("{0} {1},", PokeBank.golpes[j, k], PokeBank.dano[j, k]);
                    if (k % 2 == 0)
                        Console.Write(" ");
                    else
                        Console.Write("\n");
                }
            }
            Console.WriteLine("\nDigite os pkms que quer utilizar (max 6)\n");
            while (cont < 6)
            {
                temp = Convert.ToInt32(Console.ReadLine()) - 1;
                if (!Jogador.Id_pkm_Time.Contains(temp))
                {
                    cont++;
                    Jogador.Id_pkm_Time.Add(temp);
                    Console.WriteLine("Pokemon Aceito");

                }

            }
        }
       
    }
}
