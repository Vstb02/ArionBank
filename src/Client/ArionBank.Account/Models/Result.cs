namespace ArionBank.Account.Models
{
    public class Result
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
