namespace TmPuzzle.Entities
{
    public class EasterEgg
    {
        public int Id { get; set; }
        public int MapId { get; set; }
        public virtual Map Map { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string ImageBlob { get; set; }
        public string MediaUrl { get; set; }
        public string Hint { get; set; }
        public string ManiaScript { get; set; }
        public virtual List<PlayerSolves> PlayerSolves { get; set; }
    }
}
