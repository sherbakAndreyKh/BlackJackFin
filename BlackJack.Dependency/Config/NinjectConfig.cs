using Ninject.Modules;
using Ninject.Web.Common;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.BusinessLogicLayer.BusinessLogic;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.DataAccessLayer.Repositories;
using BlackJack.DataAccessLayer.Context;
using BlackJack.Services.Interfaces;
using BlackJack.Services.Services;


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

            // BLL
            Bind<IPlayerLogic>().To<PlayerLogic>();
            Bind<IPlayerRoundHandLogic>().To<PlayerRoundHandLogic>();
            Bind<ICardLogic>().To<CardLogic>();
            Bind<IGameLogic>().To<GameLogic>();
            Bind<IRoundLogic>().To<RoundLogic>();

            // Service
            Bind<IGameService>().To<GameService>();
            Bind<IHistoryService>().To<HistoryService>();
        }
    }
}
