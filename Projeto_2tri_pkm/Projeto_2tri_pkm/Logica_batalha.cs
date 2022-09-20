using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_2tri_pkm
{
    internal class Logica_batalha
    {
        public enum Tipo
        {
            Normal,
            Fogo,
            Agua,
            Grama,
            Eletrico,
            Gelo,
            Lutador,
            Veneno,
            Terra,
            Voador,
            Psiquico,
            Inseto,
            Pedra,
            Fantasma,
            Dragao,
            Dark,
            Metal,
            Fada,
            Nulo
        }

        // fazer ginásios           
         public static double[,] Efetividade = {

            {1.0, 1.0,  1.0,  1.0,  1.0, 1.0,  1.0,  1.0,  1.0,1.0,  1.0, 1.0, 0.5, 0.0,  1.0, 1.0, 0.5, 1.0, 1.0},//normal corrto
            {1.0, 0.5 ,0.5 ,2.0, 1.0, 2.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 0.5 ,1.0, 0.5, 1.0, 2.0, 1.0,1.0}, //F0go correto
            {1.0, 2.0, 0.5, 0.5, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 1.0, 2.0, 1.0, 0.5, 1.0, 1.0, 1.0,1.0},//agua corretp
            {1.0, 0.5, 2.0, 0.5, 1.0, 1.0, 1.0, 0.5, 2.0, 0.5, 1.0, 0.5, 2.0, 1.0 ,0.5, 1.0, 0.5, 1.0, 1.0},//grama correto
            {1.0, 1.0, 2.0, 0.5, 0.5, 1.0, 1.0, 1.0, 0.0, 2.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0, 1.0, 1.0 },//eletrique correto
            {1.0, 0.5, 0.5, 2.0, 1.0, 0.5, 1.0, 1.0, 2.0, 2.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 0.5,1.0,1.0}, // gelo
            {2.0, 1.0, 1.0, 1.0, 1.0, 2.0,1.0, 0.5, 1.0, 0.5, 0.5, 0.5, 2.0, 0.0, 1.0, 2.0, 2.0, 0.5, 1.0 }, // Lutador
            {1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 1.0, 0.5, 0.5, 1.0, 1.0, 1.0, 0.5, 0.5, 1.0, 1.0, 0.0, 2.0, 1.0},//Veneno
            {1.0, 2.0, 1.0, 0.5, 2.0, 1.0, 1.0, 2.0, 1.0, 0.0,1.0, 0.5, 2.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0,  },//terra
            {1.0, 1.0, 1.0, 2.0, 0.5,1.0, 2.0, 1.0, 1.0, 1.0, 1.0, 2.0, 0.5, 1.0, 1.0, 1.0, 0.5,1.0,1.0},//voador
            {1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 2.0, 1.0, 1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 0.0, 0.5, 1.0, 1.0 },//psiquico
            {1.0, 0.5,1.0, 2.0, 1.0, 1.0, 0.5, 0.5, 1.0, 0.5, 2.0, 1.0, 1.0, 0.5 ,1.0, 2.0, 0.5, 0.5, 1.0,},//inseto
            {1.0, 2.0, 1.0, 1.0, 1.0, 2.0, 0.5, 1.0, 0.5, 2.0, 1.0, 2.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0},//pedra
            {0.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 2.0, 1.0, 0.5, 1.0, 1.0, 1.0},// fantasma
            {1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 0.5, 0.0, 1.0 },//Dragao
            {1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 2.0, 1.0, 5.0, 1.0, 0.5, 1.0,},//dark
            {1.0, 0.5, 0.5, 1.0, 0.5, 2.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 1.0, 1.0, 0.5, 2.0, 1.0,},//metal
            {1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 2.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 2.0, 0.5, 1.0, 1.0 },//fada
            {1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 }//Nulo

        };
        // Linha= tipo golpe, coluna= tipo alvo

        public static double WeakResis(int PkmAttacker, int ChosenMove, int PkmDefender)
        {
            int TypeDamage = Convert.ToInt32(PokeBank.danoTipo[PkmAttacker, ChosenMove]);
            double TypeDamage_Result=1;

            int[] TypesDefensor = {Convert.ToInt32(PokeBank.pkmTipo[PkmDefender, 0]), Convert.ToInt32(PokeBank.pkmTipo[PkmDefender, 1]) };


            for(int i = 0; i < 2; i++)
            {
                TypeDamage_Result *= Efetividade[TypeDamage,TypesDefensor[i]];
            }
            return TypeDamage_Result;

        }

        public static double Stab(int PkmAttacker, int ChosenMove)
        {
            for (int i = 0; i < 2; i++)
                if (PokeBank.pkmTipo[PkmAttacker, i] == PokeBank.danoTipo[PkmAttacker, ChosenMove])
                    return 1.5;
            return 1.0;
        }
        
        public static double Critic()
        {
            int margin;
            Random rnd1 = new Random();
            margin = rnd1.Next(1, 256);
            if (margin == 255)
                return 2.0;
            return 1.0;
        }

        public static double DamegeInput(int PkmAttacker, int ChosenMove,int PkmDefender, int Position_Todos_Stats)
        {
            double DamageOutPut;
            if (PokeBank.dano[PkmAttacker, ChosenMove] % 2 == 0)
                 DamageOutPut = ((((2 * 100 / 5 + 2) * Interface_battle.Todos_Stats[Position_Todos_Stats, 2] * PokeBank.dano[PkmAttacker, ChosenMove] / Interface_battle.Todos_Stats[Position_Todos_Stats, 3]) / 50) + 2) * Stab(PkmAttacker, ChosenMove) * WeakResis(PkmAttacker, ChosenMove, PkmDefender) * Critic();
            else
                DamageOutPut = ((((2 * 100 / 5 + 2) * Interface_battle.Todos_Stats[Position_Todos_Stats, 0] * (PokeBank.dano[PkmAttacker, ChosenMove]+1) / Interface_battle.Todos_Stats[Position_Todos_Stats, 1]) / 50) + 2) * Stab(PkmAttacker, ChosenMove) * WeakResis(PkmAttacker, ChosenMove, PkmDefender) * Critic();
            return DamageOutPut;
        }

        public static void StatsModifier(int chosenMove, int Pkmativo, int gamb2,int posPlyer)
        {
            if(PokeBank.dano[Pkmativo, chosenMove] == -1)
            {
                if (gamb2 == 0)
                    Interface_battle.vidas_player[posPlyer] += Convert.ToInt32(Interface_battle.vidas_player[posPlyer] * 0.25);
                else
                    Interface_battle.vidas_bot[0] += Convert.ToInt32(Interface_battle.vidas_bot[0] * 0.25);
            }
            else if (PokeBank.dano[Pkmativo, chosenMove] == -3)
            {
                    Interface_battle.Todos_Stats[gamb2,3] = Convert.ToInt32(Interface_battle.Todos_Stats[0, 3] * 0.5);
            }
            else if (PokeBank.dano[Pkmativo, chosenMove] == -4)
            {
                Interface_battle.Todos_Stats[gamb2, 1] = Convert.ToInt32(Interface_battle.Todos_Stats[0, 1] * 0.5);
            }
            else if (PokeBank.dano[Pkmativo, chosenMove] == -5)
            {
                Interface_battle.Todos_Stats[gamb2, 0] = Convert.ToInt32(Interface_battle.Todos_Stats[0, 0] * 0.5);
            }
            else if (PokeBank.dano[Pkmativo, chosenMove] == -6)
            {
                Interface_battle.Todos_Stats[gamb2, 2] = Convert.ToInt32(Interface_battle.Todos_Stats[0, 2] * 0.5);
            }
            else if(PokeBank.dano[Pkmativo, chosenMove] == -7)
            {
                Interface_battle.Todos_Stats[gamb2, 4] = Convert.ToInt32(Interface_battle.Todos_Stats[0, 4] * 0.5);
            }

        }

    }
}

/*                      LEGENDA DOS ATAQUES
          
        -1= cura, 
        -2= proteger,
         -3= spd Buff;
         -4= df Buff; 
         -5 = atackBuff;
         -6 =spd Buff;
         -7= spe Buff;
        0= explosion;
  */