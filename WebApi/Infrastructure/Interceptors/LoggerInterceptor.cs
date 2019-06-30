using Castle.DynamicProxy;
using NLog;

namespace WebApi.Infrastructure.Interceptors
{
    public class LoggerInterceptor : IInterceptor
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public void Intercept(IInvocation invocation)
        {
            _logger.Info($"Before call: {invocation.TargetType.Name}.{invocation.Method.Name}");

            invocation.Proceed();

            _logger.Info($"After call: {invocation.TargetType.Name}.{invocation.Method.Name}");
        }
    }
}