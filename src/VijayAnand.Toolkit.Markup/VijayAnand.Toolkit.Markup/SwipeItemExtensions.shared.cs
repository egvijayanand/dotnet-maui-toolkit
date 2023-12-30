#if NET6_0_OR_GREATER
using ISwipeItem = Microsoft.Maui.Controls.ISwipeItem;
#endif

namespace VijayAnand.Toolkit.Markup
{
    public static class SwipeItemExtensions
    {
        public static TSwipeItem BackgroundColor<TSwipeItem>(this TSwipeItem swipeItem, Color value)
            where TSwipeItem : SwipeItem
        {
            swipeItem.BackgroundColor = value;
            return swipeItem;
        }

        public static TSwipeItem IsVisible<TSwipeItem>(this TSwipeItem swipeItem, bool value)
            where TSwipeItem : ISwipeItem
        {
            swipeItem.IsVisible = value;
            return swipeItem;
        }
    }
}
