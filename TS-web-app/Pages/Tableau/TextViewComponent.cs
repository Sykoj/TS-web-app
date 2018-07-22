using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ts.App.Services;
using Ts.IO;

namespace Ts.App.Pages.Tableau {

    public class TextViewComponent : ViewComponent {

        private readonly TextViewService _textViewService;

        public TextViewComponent(TextViewService textViewService) {
            _textViewService = textViewService;
        }

        public async Task<IViewComponentResult> InvokeAsync(SolutionNode solution) {

            string[] canvas = _textViewService.GetTextView(solution);
            return View(canvas);
        }
    }
}
