using Modulo_Mensageria.Services.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Modulo_Mensageria.Services.Implementation
{
    public class MensageriaService : IMensageriaService
    {
        private readonly IClienteService _clienteService;
        private readonly ICampanhaService _campanhaService;

        public MensageriaService(IClienteService clienteService, ICampanhaService campanhaService)
        {
            _clienteService=clienteService;
            _campanhaService=campanhaService;
        }

        public async Task DispararMensagensCampanhasDoDia()
        {
            try
            {
                string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
                string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

                TwilioClient.Init(accountSid, authToken);

                var campanhas = await _campanhaService.getCampanhasDoDia();
                var clientes = await _clienteService.getTodosOsUsuarios();

                foreach (var campanha in campanhas)
                {
                    foreach (var cliente in clientes)
                    {

                        var messageOptions = new CreateMessageOptions(new PhoneNumber(""))
                        {
                            From = new PhoneNumber(""),
                            Body = campanha.mensagem
                        };

                        var message = MessageResource.Create(messageOptions);

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
