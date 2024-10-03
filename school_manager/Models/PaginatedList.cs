namespace school_manager.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int TotalCount { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            TotalCount = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            this.AddRange(items);
        }

        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);
    }

}
