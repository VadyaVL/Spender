﻿using AutoMapper;
using FreshMvvm;
using FreshTinyIoC;
using Spender.Logic;

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

        #region Mehods

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

        }

        private void RegisterMappers(IMapperConfigurationExpression cfg)
        {

        }

        #endregion
    }
}
