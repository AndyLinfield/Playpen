using System.Web;
using System.Web.Mvc;

namespace ProcessWizard.Controllers
{
    public class SteppedProcess
    {
        private IProcessStep[] _steps;
        private int _currentStep;
        private string _name;

        public IProcessStep CurrentStep
        {
            get
            {
                return _steps[_currentStep];
            }
        }

        static HttpSessionStateBase Session
        {
            get
            {
                return new HttpSessionStateWrapper(
                    HttpContext.Current.Session);
            }
        }

        public SteppedProcess(string name, params IProcessStep[] steps)
        {
            _name = name;
            _steps = steps;
            UpdateSessionWithProcess(name);
        }

        private void UpdateSessionWithProcess(string name)
        {
            Session.Add(string.Format("Process_{0}", name), this);
        }

        public static SteppedProcess Get<TProcessType>(string name) where TProcessType : new()
        {
            var session =  Session[string.Format("Process_{0}", name)] as SteppedProcess;

            if (session == null)
            {
                Session[""] = new TProcessType();
            }

            return Get<TProcessType>();
        }

        public static SteppedProcess Get(string name)
        {
            return Session[string.Format("Process_{0}", name)] as SteppedProcess;
        }

        public object NextStepDto()
        {
            UpdateSessionWithProcess(_name);
            _currentStep++;
            return CurrentStep.Dto;
        }

        public ProcessResult ProcessCurrentStep(object dto)
        {
            var currentStep = CurrentStep;
            var result = currentStep.Process(dto);

            if (result.Success)
                UpdateSessionWithProcess(_name);

            return result;
        }
    }
}