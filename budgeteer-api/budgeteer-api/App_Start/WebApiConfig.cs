using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Budgeteer.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AccountsByBudgetApi",
                routeTemplate: "api/v1/budgets/{budgetID}/accounts",
                defaults: new { controller = "accounts" }
            );

            config.Routes.MapHttpRoute(
                name: "SingleAccountByBudgetApi",
                routeTemplate: "api/v1/budgets/{budgetID}/accounts/{accountID}",
                defaults: new { controller = "accounts" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );            
        }
    }
}
