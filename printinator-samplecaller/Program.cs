using System;

namespace printinator_samplecaller
{
    class Program
    {
        static void Main(string[] args)
        {

            var mail = new printinator.EmailMessage
            {
                From = new printinator.Address
                {
                    Display = "Dr. Bakare Tunde, Nigerian Prince",
                    Email = "from.me@email.com"
                },
                To = new printinator.Address[] {
                    new printinator.Address { Email = "to1@email.com", Display = "To1 Name"},
                    new printinator.Address { Email = "to2@email.com", Display = "To2 Name"}
                },
                CC = new printinator.Address[] {
                    new printinator.Address { Email = "cc1@email.com", Display = "CC1 Name"},
                    new printinator.Address { Email = "cc2@email.com", Display = "CC2 Name"}
                },
                Subject = "My cool new email!",
                IsBodyHtml = true,
                Body = @"
<html>
    <head>
        <styles>
            h1 {color:blue;}
            div.red {color:red;}
        </styles>
    </head>
    <body>
        <h1>This is a big line</h1>
        <div class=""red"">
            <p>I am Dr. Bakare Tunde, the cousin of Nigerian Astronaut, Air Force Major Abacha Tunde. He was the first African in space when he made a secret flight to the Salyut 6 space station in 1979. He was on a later Soviet spaceflight, Soyuz T-16Z to the secret Soviet military space station Salyut 8T in 1989. He was stranded there in 1990 when the Soviet Union was dissolved. His other Soviet crew members returned to earth on the Soyuz T-16Z, but his place was taken up by return cargo. There have been occasional Progrez supply flights to keep him going since that time. He is in good humor, but wants to come home.</p>
            <p>In the 14-years since he has been on the station, he has accumulated flight pay and interest amounting to almost $ 15,000,000 American Dollars. This is held in a trust at the Lagos National Savings and Trust Association. If we can obtain access to this money, we can place a down payment with the Russian Space Authorities for a Soyuz return flight to bring him back to Earth. I am told this will cost $ 3,000,000 American Dollars. In order to access the his trust fund we need your assistance.</p>
            <p>Consequently, my colleagues and I are willing to transfer the total amount to your account or subsequent disbursement, since we as civil servants are prohibited by the Code of Conduct Bureau (Civil Service Laws) from opening and/ or operating foreign accounts in our names.</p>
            <p>Needless to say, the trust reposed on you at this juncture is enormous. In return, we have agreed to offer you 20 percent of the transferred sum, while 10 percent shall be set aside for incidental expenses (internal and external) between the parties in the course of the transaction. You will be mandated to remit the balance 70 percent to other accounts in due course.</p>
        </div>
    </body>
</html>",
            };

            var server = new printinator.Server
            {
                Host = "https://12.34.56.78",
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new printinator.Credentials
                {
                    Username = "secure_username@fake.com",
                    Password = "12345_the_same_password_as_my_luggage"
                }
            };

            var response = printinator.Sender.SendMail(server, mail);
            if(response.Success == true)
            {
                Console.WriteLine("Success, email sent, now we will get some money for sure!");
            }
            else
            {
                Console.WriteLine("Problem sending email, might not get our money :(");
                Console.WriteLine(response.ErrorMessage);
            }

        }

    }
}
