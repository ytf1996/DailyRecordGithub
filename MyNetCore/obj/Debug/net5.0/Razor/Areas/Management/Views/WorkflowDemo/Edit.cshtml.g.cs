#pragma checksum "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\WorkflowDemo\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c047f1200acadda9cae3e4f63d0865a1483e888c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_WorkflowDemo_Edit), @"mvc.1.0.view", @"/Areas/Management/Views/WorkflowDemo/Edit.cshtml")]
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
#line 1 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\WorkflowDemo\Edit.cshtml"
using MyNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\WorkflowDemo\Edit.cshtml"
using MyNetCore.Business;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c047f1200acadda9cae3e4f63d0865a1483e888c", @"/Areas/Management/Views/WorkflowDemo/Edit.cshtml")]
    public class Areas_Management_Views_WorkflowDemo_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WorkflowDemo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\WorkflowDemo\Edit.cshtml"
  
    var htmlStr = BusinessHelper.BuildCreateOrEditPageForWorkflow<WorkflowDemo>(Model, 2);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\WorkflowDemo\Edit.cshtml"
Write(htmlStr);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""secondTabContent"">
    <div class=""card"">
        <div class=""card-body"">
            <div id=""toolbar"">

            </div>
            <table id=""sampleTableForWorkflowProgressDemo"" entity=""WorkflowAction""></table>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    showSecondTab(""审批记录"");
    $(document).ready(function () {
        initTable(""sampleTableForWorkflowProgressDemo"", ""GetListDataForWorkflowProgressDemo"");
    });

    tableColumn = [
        {
            title: ""操作日期"",
            field: ""createdDate"",
            sortable: true
        },
        {
            title: ""操作人"",
            field: ""createdBy"",
            sortable: true
        },
        {
            title: ""操作"",
            field: ""workflowButtonName"",
            sortable: false
        },
        {
            title: ""备注"",
            field: ""remark"",
            sortable: false
        }
    ];

    //默认Name排序
    defalutOrderCol = ""CreatedDate"";
</sc");
            WriteLiteral("ript>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WorkflowDemo> Html { get; private set; }
    }
}
#pragma warning restore 1591
