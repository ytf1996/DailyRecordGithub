#pragma checksum "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\AccessToken\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65aadb5eca575a5a657ac88faafe87d6704bad24"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_AccessToken_Edit), @"mvc.1.0.view", @"/Areas/Management/Views/AccessToken/Edit.cshtml")]
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
#line 1 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\AccessToken\Edit.cshtml"
using MyNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\AccessToken\Edit.cshtml"
using MyNetCore.Business;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65aadb5eca575a5a657ac88faafe87d6704bad24", @"/Areas/Management/Views/AccessToken/Edit.cshtml")]
    public class Areas_Management_Views_AccessToken_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AccessToken>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\AccessToken\Edit.cshtml"
  
    var htmlStr = BusinessHelper.BuildCreateOrEditPage<AccessToken>(Model, 2, true);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\01_code\MyCode\MyFrameWork\NetCoreBase3.1\MyNetCore\MyNetCore\Areas\Management\Views\AccessToken\Edit.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccessToken> Html { get; private set; }
    }
}
#pragma warning restore 1591
