﻿using System.Threading;

public class BackgroundWorkerService : BackgroundService
{
    readonly ILogger<BackgroundWorkerService> _logger;

    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger)
    {
        _logger = logger;
    }


    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}