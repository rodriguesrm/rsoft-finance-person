using MassTransit.RabbitMqTransport;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RSoft.Lib.Common.Options;
using RSoft.Lib.Design.Infra.Data;
using RSoft.Lib.Design.IoC;
using RSoft.Lib.Messaging.Abstractions;
using RSoft.Lib.Messaging.Options;
using RSoft.Person.Core.Ports;
using RSoft.Person.Core.Services;
using RSoft.Person.Infra;
using RSoft.Person.Infra.Providers;
using System;
using System.Collections.Generic;

namespace RSoft.Person.Cross.IoC
{

    /// <summary>
    /// Dependency injection register service
    /// </summary>
    public static class DependencyInjection
    {

        /// <summary>
        /// Register dependency injection services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Configuration object</param>
        /// <param name="aditionalConfig">Action to adicional configuration for messaging</param>
        public static IServiceCollection AddPersonRegister
        (
            this IServiceCollection services,
            IConfiguration configuration,
            Action<IRabbitMqBusFactoryConfigurator> aditionalConfig = null
        )
        {

            services.AddRSoftRegister<PersonContext>(configuration, true);

            #region Options

            services.Configure<CultureOptions>(options => configuration.GetSection("Application:Culture").Bind(options));
            services.Configure<MessagingOption>(options => configuration.GetSection("Messaging:Server").Bind(options));

            #endregion

            services.AddMassTransitUsingRabbitMq(configuration, cfg => aditionalConfig?.Invoke(cfg));

            #region Infra

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonProvider, PersonProvider>();
            services.AddScoped<IUserProvider, UserProvider>();

            #endregion

            #region Domain

            services.AddScoped<IPersonDomainService, PersonDomainService>();
            services.AddScoped<IUserDomainService, UserDomainService>();

            #endregion

            #region Application

            services.AddServicesMediatR();

            #endregion

            return services;

        }

        /// <summary>
        /// Add mediator services 
        /// </summary>
        /// <param name="services">Service collection object</param>
        private static IServiceCollection AddServicesMediatR(this IServiceCollection services)
        {

            List<string> assembliesNames = new()
            {
                "RSoft.Person.Application"
            };


            assembliesNames
                .ForEach(assemblyName =>
                {
                    var assembly = AppDomain.CurrentDomain.Load(assemblyName);
                    services.AddMediatR(assembly);
                });

            return services;

        }

    }

}
