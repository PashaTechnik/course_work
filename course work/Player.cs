using System;
namespace course_work
{
    public class Player
    {
        
        
        Command command;
        public Player() { }
 
        public void SetCommand(Command com)
        {
            command = com;
        }
 
        public void Move()
        {
            command.Execute();
        }
        
        
        
    }
}