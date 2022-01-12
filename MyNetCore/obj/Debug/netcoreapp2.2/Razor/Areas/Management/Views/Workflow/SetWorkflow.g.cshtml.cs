#pragma checksum "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\SetWorkflow.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f93ece2ab0ab84d5dcbdc764aafc4b608a7ae1e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_Workflow_SetWorkflow), @"mvc.1.0.view", @"/Areas/Management/Views/Workflow/SetWorkflow.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Management/Views/Workflow/SetWorkflow.cshtml", typeof(AspNetCore.Areas_Management_Views_Workflow_SetWorkflow))]
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
#line 1 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\SetWorkflow.cshtml"
using MyNetCore.Models;

#line default
#line hidden
#line 2 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\SetWorkflow.cshtml"
using MyNetCore.Business;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f93ece2ab0ab84d5dcbdc764aafc4b608a7ae1e2", @"/Areas/Management/Views/Workflow/SetWorkflow.cshtml")]
    public class Areas_Management_Views_Workflow_SetWorkflow : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\SetWorkflow.cshtml"
  
    int? workflowId = Roim.Common.ConvertHelper.ConvertToInt(AppContextMy.Current.Request.Query["workflowId"], 0);
    BusinessWorkflow businessWorkflow = new BusinessWorkflow();
    Workflow model = businessWorkflow.GetById(workflowId.Value);

#line default
#line hidden
            BeginContext(308, 3367, true);
            WriteLiteral(@"
<style class=""csscreations"">
    /*Now the CSS*/
    * {
        margin: 0;
        padding: 0;
    }

    .tree ul {
        padding-top: 20px;
        position: relative;
        transition: all 0.5s;
        -webkit-transition: all 0.5s;
        -moz-transition: all 0.5s;
    }

    .tree li {
        float: left;
        text-align: center;
        list-style-type: none;
        position: relative;
        padding: 20px 5px 0 5px;
        transition: all 0.5s;
        -webkit-transition: all 0.5s;
        -moz-transition: all 0.5s;
    }

        /*We will use ::before and ::after to draw the connectors*/

        .tree li::before, .tree li::after {
            content: '';
            position: absolute;
            top: 0;
            right: 50%;
            border-top: 1px solid #ccc;
            width: 50%;
            height: 20px;
        }

        .tree li::after {
            right: auto;
            left: 50%;
            border-left: 1px solid #ccc;
 ");
            WriteLiteral(@"       }

        /*We need to remove left-right connectors from elements without
        any siblings*/
        .tree li:only-child::after, .tree li:only-child::before {
            display: none;
        }

        /*Remove space from the top of single children*/
        .tree li:only-child {
            padding-top: 0;
        }

        /*Remove left connector from first child and
        right connector from last child*/
        .tree li:first-child::before, .tree li:last-child::after {
            border: 0 none;
        }
        /*Adding back the vertical connector to the last nodes*/
        .tree li:last-child::before {
            border-right: 1px solid #ccc;
            border-radius: 0 5px 0 0;
            -webkit-border-radius: 0 5px 0 0;
            -moz-border-radius: 0 5px 0 0;
        }

        .tree li:first-child::after {
            border-radius: 5px 0 0 0;
            -webkit-border-radius: 5px 0 0 0;
            -moz-border-radius: 5px 0 0 0;
        }
");
            WriteLiteral(@"
    /*Time to add downward connectors from parents*/
    .tree ul ul::before {
        content: '';
        position: absolute;
        top: 0;
        left: 50%;
        border-left: 1px solid #ccc;
        width: 0;
        height: 20px;
    }

    .tree li a {
        border: 1px solid #ccc;
        padding: 5px 10px;
        text-decoration: none;
        color: #666;
        font-family: arial, verdana, tahoma;
        font-size: 11px;
        display: inline-block;
        border-radius: 5px;
        -webkit-border-radius: 5px;
        -moz-border-radius: 5px;
        transition: all 0.5s;
        -webkit-transition: all 0.5s;
        -moz-transition: all 0.5s;
    }

        .tree li a:hover, .tree li a:hover + ul li a {
            background: #c8e4f8;
            color: #000;
            border: 1px solid #94a0b4;
        }
            /*Connector styles on hover*/
            .tree li a:hover + ul li::after,
            .tree li a:hover + ul li::before,
         ");
            WriteLiteral(@"   .tree li a:hover + ul::before,
            .tree li a:hover + ul ul::before {
                border-color: #94a0b4;
            }

    .workflowButton{
        border-radius: 50%!important;
    }
</style>

<div class=""page-title"">
    <div>
        <h1><i class=""fa fa-edit""></i>");
            EndContext();
            BeginContext(3677, 26, false);
#line 131 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\SetWorkflow.cshtml"
                                  Write(model==null?"": model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(3704, 302, true);
            WriteLiteral(@"</h1>
        <p>工作流设置</p>
    </div>
    <div>
        <ul class=""breadcrumb"">
            <li><a href=""/Management/Home/Index""><i class=""fa fa-home fa-lg""></i></a></li>
            <li><a href=""List"">工作流</a></li>
            <li class=""active"">工作流设置</li>
        </ul>
    </div>
</div>

");
            EndContext();
#line 143 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\SetWorkflow.cshtml"
  
    var htmlStr = businessWorkflow.GetWorkflowHtmlByWorkflowId(workflowId.Value);

#line default
#line hidden
            BeginContext(4097, 7, false);
#line 146 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\SetWorkflow.cshtml"
Write(htmlStr);

#line default
#line hidden
            EndContext();
            BeginContext(4104, 2, true);
            WriteLiteral("\r\n");
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
