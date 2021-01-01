using Microsoft.Extensions.DependencyInjection;
using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class SeedingService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public SeedingService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task InitializeAsync()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                // Check to see if there are entities
                // Add antities if necessary
            }
        }
    }
}
