using System.Collections.Generic;
using BusinessEntities;
using Common;

namespace Core.Services.Users
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateUserService : IUpdateUserService
    {
        public void Update(User user, string name, string email, UserTypes type, int? age, decimal? annualSalary, IEnumerable<string> tags)
        {
            if (name != null)
            {
                user.SetName(name);
            }

            if (email != null)
            {
                user.SetEmail(email);
            }

            if (type != default(UserTypes))
            {
                user.SetType(type);
            }

            if (age.HasValue)
            {
                user.SetAge(age.Value);
            }

            if (annualSalary.HasValue)
            {
                var roundedSalary = decimal.Round(annualSalary.Value / 12, 2);
                user.SetMonthlySalary(roundedSalary);
            }

            if (tags != null)
            {
                user.SetTags(tags);
            }
        }
    }
}