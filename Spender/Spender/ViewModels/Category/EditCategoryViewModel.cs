using AutoMapper;
using Spender.Logic.Models;
using Spender.Logic.Services;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Xamarin.Forms;

namespace Spender.ViewModels
{
    public class EditCategoryViewModel : BasicValidatableViewModel
    {
        #region Fields

        private string _title;

        private int _id;

        #endregion

        #region Properties

        [Required]
        public string Title
        {
            get => this._title;
            set => this.SetProperty(ref this._title, value);
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
            if (this.Validate())
            {
                var category = new CategoryModel { Id = this._id, Title = this.Title };
                int id;

                if (category.Id == 0)
                {
                    id = this.CategoryService.Create(category);
                    category.Id = id;
                }
                else
                {
                    id = this.CategoryService.Edit(category);
                }

                var categoryVM = Mapper.Map<CategoryViewModel>(category);

                MessagingCenter.Send(this, "EditCategory", categoryVM);
                this.CoreMethods.PopPageModel();
            }
        }

        #endregion
    }
}
