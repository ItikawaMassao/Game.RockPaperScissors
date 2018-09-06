using FluentAssertions;
using Game.RockPaperScissors.Enum;
using Game.RockPaperScissors.Exceptions;
using Game.RockPaperScissors.Game;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections;

namespace Game.RockPaperScissors.Tests.Game
{
    [TestFixture]
    public class JogadorTests
    {
        private const string NOME_JOGADOR_PADRAO = "Jogador Padrão";

        private static IEnumerable ListaEstrategia
        {
            get
            {
                yield return new TestCaseData(Estrategia.Papel)
                    .SetName("[Jogador] Deve apresentar a estratégia do jogador (Papel)");

                yield return new TestCaseData(Estrategia.Tesoura)
                    .SetName("[Jogador] Deve apresentar a estratégia do jogador (Tesoura)");

                yield return new TestCaseData(Estrategia.Pedra)
                    .SetName("[Jogador] Deve apresentar a estratégia do jogador (Pedra)");
            }
        }

        private static IEnumerable ListaJogadores
        {
            get
            {
                yield return new TestCaseData("Armando", Estrategia.Papel)
                    .SetName("[Jogador] Deve apresentar nome e estratégia do jogador (Armando/Papel)");

                yield return new TestCaseData("Dave", Estrategia.Tesoura)
                    .SetName("[Jogador] Deve apresentar nome e estratégia do jogador (Dave/Tesoura)");

                yield return new TestCaseData("Richard", Estrategia.Pedra)
                    .SetName("[Jogador] Deve apresentar nome e estratégia do jogador (Richard/Pedra)");
            }
        }

        [TestCaseSource("ListaEstrategia")]
        public void Deve_apresentar_estrategia_jogador(Estrategia estrategiaEsperada)
        {
            var jogador = new Jogador(NOME_JOGADOR_PADRAO, estrategiaEsperada);
            jogador.Estrategia.Should().BeEquivalentTo(estrategiaEsperada);
        }

        [TestCaseSource("ListaJogadores")]
        public void Deve_retornar_nome_e_estrategia_jogador(string nomeJogador, Estrategia estrategiaJogador)
        {
            var jogadorEsperado = string.Format("Jogador: {0} [{1}]", nomeJogador, estrategiaJogador);
            var jogador = new Jogador(nomeJogador, estrategiaJogador);
            jogador.ToString().Should().Be(jogadorEsperado);
        }

        [Test]
        public void Deve_lancar_excecao_quando_estrategia_invalida()
        {
            var excecao = Assert.Throws<NoSuchStrategyException>(() => new Jogador(NOME_JOGADOR_PADRAO, Estrategia.None));
            excecao.Message.Should().Be("Estratégia inválida.");
        }
    }
}