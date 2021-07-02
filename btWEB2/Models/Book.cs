namespace btWEB2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Ma sach")]
        [Required(ErrorMessage = "id khong duoc de trong")]
        public int ID { get; set; }

    

        [Display(Name = "Ten sach")]
        [Required(ErrorMessage = "Ten sach khong duoc de trong")]
        [StringLength(100, ErrorMessage = "Ten sach khong duoc vuot qua 152 ki tu")]
        public string Title { get; set; }

        [Display(Name = "Mo ta")]
        [Required(ErrorMessage = "mo ta khong duoc de trong")]
        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Tac gia")]
        [Required(ErrorMessage = "Ten tac gia khong duoc de trong")]
        [StringLength(30, ErrorMessage = "Tên tac gia khong duoc vuot qua 30 ki tu")]
        public string Author { get; set; }

        [Display(Name = "hinh anh")]
        [Required(ErrorMessage = "Hinh anh khong duoc de trong")]
        [StringLength(255)]
        public string Images { get; set; }


        [Display(Name = "Gia")]
        [Required(ErrorMessage = "Gia khong duoc de trong")]
        [Range(1000, 1000000, ErrorMessage = "Gia sach trong khoang 1000vnd - 100000vnd")]
        public double Price { get; set; }
    }
}
