namespace ArionBank.Identity.Models
{
    public class UserListModel
    {
        public IList<UserListDto> Lists { get; set; } = new List<UserListDto>();
    }
}
