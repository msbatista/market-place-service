namespace Domain;

/// <summary>
/// Represents an paginated query response.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public sealed class PaginatedItems<TEntity> where TEntity : class
{

    /// <summary>
    /// Initialize an instance of PaginatedItems.
    /// </summary>
    /// <param name="pageSize"></param>
    /// <param name="pageIndex"></param>
    /// <param name="count"></param>
    /// <param name="data"></param>
    public PaginatedItems(int pageSize, int pageIndex, long count, IList<TEntity> data)
    {
        this.PageSize = pageSize;
        this.PageIndex = pageIndex;
        this.Count = count;
        this.Data = data;
        this.CurrentPageCount = data.Count;
        this.TotalPages = (long)Math.Ceiling((count / ((decimal)pageSize))) - 1;
    }

    /// <summary>
    /// Get total of items in current page.
    /// </summary>
    /// <value></value>
    public long CurrentPageCount {get;}

    /// <summary>
    /// Gets request data content.
    /// </summary>
    /// <value>List of TEntity.</value>
    public IList<TEntity> Data { get; }

    /// <summary>
    /// Gets page size.
    /// </summary>
    /// <value>int.</value>
    public int PageSize { get; }

    /// <summary>
    /// Gets page index.
    /// </summary>
    /// <value>int.</value>
    public int PageIndex { get; }

    /// <summary>
    /// Gets request total count.
    /// </summary>
    /// <value>long.</value>
    public long Count { get; }

    /// <summary>
    /// Total number of pages.
    /// </summary>
    /// <value>long.</value>
    public long TotalPages { get; }
}
