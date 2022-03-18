namespace VijayAnand.MauiToolkit.Core
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class PreserveAttribute : Attribute
    {
        // Keep all members
        public bool AllMembers;

        // Keep member only if the type itself is kept
        public bool Conditional;
    }
}
