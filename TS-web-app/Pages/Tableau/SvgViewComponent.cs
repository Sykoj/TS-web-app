using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ts.App.Services;
using Ts.App.TableauViews.SvgView;
using Ts.IO;

namespace Ts.App.Pages.Tableau {

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
