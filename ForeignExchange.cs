using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForeignExchange
{
    public partial class ForeignExchange : Form
    {
        public ForeignExchange()
        {
            InitializeComponent();
        }

        private async void ForeignExchange_Load(object sender, EventArgs e)
        {
            await TryToGetRates();
        }

        private async Task TryToGetRates()
        {
            await FixerForeignExchangeRates.FixerForeignExchangeRates.GetRates(DateTime.Today, lstRates);
        }
    }
}
