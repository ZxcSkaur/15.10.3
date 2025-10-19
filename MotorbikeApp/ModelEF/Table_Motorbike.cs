namespace MotorbikeApp.ModelEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_Motorbike
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        public decimal Price { get; set; }

        public int HorsePower { get; set; }

        public int Mileage { get; set; }

        [Required]
        [StringLength(100)]
        public string ImageName { get; set; }
    }


}
