using System.Collections.Generic;

namespace Web.ViewModels
{
    public class PagedResults<T>
    {
        public IEnumerable<T> Items { get; set; }
        public long TotalCount { get; set; }
        public long? FirstItemId { get; set; }
        public long? LastItemId { get; set; }
    }
}