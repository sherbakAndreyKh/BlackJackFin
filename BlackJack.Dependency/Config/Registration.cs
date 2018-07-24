using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repositories;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Logic;
using BlackJack.DAL.Context;
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
            Bind<IBotRepository>().To<BotRepository>().WithConstructorArgument(connectionString);
            Bind<IPlayerRepository>().To<PlayerRepository>().WithConstructorArgument(connectionString);
            Bind<IDealerRepository>().To<DealerRepository>().WithConstructorArgument(connectionString);

            Bind<IGameRepository>().To<GameRepository>().WithConstructorArgument(connectionString);
            Bind<IRoundRepository>().To<RoundRepository>().WithConstructorArgument(connectionString);

            Bind<ICardRepository>().To<CardRepository>().WithConstructorArgument(connectionString);


            // BLL
            Bind<ICreateGame>().To<CreateGame>();
            Bind<BLL.Interfaces.IStartGame>().To<BLL.Logic.StartGame>();

            // Service
            Bind<IOptions>().To<Options>();
            Bind<Services.Interfaces.IStartGame>().To<Services.Services.StartGame>();
            

            Bind<IBJContext>().To<BJContext>().WithConstructorArgument(connectionString);
        }
    }
}
