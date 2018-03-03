using System;
using System.Collections.Generic;
using System.Text;

namespace Spender.ViewModels
{
    public class MainViewModel : BasicViewModel
    {
        #region Static Fields

        #endregion

        #region Fields

        private string _title;

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

        #region Services

        #endregion

        #region Commands

        #endregion

        #region Constructors

        public MainViewModel()
        {

        }

        #endregion

        #region Methods

        public override void Init(object initData)
        {
            base.Init(initData);

            this.Title = "Main Init";
        }

        #endregion

        #region Events

        #endregion
    }
}
