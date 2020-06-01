using System;
using System.Linq;

namespace course_work
{

    /// <summary>
    /// Класс, представляющий игру в шашки
    /// </summary>
    public class Game : IGame
    {
        /// <summary>
        /// Экземпляр состояния игры
        /// </summary>
        private IGameState State { get; set; }

        /// <summary>
        /// Инициализаця экземпляра класса Game
        /// </summary>
        public Game(IGameState state)
        {
            this.State = state;
        }

        /// <summary>
        /// Запуск цикла игры
        /// </summary>
        public void Run()
        {

            while(!this.State.GameOver())
            {
                // Вывод текущего состояния
                Console.WriteLine(this.State);

                // Ход игрока
                Console.WriteLine("Список допустимых ходов:");
                var moves = this.State.ValidMoves().ToList();
                foreach(var it in moves.Select((Move, i) => new { Move, Index = i + 1 }))
                {
                    Console.Write("{0}. ", it.Index);
                    Console.WriteLine(it.Move);
                }
                Console.WriteLine();
                int move = this.ReadMove(moves.Count());

                // Сделать ход
                this.State.MakeMove(moves[move - 1]);

                Console.WriteLine();
            }

            Console.WriteLine(this.State);
            Console.Write("Нажмите enter для выхода: ");
            Console.ReadLine();
        }

        /// <summary>
        /// Считывание с консоли, пока пользователь не введет число в правильном диапазоне
        /// </summary>
        private int ReadMove(int max)
        {
            int move;
            while(true)
            {
                Console.Write("Выберите номер хода: ");
                var input = Console.ReadLine();
                if(Int32.TryParse(input, out move))
                {
                    if(move > 0 && move <= max)
                    {
                        break;
                    }
                }

                Console.WriteLine("Выберите номер хода из всех доступных ходов:");
            }
            return move;
        }
        
    }
}
