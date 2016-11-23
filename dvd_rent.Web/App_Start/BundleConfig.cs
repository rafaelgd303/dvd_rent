using System.Web;
using System.Web.Optimization;

namespace dvd_rent.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/ui-bootstrap-csp.css",
                "~/Content/css/select2.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-ui-router.min.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/select2.min.js",
                "~/Scripts/angular-ui/ui-bootstrap.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/app/components/application/applicationControllers.js",
                "~/app/components/client/cientServices.js",
                "~/app/components/client/clientControllers.js",
                "~/app/components/movie/movieServices.js",
                "~/app/components/movie/movieControllers.js",
                "~/app/components/moviecopy/moviecopyServices.js",
                "~/app/components/moviecopy/moviecopyControllers.js",
                "~/app/components/moviecopyclient/moviecopyclientServices.js",
                "~/app/components/moviecopyclient/moviecopyclientControllers.js",
                "~/app/app.js"
                ));
        }
    }
}
