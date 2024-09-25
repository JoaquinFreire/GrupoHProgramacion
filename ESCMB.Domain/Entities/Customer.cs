using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Domain.Entities
{
        public class Customer : DomainEntity<Customer, CustomerValidator>
        {
            [Key]
            public string Id { get; private set; }
            [MaxLength(11)]
            public string CuilCuit { get; private set; }
            [MaxLength(8)]
            public string DocumentNumber { get; private set; }
            public string Email { get; private set; }
            public bool EmailConfirmed { get; private set; }
            [MaxLength(100)]
            public string FirstName { get; private set; }
            [MaxLength(100)]
            public string LastName { get; private set; }
            public CustomerStatus Status { get; private set; }

            public Customer()
            {
            }

            public Customer(string cuilCuit, string document, string email, string firstName, string lastName)
            {
                Id = Guid.NewGuid().ToString();
                CuilCuit = cuilCuit;
                DocumentNumber = document;
                Email = email;
                EmailConfirmed = false;
                FirstName = firstName;
                LastName = lastName;
                Status = CustomerStatus.PendingConfirmation;
            }

            public Customer(string id, string cuilCuit, string document, string email, string firstName, string lastName, CustomerStatus status)
            {
                Id = id;
                CuilCuit = cuilCuit;
                DocumentNumber = document;
                Email = email;
                EmailConfirmed = false;
                FirstName = firstName;
                LastName = lastName;
                Status = status;
            }

            public void SetNewData(string email, string firstName, string lastName)
            {
                Email = email;
                FirstName = firstName;
                LastName = lastName;
            }

            public void ConfirmEmail()
            {
                EmailConfirmed = true;
            }

            public void SetStatus(CustomerStatus status)
            {
                Status = status;
            }
        }
    }