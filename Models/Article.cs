using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Models
{
    public class Article
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [DisplayName("Tiêu đề")]
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(255,MinimumLength = 5,ErrorMessage ="{0} phải từ {2} đến {1} ký tự")]
        public string Title { get; set; }

        [Column(TypeName = "Date")]
        [Required]
        public DateTime PublishDate { get; set; }

        [DisplayName("Tiêu đề")]
        [Column(TypeName = "ntext")]
        public string Content { set; get; }
    }
}
