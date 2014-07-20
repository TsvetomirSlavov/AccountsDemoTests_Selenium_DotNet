using System;

namespace AccountsDemoTests.Entities
{
    public class Client
    {
        public String CompanyName { get; set; }
        public String ContactPersonName { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String PhoneNumber2 { get; set; }
        public String Email { get; set; }
        public String Email2 { get; set; }

        public Client (String CompanyName, String ContactPersonName)
        {
            this.CompanyName = CompanyName;
            this.ContactPersonName = ContactPersonName;
        }
    }
}
