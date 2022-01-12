#pragma checksum "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Views\TLBB\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0093bd06921a2ed17424b2a54f88a5b0a535f77b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TLBB_Index), @"mvc.1.0.view", @"/Views/TLBB/Index.cshtml")]
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
#line 1 "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Views\_ViewImports.cshtml"
using MyNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Views\_ViewImports.cshtml"
using MyNetCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0093bd06921a2ed17424b2a54f88a5b0a535f77b", @"/Views/TLBB/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b34712fd2cd0388a077508a08803d5f08adf0dd", @"/Views/_ViewImports.cshtml")]
    public class Views_TLBB_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\16273\Desktop\MyNetCore\MyNetCore\Views\TLBB\Index.cshtml"
  
    ViewData["Title"] = "自助添加点数";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">自助添加点数</h1>
    <div class=""row"">
        <div class=""col-md-12"">
            <input id=""account"" type=""text"" class=""control-label"" alt=""请输入需要添加点数的账号"" />
            <input id=""accountBtn"" type=""button"" class=""btn btn-primary btn-loading"" value=""添加1000点"" onclick=""addPoint()"" />
        </div>
    </div>
</div>

<script type=""text/javascript"">
    function addPoint() {
        var account = $(""#account"").val();
        if (account == """" || account == null || account == undefined) {
            showErrorMsg(""错误"", ""请输入需要操作的账号"", 0);
            return;
        }

        $.ajax({
            type: ""POST"",  //提交方式
            url: ""/TLBB/AddPoint"",//路径
            data: { account: account },
            dataType: ""json"",
            success: function (result) {//返回数据根据结果进行相应的处理
                resetLoadButton();
                if (result) {
                    if (result.result == ""failure"") {
                        showErrorMsg(""失败");
            WriteLiteral(@""", result.msg);
                        return;
                    }
                    showInfoMsg(""成功"", ""添加点数成功"");
                }
                else {
                    showErrorMsg(""失败"", ""添加点数失败"");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                dealErrorInfo(XMLHttpRequest);
                resetLoadButton();
            }
        });

    }

</script>");
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
