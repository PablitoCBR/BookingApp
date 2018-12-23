using System;
using System.Text.RegularExpressions;
using BookingApp.Entities.Users;
using BookingApp.Interfaces.Users;

namespace BookingApp.Services.Users
{
    // Validate all data except id, Username and Password
    public class UserDataValidator : IUserDataValidator
    {
        public bool ValidateAddress(Address address)
        {
            if (String.IsNullOrEmpty(address.City))
                return false;
            if (String.IsNullOrEmpty(address.Street))
                return false;
            if (String.IsNullOrEmpty(address.Number))
                return false;
            if (!ValidatePostalCode(address.PostalCode))
                return false;

            return true;                
        }
                
        public bool ValidatePostalCode(string postalCode)
        {
            string pattern = @"^[0-9]{2}-[0-9]{3}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(postalCode))
                return true;
            else return false;                
        }

        public bool ValidateUser(User user)
        {
            if (String.IsNullOrEmpty(user.BusinessName))
                return false;
            if (user.Address != null)
            {
                if (!ValidateAddress(user.Address))
                    return false;
            }
            else return false;

            return true;
        }
    }
}
