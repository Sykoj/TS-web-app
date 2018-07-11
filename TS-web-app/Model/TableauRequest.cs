using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TsWebApp.Model {

    public class TableauRequest {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }

        [Required]
        public List<RawFormula> RawFormulas { get; set; }
        [Required]
        public ulong SolverRequestId { get; set; }
        
        public string UserId { get; set; }

        public bool containsErrorMessage() {
            throw new System.NotImplementedException();
        }
    }
}
