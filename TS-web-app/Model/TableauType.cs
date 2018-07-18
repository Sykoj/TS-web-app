using System.ComponentModel.DataAnnotations;

namespace TsWebApp.Model {

    public enum TableauType {

        [Display(Name = "No result type selected")]
        Default,
        [Display(Name = "Contradictionary")]
        Contradictionary,
        [Display(Name = "All branches are non-contradictionary")]
        AllBranchesNoncontradictionary,
        [Display(Name = "Atleast one branch contradictionary & Atleast one branch non-contradictionary")]
        OtherExpected
    }
}
