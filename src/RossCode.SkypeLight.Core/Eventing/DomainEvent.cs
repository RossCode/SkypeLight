using System;
using System.Collections.Generic;
using System.Linq;

namespace RossCode.SkypeLight.Core.Eventing
{
    public static class DomainEvents
    {
        private static readonly IDictionary<Type, List<Delegate>> actions = new Dictionary<Type, List<Delegate>>();

        public static void Register<T>(Action<T> callback) 
        {
            if (!actions.ContainsKey(typeof(T)))
            {
                actions.Add(typeof(T), new List<Delegate>());
            }
            actions[typeof(T)].Add(callback);
        }

        public static void Unregister<T>(Action<T> callback)
        {
            if (actions.ContainsKey(typeof(T)))
            {
                var item = actions[typeof(T)].FirstOrDefault(i => i == (Delegate)callback);
                if (item != null)
                {
                    actions[typeof(T)].Remove(item);
                }
            }
        }

        public static void Raise<T>(T args) 
        {
            try
            {
                if (actions.ContainsKey(typeof(T)))
                {
                    actions[typeof(T)].ForEach(a => a.DynamicInvoke(args));
                }
            }
            catch { }
        }
    }
}