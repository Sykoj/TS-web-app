using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TsWebApp.Services;
using TableauxIO;

namespace TsWebApp.Pages.Tableau {

    public class SvgViewComponent : ViewComponent {

        private readonly SvgViewService _textViewService;

        public SvgViewComponent(SvgViewService textViewService) {
            _textViewService = textViewService;
        }

        public async Task<IViewComponentResult> InvokeAsync(SolutionNode solution) {

            string[] canvas = _textViewService.GetTextView(solution);
            return View(canvas);
        }

    }
}
