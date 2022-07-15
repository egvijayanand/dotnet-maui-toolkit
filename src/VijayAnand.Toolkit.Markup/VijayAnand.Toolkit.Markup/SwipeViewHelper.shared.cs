#if NET6_0_OR_GREATER
using ISwipeItem = Microsoft.Maui.Controls.ISwipeItem;
#endif

namespace VijayAnand.Toolkit.Markup
{
    public static class SwipeViewHelper
    {

        public static SwipeItems AddSwipeItem<T>(this SwipeItems list, T item)
            where T : ISwipeItem
        {
            list.Add(item);
            return list;
        }

        public static SwipeItems CreateSwipeItems(IEnumerable<ISwipeItem> swipeItems)
        {
            var swipeItemList = new SwipeItems();

            foreach (var swipeItem in swipeItems)
            {
                swipeItemList.Add(swipeItem);
            }

            return swipeItemList;
        }
    }
}