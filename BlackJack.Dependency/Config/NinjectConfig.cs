using Ninject.Modules;
using Ninject.Web.Common;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.BusinessLogicLayer.Services;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.DataAccessLayer.Repositories;
using BlackJack.DataAccessLayer.Context;



namespace BlackJack.Dependency.Config
{
    public class NinjectConfig : NinjectModule
    {
        private string connectionString;

        public NinjectConfig(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            // Context
            Bind<BlackJackContext>().ToSelf().InRequestScope().WithConstructorArgument(connectionString);

            // DAL
            Bind<IPlayerRepository>().To<PlayerRepository>();
            Bind<IPlayerRoundHandRepository>().To<PlayerRoundHandRepository>();
            Bind<IGameRepository>().To<GameRepository>();
            Bind<IRoundRepository>().To<RoundRepository>();
            Bind<ICardRepository>().To<CardRepository>();

            // Service
            Bind<IGameService>().To<GameService>();
            Bind<IHistoryService>().To<HistoryService>();
        }
    }

   
}
