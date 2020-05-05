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
                    {'32.38': 15000},
                    {'32.06': 16000},
                    {'31.74': 17000},
                    {'31.42': 18000},
                    {'31.11': 19000},
                    {'30.81': 20000},
                    {'30.50': 21000},
                    {'30.20': 22000},
                    {'29.89': 23000},
                    {'29.59': 24000},
                    {'29.30': 25000}
                ]
            }";

            ManualGrid g = ManualGrid.FromJson(json);

            foreach (var item in g.gridNodeList)
            {
                printItemData(item.Value);
            }

            Console.WriteLine("InitPrice:" + g.InitPrice);
            Console.WriteLine("InitHoldingVolume:" + g.InitHoldingVolume);
            Console.WriteLine("MinPrice:" + g.MinPrice);
            Console.WriteLine("MaxPrice:" + g.MaxPrice);


            for (int p = 13000; p < 27000; p += 500)
            {
                printExpectedItemData(g, p);

            }


            Console.WriteLine(g.ToJson());

        }

        private void printExpectedItemData(ManualGrid g, int volume)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Expected volume:" + volume);
            var egi = g.ExpectedGridItem(volume);
            printItemData(egi);
        }

        private void printItemData(GridNode node)
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
