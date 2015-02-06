namespace connectSql1
{
    class sql_select
    {
        public sql_select()
        {
			// init
        }
        public string Sql_ContainerDetail()
        {
            string sqlextract = @"
		select
		p.Company as Company, -- char 8 
		p.ContainerID as ContainerID,  --- int 
		p.ContainerShipQty as ContainerShipQty, -- decimal
		p.PONum as PONum, -- int
		p.POLine as POLine, -- int
		p.PORelNum as PORelNum, -- int
		p.PackSlip as PackSlip, -- x20
		p.Volume as Volume, -- decimal
		p.VendorNum as VendorNum, -- int
		p.OurUnitCost as OurUnitCost,  -- decimal
		p.LCAmt as LCAmt
	    FROM  erp.ContainerDetail as p
	";
            return sqlextract;
        }
        public string Sql_ContainerHeader()
        {
            string sqlextract = @"
			      select
		p.Company as Company, -- char 8 
		p.ContainerID as ContainerID,  --- int 
			p.ShipDate as ShipDate, --  int after conversion
	      p.Shipped as Shipped,  -- int
		p.ContainerClass as ContainerClass, -- x 10
		p.ContainerCost as ContainerCost, -- decimal
		p.ShippingDays as ShippingDays, -- integer
		p.ContainerDescription as ContainerDescription, -- x 50
		p.Volume as Volume, -- decimal 2
		p.ContainerReference as ContainerReference -- x 50
		FROM  erp.ContainerHeader as p
	";
            return sqlextract;
        }
        public string Sql_CustBillTo()
        {
            string sqlextract = @"
      select
      cb.Company as Company, -- char 8 
      cb.CustNum  as CustNum,  -- int
      cb.BTCustNum  as BTCustNum,  -- int
      cb.DefaultBillTo as DefaultBillTo , -- smallint
      cb.InvoiceAddress as InvoiceAddress, -- smallint
      cb.ChangedBy as ChangedBy, -- char 20
      cb.ShortChar01 as BuyGroupCustID
     FROM  erp.CustBillTo as cb

            ";
            return sqlextract;
        }
        public string Sql_CustGrup()
        {
            string sqlextract = @"
     select
      cg.Company as Company, -- char 8 
      cg.GroupCode  as GroupCode,  -- char 4
      cg.GroupDesc as GroupDesc, -- char 20
      cg.SalesCatID as SalesCatID, -- char 4
      cg.Character01 as Character01, -- char 1000 super group
      cg.CheckBox01 as CheckBox01, -- int?  supress line in reporting
      cg.Number01 as Number01,   -- int sort order
      0 as filler
     FROM  erp.CustGrup as cg

            ";
            return sqlextract;
        }
        public string Sql_CustXPrt()
        {
            string sqlextract = @"
      select
      xp.Company as Company, -- char 8 
      xp.BasePartNum as BasePartNum, --  x50
      xp.ChangeDate as ChangeDate,      -- int 
      xp.ChangedBy as ChangedBy, --     varchar(20)
      xp.CustNum  as CustNum,  -- int
      xp.PartDescription  as PartDescription, -- varchar(100)
      xp.PartNum as PartNum, -- varchar(50)
      xp.XPartNum as XPartNum, -- varchar(50)
      xp.XRevisionNum   as XRevisionNum -- varchar(12)
     FROM  pub.CustXPrt as xp

            ";
            return sqlextract;
        }
        public string Sql_Customer()
        {
            string sqlextract = @"
      select
      cm.CustID as CustID,
      cm.CustNum as CustNum,
      cm.Name    as Name,
      cm.Address1  as Address1,
      cm.Address2  as Address2,
      cm.Address3  as Address3,
      cm.City    as City,
      cm.State   as State,
      cm.Zip     as Zip,
      cm.Country as Country,
      cm.TerritoryID as TerritoryID,
      cm.SalesRepCode as SalesRepCode,
      cm.TermsCode as TermsCode,
      cm.ShipViaCode as ShipViaCode,
      cm.GroupCode as GroupCode,
      cg.SalesCatID as channel,
      cm.ResaleID as ResaleID,
      cm.PrintStatements as PrintStatements,
      cm.TaxExempt as TaxExempt,
      cm.CreditHold as CreditHold,
      cm.TaxRegionCode as TaxRegionCode,
 
      cm.CreditLimit as CreditLimit,         -- decimal

      cm.CreditHoldDate as CreditHoldDate,      -- int
      cm.CreditHoldSource as CreditHoldSource,  -- x10
      cm.CreditIncludeOrders as CreditIncludeOrders,  -- smallint

      cm.GlobalCust as GlobalCust,    -- smallint
      cm.GlobalCreditHold  as GlobalCreditHold, -- x12
      cm.GlobalCredIncOrd as GlobalCredIncOrd,      -- smallint
      cm.PhoneNum as PhoneNum,
      cm.CheckBox01 as optiPortMemeber,
      cm.CheckBox02 as visionSourceMemeber,
      cm.CheckBox03 as inactiveFlag,

      cm.CheckBox04 as printSetup,
      cm.CheckBox05 as NoInvoiceMailing,
      cm.CheckBox06 as InvoiceInABox,
      
      cm.ChangedBy as changedBy,
      cm.ChangeDate as changeDate,
      cm.EstDate  as EstDate,
      cm.CreditClearUserID as CreditClearUserID,
     cm.BTName        as  BTName,     
      cm.BTAddress1    as  BTAddress1,  
      cm.BTAddress2    as  BTAddress2,  
      cm.BTAddress3    as  BTAddress3,  
      cm.BTCity        as  BTCity,              
      cm.BTCountry     as  BTCountry,  
      cm.BTCountryNum  as  BTCountryNum,
      cm.BTFaxNum      as  BTFaxNum,    
      cm.BTFormatStr   as  BTFormatStr,
      cm.BTPhoneNum    as  BTPhoneNum,  
      cm.BTState       as  BTState,    
      cm.BTZip         as  BTZip,
      cm.ShortChar01   as  FreightTerms,
      cm.Comment       as Comment
     FROM  erp.Customer as cm
        left join erp.CustGrup as cg
        on cg.Company = cm.Company and
           cg.GroupCode = cm.GroupCode
            ";
            return sqlextract;
        }
        public string Sql_CustomerPriceLst()
        {
            string sqlextract = @"
     select
      cpl.Company as Company, -- char 8 
      cpl.CustNum  as CustNum,  -- int
      cpl.ListCode  as ListCode,  -- Varchar(10),
      cpl.SeqNum as SeqNum , -- int
      cpl.ShipToNum as ShipToNum -- varchar(14)
     FROM  pub.CustomerPriceLst as cpl

            ";
            return sqlextract;
        }
        public string Sql_PartTran()
        {
            string sqlextract = @"
      select
   pt.Company as Company,
--   pt.SysDate as SysDatex,
--   pt.SysTime as SysTimex,
pt.TranNum as TranNum,
pt.PartNum as PartNum,
pt.WareHouseCode as WareHouseCode,
pt.BinNum as BinNum,
pt.TranClass as TranClass,
pt.TranType as TranType,
pt.InventoryTrans as InventoryTrans,
pt.TranDate as TranDate,
pt.TranQty as TranQty,
pt.UM as UM,
pt.MtlUnitCost as MtlUnitCost,
pt.LbrUnitCost as LbrUnitCost,
pt.BurUnitCost as BurUnitCost,
pt.SubUnitCost as SubUnitCost,
pt.MtlBurUnitCost as MtlBurUnitCost,
pt.ExtCost as ExtCost,
pt.CostMethod as CostMethod,
pt.JobNum as JobNum,
pt.AssemblySeq as AssemblySeq,
pt.JobSeqType as JobSeqType,
pt.JobSeq as JobSeq,
pt.PackType as PackType,
pt.PackNum as PackNum,
pt.PackLine as PackLine,
pt.PONum as PONum,
pt.POLine as POLine,
pt.PORelNum as PORelNum,
pt.WareHouse2 as WareHouse2,
pt.BinNum2 as BinNum2,
pt.OrderNum as OrderNum,
pt.OrderLine as OrderLine,
pt.OrderRelNum as OrderRelNum,
pt.EntryPerson as EntryPerson,
pt.TranReference as TranReference,
pt.PartDescription as PartDescription,
pt.RevisionNum as RevisionNum,
pt.VendorNum as VendorNum,
pt.PurPoint as PurPoint,
pt.POReceiptQty as POReceiptQty,
pt.POUnitCost as POUnitCost,
pt.PackSlip as PackSlip,
pt.InvoiceNum as InvoiceNum,
pt.InvoiceLine as InvoiceLine,
pt.GLDiv as GLDiv,
pt.GLDept as GLDept,
pt.GLChart as GLChart,
pt.InvAdjSrc as InvAdjSrc,
pt.InvAdjReason as InvAdjReason,
pt.LotNum as LotNum,
pt.DimCode as DimCode,
pt.DUM as DUM,
pt.DimConvFactor as DimConvFactor,
pt.LotNum2 as LotNum2,
pt.DimCode2 as DimCode2,
pt.DUM2 as DUM2,
pt.DimConvFactor2 as DimConvFactor2,
pt.PostedToGL as PostedToGL,
pt.FiscalYear as FiscalYear,
pt.FiscalPeriod as FiscalPeriod,
pt.JournalNum as JournalNum,
pt.Costed as Costed,
pt.DMRNum as DMRNum,
pt.ActionNum as ActionNum,
pt.RMANum as RMANum,
pt.COSPostingReqd as COSPostingReqd,
pt.JournalCode as JournalCode,
pt.Plant as Plant,
pt.Plant2 as Plant2,
pt.CallNum as CallNum,
pt.CallLine as CallLine,
pt.MatNum as MatNum,
pt.JobNum2 as JobNum2,
pt.AssemblySeq2 as AssemblySeq2,
pt.JobSeq2 as JobSeq2,
pt.CustNum as CustNum,
pt.RMALine as RMALine,
pt.RMAReceipt as RMAReceipt,
pt.RMADisp as RMADisp,
pt.OtherDivValue as OtherDivValue,
pt.PlantTranNum as PlantTranNum,
pt.NonConfID as NonConfID,
pt.RefType as RefType,
pt.RefCode as RefCode,
pt.LegalNumber as LegalNumber,
pt.BeginQty as BeginQty,
pt.AfterQty as AfterQty,
pt.PlantCostValue as PlantCostValue,
pt.EmpID as EmpID,
pt.ReconcileNum as ReconcileNum
     FROM  pub.PartTran as pt
            ";
            return sqlextract;
        }
        public string Sql_OrderDtl()
        {
            string sqlextract = @"
     select
      od.Company as Company, -- char 8 
      od.OrderLine as OrderLine,  -- int
      od.OrderNum as OrderNum,    -- int
      od.OpenLine as OpenLine,    -- smallint 
      od.OrderQty as OrderQty,    -- decimal 12,2
      od.OverridePriceList as OverridePriceList, -- smallint
      od.PartNum as PartNum,               -- char 50
      od.PriceGroupCode as PriceGroupCode, -- char 10
      od.PriceListCode as PriceListCode,   -- char 10
      od.PricingQty as PricingQty,   -- decimal 12,2
      od.ProdCode as ProdCode,       -- char 8
      od.NeedByDate as NeedByDate, -- int after conversion
      od.RequestDate as RequestDate, -- int after conversion
      od.SalesCatID as SalesCatID,   -- char 4
      '' as ShortChar01,
      '' as ShortChar02,
      '' as ShortChar03,

      od.UnitPrice as UnitPrice,     -- decimal 12,4
      od.VoidLine as VoidLine,       -- int
      od.SellingFactor as SellingFactor,
      od.XPartNum as XPartNum,
      od.Discount as Discount,
      od.DiscountPercent as DiscountPercent,
      10 as EDIPOlineNum,
      0 as filler
     FROM  erp.OrderDtl as od
            ";
            return sqlextract;
        }
        public string Sql_OrderHed()
        {
            string sqlextract = @"
      select
      oh.Company as Company,               -- char 8 
      oh.OrderNum as OrderNum,             -- int
      oh.CustNum as CustNum,               -- int
      oh.OpenOrder as OpenOrder,           -- int
      oh.OrderDate as OrderDate,           -- int after conversion
      oh.PONum as PONum,                   -- char 50
      oh.NeedByDate as NeedByDate,         -- int
      oh.RequestDate as RequestDate,       -- int
      oh.ShipToNum as ShipToNum,           -- int
      oh.ShipViaCode as ShipViaCode,       -- char 4
      '' as ShortChar01,
      '' as ShortChar02,
      '' as ShortChar03,
      oh.TermsCode as TermsCode,           -- char 4
      oh.TotalCharges as TotalCharges,     -- decimal 12,2
      oh.TotalComm as TotalComm,           --  decimal 12,2
      oh.TotalInvoiced as TotalInvoiced,   --  decimal 12,2
      oh.TotalLines as TotalLines,         -- int
      oh.TotalMisc as TotalMisc,           -- decimal 12,2
      oh.TotalReleases as TotalReleases,   -- int
      oh.TotalTax as TotalTax,             -- decimal 12,2
      oh.VoidOrder as VoidOrder,            -- int      
      0 as inPrintSetup,        -- int
      0 as offShore,        -- int
      0 as freightFree        -- int
     FROM  erp.OrderHed as oh

            ";
            return sqlextract;
        }
        public string Sql_OrderRel()
        {
            string sqlextract = @"
     select
      r.Company as Company, -- char 8 
      r.OrderNum  as OrderNum,  -- integer
      r.OrderLine as OrderLine, -- integer
      r.OrderRelNum as OrderRelNum, 
      r.OpenRelease as OpenRelease,
      r.FirmRelease as FirmRelease,
      r.VoidRelease as VoidRelease,
      r.RevisionNum as RevisionNum,
      r.NeedByDate as NeedByDate,
      r.MarkForNum as MarkForNum,
      r.WarehouseCode as WarehouseCode,
      r.OurJobShippedQty as OurJobShippedQty,
      r.SellingStockQty as SellingStockQty,
      r.SellingJobQty as SellingJobQty,
      r.SellingStockShippedQty as SellingStockShippedQty,
      0 as filler
     FROM  erp.OrderRel as r

            ";
            return sqlextract;
        }
        public string Sql_Part()
        {
            string sqlextract = @"

            ";
            return sqlextract;
        }
        public string Sql_PartBin()
        {
            string sqlextract = @"

            ";
            return sqlextract;
        }
        
        /*
         * removed
         *  id.SalesChart as SalesChart,
         *  id.SalesDept as SalesDept,
         *  id.SalesDiv as SalesDiv,

         * DataTable table = reader.GetSchemaTable();  
         * foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine(row[column]);
                    }
                }
         * */
        
        public string Sql_InvcDtl()
        {
            string sqlextract = @"
     select
      ih.fiscalYear as FiscalYear,
      ih.fiscalPeriod as FiscalPeriod,
      ih.InvoiceNum as InvoiceNum,
      id.InvoiceLine as InvoiceLine,
      ih.InvoiceDate as InvoiceDate,
      id.PackNum as PackNum,
      id.PackLine as PackLine,
      ih.OrderNum as OrderNum,
      id.OrderLine as OrderLine,
      id.ShipDate as ShipDate,
      id.SellingShipQty as SellingShipQty,
      id.UnitPrice as UnitPrice,
      id.SellingShipQty * id.UnitPrice as TotalDollars,
      id.ExtPrice as ExtPrice,
      cmSt.CustID  as SoldToCustID,
      id.ShipToNum as ShipToNum,
      cmBt.CustID as billToCustID,
      id.PartNum as PartNum,
      pt.PartDescription as PartDescription,
      ih.SalesRepList as SalesRepList,
      ih.CustNum as BillToCustNum,  -- bill to custNum buygroup
      ih.SoldToCustNum as SoldToCustNum,
     
      id.MtlUnitCost as MtlUnitCost,
      id.LbrUnitCost as LbrUnitCost,
      id.BurUnitCost as BurUnitCost,
      id.SubUnitCost as SubUnitCost,
      id.MtlBurUnitCost as MtlBurUnitCost,
      id.Discount  as Discount,
      id.DiscountPercent as DiscountPercent,
      id.SellingFactor as SellingFactor,
      id.SellingFactorDirection as SellingFactorDirection,
        0 as filler,
        2 as xfill
      from erp.InvcHead as ih
       left join erp.InvcDtl as id
         on id.Company = ih.Company and
            id.InvoiceNum = ih.InvoiceNum
       left join erp.Customer as cmBt
         on ih.Company = cmBt.Company and
            cmBt.CustNum = ih.CustNum
       left join erp.Customer as cmSt
         on ih.Company = cmSt.Company and
            ih.SoldToCustNum = cmSt.CustNum
        left join erp.Part as pt
         on pt.Company = id.Company and
            pt.PartNum = id.PartNum";

            return sqlextract;
        }
    }
}