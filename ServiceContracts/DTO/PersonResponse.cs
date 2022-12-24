﻿using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents DTO class that is used as return type of most methods
    /// of Persons Service
    /// </summary>
    public class PersonResponse
    {
        public Guid PersonID { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public double? Age { get; set; }
        public bool ReceiveNewsLetters { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(PersonResponse)) return false;

            PersonResponse person = (PersonResponse)obj;
            return PersonID == person.PersonID 
                && PersonName == person.PersonName 
                && Email == person.Email 
                && DateOfBirth == person.DateOfBirth 
                && Gender == person.Gender 
                && CountryID == person.CountryID 
                && Address == person.Address 
                && ReceiveNewsLetters == person.ReceiveNewsLetters;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Person ID: {PersonID}, Person Name: {PersonName}," +
                $"Email : {Email}, Date of Birth: {DateOfBirth?.ToString("dd mm yy")}," +
                $"Gender : {Gender}, Country Id : {CountryID}, Country: {Country}, Address: {Address}," +
                $"Receive News Letters: {ReceiveNewsLetters}";
        }
    }


    public static class PersonExtensions
    {
        public static PersonResponse ToPersonResponse(this Person person)
        {
            //person => personResopse
            return new PersonResponse()
            {
                PersonID = person.PersonID,
                PersonName = person.PersonName,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
                ReceiveNewsLetters = person.ReceiveNewsLetters,
                Address = person.Address,
                CountryID = person.CountryID,
                Gender = person.Gender,
                Age = (person.DateOfBirth != null) ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) : null
            };
        }
    }
}

