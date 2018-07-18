using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TableauxIO;

namespace TsWebApp.Model {

    public class TableauSolutionEvent {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }

        public DateTime Date { get; set; }
        [Required]
        public IList<UnparsedTableauNode> RawFormulas { get; set; } = new List<UnparsedTableauNode>();
        [Required]
        public ulong SolverRequestId { get; set; }
        
        [NotMapped]
        public SolutionNode Solution { get; set; }

        public string User { get; set; }

        public TableauType ExpectedTableauType { get; set; }
        public TableauType TableauType { get; set; }
    }
}
