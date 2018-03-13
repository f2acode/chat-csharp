namespace Chat.Models.Centauro.Partials
{
    public class PayloadChatMessageTechFit
    {
        public string ChatId { get; set; }
        public string PartnerName { get; set; }
        public string Message { get; set; }
        public string PartnerAvatarUrl { get; set; }
        public string PartnerTitle { get; set; }
        public string[] PossibleAnswers { get; set; }
        public int PossibleAnswerType { get; set; }
    }
}
