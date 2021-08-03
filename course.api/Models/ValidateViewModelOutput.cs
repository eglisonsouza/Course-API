using System;
using System.Collections.Generic;

namespace course.api.Models
{
    public class ValidateViewModelOutput
    {
        public IEnumerable<String> Errors { get; private set; }

        public ValidateViewModelOutput(IEnumerable<String> errors)
        {
            Errors = errors;
        }
    }
}