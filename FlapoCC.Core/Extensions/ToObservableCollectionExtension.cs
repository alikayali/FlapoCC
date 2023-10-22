using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlapoCC.Core.Extensions
{
    public static class ToObservableCollectionExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> col)
        {
            return new ObservableCollection<T>(col);
        }
    }
}
