using TmPuzzle.Entities;
using TmPuzzle.Repositories;

namespace TmPuzzle.Services
{
    public class PuzzleService : IPuzzleService
    {
        private readonly IPuzzleRepository _puzzleRepository;
        public PuzzleService(IPuzzleRepository puzzleRepository)
        {
            _puzzleRepository = puzzleRepository;
        }

        #region Campaigns
        public async Task<List<Campaign>> GetCampaigns()
        {
            return await _puzzleRepository.GetCampaigns();
        }
        public async Task<Campaign> GetCampaign(int campaignId)
        {
            return await _puzzleRepository.GetCampaign(campaignId);
        }
        public async Task<Campaign> CreateCampaign(Campaign campaign)
        {
            return await _puzzleRepository.CreateCampaign(campaign);
        }
        public async Task<Campaign> UpdateCampaign(Campaign campaign)
        {
            return await _puzzleRepository.UpdateCampaign(campaign);
        }
        public void DeleteCampaign(int campaignId)
        {
            _puzzleRepository.DeleteCampaign(campaignId);
        }
        #endregion

        #region Maps
        public async Task<List<Map>> GetMaps()
        {
            return await _puzzleRepository.GetMaps();
        }
        public async Task<List<Map>> GetMapsForCampaign(int campaignId)
        {
            return await _puzzleRepository.GetMapsForCampaign(campaignId);
        }
        public async Task<Map> GetMap(int mapId)
        {
            return await _puzzleRepository.GetMap(mapId);
        }
        public async Task<Map> CreateMap(Map map)
        {
            return await _puzzleRepository.CreateMap(map);
        }
        public async Task<Map> UpdateMap(Map map)
        {
            return await _puzzleRepository.UpdateMap(map);
        }
        public void DeleteMap(int mapId)
        {
            _puzzleRepository.DeleteMap(mapId);
        }
        #endregion

        #region EasterEggs
        public async Task<List<EasterEgg>> GetEasterEggs()
        {
            return await _puzzleRepository.GetEasterEggs();
        }
        public async Task<List<EasterEgg>> GetEasterEggsForMap(int mapId)
        {
            return await _puzzleRepository.GetEasterEggsForMap(mapId);
        }
        public async Task<List<EasterEgg>> GetEasterEggsForCampaign(int campaignId)
        {
            return await _puzzleRepository.GetEasterEggsForCampaign(campaignId);
        }
        public async Task<EasterEgg> GetEasterEgg(int easterEggId)
        {
            return await _puzzleRepository.GetEasterEgg(easterEggId);
        }
        public async Task<EasterEgg> CreateEasterEgg(EasterEgg easterEgg)
        {
            return await _puzzleRepository.CreateEasterEgg(easterEgg);
        }
        public async Task<EasterEgg> UpdateEasterEgg(EasterEgg easterEgg)
        {
            return await _puzzleRepository.UpdateEasterEgg(easterEgg);
        }
        public void DeleteEasterEgg(int easterEggId)
        {
            _puzzleRepository.DeleteEasterEgg(easterEggId);
        }
        #endregion

        #region Players
        public async Task<List<Player>> GetPlayers()
        {
            return await _puzzleRepository.GetPlayers();
        }
        public async Task<Player> GetPlayer(int playerId)
        {
            return await _puzzleRepository.GetPlayer(playerId);
        }
        public async Task<Player> GetPlayer(string login)
        {
            return await _puzzleRepository.GetPlayer(login);
        }
        public async Task<Player> CreatePlayer(Player player)
        {
            return await _puzzleRepository.CreatePlayer(player);
        }
        public async Task<Player> UpdatePlayer(Player player)
        {
            return await _puzzleRepository.UpdatePlayer(player);
        }
        public void DeletePlayer(int playerId)
        {
            _puzzleRepository.DeletePlayer(playerId);
        }
        #endregion

        #region Permissions
        public async Task<List<Permission>> GetPermissions()
        {
            throw new NotImplementedException();
        }
        public async Task<Permission> GetPermission(int permissionId)
        {
            throw new NotImplementedException();
        }
        public async Task<Permission> CreatePermission(Permission permission)
        {
            throw new NotImplementedException();
        }
        public async Task<Permission> UpdatePermission(Permission permission)
        {
            throw new NotImplementedException();
        }
        public void DeletePermission(int permissionId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region PlayerSolves
        public async Task<List<PlayerSolves>> GetPlayerSolves(int playerId)
        {
            throw new NotImplementedException();
        }
        public async Task<PlayerSolves> GetPlayerSolve(int Id, int playerId)
        {
            throw new NotImplementedException();
        }
        public async Task<PlayerSolves> CreatePlayerSolve(PlayerSolves playerSolve)
        {
            return await _puzzleRepository.CreatePlayerSolve(playerSolve);
        }
        public async Task<PlayerSolves> UpdatePlayerSolve(PlayerSolves playerSolve)
        {
            throw new NotImplementedException();
        }
        public void DeletePlayerSolve(int playerSolveId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
