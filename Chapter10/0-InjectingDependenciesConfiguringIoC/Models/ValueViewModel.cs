public class ValueViewModel
{
    public ValueViewModel(object val)
    {
        Value = val.ToString();
    }
    public string Value { get; set; }
}
