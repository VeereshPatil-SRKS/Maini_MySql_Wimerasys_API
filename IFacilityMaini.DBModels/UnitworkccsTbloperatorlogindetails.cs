﻿using System;
using System.Collections.Generic;

namespace IFacilityMaini.DBModels
{
    public partial class UnitworkccsTbloperatorlogindetails
    {
        public UnitworkccsTbloperatorlogindetails()
        {
            UnitworkccsTbloperatormachinedetails = new HashSet<UnitworkccsTbloperatormachinedetails>();
        }

        public int OperatorLoginId { get; set; }
        public string OperatorUserName { get; set; }
        public string OperatorPwd { get; set; }
        public int? NumOfMachines { get; set; }
        public string OperatorMobileNo { get; set; }
        public string OperatorEmailId { get; set; }
        public int? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int? RoleId { get; set; }
        public int? OperatorId { get; set; }
        public string OperatorName { get; set; }
        public string Reasons { get; set; }

        public virtual UnitworkccsTblroles Role { get; set; }
        public virtual ICollection<UnitworkccsTbloperatormachinedetails> UnitworkccsTbloperatormachinedetails { get; set; }
    }
}
