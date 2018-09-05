using Ninject.Modules;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.BusinessLogicLayer.BusinessLogic;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.DataAccessLayer.Repositories;
using BlackJack.DataAccessLayer.Context;
using BlackJack.Services.Interfaces;
using BlackJack.Services.Services;


namespace BlackJack.Dependency.Config
{
    public class Registration : NinjectModule
    {
        private string connectionString;

        public Registration(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            // Context
            Bind<BlackJackContext>().ToSelf().InSingletonScope().WithConstructorArgument(connectionString);

            // DAL
            Bind<IPlayerRepository>().To<PlayerRepository>();
            Bind<IPlayerPropertiesRepository>().To<PlayerPropertiesRepository>();
            Bind<IGameRepository>().To<GameRepository>();
            Bind<IRoundRepository>().To<RoundRepository>();
            Bind<ICardRepository>().To<CardRepository>();


            // BLL
            Bind<IPlayerLogic>().To<PlayerLogic>();
            Bind<IPlayerPropertiesLogic>().To<PlayerPropertiesLogic>();
            Bind<ICardLogic>().To<CardLogic>();
            Bind<IGameLogic>().To<GameLogic>();
            Bind<IRoundLogic>().To<RoundLogic>();

            // Service
            Bind<IGameService>().To<GameService>();
            Bind<IHistoryService>().To<HistoryService>();
        }
    }
}
