using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Models.ViewModels
{
    public class PlayerModel
    {
        public string Player { get; set; }
        public IFormFile Image { get; set; }
    }
}
