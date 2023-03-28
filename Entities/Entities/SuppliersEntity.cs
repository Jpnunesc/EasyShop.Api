using Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class SuppliersEntity : IAggregateRoot
    {
        public int IdSuppliersEntity { get; set; }
        public string NumberDocument { get; set; }
        public int DocumentType { get; set; }
        public string FantasyName { get; set; }
        public string CorporateName { get; set; }
        public string ReferenceCode { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public string EmailBill { get; set; }
        public int PostalCode { get; set; }
        public int Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool Status  { get; set; }
        public int PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public string Others { get; set; }

        public void SetStatusTrue()
        {
            Status = true;
        }
        public void SetEntityUpdate(SuppliersEntity suppliersEntity)
        {
            NumberDocument = !string.IsNullOrEmpty(suppliersEntity.NumberDocument) ? suppliersEntity.NumberDocument : NumberDocument;
            DocumentType = suppliersEntity.DocumentType != 0 ? suppliersEntity.DocumentType : DocumentType;
            FantasyName = !string.IsNullOrEmpty(suppliersEntity.FantasyName) ? suppliersEntity.FantasyName : FantasyName;
            CorporateName = !string.IsNullOrEmpty(suppliersEntity.CorporateName) ? suppliersEntity.CorporateName : CorporateName;
            ReferenceCode = !string.IsNullOrEmpty(suppliersEntity.ReferenceCode) ? suppliersEntity.ReferenceCode : ReferenceCode;
            Contact = suppliersEntity.Contact != 0 ? suppliersEntity.Contact : Contact;
            Email = !string.IsNullOrEmpty(suppliersEntity.Email) ? suppliersEntity.Email : Email;
            EmailBill = !string.IsNullOrEmpty(suppliersEntity.EmailBill) ? suppliersEntity.EmailBill : EmailBill;
            PostalCode = suppliersEntity.PostalCode != 0 ? suppliersEntity.PostalCode : PostalCode;
            Address = suppliersEntity.Address != 0 ? suppliersEntity.Address : Address;
            Number = !string.IsNullOrEmpty(suppliersEntity.Number) ? suppliersEntity.Number : Number;
            Complement = !string.IsNullOrEmpty(suppliersEntity.Complement) ? suppliersEntity.Complement : Complement;
            Neighborhood = !string.IsNullOrEmpty(suppliersEntity.Neighborhood) ? suppliersEntity.Neighborhood : Neighborhood;
            City = !string.IsNullOrEmpty(suppliersEntity.City) ? suppliersEntity.City : City;
            State = !string.IsNullOrEmpty(suppliersEntity.State) ? suppliersEntity.State : State;
            Status = suppliersEntity.Status ? suppliersEntity.Status : Status;
            CellNumber = !string.IsNullOrEmpty(suppliersEntity.CellNumber) ? suppliersEntity.CellNumber : CellNumber;
            Others = !string.IsNullOrEmpty(suppliersEntity.Others) ? suppliersEntity.Others : Others;
        }
    }
}
