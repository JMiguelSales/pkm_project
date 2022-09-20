using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_2tri_pkm
{
    class Interface_battle
    {
        public static void Frase(char obj)
        {
            string txt=" ";
            if(obj == 'X')
            {
                txt = "Um pokemon foi avistado";
                Interface_map.TextWrite(txt);
            }

            if (obj == 'N')
            {
                txt = "Vamos Batalhar";
                Interface_map.TextWrite(txt);
                
            }

        }
        
        public static List<int> vidas_player= new List<int>();
        public static int[,] Todos_Stats = { {0,0,0,0,0},{0,0,0,0,0}};
        public static List<int> vidas_bot = new List<int>();
        public static List<int> Mortos_Player = new List<int>();

        public static bool Desing(char inimigo)
        {
            Console.ReadLine();
            Bot.Time_Bot(inimigo);
            Bot.Vidas_temp_Bot();
            Jogador.Vidas_temp_Player();

            int ArrayAtivoPlyer = 0; //para controlar a posição que queremos e não mandar algúém fora da matriz
            int esco;
            int ChosenMove, Pkm_Jogador_ativo = Jogador.Id_pkm_Time[ArrayAtivoPlyer];//Uso o pkm ativo para puxar do Pokebank
            double DamageOutput_Player, DamageOutput_Bot; 

            Jogador.Stats_Pkm_ativo(Pkm_Jogador_ativo);
            Bot.Stats_Pkm_ativo();

            // inicio seleção de golpes
            while (true)
            { 
                DamageOutput_Player = 0.0;
                DamageOutput_Bot = 0.0;

                Console.Clear();
                esco=Design.Molde_batalha(Pkm_Jogador_ativo, ArrayAtivoPlyer);

                switch (esco) // para a escolha do plyer
                {
                   
                    case 1:
                       ChosenMove=Design.Molde_Menu_Moves(Pkm_Jogador_ativo);
                        if (PokeBank.dano[Pkm_Jogador_ativo, ChosenMove] < 0)
                            Logica_batalha.StatsModifier(ChosenMove,Pkm_Jogador_ativo,0, ArrayAtivoPlyer);
                       else
                       DamageOutput_Player=Logica_batalha.DamegeInput(Pkm_Jogador_ativo,ChosenMove,Bot.Id_pkm_Time_Bot[0],0);
                       //vidas_bot[ArraytivoBot] -= Convert.ToInt32(DamageOutput_Player);
                    break;
                    case 2:
                        ArrayAtivoPlyer = Jogador.Switch_Pkm(ArrayAtivoPlyer);
                        Pkm_Jogador_ativo = Jogador.Id_pkm_Time[ArrayAtivoPlyer];
                        Jogador.Stats_Pkm_ativo(Pkm_Jogador_ativo);
                    break;
                }

                ChosenMove=Bot.Move_Bot(Bot.Id_pkm_Time_Bot[0], Pkm_Jogador_ativo);// Escolha do bot
                Bot.Move_bot_log = ChosenMove;
                if (ChosenMove == -1 && vidas_bot.Count != 1)
                {//trocar caso ele não encontre um "bom" golpe

                    Bot.Troca_bot();
                    Bot.Stats_Pkm_ativo();
                }
                else if (ChosenMove != -1)// dar dano caso ao contrário
                {
                    if(PokeBank.dano[Bot.Id_pkm_Time_Bot[0],ChosenMove]<0)
                        Logica_batalha.StatsModifier(ChosenMove, Pkm_Jogador_ativo, 1, ArrayAtivoPlyer);
                    else
                    DamageOutput_Bot = Logica_batalha.DamegeInput(Bot.Id_pkm_Time_Bot[0], ChosenMove, Pkm_Jogador_ativo, 1);
                }
                else
                {
                    DamageOutput_Bot = 20.0;
                    vidas_bot[0] -= 20;
                }

                //Ordem dos ataques de acordo com a velocidade
                if (Todos_Stats[0, 4] >= Todos_Stats[1, 4])
                {
                    vidas_bot[0] -= Convert.ToInt32(DamageOutput_Player);
                    if (vidas_bot[0] <= 0)
                    {
                        vidas_bot.RemoveAt(0);
                        Bot.Id_pkm_Time_Bot.RemoveAt(0);
                        if(Bot.Morte_bot() == true)
                            return true;
                        Bot.Stats_Pkm_ativo();
                        Design.gambiarra = 10;
                 
                    }
                    vidas_player[ArrayAtivoPlyer] -= Convert.ToInt32(DamageOutput_Bot);
                    if (vidas_player[ArrayAtivoPlyer] <= 0)
                    {
                        Mortos_Player.Add(ArrayAtivoPlyer);
                        if (Jogador.Morte_player() == true)
                            return false;
                        vidas_player.RemoveAt(ArrayAtivoPlyer);
                        Jogador.Id_pkm_Time.RemoveAt(ArrayAtivoPlyer);
                        ArrayAtivoPlyer = Jogador.Switch_Pkm(ArrayAtivoPlyer);
                        Pkm_Jogador_ativo = Jogador.Id_pkm_Time[ArrayAtivoPlyer];
                        Jogador.Stats_Pkm_ativo(Pkm_Jogador_ativo);
                        
                    }

                }
                // caso bot seja mais rapido
                else 
                {
                    vidas_player[ArrayAtivoPlyer] -= Convert.ToInt32(DamageOutput_Bot);
                    if (vidas_player[ArrayAtivoPlyer] <= 0)
                    {
                        Mortos_Player.Add(ArrayAtivoPlyer);
                        if (Jogador.Morte_player() == true)
                            return false;
                        vidas_player.RemoveAt(ArrayAtivoPlyer);
                        Jogador.Id_pkm_Time.RemoveAt(ArrayAtivoPlyer);
                        ArrayAtivoPlyer = Jogador.Switch_Pkm(ArrayAtivoPlyer);
                        Pkm_Jogador_ativo = Jogador.Id_pkm_Time[ArrayAtivoPlyer];
                        Jogador.Stats_Pkm_ativo(Pkm_Jogador_ativo);
                        DamageOutput_Player= 0.0;
                       
                    }
                    vidas_bot[0] -= Convert.ToInt32(DamageOutput_Player);
                    if (vidas_bot[0] <= 0)
                    {
                       vidas_bot.RemoveAt(0);
                       Bot.Id_pkm_Time_Bot.RemoveAt(0);
                        if (Bot.Morte_bot() == true)
                            return true;
                        Bot.Stats_Pkm_ativo();
                        Design.gambiarra = 10;

                    }

                }
            }

        }
    }
 
}

