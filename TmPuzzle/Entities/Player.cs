namespace TmPuzzle.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public virtual List<PlayerSolves> SolvedEasterEggs { get; set; }
        public virtual List<PlayerPermission> Permissions { get; set; }
        //TODO OAuth?
    }
}
