public class HttpApplication
{
    public System.Func<object, object, object> BeginRequest { get; internal set; }
    public System.Func<object, object, object> EndRequest { get; internal set; }
    public dynamic Response { get; internal set; }
}