namespace TmPuzzle.Entities
{
    public class PlayerSolves
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int EasterEggId { get; set; }
        public DateTime SolvedDate { get; set; } = DateTime.UtcNow;
        public virtual Player Player { get; set; }
        public virtual EasterEgg EasterEgg { get; set; }
    }
}
