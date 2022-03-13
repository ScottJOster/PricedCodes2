using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PricedCodes2Project.DataAccess.Models
{
    [Table("Properties")]
    public class Property
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("Postcode")]
        [StringLength(10)]
        public string PostCode { get; set; }

        [Column("SoldPrice")]
        public int SoldPrice { get; set; }

        [Column("Type")]
        public string PropertyType { get; set; }
    }
}
