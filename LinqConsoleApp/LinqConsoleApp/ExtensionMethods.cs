using System;
using System.Collections.Generic;
using System.Text;

namespace LinqConsoleApp
{
    public static class ExtensionMethods
    {
        public static bool IsWorkingAs(this IEnumerable<Emp> emps, Func<Emp, bool> where)
        {
            foreach(var emp in emps)
            {
                if (where(emp)) return true;
            }
            return false;
        }
    }
}
