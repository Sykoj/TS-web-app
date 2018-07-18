#pragma checksum "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\InputVerification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b60443264e467d974c0ff2ba24c72a1dc3c721b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TsWebApp.Pages.Tableau.Pages_Tableau_InputVerification), @"mvc.1.0.razor-page", @"/Pages/Tableau/InputVerification.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Tableau/InputVerification.cshtml", typeof(TsWebApp.Pages.Tableau.Pages_Tableau_InputVerification), null)]
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
#line 2 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\InputVerification.cshtml"
using TableauxIO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b60443264e467d974c0ff2ba24c72a1dc3c721b4", @"/Pages/Tableau/InputVerification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"375a44e467571932c4fd87a9b93c201ca91db0b4", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Tableau_InputVerification : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Tableau/TableauRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("cross-posting-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\InputVerification.cshtml"
  
    ViewData["Title"] = "TableauSolution";

#line default
#line hidden
            BeginContext(106, 40, true);
            WriteLiteral("\r\n<h2>TableauSolution - Loading</h2>\r\n\r\n");
            EndContext();
            BeginContext(146, 736, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a695cb8c33db4273b65724c45582ac89", async() => {
                BeginContext(225, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
#line 12 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\InputVerification.cshtml"
     for (var i = 0; i < Model.ErrorResponseForm.FormulaParseRequests.Count; ++i) {

        var isTrue = (Model.ErrorResponseForm.FormulaParseRequests[i].UnparsedTableauNode.TruthLabel == TruthValue.True) ? '1' : '0';


#line default
#line hidden
                BeginContext(453, 28, true);
                WriteLiteral("        <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("name", " name=\"", 481, "\"", 512, 3);
                WriteAttributeValue("", 488, "Formula[", 488, 8, true);
#line 16 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\InputVerification.cshtml"
WriteAttributeValue("", 496, Html.Encode(i), 496, 15, false);

#line default
#line hidden
                WriteAttributeValue("", 511, "]", 511, 1, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 513, "\"", 610, 1);
#line 16 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\InputVerification.cshtml"
WriteAttributeValue("", 521, Html.Encode(Model.ErrorResponseForm.FormulaParseRequests[i].UnparsedTableauNode.Formula), 521, 89, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(611, 33, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("name", " name=\"", 644, "\"", 678, 3);
                WriteAttributeValue("", 651, "TruthLabel[", 651, 11, true);
#line 17 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\InputVerification.cshtml"
WriteAttributeValue("", 662, Html.Encode(i), 662, 15, false);

#line default
#line hidden
                WriteAttributeValue("", 677, "]", 677, 1, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 679, "\"", 707, 1);
#line 17 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\InputVerification.cshtml"
WriteAttributeValue("", 687, Html.Encode(isTrue), 687, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(708, 33, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("name", " name=\"", 741, "\"", 778, 3);
                WriteAttributeValue("", 748, "ErrorResponse[", 748, 14, true);
#line 18 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\InputVerification.cshtml"
WriteAttributeValue("", 762, Html.Encode(i), 762, 15, false);

#line default
#line hidden
                WriteAttributeValue("", 777, "]", 777, 1, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 779, "\"", 862, 1);
#line 18 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\InputVerification.cshtml"
WriteAttributeValue("", 787, Html.Encode(Model.ErrorResponseForm.FormulaParseRequests[i].ErrorResponse), 787, 75, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(863, 3, true);
                WriteLiteral(">\r\n");
                EndContext();
#line 19 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\InputVerification.cshtml"
    }

#line default
#line hidden
                BeginContext(873, 2, true);
                WriteLiteral("\r\n");
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(882, 107, true);
            WriteLiteral("\r\n\r\n<script type=\"text/javascript\">\r\n    document.getElementById(\"cross-posting-form\").submit();\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TableauSolutionModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TableauSolutionModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TableauSolutionModel>)PageContext?.ViewData;
        public TableauSolutionModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
