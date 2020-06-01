namespace course_work
{
    public class Space
    {
        /// <summary>
        /// Все состояния доски
        /// </summary>
        private enum SpaceState
        {
            Empty,
            Invalid,
            Occupied
        }

        /// <summary>
        /// Получает новую недоступную клетку
        /// </summary>
        public static Space Invalid
        {
            get
            {
                return new Space
                {
                    State = SpaceState.Invalid,
                };
            }
        }

        /// <summary>
        /// Получает новую пустую клетку
        /// </summary>
        public static Space Empty
        {
            get
            {
                return new Space
                {
                    State = SpaceState.Empty,
                };
            }
        }

        /// <summary>
        /// Клетка поля для красной шашки
        /// </summary>
        public static Space Red
        {
            get
            {
                return new Space
                {
                    State = SpaceState.Occupied,
                    Piece = new Piece(Team.Red)
                };
            }
        }

        /// <summary>
        /// Клетка поля для черной шашки
        /// </summary>
        public static Space Black
        {
            get
            {
                return new Space
                {
                    State = SpaceState.Occupied,
                    Piece = new Piece(Team.Black)
                };
            }
        }

        /// <summary>
        /// Получает текущую шашку на клетке
        /// </summary>
        public Piece Piece { get; private set; }

        /// <summary>
        /// Получает или задает текущее состояние клетки
        /// </summary>
        private SpaceState State { get; set; }

        /// <summary>
        /// Проверка на занятость клетки
        /// </summary>
        public bool Occupied()
        {
            return this.State == SpaceState.Occupied;
        }

        /// <summary>
        /// Проверка на доступность клетки
        /// </summary>
        public bool Valid()
        {
            return this.State != SpaceState.Invalid;
        }

        /// <summary>
        /// Расположение шашки на клетке
        /// </summary>
        public void Place(Piece piece)
        {
            this.Piece = piece;
            this.State = SpaceState.Occupied;
        }

        /// <summary>
        /// Очищает клетку
        /// </summary>
        public void Clear()
        {
            this.Piece = null;
            this.State = SpaceState.Empty;
        }
        
        
        public override string ToString()
        {
            switch(this.State)
            {
                case SpaceState.Empty:
                    return " ";
                case SpaceState.Invalid:
                    return string.Empty;
                case SpaceState.Occupied:
                    return this.Piece.ToString();
                default:
                    return null;
            }
        }
    }
}