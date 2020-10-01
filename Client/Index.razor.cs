using BlazorInputFile;
using ChartJs.Blazor.ChartJS.Common.Properties;
using ChartJs.Blazor.ChartJS.PieChart;
using ChartJs.Blazor.Charts;
using ChartJs.Blazor.Util;
using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoisnFang.ThirdParty
{
    partial class Index : ModuleBase
    {
        public override List<Resource> Resources => new List<Resource>()
        {
            new Resource { ResourceType = ResourceType.Script,  Url = "Modules/PoisnFang.ThirdParty/BlazorInput/inputfile.js" },

         new Resource { ResourceType = ResourceType.Script, Bundle="ChartJs", Url =
         "Modules/PoisnFang.ThirdParty/ChartJsBlazor/moment-with-locales.min.js" },

            new Resource { ResourceType = ResourceType.Script,Bundle="ChartJs", Url = "Modules/PoisnFang.ThirdParty/ChartJsBlazor/Chart.min.js" },
            new Resource { ResourceType = ResourceType.Script,Bundle="ChartJs", Url = "Modules/PoisnFang.ThirdParty/ChartJsBlazor/ChartJsBlazorInterop.js" },
            new Resource { ResourceType = ResourceType.Stylesheet,  Url = "Modules/PoisnFang.ThirdParty/ChartJsBlazor/ChartJSBlazor.css" }
        };

        private PieConfig _config;
        private ChartJsPieChart _pieChartJs;
        private string _status;

        protected override void OnParametersSet()
        {
            _config = new PieConfig
            {
                Options = new PieOptions
                {
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Sample chart from Blazor"
                    },
                    Responsive = true,
                    Animation = new ArcAnimation
                    {
                        AnimateRotate = true,
                        AnimateScale = true
                    }
                }
            };

            _config.Data.Labels.AddRange(new[] { "A", "B", "C", "D" });

            var pieSet = new PieDataset
            {
                BackgroundColor = new[] { ColorUtil.RandomColorString(), ColorUtil.RandomColorString(), ColorUtil.RandomColorString(), ColorUtil.RandomColorString() },
                BorderWidth = 0,
                HoverBackgroundColor = ColorUtil.RandomColorString(),
                HoverBorderColor = ColorUtil.RandomColorString(),
                HoverBorderWidth = 1,
                BorderColor = "#ffffff",
            };

            pieSet.Data.AddRange(new double[] { 4, 5, 6, 7 });
            _config.Data.Datasets.Add(pieSet);
        }

        protected async Task HandleSelectionAsync(IFileListEntry[] files)
        {
            var file = files.FirstOrDefault();
            if (file != null)
            {
                // Just load into .NET memory to show it can be done Alternatively it could be saved
                // to disk, or parsed in memory, or similar
                var ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);

                _status = $"Finished loading {file.Size} bytes from {file.Name}";
            }
        }
    }
}