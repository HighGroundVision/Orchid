using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamKit2;
using HGV.Crystalys;
using HGV.Orchid.Controllers;

namespace HGV.Orchid.Test
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void GetMatchMeta()
        {
            SteamDirectory.Initialize().Wait();

            var gameClient = new DotaClient("Thantsking", "aPhan3sah");
            gameClient.Connect();

            var controller = new MatchController(gameClient);
            var match = controller.Get(3111014659);

            Assert.IsNotNull(match);
        }
    }
}
