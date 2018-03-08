using Spender.Dal.Repositories;
using Spender.Models;

namespace Spender.Dal
{
    public interface IUow
    {
        Repository<Category> Categories { get; }

        Repository<Job> Jobs { get; }
    }
}
