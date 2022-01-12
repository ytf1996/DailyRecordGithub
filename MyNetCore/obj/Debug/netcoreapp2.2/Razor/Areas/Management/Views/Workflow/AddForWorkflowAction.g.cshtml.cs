#pragma checksum "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99440b589cfcf64165478c7066ec7f192fe8cc9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Management_Views_Workflow_AddForWorkflowAction), @"mvc.1.0.view", @"/Areas/Management/Views/Workflow/AddForWorkflowAction.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Management/Views/Workflow/AddForWorkflowAction.cshtml", typeof(AspNetCore.Areas_Management_Views_Workflow_AddForWorkflowAction))]
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
#line 1 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
using MyNetCore.Models;

#line default
#line hidden
#line 2 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
using MyNetCore.Business;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99440b589cfcf64165478c7066ec7f192fe8cc9d", @"/Areas/Management/Views/Workflow/AddForWorkflowAction.cshtml")]
    public class Areas_Management_Views_Workflow_AddForWorkflowAction : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WorkflowAction>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(75, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
   
    List<SelectListItem> listWorkflowActionType = Roim.Common.EnumHelperEx.GetSelectList(typeof(WorkflowActionType));
    List<SelectModel> listSelectModel = BusinessHelper.GetDBColumnsByClassFullName(Model.Workflow.WorkflowEntityName);

#line default
#line hidden
            BeginContext(324, 1313, true);
            WriteLiteral(@"
<div class=""page-title"">
    <div>
        <h1>
            <i class=""fa fa-edit""></i>工作流按钮事件
        </h1>
        <p>添加工作流按钮事件</p>
    </div>
    <div>
        <ul class=""breadcrumb"">
            <li>
                <a href=""/Management/Home/Index"">
                    <i class=""fa fa-home fa-lg""></i>
                </a>
            </li>
            <li>
                <a href=""List"">工作流按钮事件</a>
            </li>
            <li class=""active"">添加工作流按钮事件</li>
        </ul>
    </div>
</div>
<ul class=""nav nav-tabs"" role=""tablist"">
    <li id=""firstTabTitle"" role=""presentation"" class=""active"">
        <a href=""#firstTab"" aria-controls=""firstTab"" role=""tab"" data-toggle=""tab"">详情</a>
    </li>
    <li id=""secondTabTitle"" role=""presentation"">
        <a id=""secondTabA"" href=""#secondTab"" aria-controls=""secondTab"" role=""tab"" data-toggle=""tab"">明细</a>
    </li>
</ul>
<div class=""tab-content"">
    <div role=""tabpanel"" class=""tab-pane active"" id=""firstTab"">
        <div class=""card""");
            WriteLiteral(@">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""well bs-component"">
                        <form id=""addForm"" class=""form-horizontal"" method=""post"">
                            <input type=""hidden"" name=""entityId"" id=""EntityId""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1637, "\"", 1654, 1);
#line 46 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 1645, Model.Id, 1645, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1655, 228, true);
            WriteLiteral(" />\r\n                            <fieldset>\r\n                                <legend></legend>\r\n                                <div class=\"form-group\">\r\n                                    <input type=\"hidden\" name=\"WorkflowId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1883, "\"", 1908, 1);
#line 50 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 1891, Model.WorkflowId, 1891, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1909, 85, true);
            WriteLiteral(" />\r\n                                    <input type=\"hidden\" name=\"WorkflowButtonId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1994, "\"", 2025, 1);
#line 51 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 2002, Model.WorkflowButtonId, 2002, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2026, 71, true);
            WriteLiteral(" />\r\n                                    <input type=\"hidden\" name=\"Id\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2097, "\"", 2114, 1);
#line 52 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 2105, Model.Id, 2105, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2115, 80, true);
            WriteLiteral(" />\r\n                                    <input type=\"hidden\" name=\"CreatedById\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2195, "\"", 2221, 1);
#line 53 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 2203, Model.CreatedById, 2203, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2222, 80, true);
            WriteLiteral(" />\r\n                                    <input type=\"hidden\" name=\"CreatedDate\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2302, "\"", 2328, 1);
#line 54 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 2310, Model.CreatedDate, 2310, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2329, 80, true);
            WriteLiteral(" />\r\n                                    <input type=\"hidden\" name=\"UpdatedById\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2409, "\"", 2435, 1);
#line 55 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 2417, Model.UpdatedById, 2417, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2436, 80, true);
            WriteLiteral(" />\r\n                                    <input type=\"hidden\" name=\"UpdatedDate\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2516, "\"", 2542, 1);
#line 56 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 2524, Model.UpdatedDate, 2524, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2543, 76, true);
            WriteLiteral(" />\r\n                                    <input type=\"hidden\" name=\"Deleted\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2619, "\"", 2641, 1);
#line 57 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 2627, Model.Deleted, 2627, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2642, 601, true);
            WriteLiteral(@" />
                                    <input type=""hidden"" name=""Name"" value="""" />
                                    <input type=""hidden"" name=""TerritoryId"" value="""" />
                                    <div class=""col-md-6"">
                                        <label id=""lbl_WorkflowActionType"" class=""control-label"" for=""WorkflowActionType"">事件类型</label>
                                        <select class=""form-control  select2"" id=""WorkflowActionType"" name=""WorkflowActionType"" placeholder=""事件类型""
                                                onchange=""showActionTypeSet()"">
");
            EndContext();
#line 64 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
                                              
                                                if (listWorkflowActionType != null)
                                                {
                                                    foreach (var item in listWorkflowActionType)
                                                    {

#line default
#line hidden
            BeginContext(3580, 63, true);
            WriteLiteral("                                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3643, "\"", 3662, 1);
#line 69 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 3651, item.Value, 3651, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3663, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(3666, 85, false);
#line 69 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
                                                                                Write(((int)Model.WorkflowActionType).ToString() == item.Value ? "selected='selected'" : "");

#line default
#line hidden
            EndContext();
            BeginContext(3752, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3754, 9, false);
#line 69 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
                                                                                                                                                                        Write(item.Text);

#line default
#line hidden
            EndContext();
            BeginContext(3763, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 70 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
                                                    }
                                                }
                                            

#line default
#line hidden
            BeginContext(3927, 435, true);
            WriteLiteral(@"                                        </select>
                                    </div>
                                    <div class=""col-md-6 actionTypeSet runsql"">
                                        <label id=""lbl_RunSqlText"" class=""control-label"" for=""RunSqlText"">运行SQL语句</label>
                                        <input class=""form-control "" id=""RunSqlText"" name=""RunSqlText"" type=""text"" placeholder=""运行SQL语句""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4362, "\"", 4387, 1);
#line 77 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 4370, Model.RunSqlText, 4370, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4388, 409, true);
            WriteLiteral(@" />
                                    </div>
                                    <div class=""col-md-6 actionTypeSet editcolumnvalue"">
                                        <label id=""lbl_EditColumnName"" class=""control-label"" for=""EditColumnName"">修改字段名</label>
                                        <select class=""form-control select2"" id=""EditColumnName"" name=""EditColumnName"" placeholder=""修改字段名"">
");
            EndContext();
#line 82 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
                                              
                                                if (listSelectModel != null)
                                                {
                                                    foreach (var item in listSelectModel)
                                                    {

#line default
#line hidden
            BeginContext(5120, 64, true);
            WriteLiteral("                                                        <option ");
            EndContext();
            BeginContext(5186, 75, false);
#line 87 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
                                                            Write(item.SelectStringValue == Model.EditColumnName ? "selected='selected'" : "");

#line default
#line hidden
            EndContext();
            BeginContext(5262, 8, true);
            WriteLiteral(" value=\"");
            EndContext();
            BeginContext(5271, 22, false);
#line 87 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
                                                                                                                                                 Write(item.SelectStringValue);

#line default
#line hidden
            EndContext();
            BeginContext(5293, 2, true);
            WriteLiteral("\">");
            EndContext();
            BeginContext(5297, 66, false);
#line 87 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
                                                                                                                                                                           Write(string.Format("{0}({1})", item.SelectText, item.SelectStringValue));

#line default
#line hidden
            EndContext();
            BeginContext(5364, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 88 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
                                                    }
                                                }
                                            

#line default
#line hidden
            BeginContext(5528, 460, true);
            WriteLiteral(@"                                        </select>
                                    </div>
                                    <div class=""col-md-6 actionTypeSet editcolumnvalue"">
                                        <label id=""lbl_EditColumnValue"" class=""control-label"" for=""EditColumnValue"">修改字段值</label>
                                        <input class=""form-control "" id=""EditColumnValue"" name=""EditColumnValue"" type=""text"" placeholder=""修改字段值""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 5988, "\"", 6018, 1);
#line 95 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 5996, Model.EditColumnValue, 5996, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6019, 450, true);
            WriteLiteral(@" />
                                    </div>
                                    <div class=""col-md-6 actionTypeSet noticeway"">
                                        <label id=""lbl_NoticeLineManager"" class=""control-label"" for=""NoticeLineManager"">是否通知上级</label>
                                        <div class=""toggle-flip"">
                                            <label id=""lbl_NoticeLineManager""><input type=""checkbox"" value=""true"" ");
            EndContext();
            BeginContext(6471, 50, false);
#line 100 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
                                                                                                              Write(Model.NoticeLineManager ? "checked='checked'" : "");

#line default
#line hidden
            EndContext();
            BeginContext(6522, 1483, true);
            WriteLiteral(@" name=""NoticeLineManager"" id=""NoticeLineManager"" /><span class=""flip-indecator"" data-toggle-on=""是"" data-toggle-off=""否""></span></label>
                                        </div>
                                    </div>
                                    <div class=""col-md-6 actionTypeSet noticeway"">
                                        <label id=""lbl_NoticeChannelIds"" class=""control-label"" for=""NoticeChannelIds"">通知小组</label>
                                        <select class=""form-control select2"" id=""NoticeChannelIds"" name=""NoticeChannelIds"" placeholder=""通知小组"" multiple=""multiple"" selectEntityName=""Channel""></select>
                                    </div>
                                    <div class=""col-md-6 actionTypeSet noticeway"">
                                        <label id=""lbl_NoticeUserIds"" class=""control-label"" for=""NoticeUserIds"">通知人员</label>
                                        <select class=""form-control select2"" id=""NoticeUserIds"" name=""NoticeUserIds"" placehold");
            WriteLiteral(@"er=""通知人员"" multiple=""multiple"" selectEntityName=""Users""></select>
                                    </div>
                                    <div class=""col-md-6 actionTypeSet noticeway"">
                                        <label id=""lbl_NoticeContent"" class=""control-label"" for=""NoticeContent"">通知文本</label>
                                        <input class=""form-control "" id=""NoticeContent"" name=""NoticeContent"" type=""text"" placeholder=""通知文本""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 8005, "\"", 8033, 1);
#line 113 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 8013, Model.NoticeContent, 8013, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8034, 356, true);
            WriteLiteral(@" />
                                    </div>
                                    <div class=""col-md-6"">
                                        <label id=""lbl_OrderNum"" class=""control-label"" for=""OrderNum"">运行顺序</label>
                                        <input class=""form-control "" id=""OrderNum"" name=""OrderNum"" type=""number"" placeholder=""运行顺序""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 8390, "\"", 8413, 1);
#line 117 "D:\工作\01_code\MyCode\我的框架\NetCoreBase\MyNetCore\MyNetCore\Areas\Management\Views\Workflow\AddForWorkflowAction.cshtml"
WriteAttributeValue("", 8398, Model.OrderNum, 8398, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8414, 1791, true);
            WriteLiteral(@" />
                                    </div>

                                    <div class=""col-md-12"">
                                        <br />
                                        <button class=""btn btn-default btn-loading btn-back"" type=""button"">返回</button>&nbsp;
                                        <button class=""btn btn-primary btn-loading needValid btn-add ajaxSaveForOther"" validFor=""addForm"" type=""button"" actionName=""WorkflowAction"">保存</button>&nbsp;
                                    </div>
                                </div>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div role=""tabpanel"" class=""tab-pane"" id=""secondTab""></div>
</div>

<div class=""secondTabContent"">
    <div class=""card"">
        <div class=""card-body"">
            <pre>说明：
一、修改字段值
1、工作流状态(WorkflowStatus):
0:新建
10:进行中
20:完成
30:退回
二、运行Sql语句
1、可以用@id做占位符代替当前记录的id");
            WriteLiteral(@"值</pre>
        </div>
    </div>
</div>

<script>
    showSecondTab(""说明"");

    function showActionTypeSet() {
        var t = $(""#WorkflowActionType"").val();
        $("".actionTypeSet"").hide();
        switch (t) {
            case ""EditColumnValue"":
                $("".editcolumnvalue"").show();
                break;
            case ""WeChatNotice"":
                $("".noticeway"").show();
                break;
            case ""EmailNotice"":
                $("".noticeway"").show();
                break;
            case ""RunSql"":
                $("".runsql"").show();
                break;
            default:
                break;
        }
    }
    showActionTypeSet();
    $(""#firstTabTitle"").find(""a"").click();
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WorkflowAction> Html { get; private set; }
    }
}
#pragma warning restore 1591
