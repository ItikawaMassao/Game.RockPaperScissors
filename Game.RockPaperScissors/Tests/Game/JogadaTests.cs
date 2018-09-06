using FluentAssertions;
using Game.RockPaperScissors.Enum;
using Game.RockPaperScissors.Exceptions;
using Game.RockPaperScissors.Game;
using Game.RockPaperScissors.Interfaces;
using NUnit.Framework;
using System.Collections;

namespace Game.RockPaperScissors.Tests.Game
{
    [TestFixture]
    public class JogadaTests
    {
        private static IJogador _jogadorArmando = new Jogador("Armando", Estrategia.Papel);
        private static IJogador _jogadorDave = new Jogador("Dave", Estrategia.Tesoura);
        private static IJogador _jogadorRichard = new Jogador("Richard", Estrategia.Pedra);

        private static IEnumerable ListaJogadas
        {
            get
            {
                yield return new TestCaseData(_jogadorArmando, _jogadorDave, _jogadorDave)
                    .SetName("[Jogador] Deve retornar jogador vencedor (Papel vs. Tesoura)");

                yield return new TestCaseData(_jogadorDave, _jogadorArmando, _jogadorDave)
                    .SetName("[Jogador] Deve retornar jogador vencedor (Tesoura vs. Papel)");

                yield return new TestCaseData(_jogadorRichard, _jogadorDave, _jogadorRichard)
                    .SetName("[Jogador] Deve retornar jogador vencedor (Pedra vs. Tesoura)");

                yield return new TestCaseData(_jogadorDave, _jogadorRichard, _jogadorRichard)
                    .SetName("[Jogador] Deve retornar jogador vencedor (Tesoura vs. Pedra)");

                yield return new TestCaseData(_jogadorRichard, _jogadorArmando, _jogadorArmando)
                    .SetName("[Jogador] Deve retornar jogador vencedor (Pedra vs. Papel)");

                yield return new TestCaseData(_jogadorArmando, _jogadorRichard, _jogadorArmando)
                    .SetName("[Jogador] Deve retornar jogador vencedor (Papel vs. Pedra)");

                yield return new TestCaseData(_jogadorDave, new Jogador("Pedra", Estrategia.Pedra), _jogadorRichard)
                    .SetName("[Jogador] Deve retornar jogador vencedor (Pedra vs. Pedra)");

                yield return new TestCaseData(_jogadorArmando, new Jogador("Papel", Estrategia.Papel), _jogadorArmando)
                    .SetName("[Jogador] Deve retornar jogador vencedor (Papel vs. Papel)");

                yield return new TestCaseData(_jogadorRichard, new Jogador("Tesoura", Estrategia.Tesoura), _jogadorRichard)
                    .SetName("[Jogador] Deve retornar jogador vencedor (Tesoura vs. Tesoura)");
            }
        }

        private static IEnumerable ListaJogadores
        {
            get
            {
                yield return new TestCaseData(null, _jogadorDave)
                    .SetName("[Jogador] Deve lançar exceção quando primeiro jogador nulo");

                yield return new TestCaseData(_jogadorArmando, null)
                    .SetName("[Jogador] Deve lançar exceção quando segundo jogador nulo");
            }
        }

        private IJogador Jogar(IJogador primeiroJogador, IJogador segundoJogador)
        {
            return new Jogada().Jogar(primeiroJogador, segundoJogador);
        }

        [TestCaseSource("ListaJogadas")]
        public void Deve_retornar_jogador_vencedor(IJogador primeiroJogador, IJogador segundoJogador, IJogador vencedorEsperado)
        {
            var jogadorVencedor = Jogar(primeiroJogador, segundoJogador);
            jogadorVencedor.Should().BeEquivalentTo(vencedorEsperado);
        }

        [TestCaseSource("ListaJogadores")]
        public void Lanca_excecao_quando_numero_jogadores_invalido(IJogador primeiroJogador, IJogador segundoJogador)
        {
            var excecao = Assert.Throws<WrongNumberOfPlayersException>(() => Jogar(primeiroJogador, segundoJogador));
            excecao.Message.Should().Be("Número de jogadores inválido.");
        }
    }
}