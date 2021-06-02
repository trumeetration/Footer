using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Footer.Views.TabItemsContents
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatisticsPage : Grid
    {
        private List<ChartEntry> entries = new List<ChartEntry>()
        {
            new ChartEntry(10)
            {
                Color = SKColor.Parse("#FF7600")
            },
            new ChartEntry(5)
            {
                Color = SKColor.Parse("#FF7600")
            },
            new ChartEntry(30)
            {
                Color = SKColor.Parse("#FF7600")
            },
            new ChartEntry(25)
            {
                Color = SKColor.Parse("#FF7600")
            },
            new ChartEntry(20)
            {
                Color = SKColor.Parse("#FF7600")
            },
        };
		public StatisticsPage ()
        {
			InitializeComponent ();
            ChartView1.Chart = new LineChart() {Entries = entries};
		}
	}
}