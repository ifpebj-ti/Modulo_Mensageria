using Modulo_Mensageria.Services.Interfaces;
using Quartz;

namespace Modulo_Mensageria.QuartzJobs
{
    public class QuartzMensageria : IJob
    {
        private readonly ILogger<QuartzMensageria> _logger;
        private readonly ICampanhaService _campanhaService;

        public QuartzMensageria(ILogger<QuartzMensageria> logger, ICampanhaService campanhaService)
        {
            _logger = logger;
            _campanhaService = campanhaService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var teste = await _campanhaService.getCampanhasDoDia();
            _logger.LogWarning("Processo de envio de mensagens começou");
        }
    }
}
