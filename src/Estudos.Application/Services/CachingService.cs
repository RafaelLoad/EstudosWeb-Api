using Estudos.Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Estudos.Application.Services
{
    public class CachingService : ICachingService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMemoryCache _cache;
        public CachingService(IServiceProvider serviceProvider, IMemoryCache cache)
        {
            _serviceProvider = serviceProvider;
            _cache = cache;
        }
        public async Task<string> GetAsync(string key)
        {

            _cache.TryGetValue(key, out object? value);
            if(value is null)
                return string.Empty;

            return (string)value;
        }

        public async Task SetAsync(string key, string value)
        {
            var memoryCachaEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30), // deixa salvo ate o tempo acaba
                SlidingExpiration = TimeSpan.FromMinutes(20) // se nao for acesso ele ja tira
            };
            _cache.Set(key, value, memoryCachaEntryOptions);
        }
    }
}
