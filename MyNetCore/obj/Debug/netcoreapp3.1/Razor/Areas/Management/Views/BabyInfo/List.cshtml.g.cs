#pragma checksum "C:\Users\16273\Desktop\DailyRecord\MyNetCore\Areas\Management\Views\BabyInfo\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90aa1c020d8622341c00366b5d1c1590542a4369"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_BabyInfo_List), @"mvc.1.0.view", @"/Areas/Management/Views/BabyInfo/List.cshtml")]
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
#line 1 "C:\Users\16273\Desktop\DailyRecord\MyNetCore\Areas\Management\Views\BabyInfo\List.cshtml"
using MyNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\16273\Desktop\DailyRecord\MyNetCore\Areas\Management\Views\BabyInfo\List.cshtml"
using MyNetCore.Business;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90aa1c020d8622341c00366b5d1c1590542a4369", @"/Areas/Management/Views/BabyInfo/List.cshtml")]
    public class Areas_Management_Views_BabyInfo_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\16273\Desktop\DailyRecord\MyNetCore\Areas\Management\Views\BabyInfo\List.cshtml"
  
    var htmlStr = BusinessHelper.BuildListPage<BabyInfo>();

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\16273\Desktop\DailyRecord\MyNetCore\Areas\Management\Views\BabyInfo\List.cshtml"
Write(htmlStr);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


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
            title: ""性别"",
            field: ""sex"",
            sortable: true,
        },
        {
            title: ""出生时间"",
            field: ""timeOfBirth"",
            sortable: true,
        },
        {
            title: ""出生重量"",
            field: ""birthWeight"",
            sortable: true,
        }
    ];
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
