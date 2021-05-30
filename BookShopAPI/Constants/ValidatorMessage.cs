using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopAPI.Constants
{
    public class ValidatorMessage
    {
        internal static readonly string NameInUse = "Name is in use";
        internal static readonly string PageSize = "Page size must be in ";
        internal static readonly string SortBy = "SortBy must be in ";
        internal static readonly string SortDirection = "Sort direction must be in ";
    }
}
