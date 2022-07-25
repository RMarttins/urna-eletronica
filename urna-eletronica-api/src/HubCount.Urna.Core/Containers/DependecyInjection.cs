using HubCount.Urna.Core.Repositories;
using HubCount.Urna.Core.Repositories.Interfaces;
using HubCount.Urna.Core.Services;
using HubCount.Urna.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HubCount.Urna.Core.Containers
{
    public abstract class DependecyInjection
    {
        public static void RegisterService(IServiceCollection services)
        {
            //Repositories
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();

            // Services
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IVoteService, VoteService>();
        }
    }
}