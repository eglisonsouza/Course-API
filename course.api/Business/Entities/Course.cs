using System;

namespace course.api.Business.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
    }
}