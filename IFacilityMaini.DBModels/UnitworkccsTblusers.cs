﻿using System;
using System.Collections.Generic;

namespace IFacilityMaini.DBModels
{
    public partial class UnitworkccsTblusers
    {
        public UnitworkccsTblusers()
        {
            UnitworkccsTblrolemodulelink = new HashSet<UnitworkccsTblrolemodulelink>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PrimaryRole { get; set; }
        public int? SecondaryRole { get; set; }
        public string DisplayName { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public int? MachineId { get; set; }
        public int? PlantId { get; set; }

        public virtual UnitworkccsTblroles PrimaryRoleNavigation { get; set; }
        public virtual UnitworkccsTblroles SecondaryRoleNavigation { get; set; }
        public virtual ICollection<UnitworkccsTblrolemodulelink> UnitworkccsTblrolemodulelink { get; set; }
    }
}
