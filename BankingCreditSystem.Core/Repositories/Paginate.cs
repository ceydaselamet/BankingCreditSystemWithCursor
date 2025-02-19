namespace BankingCreditSystem.Core.Repositories;

public class Paginate<T> : IPaginate<T>
{
    public int From { get; set; }
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public IList<T> Items { get; set; }
    public bool HasPrevious => Index > 1;
    public bool HasNext => Index < Pages;

    public Paginate()
    {
        Items = new List<T>();
    }
} 