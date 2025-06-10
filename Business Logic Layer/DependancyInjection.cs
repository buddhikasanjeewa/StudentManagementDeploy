using Business_Logic_Layer.Services.AbstactClasses;
using Business_Logic_Layer.Services.ConcreteClasses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    /*Develope:Buddhika Walpita
     * Date:2025.05.29
     * Description:Dependancy injection for BLL layer
     */
    public static class DependancyInjection
    {
        //*Register Business Logic Services
        public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            //Register services
            services.AddScoped<AStudentService, StudentService>();
     
        }
    }
}
