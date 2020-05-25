using System;

namespace course_work
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckerBoard test = new CheckerBoard();
    
            Console.WriteLine(CheckerBoard.Board);
            
            Player test1 = new Player();
            
            test1.SetCommand(new PlayerMove(test));
            
            test1.Move();
            


            /*for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.WriteLine(CheckerBoard.MatrixBoard[i,j]);
                }
            }*/


        }
    }


 
}
