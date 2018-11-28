using Autofac;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Maping;
using BlackJack.BusinessLogic.Services;
using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.DataAccess.Repositories;

namespace BlackJack.BusinessLogic.Dependency
{
    public class AutofacConfig : Autofac.Module
    {
        string connectionString;

        public AutofacConfig(string connection)
        {
            connectionString = connection;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlackJackContext>().AsSelf().WithParameter("connectionString", connectionString).InstancePerRequest();

            builder.RegisterType<CardRepository>().As<ICardRepository>().WithParameter("connectionString", connectionString).InstancePerRequest();
            builder.RegisterType<GameRepository>().As<IGameRepository>().WithParameter("connectionString", connectionString).InstancePerRequest();
            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>().WithParameter("connectionString", connectionString).InstancePerRequest();
            builder.RegisterType<PlayerRoundHandRepository>().As<IPlayerRoundHandRepository>().WithParameter("connectionString", connectionString).InstancePerRequest();
            builder.RegisterType<RoundRepository>().As<IRoundRepository>().WithParameter("connectionString", connectionString).InstancePerRequest();

            builder.RegisterType<GameServiceMapProvider>().AsSelf();
            builder.RegisterType<HistoryServiceMapProvider>().AsSelf();

            builder.RegisterType<GameService>().As<IGameService>().UsingConstructor(typeof(IPlayerRepository),
                                                                                    typeof(IGameRepository),
                                                                                    typeof(IRoundRepository),
                                                                                    typeof(ICardRepository),
                                                                                    typeof(IPlayerRoundHandRepository),
                                                                                    typeof(GameServiceMapProvider));

            builder.RegisterType<HistoryService>().As<IHistoryService>().UsingConstructor(typeof(IPlayerRepository),
                                                                                          typeof(IGameRepository),
                                                                                          typeof(IRoundRepository),
                                                                                          typeof(ICardRepository),
                                                                                          typeof(IPlayerRoundHandRepository),
                                                                                          typeof(HistoryServiceMapProvider));
        }
    }
}
