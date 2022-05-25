using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaelytDocumentInfo.Models
{
    public class PersonalData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TransactionNo { get; set; } = Guid.NewGuid().ToString("N").Replace("-", "");//GenerateNo();
        public ICollection<PersonalImage> PersonalImage { get; set; }
    
        
    }
}
