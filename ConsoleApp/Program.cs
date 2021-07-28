using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            var player1 = game.CreatePlayer("player1");
            var player2 = game.CreatePlayer("player2");
            var player3 = game.CreatePlayer("player3");
            var player4 = game.CreatePlayer("player4");
            var player5 = game.CreatePlayer("player5");
            
            game.CreateRoom("room1", player1);
            game.ConnectToRoom("room1", player2);
            game.ConnectToRoom("room1", player3);
            game.ConnectToRoom("room1", player4);
            //game.ConnectToRoom("room1", player5);
            
            player1.SetState(PlayerState.Ready);
            player2.SetState(PlayerState.Ready);
            player4.SetState(PlayerState.Ready);
            
            game.Start("room1");
            
            Console.WriteLine("Player states");
            Console.WriteLine(player1.PlayerState);
            Console.WriteLine(player2.PlayerState);
            Console.WriteLine(player3.PlayerState);
            Console.WriteLine(player4.PlayerState);
            Console.WriteLine(player5.PlayerState);
            
            Console.WriteLine("Can players read and write in chat?");
            Console.WriteLine(player1.CanReadAndWriteInChat());
            Console.WriteLine(player2.CanReadAndWriteInChat());
            Console.WriteLine(player3.CanReadAndWriteInChat());
            Console.WriteLine(player4.CanReadAndWriteInChat());
            Console.WriteLine(player5.CanReadAndWriteInChat());

        }
    }
}