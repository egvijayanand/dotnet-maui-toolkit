namespace VijayAnand.Toolkit.Markup
{
    public class Stack : StackLayout { }

#if NETSTANDARD2_0_OR_GREATER
    public class HStack : StackLayout
    {
        public HStack() => Orientation = StackOrientation.Horizontal;
    }

    public class VStack : StackLayout { }
#elif NET6_0_OR_GREATER
    public class HStack : HorizontalStackLayout { }

    public class VStack : VerticalStackLayout { }
#endif
}
