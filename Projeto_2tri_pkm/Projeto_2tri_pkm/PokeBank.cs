using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projeto_2tri_pkm.Logica_batalha;

namespace Projeto_2tri_pkm
{
    internal class PokeBank
    {
        public static string[] pkms = { "Umbreon", "Garchomp", "Gyarados", "Blissey", "Chandelure", "Hawlucha", "Venusaur", "Jolteon", "Lugia", "Arcanine", "Steelix", "Lapras"};

        public static int[,] stats = {     {331,166,256,156,296,166},
                                           {357,296,226,196,206,240},
                                           {331,286,194,156,236,198},
                                           {651,25,56,186,306,146},
                                           {261,115,216,326,216,196},
                                           {297,220,186,184,162,272},
                                           {301,169,202,236,236,196},
                                           {271,135,156,256,226,296},
                                           {353,185,296,216,344,256},
                                           {321,255,196,236,196,226},
                                           {291,206,436,146,166,96},
                                           {401,175,196,206,226,156}};

        public static string[,] golpes = { {"Dark Pulse","Wish","Reflect","Crunch"},
                                           {"Earthquake","Dragon Claw","Iron Head","Swords Dance"},
                                           {"Bounce","Waterfall","Ice Fang","Dragon Dance" },
                                           {"Seismic Toss","Light Screen","Reflect","Soft-Boiled"},
                                           {"Shadow Ball","Fire Blast","Psychic","Energy Ball" },
                                           {"Acrobatics","Cross Chop","Bulk up","X-Scissor"},
                                           { "Sludge Bomb", "Giga Drain", "Earth Power", "Synthesis"},
                                           { "Thunderbolt","Shadow Ball",  "Volt Switch", "Protect"},
                                           { "Aeroblast", "Psychic","Surf","Light Screen"},
                                           { "Wild Charge","Flare Blitz", "Close Combat ","Play Rough"},
                                           { "Earthquake", "Head Smash","Heavy Slam","Explosion"  },
                                           { "Ice Beam"," Dragon Pulse","Hydro Pump", "Zen Headbutt" }};
        

        public static int[,] dano= { {80, -1, -4, 79},
                                     {99, 79, 79, -5 },
                                     {85, 79, 65, -7 },
                                     {100, -3, -4, 100 },
                                     {80, 110, 90, 90 },
                                     {109, 99, -5, 79 },
                                     {90,76,90,-1 },
                                      {90,80,70/*troca*/,70 },
                                      {100,90,90,-4 },
                                      {89,119,119,89},
                                      {99,149,99,249},
                                      {90,86,110,79}};

        public static Tipo[,] pkmTipo = { { Logica_batalha.Tipo.Dark, Logica_batalha.Tipo.Nulo},
                                              { Logica_batalha.Tipo.Dragao, Logica_batalha.Tipo.Terra},
                                              { Logica_batalha.Tipo.Agua, Logica_batalha.Tipo.Voador},
                                              { Logica_batalha.Tipo.Normal, Logica_batalha.Tipo.Nulo},
                                              { Logica_batalha.Tipo.Fogo, Logica_batalha.Tipo.Fantasma},
                                              { Logica_batalha.Tipo.Lutador, Logica_batalha.Tipo.Voador},
                                          {Logica_batalha.Tipo.Grama ,Logica_batalha.Tipo.Veneno},//"Planta","Veneno"
                                          {Logica_batalha.Tipo.Eletrico, Logica_batalha.Tipo.Nulo},//"Eletrico","Nulo"
                                          {Logica_batalha.Tipo.Voador, Logica_batalha.Tipo.Psiquico},//"Voador","Psiquico"
                                          {Logica_batalha.Tipo.Fogo, Logica_batalha.Tipo.Nulo},//"Fogo","Nulo"
                                          {Logica_batalha.Tipo.Metal, Logica_batalha.Tipo.Pedra},//"Metal","Pedra"
                                          {Logica_batalha.Tipo.Agua, Logica_batalha.Tipo.Gelo},};//"Agua","Gelo"};

        public static Tipo[,] danoTipo = { { Logica_batalha.Tipo.Dark, Logica_batalha.Tipo.Nulo, Logica_batalha.Tipo.Nulo, Logica_batalha.Tipo.Dark},
                                               { Logica_batalha.Tipo.Terra, Logica_batalha.Tipo.Dragao, Logica_batalha.Tipo.Metal, Logica_batalha.Tipo.Nulo},
                                               { Logica_batalha.Tipo.Voador, Logica_batalha.Tipo.Agua, Logica_batalha.Tipo.Gelo, Logica_batalha.Tipo.Nulo},
                                               { Logica_batalha.Tipo.Lutador, Logica_batalha.Tipo.Nulo, Logica_batalha.Tipo.Nulo, Logica_batalha.Tipo.Nulo},
                                               { Logica_batalha.Tipo.Fantasma, Logica_batalha.Tipo.Fogo, Logica_batalha.Tipo.Psiquico, Logica_batalha.Tipo.Grama},
                                               { Logica_batalha.Tipo.Voador, Logica_batalha.Tipo.Lutador, Logica_batalha.Tipo.Nulo, Logica_batalha.Tipo.Inseto},
                                             { Logica_batalha.Tipo.Veneno, Logica_batalha.Tipo.Grama, Logica_batalha.Tipo.Terra, Logica_batalha.Tipo.Nulo },
                                           { Logica_batalha.Tipo.Eletrico, Logica_batalha.Tipo.Fantasma,Logica_batalha.Tipo.Eletrico, Logica_batalha.Tipo.Normal},
                                           { Logica_batalha.Tipo.Voador,Logica_batalha.Tipo.Psiquico,Logica_batalha.Tipo.Agua,Logica_batalha.Tipo.Nulo},
                                           { Logica_batalha.Tipo.Eletrico,Logica_batalha.Tipo.Fogo,Logica_batalha.Tipo.Lutador,Logica_batalha.Tipo.Fada},//"Eletrico", "Fogo", "Lutador", "Fada"
                                           { Logica_batalha.Tipo.Terra,Logica_batalha.Tipo.Pedra,Logica_batalha.Tipo.Metal,Logica_batalha.Tipo.Normal},//"Terra", "Pedra", "Metal", "Normal" 
                                           { Logica_batalha.Tipo.Gelo,Logica_batalha.Tipo.Dragao,Logica_batalha.Tipo.Agua,Logica_batalha.Tipo.Psiquico },};//"Gelo", "Dragao", "Agua", "Psiquico"};
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