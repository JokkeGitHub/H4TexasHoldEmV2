using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace H4TexasHoldEmV2
{
    public class ConnectionManager
    {
        private ConcurrentDictionary<string, WebSocket> _connections = new ConcurrentDictionary<string, WebSocket>();

        public WebSocket GetSocketById(string id)
        {
            return _connections.FirstOrDefault(x => x.Key== id).Value;
        }

        public ConcurrentDictionary<string, WebSocket> GetAllConnections()
        {
            return _connections;
        }

        public string GetId(WebSocket socket)
        {
            return _connections.FirstOrDefault(x => x.Value == socket).Key;
        }

        public async Task RemoveSocketAsync(string id)
        {
            _connections.TryRemove(id, out WebSocket socket);
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "socket connection closed", CancellationToken.None);
        }

        public void AddSocket(WebSocket socket)
        {
            _connections.TryAdd(GetConnectionId(), socket);
        }

        private string GetConnectionId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
