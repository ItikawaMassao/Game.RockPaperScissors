using System.Collections.Generic;

namespace Game.RockPaperScissors.Interfaces
{
    public interface IJogada
    {
        IJogador Jogar(IJogador primeiroJogador, IJogador segundoJogador);
    }
}