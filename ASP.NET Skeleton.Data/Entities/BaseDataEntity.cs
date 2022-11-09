using System.ComponentModel.DataAnnotations;
using ASP.NET_Skeleton.Data.Extensions;

namespace ASP.NET_Skeleton.Data.Entities
{
    public class BaseDataEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; } = default!;

        public bool IsDeletable { get; set; } = false;

        public bool? IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsModified { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public BaseDataEntity()
        {
            this.Configure();
        }
    }
}
