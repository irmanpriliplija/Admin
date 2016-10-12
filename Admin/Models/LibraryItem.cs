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
    public class LibraryItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibraryItemID { get; set; }
        [DisplayName("Type")]
        [Required(ErrorMessage = "Item type is required")]
        public int LibraryItemTypeID { get; set; }
        [DisplayName("Group")]
        [Required(ErrorMessage = "Group is required")]
        public int LibraryItemGroupID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(250)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Subtitle { get; set; }
        [StringLength(250)]
        public string Author { get; set; }
        [StringLength(250)]
        public string Publisher { get; set; }
        [StringLength(250)]
        public string Translator { get; set; }
        [DisplayName("Language")]
        public int LanguageID { get; set; }
        [StringLength(13)]
        public string ISBN { get; set; }
        [DisplayName("Registration code")]
        [StringLength(50)]
        public string RegistrationCode { get; set; }
        [StringLength(200)]
        public string Location { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [DisplayName("Create date")]
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Activity state is required")]
        public bool Active { get; set; }


        public virtual LibraryItemGroup LibraryItemGroup { get; set; }
        public virtual LibraryItemType LibraryItemType { get; set; }




        // constructor setting default values
        public LibraryItem()
        {
            Active = true;
            CreateDate = DateTime.Now;
        }

    }
}
