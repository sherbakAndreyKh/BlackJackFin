using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;


namespace BlackJack.UI.ExceptionFilters
{
    public class StandartExceptions : Attribute, IExceptionFilter
    {
        private log4net.ILog logger = log4net.LogManager.GetLogger(typeof(StandartExceptions));

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null &&
                    actionExecutedContext.Exception is Exception ex)
            {
                logger.Error(ex.ToString());
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return Task.FromResult(response);
            }
            return Task.FromResult<object>(null);
        }
        public bool AllowMultiple
        {
            get { return true; }
        }
    }
}