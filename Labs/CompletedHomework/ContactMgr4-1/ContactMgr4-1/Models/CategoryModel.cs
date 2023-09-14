using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ContactMgr4_1.Models
{
    public class CategoryModel
    {
        //primary key
        public int CategoryId { get; set; }
        public string? Name { get; set; }

        
    }
}
