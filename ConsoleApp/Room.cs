using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Room
    {
        private readonly List<Player> _playersInRoom = new();
        private const int MaxPlayers = 4;
        private const int MaxReadyPlayers = 2;
        public string Name { get; }
        public bool InGame { get; private set; }

        public Room(string name, Player creator)
        {
            Name = name;
            AddToRoom(creator);
            InGame = false;
        }

        public void ConnectNewPlayer(Player player)
        {
            if (!InGame && _playersInRoom.Count < MaxPlayers)
            {
                AddToRoom(player);
            }
            else
            {
                throw new IndexOutOfRangeException($"Max players are {MaxPlayers}. Connect to another room.");
            }
        }
        
        public void Start()
        {
            if (!InGame && _playersInRoom.Count >= MaxReadyPlayers)
            {
                InGame = true;
            }
            else
            {
                throw new ApplicationException($"Room have not {MaxReadyPlayers} ready players or game was start.");
            }
        }

        private void AddToRoom(Player player)
        {
            _playersInRoom.Add(player);
            player.SetState(PlayerState.InRoom);
        }
    }
}