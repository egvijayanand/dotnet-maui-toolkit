namespace VijayAnand.MauiToolkit.Core.Services;

/// <summary>
/// Defines a contract for a data store that supports basic CRUD operations for items of type <typeparamref name="T"/>
/// identified by <typeparamref name="TId"/>.
/// </summary>
/// <typeparam name="T">The type of items stored in the data store.</typeparam>
/// <typeparam name="TId">The type of the identifier used to uniquely identify items in the data store.</typeparam>
public interface IDataStore<T, TId>
{
    /// <summary>
    /// Create a new item.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task<bool> AddItemAsync(T item);

    /// <summary>
    /// Read an item.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> GetItemAsync(TId id);

    /// <summary>
    /// Read all items.
    /// </summary>
    /// <param name="forceRefresh"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

    /// <summary>
    /// Update an item.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task<bool> UpdateItemAsync(T item);

    /// <summary>
    /// Delete an item.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteItemAsync(TId id);
}

/// <summary>
/// Represents a data store that provides basic operations for storing and retrieving data of type <typeparamref
/// name="T"/>.
/// </summary>
/// <typeparam name="T">The type of data to be stored and retrieved.</typeparam>
public interface IDataStore<T> : IDataStore<T, string>;
