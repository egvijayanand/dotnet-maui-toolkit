namespace VijayAnand.Toolkit.Markup
{
    public static partial class LayoutExtensions
    {
        #region LayoutOptions
        public static TView TopStart<TView>(this TView view)
            where TView : View => view.Top().Start();

        public static TView TopCenter<TView>(this TView view)
            where TView : View => view.Top().CenterHorizontal();

        public static TView TopEnd<TView>(this TView view)
            where TView : View => view.Top().End();

        public static TView MiddleStart<TView>(this TView view)
            where TView : View => view.CenterVertical().Start();

        public static TView MiddleCenter<TView>(this TView view)
            where TView : View => view.CenterVertical().CenterHorizontal();

        public static TView MiddleEnd<TView>(this TView view)
            where TView : View => view.CenterVertical().End();

        public static TView BottomStart<TView>(this TView view)
            where TView : View => view.Bottom().Start();

        public static TView BottomCenter<TView>(this TView view)
            where TView : View => view.Bottom().CenterHorizontal();

        public static TView BottomEnd<TView>(this TView view)
            where TView : View => view.Bottom().End();
        #endregion
    }
}
