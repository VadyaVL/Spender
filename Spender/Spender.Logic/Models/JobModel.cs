using System;

namespace Spender.Logic.Models
{
    public class JobModel
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public TimeSpan Duration => this.End == null ? DateTime.UtcNow.Subtract(this.Start) : this.End.Subtract(this.Start);
    }
}