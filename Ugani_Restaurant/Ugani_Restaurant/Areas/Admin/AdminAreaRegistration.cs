using System.Web.Mvc;

namespace Ugani_Restaurant.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //BANANs
            context.MapRoute(
               "Show List VIP",
               "Admin/Ban-An/Danh-Sach-Ban-VIP",
               new { controller = "BANANs", action = "ListVIP"},
                namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
           );

            context.MapRoute(
               "Show List Simple",
               "Admin/Ban-An/Danh-Sach-Ban-Thuong",
               new { controller = "BANANs", action = "ListSimple" },
                namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
           );
            context.MapRoute(
              "Create Table",
              "Admin/Ban-An/Them-Moi",
              new { controller = "BANANs", action = "Create" },
               namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
          );
            context.MapRoute(
               "Edit Table",
               "Admin/Ban-An/Chinh-Sua/{id}",
               new { controller = "BANANs", action = "Edit", id = @"\d{1,4}" },
                namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               "Delete Table",
               "Admin/Ban-An/Xoa/{id}",
               new { controller = "BANANs", action = "Delete", id = @"\d{1,4}" },
                namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
           );

            //HOADONs
            // context.MapRoute(
            //    "Show List Bill",
            //    "Admin/Don-Hang/Danh-Sach-Don-Hang",
            //    new { controller = "HOADONs", action = "Index" },
            //     namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
            //);

            // context.MapRoute(
            //    "Detail Bill",
            //    "Admin/Hoa-Don/Chi-Tiet/",
            //    new { controller = "s", action = "ListSimple" },
            //     namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
            //);

            //Home
            context.MapRoute(
               "Dashboard",
               "Admin/Home/Thong-Ke-Du-Lieu",
               new { controller = "Home", action = "Index"},
                namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
           );

            //LOAIMONs
            context.MapRoute(
               "List Category Food",
               "Admin/Loai-Mon-An/Danh-Sach-Loai-Mon",
               new { controller = "LOAIMONs", action = "Index"},
                namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
           );
            context.MapRoute(
             "Create Category Food",
             "Admin/Loai-Mon-An/Them-Moi",
             new { controller = "LOAIMONs", action = "Create", id = UrlParameter.Optional },
              namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
         );
            context.MapRoute(
              "Edit Category Food",
              "Admin/Loai-Mon-An/Chinh-Sua/{id}",
              new { controller = "LOAIMONs", action = "Edit", id = UrlParameter.Optional },
               namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
          );
            context.MapRoute(
             "Delete Category Food",
             "Admin/Loai-Mon-An/Xoa/{id}",
             new { controller = "LOAIMONs", action = "Delete", id = UrlParameter.Optional },
              namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
         );
            //MONANs
            context.MapRoute(
              "List Food",
              "Admin/Mon-An/Danh-Mon",
              new { controller = "MONANs", action = "Index" },
               namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
          );
            context.MapRoute(
             "Create Food",
             "Admin/Mon-An/Them-Moi",
             new { controller = "MONANs", action = "Create", id = UrlParameter.Optional },
              namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
         );
            context.MapRoute(
              "Edit Food",
              "Admin/Mon-An/Chinh-Sua/{id}",
              new { controller = "MONANs", action = "Edit", id = UrlParameter.Optional },
               namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
          );
            context.MapRoute(
             "Delete Food",
             "Admin/Mon-An/Xoa/{id}",
             new { controller = "MONANs", action = "Delete", id = UrlParameter.Optional },
              namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
         );

            //Default
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "Ugani_Restaurant.Areas.Admin.Controllers" }
            );
        }
    }
}