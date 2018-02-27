using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class MyActionTypeFilterAttribute : TypeFilterAttribute
{
    public MyActionTypeFilterAttribute() : base(typeof(MyActionTypeFilterAttributeImpl))
    { }

    private class MyActionTypeFilterAttributeImpl : IActionFilter
    {
        private readonly IRepository _repository;

        public MyActionTypeFilterAttributeImpl(IRepository repository)
        {
            _repository = repository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }
}
