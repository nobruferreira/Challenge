using Challenge.Domain.ValueObjects.MarvelApi.Comics;
using NServiceKit.Redis;
using PostSharp.Aspects;
using System;
using System.Text;

namespace Challenge.ExternalService.CacheOfMemory.MarvelApi
{
    [Serializable]
    public class CacheComicsRootObjectAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            using (IRedisClient cache = new RedisClient())
            {
                var result = cache.Get<ComicsRootObject>(GetKeyCache(args));

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
                cache.Set(key, args.ReturnValue, TimeSpan.FromMinutes(20));
            }
        }

        private string GetKeyCache(MethodExecutionArgs args)
        {
            var key = new StringBuilder(args.Method.Name);
            var parameters = args.Method.GetParameters();

            key.Append(":");
            for (int i = 1; i < parameters.Length; i++)
            {
                if (i > 1)
                    key.Append(":");

                key.Append(parameters[i].Name);
                key.Append(":");
                key.Append(args.Arguments[i]);
            }

            return key.ToString();
        }
    }
}

