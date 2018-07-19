using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ts.IO;
using TsWebApp.Services;
using TsWebApp.TableauViews;

namespace TsWebApp.Pages.Tableau {

    public class SvgViewComponent : ViewComponent {

        private readonly SvgViewService _textViewService;

        public SvgViewComponent(SvgViewService textViewService) {
            _textViewService = textViewService;
        }

        public async Task<IViewComponentResult> InvokeAsync(SolutionNode solution) {

            var svg = new FormulaTextSvg(14);
            svg.SetTextAndComputeSizes("p IMP q");

            return View(new List<SvgView>() {svg} );
        }

    }
}
