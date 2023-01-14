using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orak.AdvertisementApp.Entites
{
    public class AppUserRole : BaseEntity
    {
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
