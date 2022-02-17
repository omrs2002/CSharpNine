namespace FluentValidationConsole.Services
{
    public interface IMyService
    {
        Task ExecuteAsync(CancellationToken stoppingToken = default);


    }

}
