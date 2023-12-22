namespace Api.Models
{
    public class ContactModel
    {
        public ContactModel()
        {
            this.Phones = new List<string>();
        }

        public int Id { get; set; }
        
        public string? Name { get; set; }
        
        public string? Code { get; set; }
        
        public List<string> Phones { get; set; }
        
        public ContactType Type { get; set; }
    }
}
