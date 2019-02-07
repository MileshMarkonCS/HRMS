using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.Misc
{
    [NotMapped]
    public class MailConfig
    {
        [Key]
        [Required]
        [Display(Name = "Mail Config Id")]
        public Int64 MailConfigId { get; set; }

        [Required]
        [Display(Name = "App Id")]
        public Int64 AppId { get; set; }

        [Required]
        [Display(Name = "SMTP Client")]
        public string SmtpClient { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Port")]
        public int Port { get; set; }

        [Required]
        [Display(Name = "Enable Ssl")]
        public bool EnableSsl { get; set; }

        [Required]
        [Display(Name = "Sender Email Address")]
        public string SenderMailAddress { get; set; }

        [Required]
        [Display(Name = "Is Html Body")]
        public bool IsBodyHtml { get; set; }

        [Required]
        [Display(Name = "Bcc Email Address")]
        public string BccMailAddress { get; set; }

    }
}
