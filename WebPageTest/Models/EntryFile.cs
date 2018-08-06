namespace WebPageTest.Models
{
    public class EntryFile
    {
        public string Url { get; set; }
        public double BytesReceived { get; set; }
        public string Method { get; set; }
        public int Code { get; set; }
        public double StartedTime { get; set; }
        public double Time { get; set; }
        public double ChartLeft { get; set; }
        public double ChartWidth { get; set; }
    }
}