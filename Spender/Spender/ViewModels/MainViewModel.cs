using AutoMapper;
using MvvmHelpers;
using Spender.Logic.Services;
using Spender.Resources;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Spender.ViewModels
{
    public class MainViewModel : BasicViewModel
    {
        #region Fields

        private ObservableRangeCollection<CategoryViewModel> _collection = new ObservableRangeCollection<CategoryViewModel>();

        private JobViewModel _activeJob;

        #endregion

        #region Properties

        public ObservableRangeCollection<CategoryViewModel> Collection => this._collection;

        public JobViewModel ActiveJob
        {
            get => this._activeJob;
            set
            {
                this._activeJob = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand OpenCreateCategoryCommand { get; private set; }

        public ICommand OpenChartsCommand { get; private set; }
        
        public ICommand OpenEditCategoryCommand { get; private set; }

        public ICommand DeleteCategoryCommand { get; private set; }

        public ICommand StartJobCommand { get; private set; }

        public ICommand StopJobCommand { get; private set; }

        #endregion

        #region Constructors

        public MainViewModel(ICategoryService categoryService, ITimerService timerService)
        {
            this.CategoryService = categoryService;
            this.TimerService = timerService;

            this.OpenCreateCategoryCommand = new Command(this.OpenCreateCategory);
            this.OpenChartsCommand = new Command(this.OpenCharts);
            this.OpenEditCategoryCommand = new Command(this.OpenEditCategory);
            this.DeleteCategoryCommand = new Command(this.DeleteCategory);
            this.StartJobCommand = new Command(this.StartJob);
            this.StopJobCommand = new Command(this.StopJob);
        }

        #endregion

        #region Methods

        public override void Init(object initData)
        {
            base.Init(initData);
            
            var data = this.CategoryService.GetList();
            this.Collection.AddRange(data.Select(category => Mapper.Map<CategoryViewModel>(category)).ToList());

            this.ActiveJob = Mapper.Map<JobViewModel>(this.TimerService.GetActiveJob());
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            MessagingCenter.Unsubscribe<EditCategoryViewModel, CategoryViewModel>(this, "EditCategory");
        }

        private async void OpenCreateCategory()
        {
            MessagingCenter.Subscribe<EditCategoryViewModel, CategoryViewModel>(this, "EditCategory", this.EditCategory);
            await this.CoreMethods.PushPageModel<EditCategoryViewModel>();
        }

        private void OpenCharts()
        {

        }

        private async void OpenEditCategory(object item)
        {
            if (item is CategoryViewModel category)
            {
                MessagingCenter.Subscribe<EditCategoryViewModel, CategoryViewModel>(this, "EditCategory", this.EditCategory);
                await this.CoreMethods.PushPageModel<EditCategoryViewModel>(category);
            }
        }

        private async void DeleteCategory(object item)
        {
            if (item is CategoryViewModel category)
            {
                var isOk = await this.CoreMethods.DisplayAlert(Resource.DeleteText, string.Format(Resource.DeletePatternText, category.Title), Resource.AcceptText, Resource.CancelText);

                if (isOk)
                {
                    // Clear job too
                    var returnId = this.CategoryService.Delete(category.Id);

                    if (returnId != 0)
                    {
                        this.Collection.Remove(category);
                    }
                }
            }
        }

        private void EditCategory(EditCategoryViewModel sender, CategoryViewModel category)
        {
            var existed = this.Collection.FirstOrDefault(c => c.Id == category.Id);

            if(existed == null)
            {
                this.Collection.Add(category);
            }
            else
            {
                // Or use mapper
                existed.Title = category.Title;
            }
        }

        private void StartJob(object arg)
        {
            if (arg is CategoryViewModel category)
            {
                var stopJob = true;

                if(this.ActiveJob != null)
                {
                    stopJob = this.TimerService.StopJob();
                }

                if (stopJob)
                {
                   this.ActiveJob = Mapper.Map<JobViewModel>(this.TimerService.StartJob(category.Id));
                }
            }
        }

        private void StopJob(object arg)
        {
            if (this.ActiveJob != null && this.TimerService.StopJob())
            {
                this.ActiveJob = null;
            }
        }

        #endregion
    }
}