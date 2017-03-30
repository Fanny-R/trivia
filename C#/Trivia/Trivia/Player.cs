namespace Trivia
{
    class Player
    {
        public Player(string name)
        {
            Name = name;
            Place = 0;
            Purse = 0;
            IsInPenaltyBox = false;
        }

        public string Name { get; set; }

        public int Place { get; set; }

        public int Purse { get; set; }

        public bool IsInPenaltyBox { get; set; }
    }
}
