namespace course_work
{
    public interface IBoardState
    {
        public void RestartGame(CheckerBoard board);
        public void EndGame(CheckerBoard board);
    }
}