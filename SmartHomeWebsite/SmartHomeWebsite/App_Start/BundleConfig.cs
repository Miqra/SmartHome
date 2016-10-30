using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;


namespace SmartHomeWebsite.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.js",
                        "~/Scripts/jquery-1.9.1.intellisense.js",
                        "~/Scripts/jquery-1.9.1.min.js",
                        "~/Scripts/jquery-1.9.1.js",
                        "~/Scripts/responsive-nav.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/bootstrap-theme.css",
                       "~/Content/bootstrap-theme.min.css",
                       "~/Content/bootstrap.min.css"));

        }
    }
}