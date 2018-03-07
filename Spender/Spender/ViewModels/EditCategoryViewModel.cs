using Spender.Logic.Models;
using Spender.Logic.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace Spender.ViewModels
{
    public class EditCategoryViewModel : BasicViewModel
    {
        #region Fields

        private string _title;

        private int _id;

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

        #endregion
        
        #region Commands

        public ICommand SaveCommand { get; private set; }

        #endregion

        #region Constructors

        public EditCategoryViewModel(ICategoryService categoryService)
        {
            this.CategoryService = categoryService;

            this.SaveCommand = new Command(this.Save);
        }

        #endregion

        #region Methods

        public override void Init(object initData)
        {
            base.Init(initData);

            if(initData is CategoryViewModel category)
            {
                this._id = category.Id;
                this.Title = category.Title;
            }
        }

        private void Save()
        {
            var newId = this._id;

            if (newId == 0)
            {
                newId = this.CategoryService.Create(new CategoryModel { Title = this.Title });
            }
            else
            {
                newId = this.CategoryService.Edit(new CategoryModel { Id = this._id, Title = this.Title });
            }

            var categoryVM = new CategoryViewModel { Id = this._id, Title = this.Title };

            MessagingCenter.Send(this, "EditCategory", categoryVM);
            this.CoreMethods.PopPageModel();
        }

        #endregion
    }
}
