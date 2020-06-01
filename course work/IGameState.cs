using System.Collections.Generic;

namespace course_work
{
    public interface IGameState
    {
        /// <summary>
        /// Поиск всех возможных ходов для выбраной комманды
        /// </summary>

        IEnumerable<Move> ValidMoves();

        /// <summary>
        /// Показывает ход на доске
        /// </summary>
        void MakeMove(Move move);

        /// <summary>
        /// Проверка на все возможные ходы, что бы решить закончина ли игра
        /// </summary>
        bool GameOver();
    }
}