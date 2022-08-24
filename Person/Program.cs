// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using EntityFramework.Exceptions.Common;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Person.Models;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("First Name: ");
                string fName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());

                Console.WriteLine("Last Name: ");
                string lName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());

                Console.WriteLine("Phone Number: ");
                string pNum = Console.ReadLine();

                Console.WriteLine("Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("State Of Origin: ");
                string stateOfOrigin = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());

                Console.WriteLine("Male or Female: ");
                string gender = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());

                EFCoreInsert(fName, lName, pNum, age, stateOfOrigin, gender);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        static void EFCoreInsert(string fName, string lName, string pNum, int age, string stateOfOrigin, string gender)
        {
            try
            {
                //insert
                var db = new PersonDbContext();
                var person = new PostPerson();
                person.FirstName = fName;
                person.LastName = lName;
                person.phoneNumber = pNum;
                person.Age = age;
                person.stateOfOrigin = stateOfOrigin;
                person.Gender = gender;
                db.Person.Add(person);
                var noOfInserts = db.SaveChanges();//with this, what we have goes to the database
                Console.WriteLine($"{noOfInserts} row Inserted Successful");


            }
            catch (UniqueConstraintException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
    }
}