using AutoMapper;
using FreshMvvm;
using FreshTinyIoC;
using Spender.Logic;
using Spender.Logic.Models;
using Spender.Services;
using Spender.ViewModels;

namespace Spender
{
    public class AppSetup
    {
        #region Singleton

        private static AppSetup _instance;

        public static AppSetup Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppSetup();
                }

                return _instance;
            }
        }

        #endregion

        #region Fields

        private bool _isIoCInit, _isMapperInit, _isPageModelMapperInit;

        #endregion

        #region Constructors

        private AppSetup()
        {

        }

        #endregion

        #region Methods

        public void Setup()
        {
            if (!this._isIoCInit)
            {
                this.RegisterDependencies(FreshTinyIoCContainer.Current);
                IoCConfig.RegisterDependencies(FreshTinyIoCContainer.Current);

                this._isIoCInit = true;
            }

            if (!this._isMapperInit)
            {
                Mapper.Initialize(cfg =>
                {
                    this.RegisterMappers(cfg);
                    MapperConfig.RegisterMappers(cfg);
                });

                this._isMapperInit = true;
            }

            if (!this._isPageModelMapperInit)
            {
                FreshPageModelResolver.PageModelMapper = new PageModelMapper();

                this._isPageModelMapperInit = true;
            }
        }

        private void RegisterDependencies(FreshTinyIoCContainer container)
        {
            container.Register<ISettingService, SettingService>();
        }

        private void RegisterMappers(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CategoryModel, CategoryViewModel>();
            cfg.CreateMap<CategoryViewModel, CategoryModel>();
        }

        #endregion
    }
}
