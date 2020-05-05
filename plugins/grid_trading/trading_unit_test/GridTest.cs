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
        public void TestManualGrid()
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            config.Add("InitPrice", 30.50);
            config.Add("InitHoldingVolume", 21000);
            config.Add("MaxPrice", 30.50);
            config.Add("MinPrice", 30.50);

            Dictionary<string, object> priceAndHoldingVolume = new Dictionary<string, object>();
            priceAndHoldingVolume.Add("32.38", 15000);
            priceAndHoldingVolume.Add("32.06", 16000);
            priceAndHoldingVolume.Add("31.74", 17000);
            priceAndHoldingVolume.Add("31.42", 18000);
            priceAndHoldingVolume.Add("31.11", 19000);
            priceAndHoldingVolume.Add("30.81", 20000);
            priceAndHoldingVolume.Add("30.50", 21000);
            priceAndHoldingVolume.Add("30.20", 22000);
            priceAndHoldingVolume.Add("29.89", 23000);
            priceAndHoldingVolume.Add("29.59", 24000);
            priceAndHoldingVolume.Add("29.30", 25000);

            config.Add("PriceAndHoldingVolume", priceAndHoldingVolume);

            ManualGrid g = new ManualGrid();
            g.Init(config);

            foreach (var item in g.gridItemList)
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

        }

        [TestMethod]
        public void TestManualGridJson()
        {
            string json = @"{
                'InitPrice': 30.50,
                'InitHoldingVolume': 21000,
                'MaxPrice': 30.50,
                'MinPrice': 30.50,
                'PriceAndHoldingVolume': [
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
            
            ManualGrid g = new ManualGrid();
            g.Init(json);

            foreach (var item in g.gridItemList)
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

        }

        private void printExpectedItemData(ManualGrid g, int volume)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Expected volume:" + volume);
            var egi = g.ExpectedGridItem(volume);
            printItemData(egi);
        }

        private void printItemData(GridItem item)
        {
            string buy = "";
            string sell = "";

            if (item.BuyOrder != null)
            {
                buy = ", buy:" + item.BuyOrder.Price + ", " + item.BuyOrder.Volume;
            }
            if (item.SellOrder != null)
            {
                sell = ", sell:" + item.SellOrder.Price + ", " + item.SellOrder.Volume;
            }
            Console.WriteLine("price:" + item.TradingPrice +
                ", volume:" + item.HoldingVolume +
                buy + sell);
        }
    }



}
