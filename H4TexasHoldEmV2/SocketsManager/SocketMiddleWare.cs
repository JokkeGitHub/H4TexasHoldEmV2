﻿using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;

namespace H4TexasHoldEmV2
{
    public class SocketMiddleWare
    {
        private readonly RequestDelegate _next;
        private SocketHandler Handler { get; set; }

        public SocketMiddleWare(RequestDelegate next, SocketHandler handler)
        {
            _next = next;
            Handler = handler;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.WebSockets.IsWebSocketRequest)
            {
                return;
            }

            var socket = await context.WebSockets.AcceptWebSocketAsync();
            await Receive(socket, async (result, buffer) => 
            { 
                if(result.MessageType == WebSocketMessageType.Text)
                {
                    //await Handler.Receive(socket, result, buffer);
                }
                else if(result.MessageType == WebSocketMessageType.Close) 
                {
                    await Handler.OnDisconnected(socket);
                }
            });
        }

        private async Task Receive(WebSocket webSocket, Action<WebSocketReceiveResult, byte[]> messageHandler)
        {
            var buffer = new byte[1024 * 4];
            while(webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                messageHandler(result, buffer);
            }
        }
    }
}
