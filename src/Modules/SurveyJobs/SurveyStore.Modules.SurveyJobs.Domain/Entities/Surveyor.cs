using SurveyStore.Modules.SurveyJobs.Domain.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.SurveyJobs.Domain.Entities
{
    public class Surveyor : AggregateRoot
    {
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }

        private Surveyor(Guid id)
        {
            Id = id;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }

        public void ChangeFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new InvalidFirstNameException(firstName);
            }

            FirstName = firstName;
        }

        public void ChangeSurname(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new InvalidFirstNameException(surname);
            }

            Surname = surname;
        }

        public static Surveyor Create(Guid id, string email, string firstName, string surname)
        {
            var surveyor = new Surveyor(id);
            surveyor.ChangeEmail(email);
            surveyor.ChangeFirstName(firstName);
            surveyor.ChangeSurname(surname);

            return surveyor;
        }
    }
}