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
        this.TotalPages = (long)Math.Ceiling((this.Count / ((decimal)this.PageSize)));
    }

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
