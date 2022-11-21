using TmPuzzle.Entities;

namespace TmPuzzle.Services
{
    public interface IPuzzleService
    {
        #region Campaigns
        public Task<List<Campaign>> GetCampaigns();
        public Task<Campaign> GetCampaign(int campaignId);
        public Task<Campaign> CreateCampaign(Campaign campaign);
        public Task<Campaign> UpdateCampaign(Campaign campaign);
        public void DeleteCampaign(int campaignId);
        #endregion

        #region Maps
        public Task<List<Map>> GetMaps();
        public Task<List<Map>> GetMapsForCampaign(int campaignId);
        public Task<Map> GetMap(int mapId);
        public Task<Map> CreateMap(Map map);
        public Task<Map> UpdateMap(Map map);
        public void DeleteMap(int mapId);
        #endregion

        #region EasterEggs
        public Task<List<EasterEgg>> GetEasterEggs();
        public Task<List<EasterEgg>> GetEasterEggsForMap(int mapId);
        public Task<List<EasterEgg>> GetEasterEggsForCampaign(int campaignId);
        public Task<EasterEgg> GetEasterEgg(int easterEggId);
        public Task<EasterEgg> CreateEasterEgg(EasterEgg easterEgg);
        public Task<EasterEgg> UpdateEasterEgg(EasterEgg easterEgg);
        public void DeleteEasterEgg(int easterEggId);
        #endregion

        #region Players
        public Task<List<Player>> GetPlayers();
        public Task<Player> GetPlayer(int playerId);
        public Task<Player> GetPlayer(string login);
        public Task<Player> CreatePlayer(Player player);
        public Task<Player> UpdatePlayer(Player player);
        public void DeletePlayer(int playerId);
        #endregion

        #region Permissions
        public Task<List<Permission>> GetPermissions();
        public Task<Permission> GetPermission(int permissionId);
        public Task<Permission> CreatePermission(Permission permission);
        public Task<Permission> UpdatePermission(Permission permission);
        public void DeletePermission(int permissionId);
        #endregion

        #region PlayerSolves
        public Task<List<PlayerSolves>> GetPlayerSolves(int playerId);
        public Task<PlayerSolves> GetPlayerSolve(int Id, int playerId);
        public Task<PlayerSolves> CreatePlayerSolve(PlayerSolves playerSolve);
        public Task<PlayerSolves> UpdatePlayerSolve(PlayerSolves playerSolve);
        public void DeletePlayerSolve(int playerSolveId);
        #endregion
    }
}
