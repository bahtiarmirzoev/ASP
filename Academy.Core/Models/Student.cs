using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Models
{
    public class Student
    {
        public const  int MAX_LENGHT = 250;
        private Student(Guid id  , string username , string name , string surname , string email , string phone)
        {
            Id = id;
            Username = username;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;

        }
        public Guid Id { get; set; }
        public string Username {  get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public static(Student Student , string Error) Create(Guid id, string username, string name, string surname, string email, string phone)
        {
            var error = string.Empty;

           if(string.IsNullOrEmpty(username) || username.Length > MAX_LENGHT)
            {
                error = "Username can not be long than 250 symbols";
            }

           if(string.IsNullOrEmpty(name) ||  name.Length > MAX_LENGHT)
            {
                error = "Name can not be long than 250 symbols";
            }

            if (string.IsNullOrEmpty(surname) || surname.Length > MAX_LENGHT)
            {
                error = "Surname can not be long than 250 symbols";
            }

            if (string.IsNullOrEmpty(email) || email.Length > MAX_LENGHT)
            {
                error = "Email can not be long than 250 symbols";
            }

            if (string.IsNullOrEmpty(phone) || phone.Length > MAX_LENGHT)
            {
                error = "Phone can not be long than 250 symbols";
            }


            var student = new Student(id , username , name , surname , email , phone);

            return (student , error);
        }
    }
}
