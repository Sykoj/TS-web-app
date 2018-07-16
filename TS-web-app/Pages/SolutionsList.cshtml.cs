using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using TsWebApp.Model;
using System.Collections.Generic;
using TsWebApp.Services;

namespace TsWebApp.Pages {

    public class SolutionsListModel : PageModel {

        public List<TableauRequest> UserRequests { get; set; } 

        public EventService EventService { get; }

        public SolutionsListModel(EventService eventService) {
            EventService = eventService;
        }

        public IActionResult OnGet() {

            if (!HttpContext.User.Identity.IsAuthenticated) {
                return RedirectToPage("/Error");
            }

            UserRequests
                = EventService.GetRequestsMadeByUser(
                    HttpContext.User.Identity.Name
                    );

            return Page();
        }
    }
}