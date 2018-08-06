using System.Collections.Generic;

namespace WebPageTest.Models
{
    public class ResultTest
    {
        public double ElapsedTime { get; set; }
        public double BytesReceived { get; set; }
        public IList<EntryFile> Entries { get; set; } = new List<EntryFile>();
    }
}