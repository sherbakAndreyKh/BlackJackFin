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
            // DAL
            Bind<IPlayerRepository>().To<PlayerRepository>().WithConstructorArgument(connectionString);
            Bind<IPlayerPropertiesRepository>().To<PlayerPropertiesRepository>().WithConstructorArgument(connectionString);
            Bind<IGameRepository>().To<GameRepository>().WithConstructorArgument(connectionString);
            Bind<IRoundRepository>().To<RoundRepository>().WithConstructorArgument(connectionString);
            Bind<ICardRepository>().To<CardRepository>().WithConstructorArgument(connectionString);


            // BLL
          
            Bind<IPlayerLogic>().To<PlayerLogic>();
            Bind<IPlayerPropertiesLogic>().To<PlayerPropertiesLogic>();
            Bind<ICardLogic>().To<CardLogic>();
            Bind<IGameLogic>().To<GameLogic>();
            Bind<IRoundLogic>().To<RoundLogic>();

            // Service
            Bind<IGameStartService>().To<GameStartService>();

            Bind<IBlackJackContext>().To<BlackJackContext>().WithConstructorArgument(connectionString);
        }
    }
}
