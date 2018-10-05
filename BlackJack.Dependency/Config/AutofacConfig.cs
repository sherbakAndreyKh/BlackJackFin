using Autofac;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.BusinessLogicLayer.Maping;
using BlackJack.BusinessLogicLayer.Services;
using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.DataAccess.Repositories;

namespace BlackJack.Dependency.Config
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
            builder.RegisterType<BlackJackConnection>().AsSelf().WithParameter("connectionString", connectionString).InstancePerRequest();

            builder.RegisterType<CardRepository>().As<ICardRepository>();
            builder.RegisterType<GameRepository>().As<IGameRepository>();
            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>();
            builder.RegisterType<PlayerRoundHandRepository>().As<IPlayerRoundHandRepository>();
            builder.RegisterType<RoundRepository>().As<IRoundRepository>();
            builder.RegisterType<PlayerRoundHandCardsRepository>().As<IPlayerRoundHandCardsRepository>();

            builder.RegisterType<GameServiceResponseMappProvider>().AsSelf();
            builder.RegisterType<HistoryServiceMappProvider>().AsSelf();

            builder.RegisterType<GameService>().As<IGameService>().UsingConstructor(typeof(IPlayerRepository),
                                                                                    typeof(IGameRepository),
                                                                                    typeof(IRoundRepository),
                                                                                    typeof(ICardRepository),
                                                                                    typeof(IPlayerRoundHandRepository),
                                                                                    typeof(IPlayerRoundHandCardsRepository),
                                                                                    typeof(GameServiceResponseMappProvider));

            builder.RegisterType<HistoryService>().As<IHistoryService>().UsingConstructor(typeof(IPlayerRepository),
                                                                                          typeof(IGameRepository),
                                                                                          typeof(IRoundRepository),
                                                                                          typeof(ICardRepository),
                                                                                          typeof(IPlayerRoundHandRepository),
                                                                                          typeof(HistoryServiceMappProvider));
        }
    }
}

