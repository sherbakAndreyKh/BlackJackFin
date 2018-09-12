using System;
using System.Collections.Generic;
using BlackJack.Entities;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IPlayerRoundHandLogic
    {
        void Create(PlayerRoundHand item);
        void CreateMany(List<PlayerRoundHand> item);
        void Delete(int id);
        IEnumerable<PlayerRoundHand> Find(Func<PlayerRoundHand, bool> predicate);
        IEnumerable<PlayerRoundHand> GetAll();
        PlayerRoundHand Get(int id);
        PlayerRoundHand GetWithPlayerAndRoundId(int playerId, int roundId);
        void Save();
        void Update(PlayerRoundHand item);
        void UpdateMany(List<PlayerRoundHand> item);
    }
}