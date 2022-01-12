#pragma checksum "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Areas\Management\Views\WeChatWorkSettingParam\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cca61ed4c45e8fe955f1c21ae1e00d7da60186a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_WeChatWorkSettingParam_Edit), @"mvc.1.0.view", @"/Areas/Management/Views/WeChatWorkSettingParam/Edit.cshtml")]
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
#line 1 "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Areas\Management\Views\WeChatWorkSettingParam\Edit.cshtml"
using MyNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Areas\Management\Views\WeChatWorkSettingParam\Edit.cshtml"
using MyNetCore.Business;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cca61ed4c45e8fe955f1c21ae1e00d7da60186a4", @"/Areas/Management/Views/WeChatWorkSettingParam/Edit.cshtml")]
    public class Areas_Management_Views_WeChatWorkSettingParam_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WeChatWorkSettingParam>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Areas\Management\Views\WeChatWorkSettingParam\Edit.cshtml"
  
    var htmlStr = BusinessHelper.BuildCreateOrEditPage<WeChatWorkSettingParam>(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Areas\Management\Views\WeChatWorkSettingParam\Edit.cshtml"
Write(htmlStr);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""tab2Content"">
    <div class=""card"">
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <label class=""control-label"" for=""InitQYMenu"">初始化企业号应用菜单</label>
                    <div>
                        <button id=""InitQYMenu"" class=""btn btn-danger btn-loading control-label"" name=""InitQYMenu""
                           onclick=""initQYMenu()"">初始化企业号应用菜单</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">

    function initQYMenu()
    {
        $(""#InitQYMenu"").button('loading');
        swal({
            title: ""确定?"",
            text: ""此操作将会初始化企业号应用菜单!"",
            type: ""warning"",
            showCancelButton: true,
            confirmButtonText: ""是"",
            cancelButtonText: ""否"",
            closeOnConfirm: true,
            closeOnCancel: true
        }, function (isConfirm) {
            if ");
            WriteLiteral(@"(isConfirm) {
                $.ajax({
                    url: ""ChuShiHuaCaiDan"",
                    type: ""post"",
                    dataType: ""JSON"",
                    success: function (result) {
                        if (result) {
                            if (result.result == ""success"") {
                                showInfoMsg(""成功"", ""操作成功"");
                                window.setTimeout(function () { window.location.reload(); }, 2000);
                            }
                            else {
                                showErrorMsg(""操作失败"", result.msg);
                            }
                        }
                        else {
                            showErrorMsg(""操作失败"", ""未知错误"");
                        }
                    }, error: function (XMLHttpRequest, errorInfo, errorObj) {
                        resetLoadButton();
                        showErrorMsg(""操作失败"", errorInfo);
                    }
                })

            } ");
            WriteLiteral("else {\r\n                resetLoadButton();\r\n            }\r\n        });\r\n    }\r\n\r\n    $(document).ready(function () {\r\n        showOtherTab(\"其它\");\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WeChatWorkSettingParam> Html { get; private set; }
    }
}
#pragma warning restore 1591
