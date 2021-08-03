using System;

namespace course.api.Business.Entities
{
    public class User
    {
        public int Id { get; set; }
        public String Login { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
    }
}