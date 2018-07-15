#pragma checksum "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\SolutionView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21c91295339f34a1ec7f8f2d055ee0e70e7fa940"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TsWebApp.Pages.Tableau.Pages_Tableau_SolutionView), @"mvc.1.0.razor-page", @"/Pages/Tableau/SolutionView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Tableau/SolutionView.cshtml", typeof(TsWebApp.Pages.Tableau.Pages_Tableau_SolutionView), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21c91295339f34a1ec7f8f2d055ee0e70e7fa940", @"/Pages/Tableau/SolutionView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"375a44e467571932c4fd87a9b93c201ca91db0b4", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Tableau_SolutionView : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\SolutionView.cshtml"
  
    ViewData["Title"] = "SolutionView";

#line default
#line hidden
            BeginContext(81, 127, true);
            WriteLiteral("\r\n<h2>SolutionView</h2>\r\n\r\n<table>\r\n    <tr>\r\n        <th><b>Formula</b></th>\r\n        <th><b>Truth label</b></th>\r\n    </tr>\r\n");
            EndContext();
#line 14 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\SolutionView.cshtml"
     foreach (var formula in Model.TableauRequest.RawFormulas) {

#line default
#line hidden
            BeginContext(274, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(305, 28, false);
#line 16 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\SolutionView.cshtml"
           Write(Html.Encode(formula.Formula));

#line default
#line hidden
            EndContext();
            BeginContext(333, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(357, 31, false);
#line 17 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\SolutionView.cshtml"
           Write(Html.Encode(formula.TruthLabel));

#line default
#line hidden
            EndContext();
            BeginContext(388, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 19 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\SolutionView.cshtml"
    }

#line default
#line hidden
            BeginContext(417, 12, true);
            WriteLiteral("</table>\r\n\r\n");
            EndContext();
            BeginContext(430, 24, false);
#line 22 "C:\Users\Sykoj\source\repos\TS-web-app\TS-web-app\Pages\Tableau\SolutionView.cshtml"
Write(Html.Raw(Model.ViewForm));

#line default
#line hidden
            EndContext();
            BeginContext(454, 1, true);
            WriteLiteral(";");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SolutionViewModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SolutionViewModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SolutionViewModel>)PageContext?.ViewData;
        public SolutionViewModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591