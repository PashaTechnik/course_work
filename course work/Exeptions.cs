using System;

namespace course_work
{
    public class CheckersExeption : ApplicationException // базовый класс исключений для нашей коллекции
    {
        private const string CheckersEceptionMessage = "(!) Problem with the checkers game-> ";
        public CheckersExeption() : base(String.Format("{0}", CheckersEceptionMessage)) { }
        public CheckersExeption(string s) : base(String.Format("{0}{1}", CheckersEceptionMessage, s)) { } // формируем Message-свойство -сообщение.
    }
    public class NoPathExeption :CheckersExeption // базовый класс исключений для нашей коллекции
    {
        private const string SelfMessage = " path doesn't exist -> ";
        public NoPathExeption() : base(String.Format("{0}", SelfMessage)) { }
        public NoPathExeption(string s) : base(String.Format("{0}{1}", SelfMessage, s)) { } // формируем Message-свойство -сообщение.
    }
    public class CantMoveExeption : CheckersExeption // базовый класс исключений для нашей коллекции
    {
        private const string SelfMessage = " can't move -> ";
        public CantMoveExeption() : base(String.Format("{0}", SelfMessage)) { }
        public CantMoveExeption(string s) : base(String.Format("{0}{1}", SelfMessage, s)) { } // формируем Message-свойство -сообщение.
    }
    public class CantBeatFriendlyUnitExeption : CheckersExeption // базовый класс исключений для нашей коллекции
    {
        private const string SelfMessage = "It's  friendly shachka -you can't beat it-> ";
        public CantBeatFriendlyUnitExeption() : base(String.Format("{0}", SelfMessage)) { }
        public CantBeatFriendlyUnitExeption(string s) : base(String.Format("{0}{1}", SelfMessage, s)) { } // формируем Message-свойство -сообщение.
    }
    public class CantMakeSoMoreSacrificesExeption : CheckersExeption // базовый класс исключений для нашей коллекции
    {
        private const string SelfMessage = " can't beat so more units at one motion -> ";
        public CantMakeSoMoreSacrificesExeption() : base(String.Format("{0}", SelfMessage)) { }
        public CantMakeSoMoreSacrificesExeption(string s) : base(String.Format("{0}{1}", SelfMessage, s)) { } // формируем Message-свойство -сообщение.
    }
}