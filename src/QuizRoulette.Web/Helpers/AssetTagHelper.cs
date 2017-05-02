using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using QuizRoulette.Web.Services;

namespace QuizRoulette.Web.Helpers
{
    [HtmlTargetElement("script",
        Attributes = "asset-src",
        TagStructure = TagStructure.NormalOrSelfClosing)]
    public class WebpackScriptTagHelper : WebpackAssetTagHelper
    {
        public override string Source => "asset-src";
        public override string Attribute => "src";

        public WebpackScriptTagHelper(IUrlHelper urlHelper, IAssetPathService assetPathsService)
            : base(assetPathsService) { }
    }

    [HtmlTargetElement("link",
        Attributes = "asset-href",
        TagStructure = TagStructure.WithoutEndTag)]
    public class WebpackLinkTagHelper : WebpackAssetTagHelper
    {
        public override string Source => "asset-href";
        public override string Attribute => "href";

        public WebpackLinkTagHelper(IUrlHelper urlHelper, IAssetPathService assetPathsService)
            : base(assetPathsService) { }
    }

    public abstract class WebpackAssetTagHelper : TagHelper
    {
        public abstract string Source { get; }
        public abstract string Attribute { get; }

        private IAssetPathService _assetPathsService;

        public WebpackAssetTagHelper(IAssetPathService assetPathsService)
        {
            _assetPathsService = assetPathsService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            TagHelperAttribute attr;
            if (!context.AllAttributes.TryGetAttribute(Source, out attr))
            {
                throw new Exception($"Failed to get attribute: {Attribute}");
            }

            var contentPath = _assetPathsService.GetPath(attr.Value.ToString());
            output.Attributes.RemoveAt(output.Attributes.IndexOfName(Source));
            output.Attributes.SetAttribute(Attribute, contentPath);
        }
    }
}