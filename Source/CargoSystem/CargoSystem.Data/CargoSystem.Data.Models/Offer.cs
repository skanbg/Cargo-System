namespace CargoSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Offer
    {
        [Key]
        public int Id { get; set; }

        public decimal Price { get; set; }

        public virtual Carrier Carrier { get; set; }

        public virtual Package Package { get; set; }

        public virtual DeclaredRoute Route { get; set; }

        public virtual Speditor Speditor { get; set; }

        public OfferStatus OfferStatus { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
