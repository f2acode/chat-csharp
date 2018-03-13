namespace Chat.Models.Database
{
    public class MessageDBModel
    {
        public long Id { get; set; }
        public string ChatId { get; set; }
        public string Message { get; set; }
        public bool IsInternalUser { get; set; }
    }
}
