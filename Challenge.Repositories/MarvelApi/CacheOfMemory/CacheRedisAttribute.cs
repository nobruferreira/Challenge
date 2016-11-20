using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Repositories.MarvelApi.CacheOfMemory
{
    [Serializable]
    public class CacheRedisAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            using (IRedisClient cache = new RedisClient())
            {
                var result = cache.Get<IEnumerable<Product>>(GetKeyCache(args));

                if (result != null)
                {
                    args.ReturnValue = result;
                    args.FlowBehavior = FlowBehavior.Return;
                }
            }
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            using (IRedisClient cache = new RedisClient())
            {
                var key = GetKeyCache(args);
                cache.Set(key, args.ReturnValue, TimeSpan.FromMinutes(10));
            }
        }

        public string GetKeyCache(MethodExecutionArgs args)
        {
            var key = new StringBuilder(args.Method.Name);
            var parameters = args.Method.GetParameters();

            key.Append(":");
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i > 0)
                    key.Append(":");

                key.Append(parameters[i].Name);
                key.Append(":");
                key.Append(args.Arguments[i]);
            }

            return key.ToString();
        }
    }
}
