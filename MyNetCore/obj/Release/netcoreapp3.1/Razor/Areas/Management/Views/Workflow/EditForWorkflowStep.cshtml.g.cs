#pragma checksum "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\EditForWorkflowStep.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a544dae8051124cfd416b3fa13f09ef2d215a945"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_Workflow_EditForWorkflowStep), @"mvc.1.0.view", @"/Areas/Management/Views/Workflow/EditForWorkflowStep.cshtml")]
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
#line 1 "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\EditForWorkflowStep.cshtml"
using MyNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\EditForWorkflowStep.cshtml"
using MyNetCore.Business;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a544dae8051124cfd416b3fa13f09ef2d215a945", @"/Areas/Management/Views/Workflow/EditForWorkflowStep.cshtml")]
    public class Areas_Management_Views_Workflow_EditForWorkflowStep : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WorkflowStep>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\EditForWorkflowStep.cshtml"
  
    var htmlStr = BusinessHelper.BuildCreateOrEditPage<WorkflowStep>(Model, "6", true, false, "SetWorkflow?workflowId=" + Model.WorkflowId, "ajaxSaveForOther");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\EditForWorkflowStep.cshtml"
Write(htmlStr);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WorkflowStep> Html { get; private set; }
    }
}
#pragma warning restore 1591
