using Game.RockPaperScissors.Enum;

namespace Game.RockPaperScissors.Interfaces
{
    public interface IJogador
    {
        Estrategia Estrategia { get; }
    }
}