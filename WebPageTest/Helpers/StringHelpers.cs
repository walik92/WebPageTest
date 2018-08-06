using System;

namespace WebPageTest.Helpers
{
    public static class StringHelpers
    {
        public static bool IsUrlValid(this string source)
        {
            return Uri.TryCreate(source, UriKind.Absolute, out var uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}