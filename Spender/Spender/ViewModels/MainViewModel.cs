using AutoMapper;
using Spender.Logic.Models;
using Spender.Logic.Services;
using System.Collections.ObjectModel;

namespace Spender.ViewModels
{
    public class MainViewModel : BasicViewModel
    {
        #region Static Fields

        #endregion

        #region Fields

        private string _title;

        private ObservableCollection<CategoryViewModel> _collection = new ObservableCollection<CategoryViewModel>();

        #endregion

        #region Properties

        public string Title
        {
            get => this._title;
            set
            {
                this._title = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<CategoryViewModel> Collection => this._collection;

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

            this.Title = "Main Init";

            var data = this.CategoryService.GetList();

            foreach (var category in data)
            {
                this.Collection.Add(Mapper.Map<CategoryViewModel>(category));
            }
        }

        #endregion

        #region Events

        #endregion
    }
}
