#if NET6_0_OR_GREATER
using ISwipeItem = Microsoft.Maui.Controls.ISwipeItem;
#endif

namespace VijayAnand.Toolkit.Markup
{
    public static class SwipeViewHelper
    {
        public static IList<ISwipeItem> AddSwipeItem<TSwipeItem>(this IList<ISwipeItem> list, TSwipeItem item)
            where TSwipeItem : ISwipeItem
        {
            list.Add(item);
            return list;
        }

        public static SwipeItems CreateSwipeItems(IEnumerable<ISwipeItem> swipeItems)
            => new SwipeItems(swipeItems);
    }
}
