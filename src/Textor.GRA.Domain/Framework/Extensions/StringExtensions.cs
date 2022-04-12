namespace Textor.GRA.Domain.Framework.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt32(this string souce)
        {
            if (string.IsNullOrWhiteSpace(souce))
                return 0;

            _ = int.TryParse(souce, out int integer);

            return integer;
        }
    }
}
