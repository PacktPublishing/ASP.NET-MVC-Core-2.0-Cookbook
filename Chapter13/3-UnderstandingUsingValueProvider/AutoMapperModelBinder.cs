using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

public class AutoMapperModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ProductDto productDto = new ProductDto();
        var modelType = bindingContext.ModelType;
        if (modelType == typeof(ProductViewModel))
        {
            var model = (ProductViewModel)bindingContext.Model;
            if (model != null)
            {
                productDto = Mapper.Map<ProductDto>(model);
            }
            bindingContext.Result =
            ModelBindingResult.Success(productDto);
        }

        return Task.CompletedTask;
    }
}
