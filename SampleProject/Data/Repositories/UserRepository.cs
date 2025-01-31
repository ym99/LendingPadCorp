﻿using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;

namespace Data.Repositories
{
    [AutoRegister]
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IDocumentSession _documentSession;

        public UserRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        public IEnumerable<User> Get(UserTypes? userType = null, string name = null, string email = null, string tag = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<User, UsersListIndex>();

            var hasFirstParameter = false;
            if (userType != null)
            {
                query = query.WhereEquals("Type", (int)userType);
                hasFirstParameter = true;
            }

            if (name != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.Where($"Name:*{name}*");
            }

            if (email != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereEquals("Email", email);
            }

            var users = query.ToList();

            if (tag == null)
            {
                return users;
            }

            // I cannot use RavenDB to filter by tag due to the database configuration
            // Assuming that I should not change the database configuration for this task
            // I decided to filter in the memory collection

            return users
                .Where(user => user.Tags.Contains(tag))
                .ToList();
        }

        public void DeleteAll()
        {
            base.DeleteAll<UsersListIndex>();
        }
    }
}