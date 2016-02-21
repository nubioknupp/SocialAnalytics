using System.Collections.Generic;

namespace SocialAnalytics.Infra.CrossCutting.Universal
{
    public class NullOrEmpty
    {
        public static bool IsAnyNullOrEmptyList(IEnumerable<object> lst)
        {
            if (lst == null) return true;

            var isReturn = true;

            foreach (var myObject in lst)
            {
                isReturn = IsAnyNullOrEmptyObject(myObject);

                if (!isReturn) break;
            }

            return isReturn;
        }

        public static bool IsAnyNullOrEmptyObject(object myObject)
        {
            if (myObject == null) return true;
            foreach (var pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof (string))
                {
                    var value = (string) pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
