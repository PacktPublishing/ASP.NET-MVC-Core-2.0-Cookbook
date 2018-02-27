using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("vmenu")]
public class VerticalMenuTagHelper : TagHelper
{
    public List<MenuElement> Elements { get; set; }
    public override void Process(
    TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "section";
        string menuElements = "<ul>";
        foreach (var e in Elements)
        {
            menuElements += $@"<li><ahref='{e.Controller}/{e.Action}'><strong>{e.Name}</strong></a></li>";
        }
        menuElements += "</ul>";
        output.Content.SetHtmlContent(menuElements);
        output.TagMode = TagMode.StartTagAndEndTag;
    }
}
