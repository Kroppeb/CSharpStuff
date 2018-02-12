using System;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Additives.HandyExtensions
{
    static class AllObjects
    {
		public static int CompareHashTo<T>(this T self, T other) => self.GetHashCode().CompareTo(other.GetHashCode());
    }
}
