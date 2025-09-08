using System.ComponentModel.DataAnnotations;

namespace Web_Template.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Không được để trống tên Thể Loại")]
        [Display(Name="Thể Loại")]  
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Không định dạng đúng ngày!")]
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
