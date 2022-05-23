#if NET6_0_OR_GREATER
using ISwipeItem = Microsoft.Maui.Controls.ISwipeItem;
#endif

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
        {
            return new Binding(path);
        }

        public static Binding BindTo(string path, object? source = null)
        {
            return new Binding(path, source: source);
        }

        public static Thickness NoMargin()
        {
            return new Thickness(0);
        }

        public static Thickness NoPadding()
        {
            return new Thickness(0);
        }

        public static Thickness Margins(double left = 0, double top = 0, double right = 0, double bottom = 0)
        {
            return new Thickness(left, top, right, bottom);
        }

        public static Thickness Paddings(double left = 0, double top = 0, double right = 0, double bottom = 0)
        {
            return new Thickness(left, top, right, bottom);
        }

        public static Setter Create(BindableProperty property, object value)
        {
            return new Setter() { Property = property, Value = value };
        }

        #region VisualState
        public static VisualStateGroupList CreateVisualStateGroupList(IEnumerable<VisualStateGroup> visualStateGroups)
        {
            var visualStateGroupList = new VisualStateGroupList();

            foreach (var visualStateGroup in visualStateGroups)
            {
                visualStateGroupList.Add(visualStateGroup);
            }

            return visualStateGroupList;
        }
        #endregion

        #region SwipeView
        public static SwipeItems CreateSwipeItems(IEnumerable<ISwipeItem> swipeItems)
        {
            var swipeItemList = new SwipeItems();

            foreach (var swipeItem in swipeItems)
            {
                swipeItemList.Add(swipeItem);
            }

            return swipeItemList;
        }

        public static SwipeItems AddSwipeItem<T>(this SwipeItems list, T item)
            where T : ISwipeItem
        {
            list.Add(item);
            return list;
        }
        #endregion

        #region ResourceDictionary
        public static T? AppResource<T>(string key)
        {
            if (Application.Current?.Resources.TryGetValue(key, out var value) is true)
            {
                return (value is T resource) ? resource : default;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(key), $"StaticResource not found for key {key}");
            }
        }

        public static object AppResource(string key)
        {
            if (Application.Current?.Resources.TryGetValue(key, out var value) is true)
            {
                return value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(key), $"StaticResource not found for key {key}");
            }
        }
        #endregion
    }
}
