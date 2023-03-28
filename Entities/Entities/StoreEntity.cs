using Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class StoreEntity : IAggregateRoot
    {
        public int IdStore { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public bool Status { get; set; }
        public DateTime DateRegister { get; set; }
        public Byte[] Image { get; set; }
        public int PostalCode { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long PhoneNumber { get; set; }

        public void SetEntityUpdate(StoreEntity storeEntityMapping)
        {
            Name = !string.IsNullOrEmpty(storeEntityMapping.Name) ? storeEntityMapping.Name : Name;
            Cnpj = !string.IsNullOrEmpty(storeEntityMapping.Cnpj) ? storeEntityMapping.Cnpj : Cnpj;
            Status = storeEntityMapping.Status != default ? storeEntityMapping.Status : Status;
            DateRegister = storeEntityMapping.DateRegister != default ? storeEntityMapping.DateRegister : DateRegister;
            Image = storeEntityMapping.Image != null && storeEntityMapping.Image != default ? storeEntityMapping.Image : Image;
            PostalCode = storeEntityMapping.PostalCode != default ? storeEntityMapping.PostalCode : PostalCode;
            Address = storeEntityMapping.Address != default ? storeEntityMapping.Address : Address;
            Number = !string.IsNullOrEmpty(storeEntityMapping.Number) ? storeEntityMapping.Number : Number;
            Complement = !string.IsNullOrEmpty(storeEntityMapping.Complement) ? storeEntityMapping.Complement : Complement;
            City = !string.IsNullOrEmpty(storeEntityMapping.City) ? storeEntityMapping.City : City;
            State = !string.IsNullOrEmpty(storeEntityMapping.State) ? storeEntityMapping.State : State;
            PhoneNumber = storeEntityMapping.PhoneNumber != default ? storeEntityMapping.PhoneNumber : PhoneNumber;
        }
        public void SetStatusTrue()
        {
            Status = true;
        }
        public void SetStatusFalse()
        {
            Status = false;
        }
        public void SetNegationStatus()
        {
            Status = !Status;
        }
        public void SetNewDateRegister()
        {
            DateRegister = DateTime.Now;
        }

    }
}
