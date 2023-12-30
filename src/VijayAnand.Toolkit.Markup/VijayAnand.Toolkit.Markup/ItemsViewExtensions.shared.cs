namespace VijayAnand.Toolkit.Markup
{
    public static class ItemsViewExtensions
    {
        /*public static TItemsView ItemTemplate<TItemsView>(this TItemsView itemsView, DataTemplate dataTemplate)
            where TItemsView : ItemsView
        {
            itemsView.ItemTemplate = dataTemplate;
            return itemsView;
        }*/

        public static TItemsView ItemTemplate<TItemsView>(this TItemsView itemsView, Func<object> loadTemplate)
            where TItemsView : ItemsView
        {
            itemsView.ItemTemplate = new DataTemplate(loadTemplate);
            return itemsView;
        }

        public static TItemsView ItemTemplate<TItemsView>(this TItemsView itemsView, Type templateType)
            where TItemsView : ItemsView
        {
            itemsView.ItemTemplate = new DataTemplate(templateType);
            return itemsView;
        }
    }
}
