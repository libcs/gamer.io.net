﻿using Gamer.Proxy;
using System;
using System.Linq;

namespace Gamer.Estate.Cry
{
    public static class CryExtensions
    {
        public static CryGame ToCryGame(this Uri uri, out ProxySink proxySink, out string filePath)
        {
            var path = "Data.p4k";
            // game
            var host = uri.Host;
            if (host.StartsWith("#"))
                host = host.Substring(1);
            var gameName = Enum.GetNames(typeof(CryGame)).FirstOrDefault(x => string.Equals(x, host, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentOutOfRangeException(nameof(host), host);
            var game = (CryGame)Enum.Parse(typeof(CryGame), gameName);
            // scheme
            if (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
            {
                proxySink = new ProxySinkClient(uri);
                filePath = null;
            }
            else
            {
                proxySink = new ProxySink();
                filePath = FileManager.GetFilePath(path, game) ?? throw new InvalidOperationException($"{game} not available");
            }
            return game;
        }
    }
}