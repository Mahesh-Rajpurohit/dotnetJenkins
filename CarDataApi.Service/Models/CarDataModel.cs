using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace CarDataApi.Service.Models
{
    [Table("tbl_CarData")]
   public class CarDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int CarId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string FacilityId { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTimeOffset TimeStamp { get; set; }
        public  string CarName { get; set; }
        public string ManufacturingYear { get; set; }
        public string SerialNo { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }

    }
}
