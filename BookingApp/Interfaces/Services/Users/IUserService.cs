﻿using System.Collections.Generic;
using BookingApp.Entities.Users;


namespace BookingApp.Interfaces.Services.Users
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}