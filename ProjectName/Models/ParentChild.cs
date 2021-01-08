namespace ProjectName.Models
{
  public class ParentChild
    {       
        public int ParentChildId { get; set; }
        public int ChildId { get; set; }
        public int ParentId { get; set; }
        public Child Child { get; set; }
        public Parent Parent { get; set; }
    }
}