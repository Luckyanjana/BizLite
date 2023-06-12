using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizlite.Core.Specifications
{
    public class MasterSpecification : GenericSearchSpecs
    {
        public string? Title { get; set; }
        public bool? Status { get; set; }
        public string? OrderBy { get; set; }
    }
}
