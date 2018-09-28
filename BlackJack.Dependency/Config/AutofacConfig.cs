using Autofac;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.BusinessLogicLayer.Maping;
using BlackJack.BusinessLogicLayer.Services;
using BlackJack.DataAccessLayer.Context;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.DataAccessLayer.Repositories;
using BlackJack.DataAccessLayer.ResitoriesDapper;

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
            builder.RegisterType<BlackJackContext>().AsSelf().WithParameter("connectionString", connectionString).InstancePerRequest();
            builder.RegisterType<BlackJackConnection>().AsSelf().WithParameter("connectionString", connectionString).InstancePerRequest();

            builder.RegisterType<CardDapperRepository>().As<ICardRepository>();
            builder.RegisterType<GameDapperRepository>().As<IGameRepository>();
            builder.RegisterType<PlayerDapperRepository>().As<IPlayerRepository>();
            builder.RegisterType<PlayerRoundHandDapperRepository>().As<IPlayerRoundHandRepository>();
            builder.RegisterType<RoundDapperRepository>().As<IRoundRepository>();

            builder.RegisterType<GameServiceResponseMappProvider>().AsSelf();
            builder.RegisterType<HistoryServiceMappProvider>().AsSelf();

            builder.RegisterType<GameService>().As<IGameService>().UsingConstructor(typeof(IPlayerRepository),
                                                                                    typeof(IGameRepository),
                                                                                    typeof(IRoundRepository),
                                                                                    typeof(ICardRepository),
                                                                                    typeof(IPlayerRoundHandRepository),
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

