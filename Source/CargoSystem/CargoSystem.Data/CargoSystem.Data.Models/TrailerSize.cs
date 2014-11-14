namespace CargoSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class TrailerSize
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public double Volume { get; set; }
    }
}
