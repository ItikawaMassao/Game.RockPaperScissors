using FluentAssertions;
using Game.RockPaperScissors.Enum;
using Game.RockPaperScissors.Game;
using Game.RockPaperScissors.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace Game.RockPaperScissors.Tests.Game
{
    [TestFixture]
    public class TorneioTests
    {
        private IJogador _jogadorVencedor;
        private IJogada _jogada;

        [SetUp]
        public void SetUp()
        {
            _jogadorVencedor = Substitute.For<IJogador>();
            _jogada = Substitute.For<IJogada>();
            _jogada.Jogar(Arg.Any<IJogador>(), Arg.Any<IJogador>()).ReturnsForAnyArgs(_jogadorVencedor);
        }

        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(16)]
        [TestCase(32)]
        public void Deve_realizar_torneio_com_diversos_jogadores(long quantidadeJogadores)
        {
            var listaJogadores = new List<IJogador> { _jogadorVencedor };
            for (var contador = 0; contador < quantidadeJogadores; contador++)
                listaJogadores.Add(new Jogador(contador.ToString(), Estrategia.Papel));

            var processoLog = new StringBuilder();
            var torneio = new Torneio(_jogada, listaJogadores);
            torneio.Jogar((mensagem) => processoLog.AppendLine(mensagem));
            processoLog.Length.Should().BeGreaterThan(0);
            torneio.Vencedor.Should().BeEquivalentTo(_jogadorVencedor);
        }
    }
}