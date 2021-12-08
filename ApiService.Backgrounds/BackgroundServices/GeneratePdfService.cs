using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

public class GeneratePdfService : BackgroundService
{
    private readonly ILogger<GeneratePdfService> _logger;

    public GeneratePdfService(ILogger<GeneratePdfService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(" ----> Começando a gerar Pdf. ----> ");
        stoppingToken.Register(() => _logger.LogInformation("O serviço de demonstração está parando."));

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation(" ----> Gerando pdf em background. ----> ");
            await GeneratePdf();
        }
        _logger.LogInformation(" ----> Pdf gerado. ----> ");
    }

    private async Task GeneratePdf()
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
}