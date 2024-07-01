using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppResit.Models;


    public class BookItem
    {
        [Key]
        [StringLength(13, MinimumLength = 10)] // ISBN-10 or ISBN-13
        public string ISBN { get; set; }

        [StringLength(30)]
        public string ItemName { get; set; }

        [StringLength(255)]
        public string Item_desc { get; set; }
        [StringLength(40)]
        public string Author { get; set; }
            
        public Nullable<bool> Available { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public Nullable<decimal> Price { get; set; }
        
    }
