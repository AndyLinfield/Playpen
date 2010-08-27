namespace ProcessWizard.Controllers
{
    public interface IProcessStep
    {
        object Dto { get; set; }
        ProcessResult Process(object dto);
    }
}