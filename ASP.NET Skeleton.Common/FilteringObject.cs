namespace ASP.NET_Skeleton.Common
{
    public abstract class FilteringObject
    {
        public string PropertyName { get; set; } = default!;

        public object Value { get; set; } = default!;

        public int Amount { get; set; }
    }
}
