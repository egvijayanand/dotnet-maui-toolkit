namespace VijayAnand.Toolkit.Markup
{
    public static class PickerExtensions
    {
        public static TPicker Items<TPicker>(this TPicker picker, IEnumerable<string> items)
#if NET6_0_OR_GREATER
            where TPicker : BindableObject, IPicker
#else
            where TPicker : Picker
#endif
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            else
            {
                foreach (var item in items)
                {
                    picker.Items.Add(item);
                }
            }

            return picker;
        }
    }
}
