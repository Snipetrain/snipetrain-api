
namespace snipetrain_api.Models 
{
    public class Pagination<T>
    {
        public int PerPage { get; set; } 
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; } 
        public T Payload { get; set; }

    }

}