using Quartz;

namespace Modulo_Mensageria.QuartzJobs
{
    public class QuartzMensageria : IJob
    {
        private readonly ILogger<QuartzMensageria> _logger;

        public QuartzMensageria(ILogger<QuartzMensageria> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogWarning("Processo de envio de mensagens começou");
            return Task.CompletedTask;
        }
    }
}
