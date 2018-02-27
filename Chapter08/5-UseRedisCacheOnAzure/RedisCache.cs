using System;
using StackExchange.Redis;

public interface ICacheRedis
{
    T Get<T>(string key);
    void Set<T>(string key, T obj);
}
public class CacheRedis : ICacheRedis
{
    private static IDatabase redis;

    public T Get<T>(string key)
    {
        redis = Connection.GetDatabase();
        var obj = redis.Get<T>(key);
        if (obj == null)
            return default(T);

        return obj;
    }

    public void Set<T>(string key, T obj)
    {
        redis = Connection.GetDatabase();
        if (obj != null)
            redis.Set(key, obj);
    }

    public void InvalidateCache(string key)
    {
        IDatabase cache = Connection.GetDatabase();
        cache.KeyDelete(key);
    }

    private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
    {
        return ConnectionMultiplexer.Connect("localhost:6379,abortConnect=False");
    });

    public static ConnectionMultiplexer Connection
    {
        get
        {
            return lazyConnection.Value;
        }
    }
}
