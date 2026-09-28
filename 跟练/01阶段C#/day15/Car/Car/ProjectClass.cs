using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Car
{
    internal class Car
    {
        public int Id { get; }
        public string Card { get; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public double Price { get; set; }
        public Car(int Id, string Card, string Type, bool Status, double Price)
        {
            this.Id = Id;
            this.Card = Card;
            this.Type = Type;
            this.Status = Status;
            this.Price = Price;

        }
    }

    internal class User
    {
        public int Id { get; }
        public string Name { get; set; }
        public string IdCard { get; }
        public string RegTime { get; }
        public string Gender { get; set; }
        public string PhoneNo { get; set; }
        public string Motto { get; set; }
        public User(int Id, string Name, string IdCard, string RegTime, string Gender, string PhoneNo, string Motto)
        {
            this.Id = Id;
            this.Name = Name;
            this.IdCard = IdCard;
            this.RegTime = RegTime;
            this.Gender = Gender;
            this.PhoneNo = PhoneNo;
            this.Motto = Motto;

        }
    }

    internal class RentReturn
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public string RentTime { get; set; }
        public string ReturnTime { get; set; }
        public double PayMoney { get; set; }
        public RentReturn(int Id, int CarId, int UserId, string RentTime, string ReturnTime, double PayMoney)
        {
            this.Id = Id;
            this.CarId = CarId;
            this.UserId = UserId;
            this.RentTime = RentTime;
            this.ReturnTime = ReturnTime;
            this.PayMoney = PayMoney;
        }

    }
}
