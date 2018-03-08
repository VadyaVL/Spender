using Spender.Logic.Models;

namespace Spender.Logic.Services
{
    public interface ITimerService
    {
        JobModel GetActiveJob();

        JobModel StartJob(int categoryId);

        bool StopJob();
    }
}
