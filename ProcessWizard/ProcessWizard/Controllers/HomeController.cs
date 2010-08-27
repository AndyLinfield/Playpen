using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProcessWizard.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Step1()
        {
//            var steppedProcess = new SteppedProcess("name",  new EmailStep(), new FirstNameStep(), new LastNameStep());
            var steppedProcess = SteppedProcess.Get<SignUpProcess>("1");
            var step = steppedProcess.CurrentStep;
            return View("Step1", step.Dto);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Step1(EmailDto dto)
        {
            var steppedProcess = SteppedProcess.Get<SignUpProcess>("1");

            var result = steppedProcess.ProcessCurrentStep(dto);
            if (!result.Success)
            {
                // Could Get Model Errors from result.ModelErrors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View("Step1", dto);
            }

            return View("Step2", steppedProcess.NextStepDto());
        }
    }

    public class SignUpProcess : SteppedProcess
    {
        public SignUpProcess() : base("", new EmailStep(), new FirstNameStep(), new LastNameStep())
        {
            
        }
    }

    public class ProcessResult
    {
        public bool Success { get; private set; }
        public Dictionary<string, string> Errors { get; private set; }

        public ProcessResult(bool success)
        {
            Success = success;
            Errors = new Dictionary<string, string>();
        }

        public ProcessResult(Dictionary<string, string> validationErrors) : this(false)
        {
            Errors = validationErrors;
        }
    }
}
