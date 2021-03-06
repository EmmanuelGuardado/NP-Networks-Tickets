﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public partial class AspNetUserRoles
    {
        
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRoles Role { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
