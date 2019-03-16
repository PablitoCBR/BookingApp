using BookingApp.Entities.Accounts;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System;
using BookingApp.Exceptions;

namespace BookingApp.Services.Accounts
{
    public class AddressValidator
    {
        public async Task<bool> Validate(Address address)
        {
            if (address == null)
                return false;

            Task<bool> postalStatus = CheckPostalCodeAsync(address.PostalCode);

            if (String.IsNullOrEmpty(address.City))
                return false;
            if (String.IsNullOrEmpty(address.Street))
                return false;
            if (String.IsNullOrEmpty(address.Number))
                return false;
            if (!await postalStatus)
                return false;
            return true;
        }
        private async Task<bool> CheckPostalCodeAsync(string postalCode)
        {
            const string pattern = @"^[0-9]{2}-[0-9]{3}$";
            return await Task.Run(() => 
            {
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(postalCode))
                    return true;
                return false;
            });
        }
    }
}
