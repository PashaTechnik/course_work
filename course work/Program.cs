using System;

namespace course_work
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            CheckerBoard test = new CheckerBoard();
            test.EndGame();
            
            
            
            //GameContinuation game = new GameContinuation();
            
            
            
            /*String Choice;
            Console.WriteLine("Выбирите опцию:");
            Console.WriteLine("1.Начать новую игру");
            Console.WriteLine("2.Вывести рейтинг игроков");
            Choice = Console.ReadLine();
            do
            {
                switch (Choice)
                {
                    case "1":
                        
                    
                }
                
            } while (true);*/
            
            


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
