using AutoMapper;
using MvvmHelpers;
using Spender.Logic.Services;
using System.Linq;

namespace Spender.ViewModels
{
    public class MainViewModel : BasicViewModel
    {
        #region Static Fields

        #endregion

        #region Fields

        private ObservableRangeCollection<CategoryViewModel> _collection = new ObservableRangeCollection<CategoryViewModel>();

        #endregion

        #region Properties

        public ObservableRangeCollection<CategoryViewModel> Collection => this._collection;

        #endregion

        #region Services

        #endregion

        #region Commands

        #endregion

        #region Constructors

        public MainViewModel(ICategoryService categoryService)
        {
            this.CategoryService = categoryService;
        }

        #endregion

        #region Methods

        public override void Init(object initData)
        {
            base.Init(initData);
            
            var data = this.CategoryService.GetList();
            this.Collection.AddRange(data.Select(category => Mapper.Map<CategoryViewModel>(category)).ToList());
        }

        #endregion

        #region Events

        #endregion
    }
}
