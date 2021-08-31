using System;
using course.api.Business.Entities;
using course.api.Business.Repositories;
using course.api.Infra.Data;

namespace course.api.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CourseDbContext _context;

        public UserRepository(CourseDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }


    }
}