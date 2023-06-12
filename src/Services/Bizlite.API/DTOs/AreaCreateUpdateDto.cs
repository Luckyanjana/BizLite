using System.ComponentModel.DataAnnotations;

namespace ToDo.WebApi.DTOs
{
    public class AreaCreateUpdateDto
    {

        [Required]
        public string AreaName { get; set; } = string.Empty;
     


    }
}
