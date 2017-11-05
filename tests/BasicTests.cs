using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamKit2;
using HGV.Crystalys;
using HGV.Orchid.Controllers;
using System.Configuration;

namespace HGV.Orchid.Test
{
    [TestClass]
    public class BasicTests
    {
        private UserInfo GetUserInfo()
        {
            return new UserInfo()
            {
                Username = ConfigurationManager.AppSettings["Steam:Username"], 
                Password = ConfigurationManager.AppSettings["Steam:Password"] 
            };
        }

        [TestMethod]
        public void GetMatchMeta()
        {
            SteamDirectory.Initialize().Wait();

            var userinfo = GetUserInfo();
            var gameClient = new DotaClient(userinfo.Username, userinfo.Password);
            gameClient.Connect();

            var controller = new MatchController(gameClient);
            var match = controller.Get(3111014659);

            Assert.IsNotNull(match);
        }
    }
}
