using Microsoft.EntityFrameworkCore;
using TmPuzzle.Database;
using TmPuzzle.Entities;

namespace TmPuzzle.Repositories
{
    public class PuzzleRepository : IPuzzleRepository
    {
        private readonly TmPuzzleContext _context;
        public PuzzleRepository(TmPuzzleContext context)
        {
            _context = context;
        }

        #region Campaign
        public async Task<List<Campaign>> GetCampaigns()
        {
            return await _context.Campaigns.ToListAsync();
        }

        public async Task<Campaign> GetCampaign(int campaignId)
        {
            return await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == campaignId);
        }

        public async Task<Campaign> CreateCampaign(Campaign campaign)
        {
            var c = await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();
            return await GetCampaign(c.Entity.Id);
        }

        public async Task<Campaign> UpdateCampaign(Campaign campaign)
        {
            throw new NotImplementedException();
        }

        public void DeleteCampaign(int campaignId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Maps
        public async Task<List<Map>> GetMaps()
        {
            return await _context.Maps.ToListAsync();
        }
        public async Task<List<Map>> GetMapsForCampaign(int campaignId)
        {
            var campaign = await _context.Campaigns
                .Where(c => c.Id == campaignId)
                .Include(c => c.CampaignMaps).ThenInclude(cm => cm.Map)
                .FirstOrDefaultAsync();

            List<Map> maps = new List<Map>();

            if (campaign != null)
            {
                foreach (CampaignMap item in campaign.CampaignMaps)
                {
                    maps.Add(item.Map);
                }
            }

            return maps;
        }

        public async Task<Map> GetMap(int mapId)
        {
            return await _context.Maps.Where(m => m.Id == mapId).FirstOrDefaultAsync();
        }

        public async Task<Map> CreateMap(Map map)
        {
            var m = await _context.Maps.AddAsync(map);
            await _context.SaveChangesAsync();
            return await GetMap(m.Entity.Id);
        }

        public async Task<Map> UpdateMap(Map map)
        {
            throw new NotImplementedException();
        }

        public void DeleteMap(int mapId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region EasterEggs
        public async Task<List<EasterEgg>> GetEasterEggs()
        {
            return await _context.EasterEggs.ToListAsync();
        }
        public async Task<List<EasterEgg>> GetEasterEggsForMap(int mapId)
        {
            return await _context.EasterEggs.Where(ee => ee.MapId == mapId).ToListAsync();
        }
        public async Task<List<EasterEgg>> GetEasterEggsForCampaign(int campaignId)
        {
            var campaign = await _context.Campaigns
                .Where(c => c.Id == campaignId)
                .Include(c => c.CampaignMaps).ThenInclude(cm => cm.Map).ThenInclude(m => m.EasterEggs)
                .FirstOrDefaultAsync();

            List<EasterEgg> easterEggs = new List<EasterEgg>();

            if (campaign != null)
            {
                foreach (CampaignMap item in campaign.CampaignMaps)
                {
                    easterEggs.AddRange(item.Map.EasterEggs);
                }
            }

            return easterEggs;
        }

        public async Task<EasterEgg> GetEasterEgg(int easterEggId)
        {
            return await _context.EasterEggs.Where(ee => ee.Id == easterEggId).FirstOrDefaultAsync();
        }

        public async Task<EasterEgg> CreateEasterEgg(EasterEgg easterEgg)
        {
            var e = await _context.EasterEggs.AddAsync(easterEgg);
            await _context.SaveChangesAsync();
            return await GetEasterEgg(e.Entity.Id);
        }

        public async Task<EasterEgg> UpdateEasterEgg(EasterEgg easterEgg)
        {
            throw new NotImplementedException();
        }

        public void DeleteEasterEgg(int easterEggId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Players
        public async Task<List<Player>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player> GetPlayer(int playerId)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Id == playerId);
        }

        public async Task<Player> GetPlayer(string login)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Login == login);
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            var p = await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return await GetPlayer(p.Entity.Id);
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public void DeletePlayer(int playerId)
        {
            throw new NotImplementedException();
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
            return await _context.PlayerSolves.Where(ps => ps.PlayerId == playerId).ToListAsync();
        }

        public async Task<PlayerSolves> GetPlayerSolve(int Id, int playerId)
        {
            return await _context.PlayerSolves.Where(ps => ps.Id == Id && ps.PlayerId == playerId).FirstOrDefaultAsync();
        }

        public async Task<PlayerSolves> CreatePlayerSolve(PlayerSolves playerSolve)
        {
            var ps = await _context.PlayerSolves.AddAsync(playerSolve);
            await _context.SaveChangesAsync();
            return await GetPlayerSolve(ps.Entity.Id, ps.Entity.PlayerId);
        }

        public async Task<PlayerSolves> UpdatePlayerSolve(PlayerSolves playerSolve)
        {
            throw new NotImplementedException();
        }

        public void DeletePlayerSolve(int playerSolveId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EasterEgg>> GetEasterEggs(int mapId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
