namespace TmPuzzle.Entities
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<CampaignMap> CampaignMaps { get; set; }
    }
}
