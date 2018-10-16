using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSimulator.BLL.DTO;
using TruckSimulator.BLL.Interfaces;
using TruckSimulator.DAL.Entities;
using TruckSimulator.BLL.Infrastructure;
using TruckSimulator.DAL.Interfaces;
using AutoMapper;

namespace TruckSimulator.BLL.Services
{
    public class GameService:IGameService
    {
        IUnitOfWork Database { get; set; }

        public GameService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeGame(GameDTO gameDto)
        {
            //Game game = Database.Game.Get(gameDto.Id);

            // валидация
            //if (game == null)
            //    throw new ValidationException("Игра не найдена", "");
            // применяем скидку
            //decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);
            Game game = new Game
            {
                SaveName = DateTime.Now.ToString(),
                Iterations = gameDto.iterations,
                CurIteration = gameDto.CurIteration,
                QTruck = gameDto.QTruck,
                QCargo = gameDto.QTruck,
            };
            Database.Games.Create(game);
            Database.Save();
        }

        public IEnumerable<GameDTO> GetGames()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Game>, List<GameDTO>>(Database.Games.GetAll());
        }

        public GameDTO GetGame(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id игры", "");
            var game = Database.Games.Get(id.Value);
            if (game == null)
                throw new ValidationException("Игра не найден", "");

            return new GameDTO { SaveName = game.SaveName, iterations = game.Iterations,  CurIteration = game.CurIteration, QCargo = game.QCargo, QTruck = game.QTruck };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
