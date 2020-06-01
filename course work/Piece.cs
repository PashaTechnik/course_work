namespace course_work
{
    /// <summary>
    /// Клас шашек
    /// </summary>
    public class Piece
    {
        /// <summary>
        /// Команда, которая владеет шашкой
        /// </summary>
        public Team Team { get; private set; }

        /// <summary>
        /// Шашка, которая вышла в дамки
        /// </summary>
        public bool King { get; set; }

        /// <summary>
        /// Инициализатор класса Piece
        /// </summary>

        public Piece(Team team)
        {
            this.Team = team;
            this.King = false;
        }
        
        public override string ToString()
        {
            switch(this.Team)
            {
                case Team.Red:
                    return this.King ? "R" : "r";
                case Team.Black:
                    return this.King ? "B" : "b";
                default:
                    return null;
            }
        }
    }
}
