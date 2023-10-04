using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using Microsoft.DotNet.Interactive.Formatting.TabularData;
using Microsoft.DotNet.Interactive.Formatting;

namespace Naratteu.DotNet.Interactive.Formatting.Blazor;

public class BlazorTag : ComponentBase
{
    [Parameter] public required string Name { get; init; }
    [Parameter] public Dictionary<string, object>? Attr { get; init; }
    [Parameter] public RenderFragment? ChildContent { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Name);
        builder.AddMultipleAttributes(1, Attr);
        builder.AddContent(2, ChildContent);
        builder.CloseElement();
    }
}

public static class BlazorTagExtension
{
    public static RenderFragment ToDisplayHtml(this object o) => BlazorTagStatic.ToBlazorHtml(o.ToDisplayString(HtmlFormatter.MimeType));
    public static RenderFragment ToTableHtml<T>(this IEnumerable<T> t) => t.ToTabularDataResource().ToDisplayHtml();
}