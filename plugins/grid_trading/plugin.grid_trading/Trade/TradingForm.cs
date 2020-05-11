using Dragonfly.Plugin.GridTrading.Trade;
using Dragonfly.Plugin.GridTrading.Utils;
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
            string stockMarket = this.comboBoxStockMarket.Text.Trim();
            string stockCode = textBoxStockCode.Text.Trim();
            string price = textBoxBuyPrice.Text.Trim();
            string volume = textBoxBuyVolume.Text.Trim();

            if (!(
                StringValidator.IsNotEmptyAndUnsignedNumber(stockCode) &&
                StringValidator.IsNotEmptyAndUnsignedRealNumber(price) &&
                StringValidator.IsNotEmptyAndUnsignedNumber(volume)))
            {
                return;
            }

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
            string stockMarket = this.comboBoxStockMarket.Text.Trim();
            string stockCode = textBoxStockCode.Text.Trim();
            string price = textBoxSellPrice.Text.Trim();
            string volume = textBoxSellVolume.Text.Trim();

            if (!(
                StringValidator.IsNotEmptyAndUnsignedNumber(stockCode) &&
                StringValidator.IsNotEmptyAndUnsignedRealNumber(price) &&
                StringValidator.IsNotEmptyAndUnsignedNumber(volume)))
            {
                return;
            }

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
