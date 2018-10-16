using System;
using System.Collections.Generic;
using TruckSimulator.BLL.DTO;

namespace TruckSimulator.BLL.Interfaces
{
    interface IGameService
    {
        void MakeGame(GameDTO gameDto);
        GameDTO GetGame(int? id);
        IEnumerable<GameDTO> GetGames();
        void Dispose();
    }
}
