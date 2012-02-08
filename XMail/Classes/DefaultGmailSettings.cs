/*
 * User: elijah
 * Date: 02/05/2012
 * Time: 17:48
 */
using System;

namespace XMail.Classes
{
    /// <summary>
    /// Some default gmail settings
    /// </summary>
    public class DefaultGmailSettings
    {
        public static bool UseSsl = true;
        
        public static int SslPort = 995;
        
        public static int OutTlsPort = 587;
        public static int OutSslPort = 465;
        
        public static string OutServerName = "smtp.gmail.com";
        public static string InServerNAme = "pop.gmail.com";
    }
}

/*
Incoming Mail (POP3) Server - requires SSL: pop.gmail.com
Use SSL: Yes
Port: 995  
Outgoing Mail (SMTP) Server - requires TLS3 or SSL: smtp.gmail.com (use authentication)
Use Authentication: Yes
Port for TLS/STARTTLS: 587
Port for SSL: 465  
Account Name:  your full email address (including @gmail.com or @your_domain.com)  
Email Address:  your email address (username@gmail.com or username@your_domain.com)  
Password:  your Gmail password  
*/