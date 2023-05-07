using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Model
{
    public class FileUploadModel
    {
        [Required]
        public IBrowserFile[] Picture { get; set; }
    }
}
