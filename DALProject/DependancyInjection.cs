
using DAL.Context;
using DAL.Reposistory.Classes;
using DAL.Reposistory.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Developer-Buddhika Walpita
 * Description-This class is used to register the dependencies for the DAL project.
 * Date-2023.05.29
 */

namespace DAL;
public static class DependancyInjection
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
        //Map dbcontext in Application.json file
            services.AddDbContext<SofttOneSmsnewContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("StuConnStr"));
            });

            //Reister service to Dependancy 
            services.AddScoped<IStudentRepo, StudentRepo>();

        }
    }


