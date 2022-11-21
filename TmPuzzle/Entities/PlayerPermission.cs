namespace TmPuzzle.Entities
{
    public class PlayerPermission
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int PermissionId { get; set; }
        public virtual Player Player { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
