using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ts.App.Model {

    /// <summary>
    /// Represents application's request for tableau solver, with response
    /// /// </summary>
    public class AppSolutionRequest {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public int SolutionId { get; set; }
        [NotMapped]
        public TableauSolution TableauSolution { get; set; }
        public string User { get; set; }
        public TableauType ExpectedTableauType { get; set; }
        public TableauType TableauType { get; set; }
    }
}
