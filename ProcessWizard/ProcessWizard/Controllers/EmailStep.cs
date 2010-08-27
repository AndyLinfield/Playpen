using System.Collections.Generic;

namespace ProcessWizard.Controllers
{
    public class EmailStep : Stepbase<EmailDto>
    {
        public EmailStep()
        {
            Dto = new EmailDto();
        }

        public override ProcessResult Process(object dto)
        {
            var cast = CastObjectToDto(dto);
            // Validate Email Address
            if (!cast.EmailAddress.Contains("@"))
            {
                // Add Validation Errors.
                var errors = new Dictionary<string, string>();

                errors["Invalid Email Address"] = "Email Address Does Not Contain All-Important '@'";
                errors["Rob #FAIL"] = "Rob Can't Code for Shit";

                return new ProcessResult(errors);
            }

            return new ProcessResult(true);
        }
    }
}