using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Spender.Core
{
    // https://peteohanlon.wordpress.com/2008/10/22/bulk-loading-in-observablecollection/
    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        private bool suppressNotification = false;

        public Func<T, T, bool> TheSameChecker;

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!suppressNotification)
                base.OnCollectionChanged(e);
        }

        public void AddRange(ICollection<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            suppressNotification = true;

            foreach (T item in list)
            {
                Add(item);
            }
            suppressNotification = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void AddRange(IEnumerable<T> list)
        {
            this.AddRange(list.ToList());
        }

        public void Reset(ICollection<T> range)
        {
            this.Items.Clear();

            AddRange(range);
        }

        public void Reset(IEnumerable<T> range)
        {
            this.Items.Clear();

            AddRange(range);
        }
    }
}
