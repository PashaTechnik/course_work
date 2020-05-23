using System;

namespace course_work
{
    public class CheckerBoard
    {
        static public string Board =  "+—+———+———+———+———+———+———+———+———+" +
                                      "|8|   | 2 |   | 2 |   | 2 |   | 2 |" +
                                      "+—+———+———+———+———+———+———+———+———+" +
                                      "|7| 2 |   | 2 |   | 2 |   | 2 |   |" + 
                                      "+—+———+———+———+———+———+———+———+———+" +
                                      "|6|   | 2 |   | 2 |   | 2 |   | 2 |" +
                                      "+—+———+———+———+———+———+———+———+———+" +
                                      "|5|   |   |   |   |   |   |   |   |" +
                                      "+—+———+———+———+———+———+———+———+———+" +
                                      "|4|   |   |   |   |   |   |   |   |" +
                                      "+—+———+———+———+———+———+———+———+———+" +
                                      "|3| 1 |   | 1 |   | 1 |   | 1 |   |" + 
                                      "+—+———+———+———+———+———+———+———+———+" +
                                      "|2|   | 1 |   | 1 |   | 1 |   | 1 |" +
                                      "+—+———+———+———+———+———+———+———+———+" +
                                      "|1| 1 |   | 1 |   | 1 |   | 1 |   |" +
                                      "+—+———+———+———+———+———+———+———+———+" +
                                      "| a | b | c | d | e | f | g | h |";


public void UpdateBoard()
        {
            Board =  "+—+———+———+———+———+———+———+———+———+" +
                     $"|8| {MatrixBoard[0,0]} | {MatrixBoard[0,1]} | {MatrixBoard[0,2]} | {MatrixBoard[0,3]} | {MatrixBoard[0,4]} | {MatrixBoard[0,5]} | {MatrixBoard[0,6]} | {MatrixBoard[0,7]} |" +
                     "+—+———+———+———+———+———+———+———+———+" +
                     $"|7| {MatrixBoard[1,0]} | {MatrixBoard[1,1]} | {MatrixBoard[1,2]} | {MatrixBoard[1,3]} | {MatrixBoard[1,4]} | {MatrixBoard[1,5]} | {MatrixBoard[1,6]} | {MatrixBoard[7,7]} |" + 
                     "+—+———+———+———+———+———+———+———+———+" +
                     $"|6| {MatrixBoard[2,0]} | {MatrixBoard[2,1]} | {MatrixBoard[2,2]} | {MatrixBoard[2,3]} | {MatrixBoard[2,4]} | {MatrixBoard[2,5]} | {MatrixBoard[2,6]} | {MatrixBoard[7,7]} |" +
                     "+—+———+———+———+———+———+———+———+———+" +
                     $"|5| {MatrixBoard[3,0]} | {MatrixBoard[3,1]} | {MatrixBoard[3,2]} | {MatrixBoard[3,3]} | {MatrixBoard[3,4]} | {MatrixBoard[3,5]} | {MatrixBoard[3,6]} | {MatrixBoard[7,7]} |" +
                     "+—+———+———+———+———+———+———+———+———+" +
                     $"|4| {MatrixBoard[4,0]} | {MatrixBoard[4,1]} | {MatrixBoard[4,2]} | {MatrixBoard[4,3]} | {MatrixBoard[4,4]} | {MatrixBoard[4,5]} | {MatrixBoard[4,6]} | {MatrixBoard[7,7]} |" +
                     "+—+———+———+———+———+———+———+———+———+" +
                     $"|3| {MatrixBoard[5,0]} | {MatrixBoard[5,1]} | {MatrixBoard[5,2]} | {MatrixBoard[5,3]} | {MatrixBoard[5,4]} | {MatrixBoard[5,5]} | {MatrixBoard[5,6]} | {MatrixBoard[7,7]} |" + 
                     "+—+———+———+———+———+———+———+———+———+" +
                     $"|2| {MatrixBoard[6,0]} | {MatrixBoard[6,1]} | {MatrixBoard[6,2]} | {MatrixBoard[6,3]} | {MatrixBoard[6,4]} | {MatrixBoard[6,5]} | {MatrixBoard[6,6]} | {MatrixBoard[7,7]} |" +
                     "+—+———+———+———+———+———+———+———+———+" +
                     $"|1| {MatrixBoard[7,0]} | {MatrixBoard[7,1]} | {MatrixBoard[7,2]} | {MatrixBoard[7,3]} | {MatrixBoard[7,4]} | {MatrixBoard[7,5]} | {MatrixBoard[7,6]} | {MatrixBoard[7,7]} |" +
                     "+—+———+———+———+———+———+———+———+———+" +
                     "| a | b | c | d | e | f | g | h |";
            
        }


        public char[,] MatrixBoard = new char[8, 8]
        {
            {Board[39],Board[43],Board[47],Board[51],Board[55],Board[59],Board[63],Board[67]},
            {Board[109],Board[113],Board[117],Board[121],Board[125],Board[129],Board[133],Board[137]},
            {Board[179],Board[183],Board[187],Board[191],Board[195],Board[199],Board[203],Board[207]},
            {Board[249],Board[253],Board[257],Board[261],Board[265],Board[269],Board[273],Board[277]},
            {Board[319],Board[323],Board[327],Board[331],Board[335],Board[339],Board[343],Board[347]},
            {Board[389],Board[393],Board[397],Board[401],Board[405],Board[409],Board[413],Board[417]},
            {Board[459],Board[463],Board[467],Board[471],Board[475],Board[479],Board[483],Board[487]},
            {Board[529],Board[533],Board[537],Board[541],Board[545],Board[549],Board[553],Board[557]}

        };
        
        
        public bool CanMove(char a)
        {
            int queue = 1;
            if (a == '1')
            {
                if (queue == 1)
                {
                    queue = 2;
                    return true;
                }

                if (queue == 2)
                {
                    Console.WriteLine("Сейчас очередь первого игрока");
                    return false;
                }
            }

            if (a == '2')
            {
                if (queue == 2)
                {
                    queue = 1;
                    return true;
                }
                if (queue == 1)
                {
                    Console.WriteLine("Сейчас очередь второго игрока");
                    return false;
                }
            }

            return false;

        }
        
        


    }
}