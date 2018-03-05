using Spender.Dal;

namespace Spender.Logic.Services
{
    public abstract class BasicService
    {
        protected IUow Unit { get; set; }

        public BasicService(IUow uow)
        {
            this.Unit = uow;
        }
    }
}