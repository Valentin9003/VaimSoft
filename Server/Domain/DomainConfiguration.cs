using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
           => services;
               //.Scan(scan => scan
               //    .FromCallingAssembly()
               //    .AddClasses(classes => classes
               //    .AssignableTo(typeof(IFactory<>)))
               //    .AsMatchingInterface()
               //    .WithTransientLifetime());
    }
}
