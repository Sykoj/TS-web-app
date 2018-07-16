#pragma checksum "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "760af99a811c60a8f5cc572cd50c0195f4425951"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TsWebApp.Pages.Tableau.Pages_Tableau_TableauRequest), @"mvc.1.0.razor-page", @"/Pages/Tableau/TableauRequest.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Tableau/TableauRequest.cshtml", typeof(TsWebApp.Pages.Tableau.Pages_Tableau_TableauRequest), null)]
namespace TsWebApp.Pages.Tableau
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
using TableauxIO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"760af99a811c60a8f5cc572cd50c0195f4425951", @"/Pages/Tableau/TableauRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"375a44e467571932c4fd87a9b93c201ca91db0b4", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Tableau_TableauRequest : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Tableau/TableauSolution", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
  
    ViewData["Title"] = "Tableau Request Form";

#line default
#line hidden
            BeginContext(110, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(112, 2036, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "47fcb01e849e431aabbfb682f6d63815", async() => {
                BeginContext(168, 290, true);
                WriteLiteral(@"
    <h4>Set input for tableau solver</h4>
    <div>
        <table id=""container"">
            <tr>
                <th>Formula</th>
                <th><center>Truth value</center></th>
                <th></th>
                <th>Parser error message</th>
            </tr>

");
                EndContext();
#line 19 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
             for (var i = 0; i < Model.FormulaParseRequests.Count; ++i) {

                var isTrue = (Model.FormulaParseRequests[i].UnparsedTableauNode.TruthLabel == TruthValue.True) ? '1' : '0';


#line default
#line hidden
                BeginContext(662, 97, true);
                WriteLiteral("                <tr>\r\n                    <td><input class=\"text-box single-line\" id=\"formulaRow\"");
                EndContext();
                BeginWriteAttribute("name", " name=\"", 759, "\"", 790, 3);
                WriteAttributeValue("", 766, "Formula[", 766, 8, true);
#line 24 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
WriteAttributeValue("", 774, Html.Encode(i), 774, 15, false);

#line default
#line hidden
                WriteAttributeValue("", 789, "]", 789, 1, true);
                EndWriteAttribute();
                BeginContext(791, 12, true);
                WriteLiteral(" type=\"text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 803, "\"", 882, 1);
#line 24 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
WriteAttributeValue("", 811, Html.Encode(Model.FormulaParseRequests[i].UnparsedTableauNode.Formula), 811, 71, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("onchange", " onchange=\"", 883, "\"", 929, 3);
                WriteAttributeValue("", 894, "eraseErrorResponse(", 894, 19, true);
#line 24 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
WriteAttributeValue("", 913, Html.Encode(i), 913, 15, false);

#line default
#line hidden
                WriteAttributeValue("", 928, ")", 928, 1, true);
                EndWriteAttribute();
                BeginContext(930, 52, true);
                WriteLiteral("></td>\r\n                    <td><input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("name", " name=\"", 982, "\"", 1016, 3);
                WriteAttributeValue("", 989, "TruthLabel[", 989, 11, true);
#line 25 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
WriteAttributeValue("", 1000, Html.Encode(i), 1000, 15, false);

#line default
#line hidden
                WriteAttributeValue("", 1015, "]", 1015, 1, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1017, "\"", 1045, 1);
#line 25 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
WriteAttributeValue("", 1025, Html.Encode(isTrue), 1025, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1046, 94, true);
                WriteLiteral("><input type=\"checkbox\" onclick=\"this.previousSibling.value = 1 - this.previousSibling.value\" ");
                EndContext();
#line 25 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
                                                                                                                                                                                                           if (isTrue == '1') {
                                                                                                                                                                                                              

#line default
#line hidden
                BeginContext(1370, 34, false);
#line 26 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
                                                                                                                                                                                                         Write(Html.Encode("checked = 'checked'"));

#line default
#line hidden
                EndContext();
#line 26 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
                                                                                                                                                                                                                                                 
                                                                                                                                                                                                          }

#line default
#line hidden
                BeginContext(1609, 174, true);
                WriteLiteral("></td>\r\n                    <td><input type=\"button\" value=\"Remove formula\" onclick=\"deleteRow(this.parentNode.parentNode)\"/></td>\r\n                    <td><input type=\"text\"");
                EndContext();
                BeginWriteAttribute("name", " name=\"", 1783, "\"", 1820, 3);
                WriteAttributeValue("", 1790, "ErrorResponse[", 1790, 14, true);
#line 29 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
WriteAttributeValue("", 1804, Html.Encode(i), 1804, 15, false);

#line default
#line hidden
                WriteAttributeValue("", 1819, "]", 1819, 1, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1821, "\"", 1886, 1);
#line 29 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
WriteAttributeValue("", 1829, Html.Encode(Model.FormulaParseRequests[i].ErrorResponse), 1829, 57, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1887, 51, true);
                WriteLiteral(" readonly=\"readonly\"></td>\r\n                </tr>\r\n");
                EndContext();
#line 31 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\TableauRequest.cshtml"
            }

#line default
#line hidden
                BeginContext(1953, 188, true);
                WriteLiteral("\r\n        </table>\r\n    </div>\r\n\r\n    <p><input type=\"button\" id=\"addFormula\" value=\"Add new tableau formula\" onclick=\"addField();\"/></p>\r\n    <p><input type=\"submit\" value=\"Solve\"/></p>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2148, 3391, true);
            WriteLiteral(@"

<script type=""text/javascript"">
    function eraseErrorResponse(index) {

        var errorResponse = document.getElementsByName(""ErrorResponse["" + index + ""]"");
        errorResponse[0].setAttribute(""value"", """");
    }
</script>

<style>
    #formulaRow {
        width: 300px
    }

</style>

<script type=""text/javascript"">
    function deleteRow(row) {

        var index = row.rowIndex;

        var table = document.getElementById(""container"");

        if (table.rows.length > 2) {

            for (var i = index + 1; i < table.rows.length; ++i) {
                updateIndex(i - 2, table.rows[i]);
            }

            table.deleteRow(index);
        }
    }
</script>

<script type=""text/javascript"">
    function updateIndex(index, element) {

        element.children[0].firstChild.setAttribute(""name"", ""Formula["" + index + ""]"");

        element.children[0].firstChild.setAttribute(""onchange"", ""eraseErrorMessage("" + index + "")"");

        element.children[1].f");
            WriteLiteral(@"irstChild.setAttribute(""name"", ""TruthLabel["" + index + ""]"");

        element.children[3].firstChild.setAttribute(""name"", ""ErrorResponse["" + index + ""]"");
    }
</script>

<script type=""text/javascript"">
    function addField(argument) {

        var myTable = document.getElementById(""container"");
        var currentIndex = myTable.rows.length;
        var currentRow = myTable.insertRow(-1);

        var linksBox = document.createElement(""input"");
        linksBox.setAttribute(""class"", ""text-box single-line"");
        linksBox.setAttribute(""id"", ""formulaRow"");
        linksBox.setAttribute(""name"", ""Formula["" + (currentIndex - 1) + ""]"");
        linksBox.setAttribute(""type"", ""text"");
        linksBox.setAttribute(""onchange"", ""eraseErrorResponse("" + (currentIndex - 1) + "")"");
        linksBox.setAttribute(""value"", """");

        var hiddenBox = document.createElement(""input"");
        hiddenBox.setAttribute(""type"", ""hidden"");
        hiddenBox.setAttribute(""name"", ""TruthLabel["" + (currentI");
            WriteLiteral(@"ndex - 1) + ""]"");
        hiddenBox.setAttribute(""value"", ""0"");

        var keywordsBox = document.createElement(""input"");
        keywordsBox.setAttribute(""type"", ""checkbox"");
        keywordsBox.setAttribute(""onclick"", ""this.previousSibling.value = 1 - this.previousSibling.value"");

        var removeFormula = document.createElement(""input"");
        removeFormula.setAttribute(""type"", ""button"");
        removeFormula.setAttribute(""value"", ""Remove formula"");
        removeFormula.setAttribute(""onclick"", ""deleteRow(this.parentNode.parentNode)"");

        var errorResponse = document.createElement(""input"");
        errorResponse.setAttribute(""type"", ""text"");
        errorResponse.setAttribute(""name"", ""ErrorResponse["" + (currentIndex - 1)+ ""]"");
        errorResponse.setAttribute(""value"", """");
        errorResponse.setAttribute(""readonly"", ""readonly"");

        var currentCell = currentRow.insertCell(-1);
        currentCell.appendChild(linksBox);

        currentCell = currentRow.insertCe");
            WriteLiteral(@"ll(-1);
        currentCell.appendChild(hiddenBox);
        currentCell.appendChild(keywordsBox);

        currentCell = currentRow.insertCell(-1);
        currentCell.appendChild(removeFormula);

        currentCell = currentRow.insertCell(-1);
        currentCell.appendChild(errorResponse);
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TableauRequestModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TableauRequestModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TableauRequestModel>)PageContext?.ViewData;
        public TableauRequestModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
