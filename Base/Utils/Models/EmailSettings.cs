namespace BufaloCargo.Utils.Models
{
    class EmailSettings
    {
        public string? SMTPUserName { get; set; }
        public string? SMTPPassword { get; set; }
        public string? Host { get; set; }
        public string? Port { get; set; }
        public string? EnableSsl { get; set; }
        public string? Timeout { get; set; }
        public string? SenderDisplayName { get; set; }
        public string? SenderEmailAddress { get; set; }
    }
}
