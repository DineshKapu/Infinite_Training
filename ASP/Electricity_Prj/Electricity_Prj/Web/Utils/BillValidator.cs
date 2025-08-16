using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electricity_Prj.Web.Utils
{
    public class BillValidator
    {
        public string ValidateUnitsConsumed(int units)
        {
            return units < 0 ? "Given units is invalid" : string.Empty;
        }
    }
}