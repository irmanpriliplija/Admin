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
    public class LibraryItemGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibraryItemGroupID { get; set; }
        [DisplayName("Parent group")]
        public int ParentGroupID { get; set; }
        [DisplayName("Group name")]
        [Required(ErrorMessage = "Group name is required")]
        [StringLength(100)]
        public string GroupName { get; set; }
        public string Description { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [DisplayName("Create date")]
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Activity state is required")]
        public bool Active { get; set; }


        public virtual ICollection<LibraryItem> LibraryItem { get; set; }


        public LibraryItemGroup()
        {
            Active = true;
            CreateDate = DateTime.Now;
            ParentGroupID = 0;
        }


    }
}
