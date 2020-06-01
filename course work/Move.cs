namespace course_work
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Класс хода в игре в шашки
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Начальные координаты
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// Конечные координаты
        /// </summary>
        public int To { get; set; }

        /// <summary>
        /// Список забраных шашек
        /// </summary>
        public List<int> Jumps { get; private set; }

        /// <summary>
        /// Проверка на включение в ход Дамки
        /// </summary>
        public bool KingMe { get; set; }

        /// <summary>
        /// Инициализотов экземпляра класса Move
        /// </summary>
       
        public Move(int from, int to)
        {
            this.From = from;
            this.To = to;
            this.Jumps = new List<int>();
            this.KingMe = false;
        }

        /// <summary>
        /// Инициализотов экземпляра класса Move, копирующий другой экземпляр
        /// </summary>
        public Move(Move move)
        {
            this.From = move.From;
            this.To = move.To;
            this.Jumps = new List<int>();
            this.KingMe = move.KingMe;
            move.Jumps.ForEach(j => this.Jumps.Add(j));
        }
        
        public override string ToString()
        {
            var fromPt = this.CoordinateToPoint(this.From);
            var toPt = this.CoordinateToPoint(this.To);

            return string.Format("({0}, {1}) to ({2}, {3}) [{4}: Прыжки]", fromPt.X, fromPt.Y, toPt.X, toPt.Y, this.Jumps.Count);
        }

        /// <summary>
        /// Превращение координаты в точку(x, y)
        /// </summary>
        private Point CoordinateToPoint(int coord)
        {
            
            int nineRem;
            int nineDiv = Math.DivRem(coord, 9, out nineRem);
            int fourRem;
            int fourDiv = Math.DivRem(nineRem, 4, out fourRem);

            return new Point
            {
                X = this.MathModulo((-1 * fourDiv) + (2 * fourRem), 9),
                Y = (2 * nineDiv) + (nineRem - 1) / 4,
            };
        }

        
        private int MathModulo(int dividend, int divisor)
        {
            return (Math.Abs(dividend * divisor) + dividend) % divisor;
        }
    }
}
