using System;
using Dragonfly.Plugin.GridTrading.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace trading_unit_test
{
    [TestClass]
    public class GridTest
    {
 
        [TestMethod]
        public void TestManualGridJson()
        {
            string json = @"{
                'StockMarket': 1,
                'StockCode': '300348',
                'InitPrice': 30.50,
                'InitHoldingVolume': 21000,
                'MaxPrice': 30.50,
                'MinPrice': 30.50,
                'GridNodes': [
                    {'TradingPrice': 32.38,'HoldingVolume':15000},
                    {'TradingPrice': 32.06,'HoldingVolume': 16000},
                    {'TradingPrice': 31.74,'HoldingVolume': 17000},
                    {'TradingPrice': 31.42,'HoldingVolume': 18000},
                    {'TradingPrice': 31.11,'HoldingVolume': 19000},
                    {'TradingPrice': 30.81,'HoldingVolume': 20000},
                    {'TradingPrice': 30.50,'HoldingVolume': 21000},
                    {'TradingPrice': 30.20,'HoldingVolume': 22000},
                    {'TradingPrice': 29.89,'HoldingVolume': 23000},
                    {'TradingPrice': 29.59,'HoldingVolume': 24000},
                    {'TradingPrice': 29.30,'HoldingVolume': 25000}
                ]
            }";

            ManualGrid g = ManualGrid.FromJson<ManualGrid>(json);

            foreach (var node in g.GridNodes)
            {
                printNodeData(node);
            }

            Console.WriteLine("InitPrice:" + g.InitPrice);
            Console.WriteLine("InitHoldingVolume:" + g.InitHoldingVolume);
            Console.WriteLine("MinPrice:" + g.MinPrice);
            Console.WriteLine("MaxPrice:" + g.MaxPrice);


            for (int p = 13000; p < 27000; p += 500)
            {
                printExpectedNodeData(g, p);

            }


            Console.WriteLine(g.ToJson());

        }

        private void printExpectedNodeData(ManualGrid g, int volume)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Expected volume:" + volume);
            var egi = g.ExpectedGridNode(volume);
            printNodeData(egi);
        }

        private void printNodeData(GridNode node)
        {
            if (node == null)
                return;

            string buy = "";
            string sell = "";

            if (node.BuyOrder != null)
            {
                buy = ", buy:" + node.BuyOrder.Price + ", " + node.BuyOrder.Volume;
            }
            if (node.SellOrder != null)
            {
                sell = ", sell:" + node.SellOrder.Price + ", " + node.SellOrder.Volume;
            }
            Console.WriteLine("price:" + node.TradingPrice +
                ", volume:" + node.HoldingVolume +
                buy + sell);
        }
    }



}
