using System.Collections.Generic;

namespace ProjectName.Models
{
    public class Child
    {
        public Child()
        {
            this.Parents = new HashSet<ParentChild>();
        }

        public int ChildId { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser User { get; set; }

        public ICollection<ParentChild> Parents { get;}
    }
}