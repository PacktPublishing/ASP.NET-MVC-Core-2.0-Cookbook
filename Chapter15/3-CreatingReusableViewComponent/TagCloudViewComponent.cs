using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class TagCloudViewComponent : ViewComponent
{
    private readonly ITagCloudService _service;

    public TagCloudViewComponent(ITagCloudService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync(string userBlog)
    {
        var viewModel = await _service.GetTagsAsync(userBlog);
        return View(viewModel);
    }
}
