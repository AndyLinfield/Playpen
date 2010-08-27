using System;

namespace ProcessWizard.Controllers
{
    public class FirstNameStep : Stepbase<FirstNameDto>
    {
        public FirstNameStep()
        {
            Dto = new FirstNameDto();
        }

        public override ProcessResult Process(object dto)
        {
            throw new NotImplementedException();
        }
    }

    public class FirstNameDto
    {
        public string FirstName { get; set; }
        public string Initial { get; set; }

        public FirstNameDto()
        {
            FirstName = string.Empty;
            Initial = string.Empty;
        }
    }
}