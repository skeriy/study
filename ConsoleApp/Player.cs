namespace ConsoleApp
{
    public class Player
    {
        private string _name;
        public PlayerState PlayerState { get; private set; }

        public Player(string name)
        {
            _name = name;
            PlayerState = PlayerState.NotConnected;
        }

        public void SetState(PlayerState state)
        {
            PlayerState = state;
        }

        public bool CanReadAndWriteInChat()
        {
            return PlayerState == PlayerState.Ready;
        }
    }
}