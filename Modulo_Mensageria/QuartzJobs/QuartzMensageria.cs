using Modulo_Mensageria.Services.Interfaces;
using Quartz;

namespace Modulo_Mensageria.QuartzJobs
{
    public class QuartzMensageria : IJob
    {
        private readonly ILogger<QuartzMensageria> _logger;
        private readonly IMensageriaService _mensageriaService;

        public QuartzMensageria(ILogger<QuartzMensageria> logger, IMensageriaService mensageriaService)
        {
            _logger = logger;
            _mensageriaService=mensageriaService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.LogWarning("Processo de envio de mensagens começou");
                await _mensageriaService.DispararMensagensCampanhasDoDia();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
