using Game.RockPaperScissors.Enum;
using Game.RockPaperScissors.Exceptions;
using Game.RockPaperScissors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.RockPaperScissors.Game
{
    public class Jogada : IJogada
    {
        private readonly IDictionary<Tuple<Estrategia, Estrategia>, Estrategia> _jogadaResolver;

        public Jogada()
        {
            _jogadaResolver = new Dictionary<Tuple<Estrategia, Estrategia>, Estrategia>
            {
                { new Tuple<Estrategia, Estrategia>(Estrategia.Pedra, Estrategia.Papel), Estrategia.Papel },
                { new Tuple<Estrategia, Estrategia>(Estrategia.Pedra, Estrategia.Tesoura), Estrategia.Pedra },
                { new Tuple<Estrategia, Estrategia>(Estrategia.Papel, Estrategia.Pedra), Estrategia.Papel },
                { new Tuple<Estrategia, Estrategia>(Estrategia.Papel, Estrategia.Tesoura), Estrategia.Tesoura },
                { new Tuple<Estrategia, Estrategia>(Estrategia.Tesoura, Estrategia.Pedra), Estrategia.Pedra },
                { new Tuple<Estrategia, Estrategia>(Estrategia.Tesoura, Estrategia.Papel), Estrategia.Tesoura },
            };
        }

        public IJogador Jogar(IJogador primeiroJogador, IJogador segundoJogador)
        {
            if (primeiroJogador == null || segundoJogador == null)
                throw new WrongNumberOfPlayersException("Número de jogadores inválido.");

            if (primeiroJogador.Estrategia.Equals(segundoJogador.Estrategia))
                return primeiroJogador;

            var jogada = new Tuple<Estrategia, Estrategia>(primeiroJogador.Estrategia, segundoJogador.Estrategia);

            var estrategiaVencedora = _jogadaResolver[jogada];
            return primeiroJogador.Estrategia.Equals(estrategiaVencedora) ? primeiroJogador : segundoJogador;
        }
    }
}