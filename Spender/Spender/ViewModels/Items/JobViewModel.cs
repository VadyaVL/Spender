using System;

namespace Spender.ViewModels
{
    public class JobViewModel : BasicItemViewModel
    {
        #region Fields

        private DateTime _start;

        private DateTime? _end;

        private CategoryViewModel _category;

        #endregion

        #region Props

        public int Id { get; set; }

        public DateTime Start
        {
            get => this._start;
            set
            {
                this._start = value;
                this.OnPropertyChanged();
            }
        }

        public DateTime? End
        {
            get => this._end;
            set
            {
                this._end = value;
                this.OnPropertyChanged();
            }
        }

        public CategoryViewModel Category
        {
            get => this._category;
            set
            {
                this._category = value;
                this.OnPropertyChanged();
            }
        }

        public TimeSpan Duration => !this.End.HasValue ? DateTime.UtcNow.Subtract(this.Start) : this.End.Value.Subtract(this.Start);

        #endregion
    }
}