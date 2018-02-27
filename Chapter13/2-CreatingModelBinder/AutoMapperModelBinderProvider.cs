using Microsoft.AspNetCore.Mvc.ModelBinding;

public class AutoMapperModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        var type = context.BindingInfo.BinderType;
        if (type != typeof(ProductViewModel))
        {
            return null;
        }
        return new AutoMapperModelBinder();
    }
}
