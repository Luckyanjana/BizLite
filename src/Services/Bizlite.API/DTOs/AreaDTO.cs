namespace ToDo.WebApi.DTOs
{
    public class AreaDTO
    {
        public int AreaId { get; set; }

        public string AreaName { get; set; } = string.Empty;

        public bool? IsActive { get; set; }
    
        public DateTime? DateAdded { get; set; }

        public DateTime? DateModified { get; set; }

        public long? AddedbyUserIdno { get; set; }

        public long? ModifiedByUserIdno { get; set; }



    }
}
