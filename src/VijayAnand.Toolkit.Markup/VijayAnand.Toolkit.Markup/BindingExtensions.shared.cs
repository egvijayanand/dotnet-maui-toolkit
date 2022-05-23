namespace VijayAnand.Toolkit.Markup
{
    public static class BindingExtensions
    {
        public static Binding Path(this Binding binding, string path)
        {
            binding.Path = path;
            return binding;
        }

        public static Binding Format(this Binding binding, string format)
        {
            binding.StringFormat = format;
            return binding;
        }
    }
}
