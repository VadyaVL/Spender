﻿using FreshMvvm;
using Spender.Logic.Services;

namespace Spender.ViewModels
{
    public abstract class BasicViewModel : FreshBasePageModel
    {
        #region Static Fields

        #endregion

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Services

        protected ITimerService TimerService { get; set; }

        protected ICategoryService CategoryService { get; set; }

        #endregion

        #region Commands

        #endregion

        #region Constructors

        public BasicViewModel()
        {

        }

        #endregion

        #region Methods

        #endregion

        #region Events

        #endregion
    }
}