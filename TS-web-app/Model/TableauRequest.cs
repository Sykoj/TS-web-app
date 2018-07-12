using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TsWebApp.Model {

    public class TableauRequest {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }

        [Required]
        public IList<UnparsedTableauNode> RawFormulas { get; set; } = new List<UnparsedTableauNode>();
        [Required]
        public ulong SolverRequestId { get; set; }
        
        public string User { get; set; }
    }
}
