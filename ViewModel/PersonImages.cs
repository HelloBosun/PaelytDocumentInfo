using Microsoft.AspNetCore.Http;
using PaelytDocumentInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paelyt_Data_System.ViewModel
{
    public class PersonImages
    {
        public List<IFormFile> Images { get; set; }
        //The PersonalData property is mapping with Personal Data class
        public PersonalData PersonalData { get; set; }
    }
}
