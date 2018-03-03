using System.Web.Mvc;

namespace cams
{
    /// <summary>
    /// Defines the filter configuration.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers the filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}