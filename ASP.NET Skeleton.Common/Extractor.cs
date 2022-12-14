using System.Text;

namespace ASP.NET_Skeleton.Common
{
    public static class Extractor
    {
        private static readonly StringBuilder _stringBuilder = new();

        private static string Extract<T>(this T entity)
        {
            _stringBuilder.AppendLine($"{nameof(T)}:");
            if (typeof(T).IsGenericType && typeof(T) != typeof(ICollection<>))
                typeof(T).GetProperties().Where(x => x.CanRead).ToList().ForEach(x => Extract(x.GetValue(entity)));
            else if (typeof(T) != typeof(ICollection<>))
                typeof(T).GetProperties().Where(x => x.CanRead).ToList().ForEach(x =>
                    _stringBuilder.AppendLine($"{x.Name}: {x.GetValue(entity)}"));
            else
                entity!.MapTo<List<object>>().ForEach(x => Extract(x));

            return _stringBuilder.ToString();
        }
    }
}
