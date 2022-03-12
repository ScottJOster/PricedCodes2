using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PricedCodes2Project.DataAccess.Models
{
    [Table("postcodelatlng")]
        public class PostCodePosition
        {
            [Column("Id")]
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Required]
            public int Id { get; set; }

            [Column("Postcode")]
            [StringLength(9)]
            public string PostCode { get; set; }

            [Column("Latitude", TypeName = "decimal(10,7)")]
            public decimal Latitude { get; set; }

            [Column("Longitude", TypeName = "decimal(10,7)")]
            public decimal Longitude { get; set; }


        }
    }

