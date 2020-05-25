namespace course_work
{
    public class PlayerMove : Command
    {
        
        
        CheckerBoard board = new CheckerBoard();

        public PlayerMove(CheckerBoard checkerBoard)
        {
            board = checkerBoard;
        }
        public override void Execute()
        {
            board.MakeMove();
        }
    }
}