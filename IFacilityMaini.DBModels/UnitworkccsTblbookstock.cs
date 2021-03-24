﻿using System;
using System.Collections.Generic;

namespace IFacilityMaini.DBModels
{
    public partial class UnitworkccsTblbookstock
    {
        public long BookStockId { get; set; }
        public string BookStockName { get; set; }
        public string BookStockDesc { get; set; }
        public string ToolSapCode { get; set; }
        public string PlantCode { get; set; }
        public long? PlantId { get; set; }
        public string SapLoaction { get; set; }
        public long? Quantity { get; set; }
        public string SapBatch { get; set; }
        public byte? IsDeleted { get; set; }
        public byte? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
