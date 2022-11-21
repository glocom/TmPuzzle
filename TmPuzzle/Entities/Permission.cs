namespace TmPuzzle.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<PlayerPermission> PlayerPermissions { get; set; }
    }
}
