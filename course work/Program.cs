using System;

namespace course_work
{
    public class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        static void Main(string[] args)
        {
            
            Board board = new Board();
            GameState state = new GameState(board);
            Game game = new Game(state);
            game.Run();
        }
        
    }
}
