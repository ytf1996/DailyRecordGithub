#pragma checksum "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\WorkflowDemo\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "034c31863d57f97d931bc2933a244ca8e731828a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_WorkflowDemo_List), @"mvc.1.0.view", @"/Areas/Management/Views/WorkflowDemo/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Management/Views/WorkflowDemo/List.cshtml", typeof(AspNetCore.Areas_Management_Views_WorkflowDemo_List))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"034c31863d57f97d931bc2933a244ca8e731828a", @"/Areas/Management/Views/WorkflowDemo/List.cshtml")]
    public class Areas_Management_Views_WorkflowDemo_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Management/Home/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\WorkflowDemo\List.cshtml"
  
    ViewBag.Title = "WorkflowDemo列表";

#line default
#line hidden
            BeginContext(48, 124, true);
            WriteLiteral("<div class=\"page-title\">\r\n    <div>\r\n        <h1>WorkflowDemo列表</h1>\r\n        <ul class=\"breadcrumb side\">\r\n            <li>");
            EndContext();
            BeginContext(172, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "034c31863d57f97d931bc2933a244ca8e731828a3700", async() => {
                BeginContext(206, 32, true);
                WriteLiteral("<i class=\"fa fa-home fa-lg\"></i>");
                EndContext();
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
            EndContext();
            BeginContext(242, 1070, true);
            WriteLiteral(@"</li>
            <li>管理</li>
            <li class=""active"">WorkflowDemo</li>
        </ul>
    </div>
    <div>
        <a class=""btn btn-primary btn-flat"" href=""Add""><i class=""fa fa-lg fa-plus""></i></a>
    </div>
</div>
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card"">
            <div class=""card-body"">
                <table id=""sampleTable"" entity=""WorkflowDemo""></table>
            </div>
        </div>
    </div>
</div>


<script>
    tableColumn = [
        //{
        //    checkbox: true
        //},
        {
            title: ""名称"",
            field: ""name"",
            sortable: true,
            formatter: function (value, row, index) {
                return '<a href=""Edit?id=' + row.id + '"">' + value + '</a>';
            }
        },
        {
            title: ""工作流状态"",
            field: ""workflowStatus"",
            sortable: true,
        },
        {
            title: ""当前操作人"",
            field: ""shenPiRen"",
            ");
            WriteLiteral("sortable: false,\r\n        }\r\n    ];\r\n</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
