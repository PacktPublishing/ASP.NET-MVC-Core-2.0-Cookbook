using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

public static class CustomHtmlHelpers
{
    public static IHtmlContent CustomTextboxFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string labelText)
    {
        var label = htmlHelper.LabelFor(expression, labelText);
        var textBox = htmlHelper.TextBoxFor(expression,
        new { @class = "form-control" });
        var validation = htmlHelper.ValidationMessageFor
        (expression, null,
        new { @class = "text-danger" });

        var writer = new StringWriter();
        label.WriteTo(writer, HtmlEncoder.Default);
        textBox.WriteTo(writer, HtmlEncoder.Default);
        validation.WriteTo(writer, HtmlEncoder.Default);

        return new HtmlString(writer.GetStringBuilder().ToString());
    }

    public static IHtmlContent CustomDropDownListFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, string labelText)
    {
        var label = htmlHelper.LabelFor(expression, labelText);
        var dropdownlist = htmlHelper.DropDownListFor
        (expression, selectList,
        "Please select one element on the list",
        new { @class = "form-control" });
        var validation = htmlHelper.ValidationMessageFor(expression, null,
        new { @class = "text-danger" });

        var writer = new StringWriter();
        label.WriteTo(writer, HtmlEncoder.Default);
        dropdownlist.WriteTo(writer, HtmlEncoder.Default);
        validation.WriteTo(writer, HtmlEncoder.Default);

        return new HtmlString(writer.GetStringBuilder().ToString());
    }
}
