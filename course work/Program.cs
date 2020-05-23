using System;

namespace course_work
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CheckerBoard test = new CheckerBoard();


           
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(test.MatrixBoard[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
          

        }
    }
}
