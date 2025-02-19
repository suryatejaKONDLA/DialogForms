namespace DialogForms.Models.MasterModels;

public class CustomerModel
{
    [Required(ErrorMessage = "First Name is required."), MaxLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")] public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required."), MaxLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")] public string LastName { get; set; }

    [Required(ErrorMessage = "Date of Birth is required."), DataType(DataType.Date), CustomValidation(typeof(CustomerModel), "ValidateDateOfBirth")] public DateTime DateOfBirth { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Email is required."), EmailAddress(ErrorMessage = "Invalid email format.")] public string Email { get; set; }

    [Required(ErrorMessage = "Phone Number is required."), RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be 10 digits.")] public string PhoneNumber { get; set; }

    [RegularExpression(@"^\d{10}$", ErrorMessage = "Alternate Phone Number must be 10 digits.")] public string AlternatePhoneNumber { get; set; }

    [Required(ErrorMessage = "Address Line 1 is required.")] public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    [Required(ErrorMessage = "City is required.")] public string City { get; set; }

    public string State { get; set; }

    public int Id { get; set; }

    [Required(ErrorMessage = "Postal Code is required."), RegularExpression(@"^\d{5}$", ErrorMessage = "Postal Code must be 5 digits.")] public string PostalCode { get; set; }

    [Required(ErrorMessage = "Subscription preference must be selected.")] public bool IsSubscribedToNewsletter { get; set; }

    [Required(ErrorMessage = "Preferred Contact Method is required.")] public string PreferredContactMethod { get; set; } // e.g., Email, Phone

    [MaxLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")] public string Notes { get; set; }

    public static ValidationResult ValidateDateOfBirth(DateTime dateOfBirth, ValidationContext context)
    {
        if (dateOfBirth > DateTime.Today)
        {
            return new("Date of Birth must be in the past.");
        }

        return ValidationResult.Success;
    }
}