#pragma checksum "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10067cf11352c8cd793c82b1f52ab9ae31b8661f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_Territory_Edit), @"mvc.1.0.view", @"/Areas/Management/Views/Territory/Edit.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
using MyNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
using MyNetCore.Business;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10067cf11352c8cd793c82b1f52ab9ae31b8661f", @"/Areas/Management/Views/Territory/Edit.cshtml")]
    public class Areas_Management_Views_Territory_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Territory>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Management/Home/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
  
    var ParentTerritoryModel = new BusinessTerritory().GetByTerrId(Model.ParentTerrId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-title\">\r\n    <div>\r\n        <h1><i class=\"fa fa-edit\"></i>区域</h1>\r\n        <p>编辑区域</p>\r\n    </div>\r\n    <div>\r\n        <ul class=\"breadcrumb\">\r\n            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10067cf11352c8cd793c82b1f52ab9ae31b8661f3985", async() => {
                WriteLiteral("<i class=\"fa fa-home fa-lg\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
            <li><a href=""List"">区域</a></li>
            <li class=""active"">编辑区域</li>
        </ul>
    </div>
</div>

<ul class=""nav nav-tabs"" role=""tablist"">
    <li id=""firstTabTitle"" role=""presentation"" class=""active"">
        <a href=""#firstTab"" aria-controls=""firstTab"" role=""tab"" data-toggle=""tab"">详情</a>
    </li>
    <li id=""secondTabTitle"" role=""presentation"">
        <a id=""secondTabA"" href=""#secondTab"" aria-controls=""secondTab"" role=""tab"" data-toggle=""tab"">明细</a>
    </li>
</ul>
<div class=""tab-content"">
    <div role=""tabpanel"" class=""tab-pane active"" id=""firstTab"">
        <div class=""card"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""well bs-component"">
                        <form id=""editForm"" class=""form-horizontal"" method=""post"">
                            <input type=""hidden""");
            BeginWriteAttribute("value", " value=\"", 1307, "\"", 1324, 1);
#nullable restore
#line 38 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
WriteAttributeValue("", 1315, Model.Id, 1315, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"Id\" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1388, "\"", 1414, 1);
#nullable restore
#line 39 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
WriteAttributeValue("", 1396, Model.CreatedById, 1396, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"CreatedById\" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1487, "\"", 1513, 1);
#nullable restore
#line 40 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
WriteAttributeValue("", 1495, Model.CreatedDate, 1495, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"CreatedDate\" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1586, "\"", 1606, 1);
#nullable restore
#line 41 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
WriteAttributeValue("", 1594, Model.Depth, 1594, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"Depth\" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1673, "\"", 1702, 1);
#nullable restore
#line 42 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
WriteAttributeValue("", 1681, Model.NextRangeStart, 1681, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"NextRangeStart\" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1778, "\"", 1801, 1);
#nullable restore
#line 43 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
WriteAttributeValue("", 1786, Model.RangeEnd, 1786, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"RangeEnd\" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1871, "\"", 1900, 1);
#nullable restore
#line 44 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
WriteAttributeValue("", 1879, Model.RangeIncrement, 1879, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"RangeIncrement\" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1976, "\"", 2002, 1);
#nullable restore
#line 45 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
WriteAttributeValue("", 1984, Model.TerritoryId, 1984, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"TerritoryId\" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 2075, "\"", 2098, 1);
#nullable restore
#line 46 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
WriteAttributeValue("", 2083, Model.TheOrder, 2083, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""TheOrder"" />
                            <fieldset>
                                <div class=""form-group"">
                                    <div class=""col-md-6"">
                                        <label class=""control-label"" for=""ParentTerrId"">上级</label>
                                        <select class=""form-control required select2"" id=""ParentTerrId"" name=""ParentTerrId"">
");
#nullable restore
#line 52 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
                                             if (ParentTerritoryModel != null)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <option");
            BeginWriteAttribute("value", " value=\"", 2686, "\"", 2727, 1);
#nullable restore
#line 54 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
WriteAttributeValue("", 2694, ParentTerritoryModel.TerritoryId, 2694, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 54 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
                                                                                             Write(ParentTerritoryModel.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 55 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </select>
                                    </div>
                                    <div class=""col-md-6"">
                                        <label class=""control-label"" for=""Name"">名称</label>
                                        <input class=""form-control required"" id=""Name"" name=""Name"" type=""text"" placeholder=""名称""");
            BeginWriteAttribute("value", " value=\"", 3187, "\"", 3206, 1);
#nullable restore
#line 60 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
WriteAttributeValue("", 3195, Model.Name, 3195, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    </div>\r\n                                </div>\r\n\r\n\r\n                                <div class=\"form-group\">\r\n                                    <div class=\"col-md-12\">\r\n                                        ");
#nullable restore
#line 67 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
                                    Write(ButtonHelper.GetBackButton());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 68 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
                                    Write(ButtonHelper.GetDeleteButton<Territory>(Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 69 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\Territory\Edit.cshtml"
                                    Write(ButtonHelper.GetSaveButtonForEdit<Territory>(Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </div>
                                </div>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Territory> Html { get; private set; }
    }
}
#pragma warning restore 1591
