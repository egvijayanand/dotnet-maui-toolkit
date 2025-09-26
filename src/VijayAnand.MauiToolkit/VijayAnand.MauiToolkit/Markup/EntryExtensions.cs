namespace VijayAnand.MauiToolkit.Markup;

public static class EntryExtensions
{
    public static TEntry ReturnType<TEntry>(this TEntry entry, ReturnType kind)
        where TEntry : Entry
    {
        entry.ReturnType = kind;
        return entry;
    }

    public static TEntry Secure<TEntry>(this TEntry entry)
        where TEntry : Entry
    {
        entry.IsPassword = true;
        return entry;
    }
}
