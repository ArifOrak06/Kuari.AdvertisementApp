
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orak.AdvertisementApp.Business.İnterfaces;
using Orak.AdvertisementApp.Business.Mappings.AutoMapper;
using Orak.AdvertisementApp.Business.Services;
using Orak.AdvertisementApp.Business.ValidationRules;
using Orak.AdvertisementApp.DataAccess.Contexts;
using Orak.AdvertisementApp.DataAccess.UnitOfWork;
using Orak.AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orak.AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
          
           
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
           
            
            services.AddScoped<IUow, Uow>();
            services.AddScoped<IProvidedServiceService, ProvidedServiceManager>();
            services.AddScoped<IAdvertisementService, AdvertisementServiceManager>();
            services.AddScoped<IAppUserService, AppUserServiceManager>();
            services.AddScoped<IGenderService, GenderServiceManager>();
        }
      
    }
}
