﻿using System.Web.Optimization;

namespace SocialPhotoEditor
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/emojionearea.min.css",
                      "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/angular-resource.min.js",
                "~/Scripts/Angular/module.js"));

            //MVC ANGULAR __ MY
            bundles.Add(new ScriptBundle("~/bundles/current-user").Include(
                "~/Scripts/Angular/current-user/current-user.controller.js",
                "~/Scripts/Angular/current-user/current-user.service.js"));

            bundles.Add(new ScriptBundle("~/bundles/user-list").Include(
                "~/Scripts/Angular/user-list/user-list.controller.js",
                "~/Scripts/Angular/user-list/user-list.service.js"));

            bundles.Add(new ScriptBundle("~/bundles/user-page").Include(
                "~/Scripts/Angular/user-page/user-page.controller.js",
                "~/Scripts/Angular/user-page/user-page.service.js"));

            bundles.Add(new ScriptBundle("~/bundles/image").Include(
                "~/Scripts/emojionearea.min.js",
                "~/Scripts/Angular/image/image.controller.js",
                "~/Scripts/Angular/image/image.service.js"));

            bundles.Add(new ScriptBundle("~/bundles/user-min-list").Include(
                "~/Scripts/Angular/user-min-list/user-min-list.controller.js",
                "~/Scripts/Angular/user-min-list/user-min-list.service.js"));

            bundles.Add(new ScriptBundle("~/bundles/news").Include(
                "~/Scripts/Angular/news/news.controller.js",
                "~/Scripts/Angular/news/news.service.js"));

            bundles.Add(new ScriptBundle("~/bundles/folder").Include(
                "~/Scripts/emojionearea.min.js",
                "~/Scripts/Angular/folder/folder.controller.js",
                "~/Scripts/Angular/folder/folder.service.js"));

            bundles.Add(new ScriptBundle("~/bundles/setting").Include(
                "~/Scripts/emojionearea.min.js",
                "~/Scripts/Angular/setting/setting.controller.js",
                "~/Scripts/Angular/setting/setting.service.js"));

            bundles.Add(new ScriptBundle("~/bundles/new-image").Include(
                "~/Scripts/emojionearea.min.js",
                "~/Scripts/Angular/new-image/new-image.controller.js",
                "~/Scripts/Angular/new-image/new-image.service.js"));
        }
    }
}
