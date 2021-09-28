namespace RBS.Model
{
    public class ExceptionModel
    {
        public double No { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
