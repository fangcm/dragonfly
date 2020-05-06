using System;
using Dragonfly.Plugin.GridTrading.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Dragonfly.Plugin.GridTrading.Utils;

namespace trading_unit_test
{
    [TestClass]
    public class GridDaoTest
    {
 
        [TestMethod]
        public void TestManualGridJson()
        {

            SqliteHelper.DataSource = @"D:\work\my\dragonfly\plugins\bin\Debug\grid_trading.db";


            List<Grid> grids = GridDao.GetAllGrids();


            Console.WriteLine("InitPrice:" + grids.Count);
        }

       
    }



}
