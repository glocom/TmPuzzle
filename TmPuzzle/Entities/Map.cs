namespace TmPuzzle.Entities
{
    public class Map
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MapUid { get; set; }
        public virtual List<EasterEgg> EasterEggs { get; set; }
        public virtual List<CampaignMap> CampaignMaps { get; set; }
    }
}
