using System.Web;
using System.Web.Optimization;

namespace FinalProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.dataTables.min.js",
                        "~/Scripts/sweetalert.min.js",
                        "~/Scripts/sidebar.js",
                        "~/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/Login").Include(
                       "~/Scripts/sweetalert.min.js",
                       "~/Scripts/login.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/customModal.css",
                      "~/Content/jquery.dataTables.min.css",
                      "~/Content/table.css",
                      "~/Content/Site.css"));

            // customize bundles 
            bundles.Add(new ScriptBundle("~/Scripts/Registration").Include(
                      "~/Scripts/Registration.js"
                      /*,"~/Content/Registration.css")*/));
            
            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                      "~/Scripts/dataTableModule.js"));


        }
    }
}
