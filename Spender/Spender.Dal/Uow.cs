using Spender.Dal.Repositories;
using Spender.Models;

namespace Spender.Dal
{
    public class Uow : IUow
    {
        #region Properties

        public const string DatabaseName = "spender.db";

        #endregion

        #region Constructors

        public Uow()
        {

        }

        #endregion

        #region Repositories

        private static Repository<Category> _categories;

        public Repository<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new CategoryRepository(DatabaseName);
                }

                return _categories;
            }
        }
        
        #endregion
    }
}
