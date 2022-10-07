using MathCore.WPF.Services;
using MathCore.WPF;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_task.Data;
using wpf_task.Services.Interfaces;

namespace wpf_task.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<DbInit>()
            .AddTransient<IUserDialog, UserDialog>()
            .AddTransient<IUserDialogBase, FileDialog>()
            .AddTransient<IFileConverter, ImageConverter>()
        ;
    }
}
