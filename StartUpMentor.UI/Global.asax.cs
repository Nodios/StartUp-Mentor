﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StartUpMentor.Model.AutoMapperModelLayerMapping;
using StartUpMentor.UI.App_Start;

namespace StartUpMentor.UI
{
	public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapper.Mapper.Initialize(c =>
            {
                c.AddProfile<MappingConfiguration>();
                c.AddProfile<UIMappingConfiguration>();
            });
        }
    }
}
