using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace WebApplication
{
    public class ValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            return Task.FromResult(true);
        }
    }
}
