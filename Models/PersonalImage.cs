using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaelytDocumentInfo.Models
{
    public class PersonalImage
    {
        public int ImageId { get; set; }
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public PersonalData PersonalData { get; set; }
    }
}
