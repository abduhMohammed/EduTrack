using System.ComponentModel.DataAnnotations;

namespace MVC02.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        public string? Message;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            
            string? newName = value.ToString();
            AppDBContext context = new AppDBContext();
            Instructor? instDB = context.Instructor.FirstOrDefault(s => s.Name == newName);
            Instructor? instForm = (Instructor)validationContext.ObjectInstance;

            if(instDB != null)
            {
                return new ValidationResult("Name must be Unique");
            }
            return ValidationResult.Success;
        }
    }
}
