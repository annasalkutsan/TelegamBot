namespace Domain.Entities
{
    public class CustomField <TType> :BaseEntity
    {
        //для EF
        public CustomField()
        {
            
        }
        
        public string Name { get; set; }

        public TType Value { get; set; }
    }
}