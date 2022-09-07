namespace Fun_Olympic_Broadcaster.Models
{
    public class SMTPConfigModel
    {
        //public string SenderAddress { get; set; }
        //public string SenderDisplayName { get; set; }
        public string Host { get; set; }

        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string DisplayName { get; set; }
      
        //public string EnabledSSL { get; set; }
        //public string UserDefaultCredintials { get; set; }
        //public string IsBodyHTML { get; set; }
    }
}
