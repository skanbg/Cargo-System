namespace CargoSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [ComplexType]
    public class TrailerSize
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public double Volume { get; set; }
    }
}
