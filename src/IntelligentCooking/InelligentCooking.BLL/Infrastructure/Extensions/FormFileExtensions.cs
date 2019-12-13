using System;
using Microsoft.AspNetCore.Http;

namespace InelligentCooking.BLL.Infrastructure.Extensions
{
    public static class FormFileExtensions
    {
        public static bool IsImage(this IFormFile file)
        {
            if (!string.Equals(
                    file.ContentType,
                    "image/jpg",
                    StringComparison.OrdinalIgnoreCase)
                && !string.Equals(
                    file.ContentType,
                    "image/jpeg",
                    StringComparison.OrdinalIgnoreCase)
                && !string.Equals(
                    file.ContentType,
                    "image/pjpeg",
                    StringComparison.OrdinalIgnoreCase)
                && !string.Equals(
                    file.ContentType,
                    "image/x-png",
                    StringComparison.OrdinalIgnoreCase)
                && !string.Equals(
                    file.ContentType,
                    "image/png",
                    StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }
}
