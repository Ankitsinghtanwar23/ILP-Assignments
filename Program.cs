using Assignment3;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using static OrderProcessor;

namespace Assignment3
{
    public class program
    {
        public static void Main(string[]args)
        {
            Customer cust = new PlatinumCustomerRegister
            {
                FirstName = "ankit",
                LastName = "singh",
                Email = "ankitsingh@.com",
            };
            cust.Register();

            ICustomerDiscount discountCust = new PlatinumCustomerDiscount();



            IProcessOrder newOrder = new OrderProcessor(discountCust);
            newOrder.ProcessOrder();

            IDataStorage storedCust = new DatabaseStore(cust);
            storedCust.SaveCustomer();

            Lead lead = new Leads
            {
                Name = "Rahul",
                ContactEmail = "rahul@gmail.com"
            };
            Lead.GeneralEnquiry();
        }
    }

    internal class PlatinumCustomerDiscount : ICustomerDiscount
    {
        public int GetDiscountPercentage()
        {
            ImplementedException();
        }

        private void ImplementedException()
        {
            ImplementedException();
        }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }



        public virtual void Register()
        {
            Console.WriteLine("Customer registered!!");
        }
    }
    public class BronzeCustomerRegister : Customer
    {
        public override void Register()
        {
            Console.WriteLine($"{FirstName} is registred as a Bronze customer.");
        }
    }
    public class SilverCustomerRegister : Customer
    {
        public override void Register()
        {
            Console.WriteLine($"{FirstName}is registred as a Silver customer.");
        }
    }
    public class GoldCustomerRegister : Customer
    {
        public override void Register()
        {
            Console.WriteLine($"{FirstName} is registred as aGold customer.");
        }
    }
    public class PlatinumCustomerRegister : Customer
    {
        public override void Register()
        {
            Console.WriteLine($"{FirstName}is registred as aPlatinum customer.");
        }
    }
    public interface ICustomerDiscount
    {
        int GetDiscountPercentage();
    }
    public class BronzeCustomerDiscount : ICustomerDiscount
    {
        public int GetDiscountPercentage()
        {
            return 20;
        }
    }
    public class GoldCustomerDiscount : ICustomerDiscount
    {
        public int GetDiscountPercentage()
        {
            return 25;
        }
    }
    public class platinumCustomerDiscount : ICustomerDiscount
    {
        public int GetDiscountPercentage()
        {
            return 30;
        }
    }
    public interface IDataStorage
    {
        bool SaveCustomer();
    }
    public class DatabaseStore : IDataStorage
    {
        private Customer _customer;
        public DatabaseStore(Customer customer)
        {
            _customer = customer;
        }
        public bool SaveCustomer()
        {
            Console.WriteLine($"{_customer.FirstName} saved to database.");
            return true;
        }
    }
    public interface IProcessOrder
    {
        void Processorder();
        void ProcessOrder();
    }
}
public class OrderProcessor : IProcessOrder
{
    private ICustomerDiscount _customerDiscount;
    public OrderProcessor(ICustomerDiscount customerDiscount)
    {
        _customerDiscount = customerDiscount;
    }
    public void ProcessOrder()
    {
        var discount = _customerDiscount.GetDiscountPercentage();
        Console.WriteLine($"Order processed with {discount}% discount.");
        Console.WriteLine("Order Placed successfully");
    }

    public void Processorder()
    {
        throw new ImplementedException();
    }

    public class Leads
    {
        public String Name { get; set; }
        public string ContactEmail { get; set; }

        public void GeneralEnquiry()
        {
            Console.WriteLine($"Enqiuring with lead:{Name}");
        }
    }
}
    

