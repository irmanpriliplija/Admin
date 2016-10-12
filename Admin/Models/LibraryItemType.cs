using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public class LibraryItemType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibraryItemTypeID { get; set; }

        [DisplayName("Type name")]
        [Required(ErrorMessage = "Type name is required")]
        [StringLength(100)]
        public string TypeName { get; set; }
        public string Description { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [DisplayName("Create date")]
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Activity state is required")]
        public bool Active { get; set; }


        public virtual ICollection<LibraryItem> LibraryItem { get; set; }


        public LibraryItemType()
        {
            Active = true;
            CreateDate = DateTime.Now;
        }
    }
}
