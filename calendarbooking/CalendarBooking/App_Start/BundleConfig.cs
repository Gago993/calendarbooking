using System.Web;
using System.Web.Optimization;

namespace CalendarBooking
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular/library").Include(
                        "~/Scripts/bower_components/angular/angular.js",
                        "~/Scripts/bower_components/angular-route/angular-route.js",
                        "~/Scripts/bower_components/angular-resource/angular-resource.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular/app").Include(
                        "~/App/App.js",

                        "~/App/DataServices/services.data.module.js",

                        "~/App/Core/core.module.js",
                        "~/App/Core/config.js",

                        "~/App/Main/main.module.js",
                        "~/App/Main/main.controller.js",

                        "~/Scripts/bower_components/angular-resource/angular-resource.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
