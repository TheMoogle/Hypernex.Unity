﻿using System;
using System.Collections.Generic;
using System.Linq;
using Hypernex.Game;
using Hypernex.Networking.Messages;
using Hypernex.Player;
using Nexport;

namespace Hypernex.Sandboxing.SandboxedTypes
{
    public class ClientNetworkEvent
    {
        private GameInstance gameInstance;

        public ClientNetworkEvent()
        {
            throw new Exception("Cannot instantiate ClientNetworkEvent!");
        }

        internal ClientNetworkEvent(GameInstance gameInstance) => this.gameInstance = gameInstance;

        public void SendToServer(string eventName, object[] data = null, 
            MessageChannel messageChannel = MessageChannel.Reliable)
        {
            NetworkedEvent networkedEvent = new NetworkedEvent
            {
                Auth = new JoinAuth
                {
                    UserId = APIPlayer.APIUser.Id,
                    TempToken = gameInstance.userIdToken
                },
                EventName = eventName,
                Data = new List<object> {data?.ToArray() ?? Array.Empty<object>()}
            };
            gameInstance.SendMessage(Msg.Serialize(networkedEvent), messageChannel);
        }
    }
}