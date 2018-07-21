using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TsWebApp.Model {

    public class AppSolutionEventRequest {

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
