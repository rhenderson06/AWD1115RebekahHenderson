using System.ComponentModel;

namespace Faqs6.Models
{
    public class FAQ
    {
        public int Id { get; set; }

        public string Question { get; set; } = string.Empty;

        public string Answer { get; set; } = string.Empty;


        public string TopicId { get; set; } //foreign key
        public Topic Topic { get; set; }    //navigation property
        
        public string CategoryId { get; set; } //foreign key
        public Category Category { get; set; } //navigation property

    }
}
