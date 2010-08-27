namespace ProcessWizard.Controllers
{
    public abstract class Stepbase<TDto> : IProcessStep where TDto: class
    {
        public object Dto { get; set;}
        
        public TDto CastDto
        {
            get { return Dto as TDto; }
        }

        public TDto CastObjectToDto(object dto)
        {
            var cast = dto as TDto;
            Dto = cast;
            return cast;
        }

        public abstract ProcessResult Process(object dto);
    }
}