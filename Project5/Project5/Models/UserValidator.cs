using Plugin.ValidationRules;
using Plugin.ValidationRules.Interfaces;
using Project5.Validations;

namespace Project5.Models
{
    public class UserValidator : IMapperValidator<User>
    {
        ValidationUnit _unit1;

        public UserValidator()
        {
            Fname = new Validatable<string>();
            Lname = new Validatable<string>();
            Email = new Validatable<string>();
            mobileNo = new Validatable<string>();
            password = new Validatable<string>();

            _unit1 = new ValidationUnit(Fname, Lname, Email,mobileNo,password);

            // Name validations
            Fname.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name cannot be blank" });

            //Lastname validations
            Lname.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Last Name cannot be blank" });

            //Email validations
            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Please Enter Email" });
            Email.Validations.Add(new EmailRule());

            mobileNo.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Please Enter Mobile no" });
            mobileNo.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Please Enter a Password" });
        }

        public Validatable<string> Fname { get; set; }
        public Validatable<string> Lname { get; set; }
        public Validatable<string> Email { get; set; }
        public Validatable<string> mobileNo { get; set; }
        public Validatable<string> password { get; set; }
        public bool Validate() 
        { 
            // Your logic goes here
            return _unit1.Validate(); 
        }

        public User Map()
        {
            // Simple Manual Mapper
            var manualMapperUser = new User
            {
                Fname = this.Fname.Value,
                Lname = this.Lname.Value,
                Email = this.Email.Value,
                mobileNo = this.mobileNo.Value,
                password = this.password.Value
            };

            return manualMapperUser;
        }
    }
}
