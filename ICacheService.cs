using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration
{
    public interface ICacheService
    {
        void Set<T>(string key, T value, int hours);
        T Get<T>(string key);
        void Clear(string key);
    }
}
