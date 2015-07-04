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
		p.ContainerReference as ContainerReference,
        p.ShipStatus as ShipStatus
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
      cud.SuperGroup_c as SuperGroup,
      cud.SortOrder_c as SortOrder,
      0 as filler
     FROM  erp.CustGrup as cg
     left join erp.CustGrup_UD as cud
     on cg.SysRowID = cud.ForeignSysRowID

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
      cm.CreditHold as CreditHold,
      cm.ResaleID as ResaleID,
      cm.PrintStatements as PrintStatements,
      cm.TaxExempt as TaxExempt,
        cm.TaxRegionCode as TaxRegionCode,
        cm.CreditLimit as CreditLimit,  
        cm.PhoneNum as PhoneNum,
       cmud.BuyGroupCustID_c as BuyGroupCustID,
       cmud.VisionSourceID_c as VisionSourceID

     FROM  erp.Customer as cm
	 left join erp.Customer_UD as cmud
	      on cm.SysRowID = cmud.ForeignSysRowID

        left join erp.CustGrup as cg
        on cg.Company = cm.Company and
           cg.GroupCode = cm.GroupCode
            ";
            return sqlextract;
        }
        public string Sql_CustomerFull()
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
      od.OpenLine as OpenLine,    -- bool
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
      od.UnitPrice as UnitPrice,     -- decimal 12,4
      od.VoidLine as VoidLine,       -- int
      od.SellingFactor as SellingFactor,
      od.XPartNum as XPartNum,
      od.Discount as Discount,
      od.DiscountPercent as DiscountPercent,
      odud.EDIPOLineNo_c as EDIPOlineNum,
    od.SellingQuantity as SellingQuantity,
      0 as filler
     FROM  erp.OrderDtl as od
     left join erp.OrderDtl_UD as odud
     on od.SysRowID = odud.ForeignSysRowID
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
      ohud.OrderType_c as OrderType,
      oh.TermsCode as TermsCode,           -- char 4
      oh.TotalCharges as TotalCharges,     -- decimal 12,2
      oh.TotalComm as TotalComm,           --  decimal 12,2
      oh.TotalInvoiced as TotalInvoiced,   --  decimal 12,2
      oh.TotalLines as TotalLines,         -- int
      oh.TotalMisc as TotalMisc,           -- decimal 12,2
      oh.TotalReleases as TotalReleases,   -- int
      oh.TotalTax as TotalTax,             -- decimal 12,2
      oh.VoidOrder as VoidOrder,            -- int 
      ohud.PrintSetup_c as inPrintSetup,
      ohud.OverseasOrder_c as offShore,        -- int
      ohud.FreeFreight_c as freightFree      -- int
      
     FROM  erp.OrderHed as oh
	 left join erp.OrderHed_UD as ohud
	      on oh.SysRowID = ohud.ForeignSysRowID

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
     select
      p.Company as Company, -- char 8 
      p.partNum  as partNum,  -- char 50
      p.PartDescription as PartDescription, -- char 50
      p.ProdCode as ProdCode,   -- char 8
      substring(p.PartDescription,1,19) as basePart, -- char 20
      substring(p.PartDescription,21,3) as printType,  -- 3
      p.UnitPrice as unitPrice, -- 12,4
      p.RunOut  as RunOut,   -- int
      p.SearchWord as SearchWord,  -- varchar 8
      p.TypeCode as TypeCode, -- char 1
      p.Inactive as Inactive,
      p.ClassID     as ClassID,
      p.SellingFactor as SellingFactor,
      pud.LOC_c as LOC,
      pud.AICDesc_c as AICDesc,
      pud.Brand_c as Brand,
      pud.CasePack_c as CasePack,
      pud.ColorAssortment_c as ColorAssortment,
      pud.DirectShip_c as DirectShip,
      pud.ListPrice__c as ListPrice,
      pud.Flyer_c as Flyer,
      pud.FlyerName_c as FlyerName,
      pud.TeamSpirit_c as TeamSpirit,
      pud.OrderingType_c as OrderingType,
      pud.PrintOptions_c as PrintOptions,
      pud.MaximumWOS_c as MaximumWOS,
      pud.MinimumWOS_c as MinimumWOS,
      pud.League_c as t_League,
      pud.Item_c as t_PartDescrption,
      pud.ARCoating_c as ARCoating,
      pud.CoordinatedCase_c as CoordinatedCase,
      pud.RxAdaptable_c as RxAdaptable,
      pud.SpringHinge_c as SpringHinge,
      pud.Program_c as Program,
      pud.ProgramLOC_c as ProgramLOC, 
      p.SalesUM as SalesUM,
      pud.RetailPrice_c as RetailPrice,
      1  as filler
     FROM  erp.Part as p
     LEFT JOIN erp.Part_UD as pud
     on p.SysRowID = pud.ForeignSysRowID
            ";
            return sqlextract;
        }
        public string Sql_PartFull()
        {
            string sqlextract = @"
     select
      p.Company as Company, -- char 8 
      p.partNum  as partNum,  -- char 50
      p.PartDescription as PartDescription, -- char 50
      p.ProdCode as ProdCode,   -- char 8
      substring(p.PartDescription,1,19) as basePart, -- char 20
      substring(p.PartDescription,21,3) as printType,  -- 3
      p.UnitPrice as unitPrice, -- 12,4
      p.ShortChar02 as loc,  -- varchar 50
      p.RunOut  as RunOut,   -- int
      p.SearchWord as SearchWord,  -- varchar 8
      p.TypeCode as TypeCode, -- char 1
      p.Number01 as CasePack, -- decimal 10,2
      p.ShortChar03 as flyer, -- x 50
      p.ShortChar04 as flyerNickname, -- x 50
      p.CheckBox01 as oneTimeBuy, -- smallint
      p.UserChar1 as aicDescr,     -- x30
      p.Inactive as Inactive,
      p.Number02 as minWOS,
      p.Number03 as maxWOS,
      p.Number04 as retailPrice,
      p.Number08 as listPrice,
      p.CheckBox02 as arCoating,        -- smallint
      p.CheckBox03 as rxAdaptable,      -- smallint
      p.CheckBox04 as springHinge,      -- smallint
      p.CheckBox05 as coordinatingCase, -- smallint
      p.Character01 as character01,
      p.Character02 as character02,
      p.Character03 as character03,
      p.Character04 as character04,
      p.Character05 as character05,
      p.Character06 as character06,
      p.Number05 as frameDim,
      p.Number06 as bridgeDim,
      p.Number07 as templeDim,
      p.Number09 as avgCost,
      p.Number10 as avgPOCost,
      p.Number11 as freightCost,
      p.Number12 as customsCost,
      p.Number13 as matlBurden, 
      p.Number14 as lastPOCost, 
      p.ShortChar05 as OrderingType,
      p.ShortChar06 as PrintOptions,
      p.ShortChar07 as gender,
      p.ShortChar08 as programLoc,

      p.ClassID     as ClassID,
      p.CheckBox08 as DirectShip,         -- smallint
      p.SellingFactor as SellingFactor,
      p.Character07 as character07,
      p.Character08 as character08,
      p.Character09 as character09,
      p.Character10 as character10,
      1  as filler
     FROM  erp.Part as p
            ";
            return sqlextract;
        }
        public string Sql_PartBin()
        {
            string sqlextract = @"
      select
      pb.Company as Company, -- char 8 
      pb.partNum  as partNum,  -- char 50
      pb.WarehouseCode as WarehouseCode, -- char 8
      pb.BinNum as BinNum, -- char 10
      pb.OnhandQty as OnhandQty, -- decimal 12,2
      pb.LotNum as LotNum  -- char 30
     FROM  erp.PartBin as pb
            ";
            return sqlextract;
        }
        public string Sql_WhseBin()
        {
            string sqlextract = @"
            ";
            return sqlextract;
        }
        public string Sql_InvcHeadEx()
        {
            string sqlextract = @"
                select
      ih.fiscalYear as wyear,
      ih.fiscalPeriod as wper,
      ih.SoldToCustNum as SoldToCustNum,
      ih.CustNum as BillToCustNum,
      ih.InvoiceNum as invNum,
      ih.OrderNum as orderNum,
      ih.InvoiceDate as InvoiceDate,
      ih.CreditMemo as CreditMemo,
      ih.DocInvoiceAmt as DocInvoiceAmt,
      ih.InvoiceAmt as InvoiceAmt,
      ih.EntryPerson as EntryPerson,
      ih.SalesRepList as SalesRepList,
      ih.StartUp as StartUp,
      ih.Posted as Posted,
      ih.InvoiceBal as InvoiceBal,
      ih.UnappliedCash as UnappliedCash,
      ih.DebitNote as DebitNote,
      ih.InvoiceSuffix as InvoiceSuffix,
      0 as CheckBox01,
      1 as filler
      from erp.InvcHead as ih
      where ih.InvoiceNum >= 1100000
        ";
return sqlextract;
        }
        public string Sql_InvcMisc()
        {
            string sqlextract = @"
       select
            im.Company as Company,  -- char 8
            im.InvoiceNum as InvoiceNum, -- int
            im.InvoiceLine as InvoiceLine, -- int
            im.MiscCode as MiscCode,  -- char 4
            im.Description as Description,  -- char 30
            im.DocMiscAmt as DocMiscAmt,   -- 12,2 decimal
            im.MiscAmt as MiscAmt          -- 12,2 decimal
            
      from erp.InvcMisc as im
  where im.InvoiceNum >= 1100000
     --  LEFT JOIN erp.InvcMisc_UD as imud
     -- on im.SysRowID = imud.ForeignSysRowID

        ";
            return sqlextract;
        }
        public string Sql_InvcTax()
        {
            string sqlextract = @"
        select
            it.Company          as Company,  
            it.InvoiceNum       as InvoiceNum, 
            it.InvoiceLine      as InvoiceLine,
            it.TaxCode          as TaxCode ,
            it.ReportableAmt    as ReportableAmt,
            it.DocReportableAmt as DocReportableAmt,
            it.TaxableAmt       as TaxableAmt,
            -- it.Percent          as Percent,
            it.TaxAmt           as TaxAmt, 
            
            it.Manual           as Manual
      from erp.InvcTax as it
        ";
            return sqlextract;
        }
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
            pt.PartNum = id.PartNum
    where ih.InvoiceNum >= 1100000";
            return sqlextract;
        }
        public string Sql_RlsHead()
        {
            string sqlextract = @"
            select
            rl.Company as Company,
            rl.RlsClassCode as RlsClassCode,
            rl.TopCustNum as TopCustNum,
            rl.CustNum as CustNum
            from erp.RlsHead as rl
            ";

            return sqlextract;
        }
        public string Sql_ProdGrup()
        {
            string sqlextract = @"
      select
      pg.Company as Company, -- char 8 
      pg.ProdCode  as ProdCode,  -- char 8
      pg.Description as Description, -- char 30
      pud.Burden_c as Burden,
      pud.Duty_c as Duty,
      pud.RetailFlag_c as RetailFlag
     FROM  erp.ProdGrup as pg
     LEFT JOIN erp.ProdGrup_UD as pud
     on pg.SysRowID = pud.ForeignSysRowID

";

            return sqlextract;
        }
        public string Sql_UDCodes()
        {
            string sqlextract = @"
      select
      ic.Company as Company,
      ic.CodeTypeID as CodeTypeID,
      ic.CodeID as CodeID,
      ic.IsActive as IsActive,
      ic.CodeDesc as CodeDesc,
      ic.LongDesc as LongDesc
     
FROM  ice.UDCodes as ic
            ";

            return sqlextract;
        }
        public string Sql_ShipTo()
        {
            string sqlextract = @"
     select
      st.Company              as Company, -- char 8 
      st.CustNum              as CustNum,  -- int
      st.ShipToNum            as ShipToNum, -- x14
      st.Name                 as Name, -- x50
      st.Address1             as Address1, -- x50
      st.Address2             as Address2, -- x50
      st.Address3             as Address3, -- x50
      st.City                 as City, -- x50
      st.State                as State, -- x50
      st.ZIP                  as ZIP, -- x10
      st.PhoneNum             as PhoneNum, -- x20
      st.Country              as Country, -- x50
      st.TerritoryID          as TerritoryID, -- x8
      st.CountryNum           as CountryNum, -- int
      st.SalesRepCode         as SalesRepCode,
      st.ShipViaCode          as ShipViaCode
     FROM  erp.ShipTo as st
            ";

            return sqlextract;
        }
        public string Sql_ShipHead()
        {
            string sqlextract = @"
      select
      sh.Company as Company,               -- char 8 
      sh.CustNum as CustNum,               -- int
      sh.PackNum as PackNum,               -- int
      sh.ReadyToInvoice as ReadyToInvoice,  -- smallint
      sh.Invoiced as Invoiced,             -- smallint
      sh.FreightedShipViaCode as FreightedShipViaCode, -- char 4
      sh.EntryPerson as EntryPerson,       -- char 20
      sh.ShipDate as ShipDate,             -- int
      sh.Voided as Voided,                  -- smallint
      sh.TrackingNumber as TrackingNumber,
      sh.PayBTAddress1 as PayBTAddress1, 
      sh.PayBTAddress2 as PayBTAddress2, 
      sh.PayBTCity     as PayBTCity,     
      sh.PayBTState    as PayBTState,    
      sh.PayBTZip      as PayBTZip,      
      sh.PayBTCountry  as PayBTCountry,  
      sh.PayBTPhone    as PayBTPhone,
      sh.ShipToNum     as ShipToNum,
      sh.ShipViaCode   as ShipViaCode,
      1 as filler
     FROM  erp.ShipHead as sh
            ";

            return sqlextract;
        }
        public string Sql_ShipDtl()
        {
            string sqlextract = @"
      select
      sd.Company as Company,               -- char 8 
      sd.PackNum as PackNum,               -- int
      sd.PackLine as PackLine,             -- int
      sd.OrderNum as OrderNum,             -- int
      sd.OrderLine as OrderLine,           -- int
      sd.OrderRelNum as OrderRelNum,       -- int
      sd.OurInventoryShipQty as OurInventoryShipQty, -- decimal 12 2
      sd.OurJobShipQty as OurJobShipQty,   -- decimal 12 2
      sd.JobNum as JobNum,                 -- char 14
      sd.PartNum as PartNum,               -- char 50
      sd.ShipCmpl as ShipCmpl,              -- smallint
      sd.WarehouseCode as WarehouseCode,   -- char 8
      sd.BinNum   as BinNum,               -- char 10
      sd.UpdatedInventory as UpdatedInventory, -- smallint
      sd.Invoiced as Invoiced,              -- smallint
      sd.CustNum as CustNum,               -- int
      sd.ShipToNum  as ShipToNum,          -- char 14
      sd.ReadyToInvoice as ReadyToInvoice,  -- smallint
      sd.ChangedBy as ChangedBy,            -- char 20
      sd.ChangeDate as ChangeDate          -- int
     FROM  erp.ShipDtl as sd
            ";

            return sqlextract;
        }
        public string Sql_POHeader()
        {
            string sqlextract = @"
      select
      p.Company as Company, -- char 8 
      p.PONum  as PONum,  -- integer
      p.OrderDate as OrderDate, -- int after conversion
      p.ApprovalStatus as ApprovalStatus, -- char 1
      p.Approve as Approve, -- smallint
      p.ApprovedBy as ApprovedBy, -- x 20
      p.ApprovedDate as ApprovedDate, -- int after 
      p.BuyerID as BuyerID,  -- x8
      p.Confirmed as Confirmed, -- smallint
      p.EntryPerson as EntryPerson, -- x 20
      p.Linked as Linked, -- smallint
      p.OpenOrder as OpenOrder, -- smallint
      p.VendorNum as VendorNum,
      v.VendorId as VendorId
     FROM  erp.POHeader as p
     left join erp.Vendor as v
     on p.VendorNum = v.VendorNum
            ";

            return sqlextract;
        }
        public string Sql_PODetail()
        {
            string sqlextract = @"
    select
      p.Company as Company, -- char 8 
      p.OpenLine as OpenLine, -- int
      p.VoidLine as VoidLine, -- int
      p.PONUM  as PONum,  -- integer
      p.POLine as POLine, -- integer
      p.LineDesc as LineDesc,   -- x1000
      p.IUM as IUM, -- x2
      p.UnitCost as UnitCost, -- decimal.5
      p.OrderQty as OrderQty, -- decimal 2
      p.XOrderQty as XOrderQty, -- decimal 2
      p.Taxable as Taxable, -- int
      p.PUM as PUM, -- x2      
      p.CostPerCode as CostPerCode, -- char 1
      p.PartNum as PartNum, -- x 50
      p.VenPartNum as VenPartNum, -- int
      p.AdvancePayBal as AdvancePayBal, -- dec 2
      p.Confirmed as Confirmed, -- int
      p.DateChgReq as DateChgReq,  -- int
      p.ConfirmDate as ConfirmDate, -- int after convert
      p.OrderNum as OrderNum, -- int
      p.OrderLine as OrderLine, -- int
      p.Linked as Linked, -- smallint
      pdud.CustomerShipDate_c as CustomerShipDate,
      pdud.ReqDeliveryDate_c as ReqDeliveryDate,

      0 as filler
    FROM  erp.PODetail as p
    left join erp.PODetail_UD as pdud
    on p.SysRowID = pdud.ForeignSysRowID
            ";

            return sqlextract;
        }
        public string Sql_PORel()
        {
            string sqlextract = @"
            
     select
      p.Company as Company, -- char 8 
      p.PONum  as PONum,  -- integer
      p.POLine as POLine, -- integer
      p.PORelNum as PORelNum,   -- integer
      p.DueDate as DueDate, -- int after conversion
      p.XRelQty as XRelQty, -- decimal
      p.RelQty  as RelQty, --  decimal
      p.WarehouseCode as WarehouseCode, -- char 8
      p.ReceivedQty as ReceivedQty, -- decimal  rec to date
      p.PromiseDt as PromiseDt, -- int after conversion
      p.ShippedQty as ShippedQty, -- decimal
      p.ReqChgDate as ReqChgDate, -- int after
      p.ShippedDate as ShippedDate, -- int after conversion
      p.ContainerID as ContainerID,
      pud.ExAsiaDate_c  as ExAsiaDate,
      pud.ExpressDate_c  as ExpressDate,
      p.OpenRelease as OpenRelease,
      0 as filler
     FROM  erp.PORel as p
     left join erp.PORel_UD as pud
     on p.SysRowID = pud.ForeignSysRowID
";
            return sqlextract;
        }
        public string Sql_Vendor()
        {
            string sqlextract = @"
      select
      v.Company as Company, -- char 8 
      v.VendorID as VendorID,    -- char 8
      v.Name   as Name,          -- varchar(50)
      v.VendorNum as VendorNum,  -- int
      v.Address1 as Address1,   -- varchar(50)
      v.Address2 as Address2,  -- varchar(50)
      v.Address3 as Address3,  -- varchar(50)
      v.City     as City,     -- varchar(50)
      v.State    as State, -- varchar(50)  
      v.ZIP    as Zip,     -- varchar(10)  
      v.Country  as Country
     FROM  erp.Vendor as v
            ";
            return sqlextract;
        }
        public string Sql_Region()
        {
            string sqlextract = @"

            ";

            return sqlextract;
        }
        public string Sql_SalesTer()
        {
            string sqlextract = @"
      select
      st.Company as Company,               -- char 8 
      st.ConsToPrim as ConsToPrim,         -- smallint
      st.DefTaskSetID as DefTaskSetID,     -- Char 8
      st.Inactive as Inactive,             -- smallint
      st.PrimeSalesRepCode as PrimeSalesRepCode,  -- char 8
      st.RegionCode as RegionCode,                -- x 12
      st.TerritoryDesc as TerritoryDesc,          -- x 30
      st.TerritoryID as TerritoryID,              -- x 8
      stud.OverrideCommRate_c as terrCommRate
     FROM  erp.SalesTer as st
     left join erp.SalesTer_UD as stud
 on st.SysRowID = stud.ForeignSysRowID

";

            return sqlextract;
        }
        public string Sql_SalesRep()
        {
            string sqlextract = @"
    select
      sr.Company as Company,                       -- x 8 
      sr.SalesRepCode as SalesRepCode,             -- x 8
      sr.Name as Name,                             -- x 30
      sr.CommissionPercent as CommissionPercent,   -- decimal 
      sr.CommissionEarnedAt as CommissionEarnedAt,  -- x 1 , I or P  
      sr.AlertFlag as AlertFlag,                    -- small int
      sr.EMailAddress as EMailAddress,              -- x 50
      sr.WebSaleGetsCommission as WebSaleGetsCommission,   -- small int
      srud.bgCommRate_c as bgCommRate,                      -- decimal
      srud.BonusCalcRate_c as BonusCalcRate,                      -- decimal
      srud.ReaderRate_c as ReaderRate,                      -- decimal
      sr.InActive as InActive,                       -- small int
      srud.RunCommReport_c as RunCommReport,                    -- small int run report
      sr.OfficePhoneNum as OfficePhoneNum,
      sr.CellPhoneNum as CellPhoneNum,
      sr.HomePhoneNum as HomePhoneNum
     FROM  erp.SalesRep as sr
     left join erp.SalesRep_UD as srud
     on sr.SysRowID = srud.ForeignSysRowID
            ";

            return sqlextract;
        }
        public string Sql_ShipVia()
        {
            string sqlextract = @"
      select
      sv.Company as Company, -- char 8 
      sv.Description  as Description,  -- char 30
      sv.ShipViaCode  as ShipViaCode  -- char 4
     FROM  erp.ShipVia as sv
            ";

            return sqlextract;
        }
        public string Sql_Terms()
        {
            string sqlextract = @"
      select
      t.Company as Company, -- char 8 
      t.TermsCode as TermsCode, -- char 4
      t.Description  as Description,  -- char 30

     1 as filler
     FROM  erp.Terms as t
            ";

            return sqlextract;
        }
        public string Sql_Warehse()
        {
            string sqlextract = @"
            select 
             w.WarehouseCode as WarehouseCode,
             w.Description as Description
             from erp.Warehse as w
            ";

            return sqlextract;
        }
        public string Sql_xxq()
        {
            string sqlextract = @"

            ";

            return sqlextract;
        }

    }
}