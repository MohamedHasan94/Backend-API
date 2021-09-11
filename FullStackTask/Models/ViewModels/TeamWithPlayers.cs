using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Models.ViewModels
{
    public class TeamWithPlayers
    {
        public string Team { get; set; }

        public string Players { get; set; }

        public IFormFile TeamImage { get; set; }
        public List<IFormFile> PlayersImages { get; set; }
    }
}