﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserRole:IEntity
    {
        public int UserRoleId {  get; set; }    
        public int UserId {  get; set; }
        public int RoleId { get; set; }

        
    }
}
