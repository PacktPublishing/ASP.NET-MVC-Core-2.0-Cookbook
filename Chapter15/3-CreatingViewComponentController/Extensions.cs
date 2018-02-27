using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.AspNetCore.Http;

public static class SessionExtensions
{
    public static T Get<T>(this ISession session, string key)
    {
        var obj = session.Get(key);
        if (obj == null)
            return default(T);

        return Deserialize<T>(obj);
    }

    public static void Set<T>(this ISession session, string key, T obj)
    {
        if (obj != null)
            session.Set(key, Serialize(obj));
    }

    private static byte[] Serialize(object o)
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

    private static T Deserialize<T>(byte[] stream)
    {
        if (stream == null)
            return default(T);

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (MemoryStream memoryStream = new MemoryStream(stream))
        {
            T result = (T)binaryFormatter.Deserialize(memoryStream);
            return result;
        }
    }
}
