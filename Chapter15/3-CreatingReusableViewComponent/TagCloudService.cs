using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITagCloudService
{
    Task<List<Tag>> GetTagsAsync(string userBlog);
}

public class TagCloudService : ITagCloudService
{
    public async Task<List<Tag>> GetTagsAsync(string userBlog)
    {
        return await Task.Run(() => GetTags(userBlog));
    }

    private List<Tag> GetTags(string userBlog)
    {
        return new List<Tag>
        {
            new Tag { Id = 1, Name = "Asp.Net Core" },
            new Tag { Id = 2, Name = "EF Core" }
        };
    }
}

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
}
