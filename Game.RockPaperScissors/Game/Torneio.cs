using Game.RockPaperScissors.Extensions;
using Game.RockPaperScissors.Factories;
using Game.RockPaperScissors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.RockPaperScissors.Game
{
    public class Torneio
    {
        private readonly IJogada _jogada;
        private readonly ICollection<IJogador> _listaJogadores;
        public IJogador Vencedor { get; private set; }

        public Torneio(IJogada jogada, ICollection<IJogador> listaJogadores)
        {
            _jogada = jogada;
            _listaJogadores = listaJogadores;
        }

        public Torneio()
            : this(new Jogada(), JogadorFactory.Obter())
        {
        }

        public void Jogar(Action<string> metodoImpressao)
        {
            var listaJogadoresAtivos = _listaJogadores;
            metodoImpressao(string.Format("Início torneio com {0} jogadores{1}", _listaJogadores.Count, Environment.NewLine));
            var contador = 0;
            while (listaJogadoresAtivos.ContainsValue() && listaJogadoresAtivos.Count() > 1)
            {
                var jogadoresJogada = listaJogadoresAtivos.Take(2);
                listaJogadoresAtivos = listaJogadoresAtivos.Except(jogadoresJogada).ToList();
                var primeiroJogador = jogadoresJogada.FirstOrDefault();
                var segundoJogador = jogadoresJogada.LastOrDefault();
                metodoImpressao(string.Format("Jogada {0}: {1}{2} vs. {3}", ++contador, Environment.NewLine, primeiroJogador, segundoJogador));
                var vencedorJogada = _jogada.Jogar(primeiroJogador, segundoJogador);
                listaJogadoresAtivos.Add(vencedorJogada);

                metodoImpressao(string.Format("Vencedor: {0}", vencedorJogada));
            }

            Vencedor = listaJogadoresAtivos.FirstOrDefault();
            metodoImpressao(string.Format("{0}Fim do torneio{0}{0}Vencedor:{0}{0}\t{1}", Environment.NewLine, Vencedor));
        }
    }
}