using Plugin.ValidationRules.Interfaces;
using Project5.Models;
using System.Text.RegularExpressions;

namespace Project5.Validations
{
    public class UserRule : IValidationRule<User>
    {
        public string ValidationMessage { get; set; }

        public bool Check(User value)
        {
            if (value == null)
            {
                throw new Exception();
            }

            if (string.IsNullOrEmpty(value.Fname))
            {
                ValidationMessage = "A name is required.";
                return false;
            }

            if (string.IsNullOrEmpty(value.Email))
            {
                ValidationMessage = "A email is required.";
                return false;
            }

            var str = value.Email as string;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(str);

            if (!match.Success)
            {
                ValidationMessage = "Email is not valid.";
                return false;
            }
            
            return true; 
        }
    }

}
