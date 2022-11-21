namespace TmPuzzle.Entities
{
    public class CampaignMap
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int MapId { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual Map Map { get; set; }
    }
}
