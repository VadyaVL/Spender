namespace Spender.ViewModels
{
    public class CategoryViewModel : BasicItemViewModel
    {
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
                this.OnPropertyChanged();
            }
        }
        
        #endregion
    }
}