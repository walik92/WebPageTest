using System;
using HttpWatch;
using WebPageTest.Models;

namespace WebPageTest.Helpers
{
    public class WebsiteAnalyzer
    {
        public static ResultTest Analyze(string url)
        {
            if (!url.IsUrlValid()) throw new Exception($"Incorrect URL {url}");

            var controller = new Controller();
            var plugin = controller.Firefox.New();
            plugin.Log.EnableFilter(false);
            plugin.ClearCache();
            plugin.Record();
            plugin.GotoURL(url);

            controller.Wait(plugin, -1);
            plugin.Stop();

            var elapsedTime = plugin.Log.Pages[0].Entries.Summary.Time;
            var bytesReceived = plugin.Log.Pages[0].Entries.Summary.BytesReceived;
            var result = new ResultTest {ElapsedTime = elapsedTime, BytesReceived = bytesReceived};

            foreach (Entry entry in plugin.Log.Pages[0].Entries)
                result.Entries.Add(new EntryFile
                {
                    Url = entry.URL,
                    BytesReceived = entry.BytesReceived,
                    Code = entry.StatusCode,
                    Method = entry.Method,
                    StartedTime = entry.StartedSecs,
                    Time = entry.Time,
                    ChartLeft = entry.StartedSecs / elapsedTime * 200,
                    ChartWidth = entry.Time / elapsedTime * 200
                });

            return result;
        }
    }
}