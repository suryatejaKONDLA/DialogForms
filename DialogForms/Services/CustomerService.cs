namespace DialogForms.Services;

public class CustomerService
{
    private readonly List<CustomerModel> Customers;

    private int CurrentId = 1;

    public CustomerService() => Customers =
    [
        new CustomerModel
        {
            Id = CurrentId++,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new(1985, 5, 15),
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890",
            AlternatePhoneNumber = "0987654321",
            AddressLine1 = "123 Main St",
            AddressLine2 = "Apt 4B",
            City = "New York",
            State = "NY",
            PostalCode = "10001",
            IsSubscribedToNewsletter = true,
            PreferredContactMethod = "Email",
            Notes = "Loyal customer since 2010."
        },
        new CustomerModel
        {
            Id = CurrentId++,
            FirstName = "Jane",
            LastName = "Smith",
            DateOfBirth = new(1990, 8, 22),
            Email = "jane.smith@example.com",
            PhoneNumber = "2345678901",
            AlternatePhoneNumber = "1234567890",
            AddressLine1 = "456 Elm St",
            AddressLine2 = string.Empty,
            City = "Los Angeles",
            State = "CA",
            PostalCode = "90001",
            IsSubscribedToNewsletter = false,
            PreferredContactMethod = "Phone",
            Notes = "Prefers phone communication."
        }
    ];

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

    public List<CustomerModel> GetCustomers() => Customers;

    public bool AddCustomer(CustomerModel customer)
    {
        if (Customers.Any(c => c.Email.Equals(customer.Email, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }

        customer.Id = CurrentId++;
        Customers.Add(customer);
        NotifyStateChanged();
        return true;
    }

    public bool UpdateCustomer(int id, CustomerModel updatedCustomer)
    {
        var existingCustomer = Customers.FirstOrDefault(c => c.Id == id);
        if (existingCustomer == null)
        {
            return false;
        }

        existingCustomer.FirstName = updatedCustomer.FirstName;
        existingCustomer.LastName = updatedCustomer.LastName;
        existingCustomer.DateOfBirth = updatedCustomer.DateOfBirth;
        existingCustomer.Email = updatedCustomer.Email;
        existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
        existingCustomer.AlternatePhoneNumber = updatedCustomer.AlternatePhoneNumber;
        existingCustomer.AddressLine1 = updatedCustomer.AddressLine1;
        existingCustomer.AddressLine2 = updatedCustomer.AddressLine2;
        existingCustomer.City = updatedCustomer.City;
        existingCustomer.State = updatedCustomer.State;
        existingCustomer.PostalCode = updatedCustomer.PostalCode;
        existingCustomer.IsSubscribedToNewsletter = updatedCustomer.IsSubscribedToNewsletter;
        existingCustomer.PreferredContactMethod = updatedCustomer.PreferredContactMethod;
        existingCustomer.Notes = updatedCustomer.Notes;

        NotifyStateChanged();
        return true;
    }

    public bool DeleteCustomer(int id)
    {
        var customer = Customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            return false;
        }

        Customers.Remove(customer);
        NotifyStateChanged();
        return true;
    }
}