namespace ArionBank.Identity.Models
{
    public class UpdateResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
