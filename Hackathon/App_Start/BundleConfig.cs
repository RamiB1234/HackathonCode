﻿using System.Web;
using System.Web.Optimization;

namespace Hackathon
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/jquery-{version}.js",

                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                       "~/Scripts/dataTables.min.js", "~/Content/Chart.bundle",
                       "~/Scripts/dataTables.buttons.min.js", "~/Scripts/jQuery.print.js"
                       , "~/Scripts/demo/bootstrap.min.js", "~/Scripts/jquery-breadcrumbs.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       //"~/Content/site.css",
                       "~/Content/dataTables.min.css",
                            "~/Content/buttons.dataTables.min.css",
                           "~/Content/demo/font-awesome.min.css", "~/Content/jquery-breadcrumbs.css"));

        }
    }
}
