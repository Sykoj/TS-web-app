using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ts.App.Model;
using Ts.App.Services;

namespace Ts.App.Pages {

    public enum SortOrder {
       Newest, Oldest
    }

    public class SolutionsListModel : PageModel {

        public IQueryable<AppSolutionRequest> FilteredUserRequests { get; set; }
        public TableauType ExpectedTableauType { get; set; }
        public TableauType TableauType { get; set; }
        public SortOrder SortOrder { get; set; }

        public EventService EventService { get; }

        public SolutionsListModel(EventService eventService) {
            EventService = eventService;
        }

        public IActionResult OnGet(TableauType expectedTableauType, TableauType tableauType, SortOrder sortOrder) {

            ExpectedTableauType = expectedTableauType;
            TableauType = tableauType;
            SortOrder = sortOrder;

            if (!HttpContext.User.Identity.IsAuthenticated) {
                return RedirectToPage("/ErrorAnon");
            }

            var userRequests
                = EventService.GetRequestsMadeByUser(
                    HttpContext.User.Identity.Name
                    );

            Func<TableauType, TableauType, bool> isRequestedType = (expected, type) => {

                if (type == TableauType.Default) return true;
                return type == expected;
            };

            FilteredUserRequests = (from request in userRequests
                where isRequestedType(request.TableauType, tableauType)
                where isRequestedType(request.ExpectedTableauType, expectedTableauType)
                select request).OrderByTime(sortOrder);

            return Page();
        }
        
    }

    public static class IQueryableExtension {

        public static IQueryable<AppSolutionRequest> OrderByTime(this IQueryable<AppSolutionRequest> query, SortOrder order) {
            
            switch(order) {
                case SortOrder.Newest:
                    return query.OrderByDescending(r => r.TableauSolution.RequestDateTime);
                case SortOrder.Oldest:
                    return query.OrderBy(r => r.TableauSolution.RequestDateTime);
                default:
                    throw new ArgumentOutOfRangeException(nameof(order), order, null);
            }
        }
    }
}