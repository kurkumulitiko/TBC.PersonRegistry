namespace TBC.PersonRegistry.Application.Commons;


public class Pagination<T>
{
    public IEnumerable<T> Items { get; private set; }

    public int CurrentPage { get; private set; }
    public int PageSize { get; private set; }

    public int TotalPages { get; private set; }
    public int TotalCount { get; private set; }

    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;

    public Pagination() { }
    public Pagination(IEnumerable<T> items, int totalCount, int pageIndex, int pageSize)
    {
        CurrentPage = pageIndex;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        TotalCount = totalCount;
        Items = items;
    }
}

