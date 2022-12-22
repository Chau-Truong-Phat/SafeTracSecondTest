namespace MedWorking.Core.Application;

public class PagingQuery
{
    public PagingQuery()
    {
        //Default Query Options
        PageSize = 20;
        PageNumber = 1;
    }

    public string? FullTextSearch { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalCount { get; set; }
    public int RowModify { get; set; }
}

public class PagingPageQuery
{
    public PagingPageQuery()
    {
        //Default Query Options
        PageSize = 20;
        PageNumber = 1;
    }

    public string? FullTextSearch { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalCount { get; set; }
    public int RowModify { get; set; }
}
