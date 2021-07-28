using System.Collections.Generic;

namespace ConsoleApp
{
    public class Game
    {
        private List<Room> _rooms = new();

        public Player CreatePlayer(string name)
        {
            return new(name);
        }

        public void CreateRoom(string name, Player creator)
        {
            _rooms.Add(new Room(name, creator));
        }

        public void ConnectToRoom(string roomName, Player player)
        {
            GetRoomByName(roomName).ConnectNewPlayer(player);
            
        }

        public void Start(string roomName)
        {
            GetRoomByName(roomName).Start();
        }

        private Room GetRoomByName(string name)
        {
            var foundRoom = _rooms.Find(room => room.Name.Equals(name));
            if (foundRoom == null)
            {
                throw new KeyNotFoundException("Room not found");
            }
            return foundRoom;
        }
    }
}