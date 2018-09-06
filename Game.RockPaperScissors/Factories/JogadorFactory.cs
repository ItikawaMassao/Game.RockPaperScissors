using Game.RockPaperScissors.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Game.RockPaperScissors.Enum;
using Game.RockPaperScissors.Game;

namespace Game.RockPaperScissors.Factories
{
    public static class JogadorFactory
    {
        public static ICollection<IJogador> Obter()
        {
            return new Collection<IJogador>
            {
                new Jogador("Armando", Estrategia.Papel),
                new Jogador("Dave", Estrategia.Tesoura),
                new Jogador("Richard", Estrategia.Pedra),
                new Jogador("Michael", Estrategia.Tesoura),
                new Jogador("Allen", Estrategia.Tesoura),
                new Jogador("Omer", Estrategia.Papel),
                new Jogador("David E.", Estrategia.Pedra),
                new Jogador("Richard X.", Estrategia.Papel)
            };
        }
    }
}