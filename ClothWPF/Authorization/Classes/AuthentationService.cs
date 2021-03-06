﻿using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System;
using System.Windows;

namespace ClothWPF.Authorization
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private class InternalUserData
        {
            public InternalUserData(string username, string email, string hashedPassword, string[] roles)
            {
                Username = username;
                Email = email;
                HashedPassword = hashedPassword;
                Roles = roles;
            }
            public string Username { get; private set; }
            public string Email { get; private set; }
            public string HashedPassword { get; private set; }
            public string[] Roles { get; private set; }
        }

        private static readonly List<InternalUserData> _users = new List<InternalUserData>()
        {
            new InternalUserData("admin", "kovalchuknm1997@gmail.com",
                "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", new string[] { "Administrators" }),
            new InternalUserData("user", "john@company.com",
                "BPiZbadjt6lpsQKO4wB1aerzpjVIbdqyEdUSyFud+Ps=", new string[] { "User"})
        };

        public User AuthenticateUser(string username, string clearTextPassword)
        {
            InternalUserData userData = _users.FirstOrDefault(u =>( u.Username.Equals(username) || u.Email.Equals(username)) && u.HashedPassword.Equals(CalculateHash(clearTextPassword)));
            if (userData == null)
                throw new UnauthorizedAccessException("В доступі відмовлено. Вкажіть будь-ласка вірні дані.");

            return new User(userData.Username, userData.Email, userData.Roles);
        }

        private string CalculateHash(string clearTextPassword)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password

            return Convert.ToBase64String(hash);
        }
    }

    public class User
    {
        public User(string username, string email, string[] roles)
        {
            Username = username;
            Email = email;
            Roles = roles;
        }
        public string Username { get; set; }

        public string Email { get; set; }

        public string[] Roles { get; set; }
    }
}