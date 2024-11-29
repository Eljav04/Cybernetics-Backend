using System;
using Lesson_51_HT.Model;

namespace Lesson_51_HT.Controller
{
	public class CustomerController
	{
		public List<Customer> CustomersData { get; set; }
		public CustomerController()
		{
			CustomersData = new();
		}

		public void AddCustomer(Customer new_customer)
		{
            CustomersData.Add(new_customer);
		}

        public void AddCustomer(params Customer[] customers)
        {
            foreach (Customer customer in customers)
            {
                CustomersData.Add(customer);
            }
        }

        public Customer? GetCustomerByID(int CustomerID)
        {
            foreach (Customer Customer in CustomersData)
            {
                if (CustomerID.Equals(Customer.ID))
                {
                    return Customer;
                }
            }
            return null;
        }
    }
}

