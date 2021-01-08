using System.Collections.Generic;

namespace ProjectName.Models
{
  public class Parent
    {
        public Parent()
        {
            this.Childs = new HashSet<ParentChild>();
        }

        public int ParentId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ParentChild> Childs { get; set; }
    }
}