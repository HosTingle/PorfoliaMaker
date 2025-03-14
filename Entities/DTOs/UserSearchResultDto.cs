using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserSearchResultDto:IDto
    {
        public int UserInfoId { get; set; }
        public string NickName { get; set; }

        public int UserId { get; set; }
    }
}
