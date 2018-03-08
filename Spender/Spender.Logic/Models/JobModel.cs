using System;

namespace Spender.Logic.Models
{
    public class JobModel
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public CategoryModel Category { get; set; }
    }
}