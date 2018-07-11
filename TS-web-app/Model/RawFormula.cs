using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TableauxIO;

namespace TsWebApp.Model {
    public class RawFormula {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; private set; }

        public string Formula { get; set; } = string.Empty;
        public TruthValue TruthLabel { get; set; } = TruthValue.True;
    }
}
