using Alkahest.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alkahest.Core.Net;
using Alkahest.Core.Net.Protocol.Packets;
using Alkahest.Core;

namespace Alkahest.Plugins.NoFireworks
{
    public class NoFireworksPlugin : IPlugin
    {
        public string Name => "no-fireworks";

        public void Start(GameProxy[] proxies)
        {
            foreach (var p in proxies.Select(x => x.Processor))
            {
                p.AddHandler<SSpawnNpcPacket>(HandleSpawnNpc);
            }
        }

        private bool HandleSpawnNpc(GameClient client, Direction direction, SSpawnNpcPacket packet)
        {
            if (packet.HuntingZoneId == 1023 && (packet.Template.Raw == 60016000 || packet.Template.Raw == 80037000))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Stop(GameProxy[] proxies)
        {
            foreach (var p in proxies.Select(x => x.Processor))
            {
                p.RemoveHandler<SSpawnNpcPacket>(HandleSpawnNpc);
            }
        }
    }
}
