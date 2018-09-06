using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using Game.RockPaperScissors.Extensions;

namespace Game.RockPaperScissors.Tests.Extensions
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        private IEnumerable<string> _listaNomes;

        private static IEnumerable ListaNomes
        {
            get
            {
                yield return new TestCaseData(
                    new Collection<string>
                    {
                        "Armando",
                        "Dave",
                        "Richard",
                        "Michael",
                        "Allen",
                        "Omer",
                        "David E.",
                        "Richard X."
                    }, true)
                    .SetName("[EnumerableExtensions] Deve retornar verdadeiro, quando conter os valores");

                yield return new TestCaseData(
                    new Collection<string>(), false)
                    .SetName("[EnumerableExtensions] Deve retornar falso, quando enumeração vazia");

                yield return new TestCaseData(null, false)
                    .SetName("[EnumerableExtensions] Deve retornar falso, quando enumeração nula");
            }
        }

        [TestCaseSource("ListaNomes")]
        public void Deve_verificar_existencia_valores_enumeracao(IEnumerable<string> lista, bool resultadoEsperado)
        {
            lista.ContainsValue().Should().Be(resultadoEsperado);
        }
    }
}