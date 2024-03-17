using SurveyStore.Modules.Surveyors.Core.Entities;

namespace SurveyStore.Modules.Surveyors.Core.DTO
{
    public static class Extensions
    {
        public static SurveyorDto AsDto(this Surveyor surveyor)
            => new()
            {
                Id = surveyor.Id,
                Email = surveyor.Email,
                FirstName = surveyor.FirstName,
                Surname = surveyor.Surname,
                Position = surveyor.Position
            };
    }
}
