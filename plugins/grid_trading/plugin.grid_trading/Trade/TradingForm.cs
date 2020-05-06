using Dragonfly.Plugin.GridTrading.Trade;
using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading
{
    internal partial class TradingForm : Form
    {


        public TradingForm()
        {
            InitializeComponent();
        }

        private void GridTradingSettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            string stockMarket = this.comboBoxStockMarket.Text;
            string stockCode = textBoxStockCode.Text;
            string price = textBoxBuyPrice.Text;
            string volume = textBoxBuyVolume.Text;
            switch (stockMarket)
            {
                case "A股":
                    TraderHelper.Instance.BuyStock(stockCode, decimal.Parse(price), int.Parse(volume));
                    break;
                case "沪港通":
                    TraderHelper.Instance.HgtBuyStock(stockCode, decimal.Parse(price), int.Parse(volume));
                    break;
                case "深港通":
                    TraderHelper.Instance.SgtBuyStock(stockCode, decimal.Parse(price), int.Parse(volume));
                    break;
            }
        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            string stockMarket = this.comboBoxStockMarket.Text;
            string stockCode = textBoxStockCode.Text;
            string price = textBoxBuyPrice.Text;
            string volume = textBoxBuyVolume.Text;
            switch (stockMarket)
            {
                case "A股":
                    TraderHelper.Instance.SellStock(stockCode, decimal.Parse(price), int.Parse(volume));
                    break;
                case "沪港通":
                    TraderHelper.Instance.HgtSellStock(stockCode, decimal.Parse(price), int.Parse(volume));
                    break;
                case "深港通":
                    TraderHelper.Instance.SgtSellStock(stockCode, decimal.Parse(price), int.Parse(volume));
                    break;
            }
        }
    }
}
