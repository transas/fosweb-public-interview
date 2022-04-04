using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Transas.Tornado.Html5.WebApi.RealTimeMonitoring.RtmClientsRegister
{
    public interface IRtmClientsRegister
    {
        void MarkClientAsMonitored(Guid dmsClientId, string connectionId);
        void RemoveMonitoringMarkForClient(Guid dmsClientId, string connectionId);
        bool IsClientOnMonitoring(Guid dmsClientId);
    }

    public class RtmClientsRegister : IRtmClientsRegister
    {
        private readonly ConcurrentDictionary<Guid, HashSet<string>> clientsRegister;

        public RtmClientsRegister()
        {
            clientsRegister = new ConcurrentDictionary<Guid, HashSet<string>>();
        }

        public void MarkClientAsMonitored(Guid dmsClientId, string connectionId)
        {
            HashSet<string> connections;
            if (clientsRegister.TryGetValue(dmsClientId, out connections))
            {
                connections.Add(connectionId);
            }
            else
            {
                clientsRegister.TryAdd(dmsClientId, new HashSet<string>() { connectionId });
            }
        }

        public void RemoveMonitoringMarkForClient(Guid dmsClientId, string connectionId)
        {
            HashSet<string> connections;
            if (clientsRegister.TryGetValue(dmsClientId, out connections))
            {
                connections.Remove(connectionId);

                if (connections.Count == 0)
                {
                    clientsRegister.TryRemove(dmsClientId, out connections);
                }
            }
        }

        public bool IsClientOnMonitoring(Guid dmsClientId)
        {
            Trace.TraceInformation($"clientsOnMonitoring: {GetClientsOnMonitoring()}");
            return clientsRegister.ContainsKey(dmsClientId);
        }

        private string GetClientsOnMonitoring()
        {
            return string.Join(", ", clientsRegister.Keys);
        }

    }


}