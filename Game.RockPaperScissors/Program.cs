using System;
using Game.RockPaperScissors.Game;

namespace Game.RockPaperScissors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var torneio = new Torneio();
            torneio.Jogar((mensagem) => Console.WriteLine(mensagem));
            Console.ReadKey();
        }
    }
}