#pragma checksum "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db4bf6b9bd4b83904beecda596c49c8d9febf097"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TsWebApp.Pages.Pages_SolutionsList), @"mvc.1.0.razor-page", @"/Pages/SolutionsList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/SolutionsList.cshtml", typeof(TsWebApp.Pages.Pages_SolutionsList), null)]
namespace TsWebApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
using Model;

#line default
#line hidden
#line 3 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
using TableauxIO;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db4bf6b9bd4b83904beecda596c49c8d9febf097", @"/Pages/SolutionsList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"375a44e467571932c4fd87a9b93c201ca91db0b4", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SolutionsList : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
  
    ViewData["Title"] = "Your solutions";


#line default
#line hidden
            BeginContext(131, 177, true);
            WriteLiteral("    <style>\r\n        #truthValue {\r\n            width: 50px;\r\n        }\r\n\r\n        th, td {\r\n            padding: 15px;\r\n            text-align: left;\r\n        }\r\n    </style>\r\n");
            EndContext();
            BeginContext(317, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(325, 762, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27443201b592401da4167ca2ab155592", async() => {
                BeginContext(344, 89, true);
                WriteLiteral("\r\n            <div style=\"display: inline-block;\">\r\n                <label>Tableau type: ");
                EndContext();
                BeginContext(434, 122, false);
#line 21 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                                Write(Html.DropDownListFor(m => m.TableauType, Html.GetEnumSelectList(typeof(TableauType)), new { onchange = "form.submit();" }));

#line default
#line hidden
                EndContext();
                BeginContext(556, 131, true);
                WriteLiteral("</label></div>\r\n            <br/>\r\n            <div style=\"display: inline-block;\">\r\n                <label>Expected tableau type: ");
                EndContext();
                BeginContext(688, 130, false);
#line 24 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                                         Write(Html.DropDownListFor(m => m.ExpectedTableauType, Html.GetEnumSelectList(typeof(TableauType)), new { onchange = "form.submit();" }));

#line default
#line hidden
                EndContext();
                BeginContext(818, 120, true);
                WriteLiteral("</label></div>\r\n            <br/>\r\n            <div style=\"display: inline-block;\">\r\n                <label>Sort order: ");
                EndContext();
                BeginContext(939, 117, false);
#line 27 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                              Write(Html.DropDownListFor(m => m.SortOrder, Html.GetEnumSelectList(typeof(SortOrder)), new { onchange = "form.submit();"}));

#line default
#line hidden
                EndContext();
                BeginContext(1056, 24, true);
                WriteLiteral("</label></div>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1087, 184, true);
            WriteLiteral("\r\n    <center>\r\n        <table border=\"1\">\r\n            <tr>\r\n                <th>Date</th>\r\n                <th>Formulas</th>\r\n                <th>Solution</th>\r\n            </tr>\r\n\r\n");
            EndContext();
#line 37 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
             foreach (var request in Model.FilteredUserRequests) {

#line default
#line hidden
            BeginContext(1339, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(1386, 25, false);
#line 39 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                   Write(Html.Encode(request.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1411, 63, true);
            WriteLiteral("</td>\r\n                    <td>\r\n                        <ul>\r\n");
            EndContext();
#line 42 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                             foreach (var unparsedTableauNode in request.RawFormulas) {


#line default
#line hidden
            BeginContext(1565, 79, true);
            WriteLiteral("                                <li>\r\n                                    <div>");
            EndContext();
            BeginContext(1645, 43, false);
#line 45 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                                    Write(Html.Encode(unparsedTableauNode.TruthLabel));

#line default
#line hidden
            EndContext();
            BeginContext(1688, 6, true);
            WriteLiteral("</div>");
            EndContext();
            BeginContext(1695, 40, false);
#line 45 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                                                                                      Write(Html.Encode(unparsedTableauNode.Formula));

#line default
#line hidden
            EndContext();
            BeginContext(1735, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 46 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                            }

#line default
#line hidden
            BeginContext(1773, 84, true);
            WriteLiteral("                        </ul>\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 50 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                          
                            var link = $"Tableau/SolutionView?id={request.Id}&solutionViewType=Text";
                            var url = $"<a href={link}>Show solution as text</a>";
                        

#line default
#line hidden
            BeginContext(2099, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2124, 13, false);
#line 54 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                   Write(Html.Raw(url));

#line default
#line hidden
            EndContext();
            BeginContext(2137, 32, true);
            WriteLiteral("\r\n                        <br>\r\n");
            EndContext();
#line 56 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                          
                            link = $"Tableau/SolutionView?id={request.Id}&solutionViewType=Svg";
                            url = $"<a href={link}>Show solution as svg</a>";
                        

#line default
#line hidden
            BeginContext(2401, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2426, 13, false);
#line 60 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
                   Write(Html.Raw(url));

#line default
#line hidden
            EndContext();
            BeginContext(2439, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 63 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\SolutionsList.cshtml"
            }

#line default
#line hidden
            BeginContext(2506, 35, true);
            WriteLiteral("\r\n        </table>\r\n    </center>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TsWebApp.Pages.SolutionsListModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TsWebApp.Pages.SolutionsListModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TsWebApp.Pages.SolutionsListModel>)PageContext?.ViewData;
        public TsWebApp.Pages.SolutionsListModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591