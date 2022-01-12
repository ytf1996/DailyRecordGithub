#pragma checksum "C:\Users\16273\Desktop\DailyRecord\MyNetCore\Views\Home\PDFHelper.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "851ea2bc887606eb0a7abf63185d28dae987bd2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_PDFHelper), @"mvc.1.0.view", @"/Views/Home/PDFHelper.cshtml")]
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
#line 1 "C:\Users\16273\Desktop\DailyRecord\MyNetCore\Views\_ViewImports.cshtml"
using MyNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\16273\Desktop\DailyRecord\MyNetCore\Views\_ViewImports.cshtml"
using MyNetCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"851ea2bc887606eb0a7abf63185d28dae987bd2b", @"/Views/Home/PDFHelper.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b34712fd2cd0388a077508a08803d5f08adf0dd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_PDFHelper : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<style>\r\n    .btn {\r\n        width: 100%;\r\n    }\r\n</style>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <a href=\"http://118.25.35.119/Home/PDFHelper\">速度慢(切换线路)</a>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 13 "C:\Users\16273\Desktop\DailyRecord\MyNetCore\Views\Home\PDFHelper.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row"" id=""filesRow"">
        <div class=""col-md-12"">
            <input type=""hidden"" id=""mergeFilePath"" />
            <label class=""control-label"">上传PDF文件</label>
            <div class=""input-group"">
                <input class=""form-control files"" name=""file"" type=""file"" accept=""application/pdf"">
                <span class=""input-group-btn""><button class=""btn btn-danger btn-add-file"" type=""button""><i class=""fa fa-plus""></i></button></span>
            </div>
        </div>
    </div>
    <br />
    <div class=""row"">
        <div class=""col-md-12"">
            <input id=""btn-submit"" type=""button"" class=""btn btn-info btn-loading"" value=""上传并合并"" />
        </div>
        <div class=""col-md-12 download"">
            <input id=""btn-submit"" type=""button"" class=""btn btn-success btn-download"" value=""下载"" />
        </div>
    </div>
");
#nullable restore
#line 34 "C:\Users\16273\Desktop\DailyRecord\MyNetCore\Views\Home\PDFHelper.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    $("".btn-add-file"").click(function () {
        var htmlStr = ""<div class=\""input-group\""><input name=\""file\"" class=\""form-control files\"" type=\""file\"" accept=\""application/pdf\""><span class=\""input-group-btn\""><button class=\""btn btn-danger btn-remove-file\"" type=\""button\""><i class=\""fa fa-minus\""></i></button></span></div>"";
        $(""#filesRow"").find("".col-md-12"").append(htmlStr);
        $("".btn-remove-file"").click(function () {
            $(this).parent().parent().remove();
        });
    });

    $("".download"").hide();

    $(""#btn-submit"").click(function () {
        $("".download"").hide();
        var formData = new FormData();
        var fileTypeIsCorrect = true;
        $("".files"").each(function () {
            if ($(this)[0].files && $(this)[0].files[0]) {
                if ($(this)[0].files[0].type != ""application/pdf"") {
                    fileTypeIsCorrect = false;
                    return;
                }
                for");
            WriteLiteral(@"mData.append($(this)[0].files[0].name, $(this)[0].files[0]);
            }
        });

        if (fileTypeIsCorrect == false) {
            showErrorMsg(""操作失败"", ""选择的文件类型不正确"");
            window.setTimeout(function () { resetLoadButton(); }, 1000);
            return;
        }

        if (formData.forEach.length == 0) {
            showErrorMsg(""操作失败"", ""请先选择要合并的文件"");
            window.setTimeout(function () { resetLoadButton(); }, 1000);
            return;
        }

        formData.append(""mergeFilePath"", $(""#mergeFilePath"").val());

        $.ajax({
            url: ""PDFMerge"",
            type: ""POST"",
            data: formData,
            contentType: false,//必须false才会自动加上正确的Content-Type
            processData: false,//必须false才会避开jQuery对 formdata 的默认处理.XMLHttpRequest会对 formdata 进行正确的处理.
            success: function (result) {
                resetLoadButton();
                if (result) {
                    if (result.result == ""failure"") {
                        ");
            WriteLiteral(@"showErrorMsg(""操作失败"", result.msg);
                        return;
                    }
                    $(""#mergeFilePath"").val(result.data.outMergeFile);
                    if (result.msg && result.msg != """") {
                        showInfoMsg(""合并成功"", result.msg, 0);
                        $("".download"").show();
                    }
                    if (result.data.outMergeFile && result.data.outMergeFile != """") {
                        downloadFile(getRootPath() + result.data.outMergeFile);
                    }
                }
                else {
                    showErrorMsg(""操作失败"", ""服务器未响应"");
                    return;
                }
            },
            error: function (result) {
                resetLoadButton();
            }
        });

    });

    function downloadFile(url) {
        window.open(url);
    }

    $("".btn-download"").click(function () {
        var fileUrl = $(""#mergeFilePath"").val();
        if (fileUrl != """") {
        ");
            WriteLiteral(@"    downloadFile(getRootPath() + fileUrl);
        }
    });

    //判断是否是微信浏览器的函数
    function isWeiXin() {
        //window.navigator.userAgent属性包含了浏览器类型、版本、操作系统类型、浏览器引擎类型等信息，这个属性可以用来判断浏览器类型
        var ua = window.navigator.userAgent.toLowerCase();
        //通过正则表达式匹配ua中是否含有MicroMessenger字符串
        if (ua.match(/MicroMessenger/i) == 'micromessenger') {
            return true;
        } else {
            return false;
        }
    }

    if(isWeiXin())
    {
        showErrorMsg(""注意"", ""微信中无法操作，请在浏览器中打开，建议在电脑端浏览器中操作"",0);
    }

</script>
");
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
