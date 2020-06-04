using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace course_work
{

    /// <summary>
    /// Класс, представляющий поле для шашек
    /// </summary>
    public class Board : IBoard
    {
        /// <summary>
        /// Словарь, отображающий 2D точки на клетках поля
        /// </summary>
        public Space[] Spaces { get; private set; }

        /// <summary>
        /// Инициализирует экземпляр класса Board
        /// </summary>
        public Board()
        {
            this.Spaces = new Space[46];
            this.Initialize();
        }

        /// <summary>
        /// Возвращает строку, которая представляет текущий объект
        /// </summary>
        /// <returns>Строковое представление</returns>
        public override string ToString()
        {
            // Текущий элемент для вывода
            var piecePointer = 5;
            var sb = new StringBuilder();

            // Три горизонтальные линии для закраски черных клеток
            var bar = "\u2550\u2550\u2550";
            // Повторяющийся кусок верхней полосы
            var top = String.Concat(Enumerable.Repeat(bar + "\u2566", 7));
            // Повторяющиеся куски средних полос
            var middle = String.Concat(Enumerable.Repeat(bar + "\u256C", 7));
            // Повторяющийся кусок нижней полосы
            var bottom = String.Concat(Enumerable.Repeat(bar + "\u2569", 7));

            // Номера колонок
            sb.Append("     1   2   3   4   5   6   7   8\n");
            // Верхняя полоса
            sb.AppendFormat("   \u2554{0}{1}\u2557\n", top, bar);
            
            foreach (var i in Enumerable.Range(0, 8))
            {
                
                sb.AppendFormat("{0}  ", i + 1);
                
                foreach (var j in Enumerable.Range(0, 8))
                {
                    // Вертикальная полоса
                    sb.Append("\u2551");
                    // Это часть квадрата, если обе координаты четные или обе нечетные
                    if (i % 2 == j % 2)
                    {
                        // Добавить пробел и переместить указатель
                        sb.AppendFormat(" {0} ", this.Spaces[piecePointer++]);
                        while (piecePointer % 9 == 0) ++piecePointer;
                    }
                    else
                    {
                        // Добавляет блок для черной клетки доски
                        sb.Append("\u2591\u2591\u2591");
                    }
                }
                // Заканчиваем вертикальной полосой
                sb.Append("\u2551\n");

                // Добавяем 7 средних полос
                if (i < 7)
                {
                    sb.AppendFormat("   \u2560{0}{1}\u2563\n", middle, bar);
                }
            }

            // Нижняя полоса
            sb.AppendFormat("   \u255A{0}{1}\u255D\n", bottom, bar);

            return sb.ToString();
        }

        /// <summary>
        /// Инициализируем поле для шашек
        /// </summary>
        private void Initialize()
        {
            foreach (var i in Enumerable.Range(0, this.Spaces.Length))
            {
                if (i % 9 == 0 || i < 5 || i > 40)
                {
                    this.Spaces[i] = Space.Invalid;
                }
                else if (i >= 5 && i <= 17)
                {
                    this.Spaces[i] = Space.Black;
                }
                else if (i >= 28 && i <= 40)
                {
                    this.Spaces[i] = Space.Red;
                }
                else
                {
                    this.Spaces[i] = Space.Empty;
                }
            }
        }
    }
}
