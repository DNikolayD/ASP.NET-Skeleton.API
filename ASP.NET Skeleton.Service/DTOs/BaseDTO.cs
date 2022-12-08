namespace ASP.NET_Skeleton.Service.DTOs
{
    public abstract class BaseDto<TKey>
    {
        public TKey Id { get; set; } = default!;

        public bool IsDeletable { get; set; } = false;

        public bool? IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsModified { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
