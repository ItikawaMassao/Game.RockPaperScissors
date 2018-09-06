using Game.RockPaperScissors.Enum;
using Game.RockPaperScissors.Exceptions;
using Game.RockPaperScissors.Interfaces;

namespace Game.RockPaperScissors.Game
{
    public class Jogador : IJogador
    {
        private readonly string _nome;
        public Estrategia Estrategia { get; private set; }

        public Jogador(string nome, Estrategia estrategia)
        {
            if (default(Estrategia).Equals(estrategia))
                throw new NoSuchStrategyException("Estratégia inválida.");

            _nome = nome;
            Estrategia = estrategia;
        }

        public override string ToString()
        {
            return string.Format("Jogador: {0} [{1}]", _nome, Estrategia);
        }
    }
}