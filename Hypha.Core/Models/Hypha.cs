using Hypha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypha.Models
{
    public class Hypha
    {
        private ILayer InputLayer { get; set; }

        private IEnumerable<ILayer> Layers { get; set; }

        private ILayer OutputLayer { get; set; }
    }
}
