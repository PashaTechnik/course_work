namespace course_work
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Класс, представляющий текущее состояние игры
    /// </summary>
    public class GameState : IGameState
    {
        /// <summary>
        /// Экземпляр доски связан с этим игровым состоянием.
        /// </summary>
        private IBoard Board { get; set; }

        /// <summary>
        /// Текущий ход
        /// </summary>
        private Team CurrentTurn { get; set; }

        /// <summary>
        /// Инициализатор состояния игровой доски
        /// </summary>
        public GameState(IBoard board)
        {
            this.Board = board;
            this.CurrentTurn = Team.Red;
        }

        /// <summary>
        /// Поиск всех текущих ходов для текущей комманды
        /// </summary>
        public IEnumerable<Move> ValidMoves()
        {
            var moves = new List<Move>();
            foreach(var it in this.Board.Spaces
                .Select((Space, Index) => new { Space, Index })
                .Where(it => it.Space.Occupied() && it.Space.Piece.Team == this.CurrentTurn))
            {
                moves.AddRange(this.FindMoves(this.CurrentTurn, new Move(it.Index, it.Index)));
            }

            // Прыжок через шашку
            var jumpMoves = moves.Where(m => m.Jumps.Any());
            return jumpMoves.Any() ? jumpMoves : moves;
        }

        /// <summary>
        /// Показывает ход на доске
        /// </summary>
        /// <param name="move">Move to perform</param>
        public void MakeMove(Move move)
        {
            var fromSpace = this.Board.Spaces[move.From];
            var toSpace = this.Board.Spaces[move.To];

            toSpace.Place(fromSpace.Piece);
            fromSpace.Clear();

            if (move.KingMe)
            {
                toSpace.Piece.King = true;
            }

            move.Jumps.ForEach(j => this.Board.Spaces[j].Clear());

            // Переключить текущий ход
            this.CurrentTurn = (Team)((((int)this.CurrentTurn) + 1) % 2);
        }

        /// <summary>
        /// Проверка на окончание игры
        /// </summary>
        public bool GameOver()
        {
            return new int[] { this.PieceCount(Team.Red), this.PieceCount(Team.Black) }.Any(c => c == 0);
        }


        public override string ToString()
        {
            var turnMsg = string.Format("Сейчас ход команды {0}.", this.CurrentTurn);
            var winMsg = string.Format("Команда {0} выграла!", this.WinningTeam());

            return string.Format("{0}\n\n{1}", this.GameOver() ? winMsg : turnMsg, this.Board);
        }

        /// <summary>
        /// Решает команду-победителя
        /// </summary>
        private Team WinningTeam()
        {
            return this.PieceCount(Team.Red) > this.PieceCount(Team.Black) ? Team.Red : Team.Black;
        }

        /// <summary>
        /// Найти все ходы, начиная с начального хода
        /// </summary>
        private IEnumerable<Move> FindMoves(Team team, Move move)
        {
            var moves = new List<Move>();
            var multiplier = this.CurrentTurn == Team.Black ? 1 : -1;

            // Попробуйте оба направления вперед
            moves.AddRange(this.FindMoves(this.CurrentTurn, new Move(move), multiplier * 4));
            moves.AddRange(this.FindMoves(this.CurrentTurn, new Move(move), multiplier * 5));

            // Проверка шашки на Дамку, или этот ход сделает ее Дамкой
            if(this.Board.Spaces[move.From].Piece.King || move.KingMe)
            {
                moves.AddRange(this.FindMoves(this.CurrentTurn, new Move(move), -1 * multiplier * 4));
                moves.AddRange(this.FindMoves(this.CurrentTurn, new Move(move), -1 * multiplier * 5));
            }

            // Нельзя сделать ход
            if(!moves.Any() && move.To != move.From)
            {
                moves.Add(move);
            }
            return moves;
        }

        /// <summary>
        /// Найти все движения в одном направлении
        /// </summary>
        private IEnumerable<Move> FindMoves(Team team, Move move, int direction)
        {
            var moves = new List<Move>();
            var possibleSpace = this.Board.Spaces[move.To + direction];
            // Учитывайте только направление, если оно действительно, а мы его еще не перепрыгнули
            if(possibleSpace.Valid() && !move.Jumps.Contains(move.To + direction))
            {
                // Простой ход возможен. Если этот ход уже имеет прыжки, мы не можем делать простые движения
                if (!possibleSpace.Occupied() && !move.Jumps.Any())
                {
                    move.To += direction;
                    if(KingSpace(team, move.To))
                    {
                        move.KingMe = true;
                    }
                    moves.Add(move);
                }
                else if (possibleSpace.Occupied() && possibleSpace.Piece.Team != team)
                {
                    possibleSpace = this.Board.Spaces[move.To + 2 * direction];
                    // По крайней мере, один прыжок возможен
                    if (possibleSpace.Valid() && !possibleSpace.Occupied())
                    {
                        move.Jumps.Add(move.To + direction);
                        move.To += 2 * direction;
                        if(KingSpace(team, move.To))
                        {
                            move.KingMe = true;
                        }
                        // Рекурсивный поиск новых ходов для взятия шашки
                        moves.AddRange(this.FindMoves(team, move));
                    }
                }
            }
            return moves;
        }

        /// <summary>
        /// Проверка на дамку во время хода заданой комманды
        /// </summary>
        private bool KingSpace(Team team, int coord)
        {
            if(team == Team.Red && coord >= 5 && coord <= 8)
            {
                return true;
            }

            if(team == Team.Black && coord >= 37 && coord <= 40)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Подсчет оставшихся шашек переданой комманды
        /// </summary>
        private int PieceCount(Team team)
        {
            return this.Board.Spaces.Where(s => s.Occupied() && s.Piece.Team == team).Count();
        }
    }
}
