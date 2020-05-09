﻿using System;
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


            Console.WriteLine("grid Count:" + grids.Count);

            foreach (Grid g in grids)
            {
                GridTest.PrintGridData(g);
            }
        }


    }



}
