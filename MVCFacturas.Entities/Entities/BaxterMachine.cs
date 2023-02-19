using MVCFacturas.ExternalConnections.DbContexts;
using System;
using System.Collections.Generic;

#nullable disable

namespace MVCFacturas.Entities
{
    public partial class BaxterMachine:EntityBase
    {
        public DateTime? DateUpdated { get; set; }
        public string GenericCode { get; set; }
        public string GenericCode2 { get; set; }
        public string SpecificCode { get; set; }
        public string SpecificCode3 { get; set; }
        public string LotSerialNumber { get; set; }
        public string BusinessUnit { get; set; }
        public string OrderCo { get; set; }
        public string DocCo { get; set; }
        public string OrTy { get; set; }
        public string OrderType { get; set; }
        public string DoTy { get; set; }
        public double? DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public DateTime? ShipReceiveDate { get; set; }
        public string DivSubDiv { get; set; }
        public string BusinessPurpose { get; set; }
        public string OwnershipFlag { get; set; }
        public string Ctry { get; set; }
        public double? ShipToNumber { get; set; }
        public string ShipTo { get; set; }
        public double? AddressNumber { get; set; }
        public string AddressNumber4 { get; set; }
        public double? AssetNumber { get; set; }
        public string UnitNumber { get; set; }
    }
}
