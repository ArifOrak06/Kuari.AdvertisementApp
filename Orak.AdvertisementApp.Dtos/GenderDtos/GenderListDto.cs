using Orak.AdvertisementApp.Dtos.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orak.AdvertisementApp.Dtos
{
    public class GenderListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
