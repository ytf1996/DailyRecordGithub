#pragma checksum "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Notice\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7b0c478582b07246698c74d642b015cab0eb708"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_Notice_Edit), @"mvc.1.0.view", @"/Areas/Management/Views/Notice/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Management/Views/Notice/Edit.cshtml", typeof(AspNetCore.Areas_Management_Views_Notice_Edit))]
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
#line 1 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Notice\Edit.cshtml"
using MyNetCore.Models;

#line default
#line hidden
#line 2 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Notice\Edit.cshtml"
using MyNetCore.Business;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7b0c478582b07246698c74d642b015cab0eb708", @"/Areas/Management/Views/Notice/Edit.cshtml")]
    public class Areas_Management_Views_Notice_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Notice>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(67, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Notice\Edit.cshtml"
  
    var htmlStr = BusinessHelper.BuildCreateOrEditPage<Notice>(Model, 2, true, true);

#line default
#line hidden
            BeginContext(163, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(166, 7, false);
#line 9 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Notice\Edit.cshtml"
Write(htmlStr);

#line default
#line hidden
            EndContext();
            BeginContext(173, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Notice> Html { get; private set; }
    }
}
#pragma warning restore 1591
