using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public FullName FullName { get; set; }

        [RegularExpression("^[0 - 9]{8}$")]
        public string TelNumber { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
       // public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "FirstName= "+ FullName.FirstName + " LastName "+ FullName.LastName;
        }

        //public bool CheckProfile(string firstname, string lastname)
        //{
        //    return this.FirstName.Equals(firstname) 
        //        && this.LastName.Equals(lastname);
        //}

        //public bool CheckProfile(string firstname, string lastname, string email)
        //{
        //    return this.FirstName.Equals(firstname)
        //        && this.LastName.Equals(lastname)
        //        && this.EmailAddress.Equals(email);
        //}

        public bool CheckProfile(string firstname, string lastname, string? email=null)
        { if (email != null)
                return this.FullName.FirstName.Equals(firstname)
                    && this.FullName.LastName.Equals(lastname)
                    && this.EmailAddress.Equals(email);

            else 
                return this.FullName.FirstName.Equals(firstname)
                    && this.FullName.LastName.Equals(lastname);
        }


    }
}
