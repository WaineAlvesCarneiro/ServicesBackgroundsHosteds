using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

public class TimerHostedService : IHostedService
{
    private readonly ILogger _logger;

    public TimerHostedService(ILogger<TimerHostedService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        return Task.CompletedTask;
    }

    private void ExecuteProcess(object state)
    {
        _logger.LogInformation(" ----> Execução do processo. ----> ");
        _logger.LogInformation($"{DateTime.Now}");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation(" <---- Parando o processo. <---- ");
        _logger.LogInformation($"{DateTime.Now}");
        return Task.CompletedTask;
    }
}
