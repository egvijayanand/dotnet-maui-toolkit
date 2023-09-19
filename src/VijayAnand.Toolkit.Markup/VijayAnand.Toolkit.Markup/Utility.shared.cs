using System.Linq.Expressions;
using System.Reflection;

namespace VijayAnand.Toolkit.Markup
{
    public static class Utility
    {
        #region Generic
        public static List<T> AddItem<T>(this List<T> list, T item)
        {
            list.Add(item);
            return list;
        }
        #endregion

        public static Binding BindTo(string path)
            => new Binding(path);

        public static Binding BindTo(string path, object? source = null)
            => new Binding(path, source: source);

        public static Thickness NoMargin()
            => new Thickness(0);

        public static Thickness NoPadding()
            => new Thickness(0);

        public static Thickness Margins(double left = 0, double top = 0, double right = 0, double bottom = 0)
            => new Thickness(left, top, right, bottom);

        public static Thickness Paddings(double left = 0, double top = 0, double right = 0, double bottom = 0)
            => new Thickness(left, top, right, bottom);

        public static Setter Create(BindableProperty property, object value)
            => new Setter() { Property = property, Value = value };        
    }
}
