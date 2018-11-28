using System.Collections.Generic;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.Entities.Enums;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Task<Player> GetPlayerByPlayerName(string playerName);
        Task<List<Player>> GetQuantityByRole(int quantity, int role);
        Task<List<Player>> GetAllPlayersByRole(PlayerRole role);
        Task<Player> GetFirstPlayerByRole(PlayerRole role);
        Task<long> GetPlayerIdByPlayerName(string playerName);
    }
}