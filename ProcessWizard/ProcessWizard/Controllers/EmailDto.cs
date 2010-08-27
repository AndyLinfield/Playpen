namespace ProcessWizard.Controllers
{
    public class EmailDto
    {
        public string EmailAddress { get; set; }

        public EmailDto()
        {
            EmailAddress = "no_user@somedomain.com";
        }
    }
}