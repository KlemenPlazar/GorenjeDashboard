using System.Web;
using System.Web.Optimization;

namespace GorenjeDashboard
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/vendor/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/metisMenu").Include(
                       "~/Content/vendor/metisMenu/metisMenu.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/MorrisCharts").Include(
                      "~/Content/vendor/raphael/raphael.min.js",
                      "~/Content/vendor/raphael/morris.min.js",
                      "~/Content/data/morris-data.js"));

            bundles.Add(new ScriptBundle("~/bundles/customTheme").Include(
                       "~/Content/dist/js/sb-admin-2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/vendor/metisMenu/metisMenu.min.css",
                      "~/Content/dist/css/sb-admin-2.css",
                      "~/Content/vendor/morrisjs/morris.css",
                      "~/Content/vendor/font-awesome/css/font-awesome.min.css"));
        }
    }
}
