using StackExchange.Redis;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class RedisCacheExtensions
{
    public static T Get<T>(this IDatabase cache, string key)
    {
        return Deserialize<T>(cache.StringGet(key));
    }

    public static void Set(this IDatabase cache, string key, object value)
    {
        cache.StringSet(key, Serialize(value));
    }

    static byte[] Serialize(object o)
    {
        if (o == null)
        {
            return null;
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (MemoryStream memoryStream = new MemoryStream())
        {
            binaryFormatter.Serialize(memoryStream, o);
            byte[] objectDataAsStream = memoryStream.ToArray();
            return objectDataAsStream;
        }
    }

    static T Deserialize<T>(byte[] stream)
    {
        if (stream == null)
        {
            return default(T);
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (MemoryStream memoryStream = new MemoryStream(stream))
        {
            T result = (T)binaryFormatter.Deserialize(memoryStream);
            return result;
        }
    }
}
