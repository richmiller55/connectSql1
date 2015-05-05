namespace connectSql1
{
    public enum ContainerDetail
    {
    	Company,
		ContainerID, 
		ContainerShipQty,
		PONum,
		POLine,
		PORelNum,
		PackSlip,
		Volume,
		VendorNum,
		OurUnitCost,
		LCAmt
    }
    public enum ContainerHeader
    {
        Company,
        ContainerID,
        ShipDate,
        Shipped,
        ContainerClass,
        ContainerCost,
        ShippingDays,
        ContainerDescription,
        Volume,
        ContainerReference
    }
    public enum Customer
    {
        CustID,
        CustNum,
        Name,
        Address1,
        Address2,
        Address3,
        City,
        State,
        Zip,
        Country,
        TerritoryID,
        SalesRepCode,
        TermsCode,
        ShipViaCode,
        GroupCode,
        SalesCatID,
        CreditHold,
        ResaleID,
        PrintStatements,
        TaxExempt,
        TaxRegionCode,
        CreditLimit,
        PhoneNum,
        BuyGroupCustID,
        VisionSourceID
    }
    public enum InvcDtl
    {
    FiscalYear   ,
    FiscalPeriod ,
    InvoiceNum   ,
    InvoiceLine  ,
    InvoiceDate  ,
    PackNum      ,
    PackLine     ,
    OrderNum     ,
    OrderLine    ,
    ShipDate     ,
    SellingShipQty ,
    UnitPrice      ,
    TotalDollars   ,
    ExtPrice       ,
    SoldToCustID   ,
    ShipToNum      ,
    BillToCustID   , 
    PartNum         ,
    PartDescription ,
    SalesRepList    ,
    BillToCustNum   ,
    SoldToCustNum   ,
    MtlUnitCost     ,
    LbrUnitCost     ,
    BurUnitCost     ,
    SubUnitCost     ,
    MtlBurUnitCost  ,
    Discount        ,
    DiscountPercent ,
    SellingFactor   ,
    SellingFactorDirection,
    filler,

	}
    public enum InvcHeadEx
    {
        FiscalYear,
        FiscalPeriod,
        SoldToCustNum,
        CustNum,
        InvoiceNum,
        OrderNum,
        InvoiceDate,
        CreditMemo,
        DocInvoiceAmt,
        InvoiceAmt,
        EntryPerson,
        SalesRepList,
        StartUp,
        Posted,
        InvoiceBal,
        UnappliedCash,
        DebitNote,
        InvoiceSuffix,
        CheckBox01
    }
    public enum InvcMisc
    {
        Company,
        InvoiceNum,
        InvoiceLine,
        MiscCode,
        Description,
        DocMiscAmt,
        MiscAmt,
        PackNum,
        TrackingNum
    }
    public enum InvcTax
    {
        Company,
        InvoiceNum,
        InvoiceLine,
        TaxCode,
        ReportableAmt,
        DocReportableAmt,
        TaxableAmt,
        TaxAmt,
        Manual
    }
    public enum OrderRel
    {
        Company,
        OrderNum,
        OrderLine,
        OrderRelNum,
        OpenRelease,
        FirmRelease,
        VoidRelease,
        RevisionNum,
        NeedByDate,
        MarkForNum,
        WarehouseCode,
        OurJobShippedQty,
        SellingStockQty,
        SellingJobQty,
        SellingStockShippedQty
    }
    public enum OrderDtl
    {
        Company,
        OrderLine,
        OrderNum,
        OpenLine,
        OrderQty,
        OverridePriceList,
        PartNum,
        PriceGroupCode,
        PriceListCode,
        PricingQty,
        ProdCode,
        NeedByDate,
        RequestDate,
        SalesCatID,
        UnitPrice,
        VoidLine,
        SellingFactor,
        XPartNum,
        Discount,
        DiscountPercent,
        EDIPOlineNum,
        SellingQuantity
    }
    public enum OrderHed
    {
        Company,
        OrderNum,
        CustNum,
        OpenOrder,
        OrderDate,
        PONum,
        NeedByDate,
        RequestDate,
        ShipToNum,
        ShipViaCode,
        OrderType,
        TermsCode,
        TotalCharges,
        TotalComm,
        TotalInvoiced,
        TotalLines,
        TotalMisc,
        TotalReleases,
        TotalTax,
        VoidOrder,
        inPrintSetup,
        offShore,
        freightFree

    }
    public enum CustomerFull
    {
        CustID,
        CustNum,
        Name,
        Address1,
        Address2,
        Address3,
        City,
        State,
        Zip,
        Country,
        TerritoryID,
        SalesRepCode,
        TermsCode,
        ShipViaCode,
        GroupCode,
        SalesCatID,
        ResaleID,
        PrintStatements,
        TaxExempt,
        CreditHold,
        TaxRegionCode,
        CreditLimit,
        CreditHoldDate,
        CreditHoldSource,
        CreditIncludeOrders,
        GlobalCust,
        GlobalCreditHold,
        GlobalCredIncOrd,
        PhoneNum,
        CheckBox01,
        CheckBox02,
        CheckBox03,
        CheckBox04,
        CheckBox05,
        CheckBox06,
        ChangedBy,
        ChangeDate,
        EstDate,
        CreditClearUserID,
        BTName,
        BTAddress1,
        BTAddress2,
        BTAddress3,
        BTCity,
        BTCountry,
        BTCountryNum,
        BTFaxNum,
        BTFormatStr,
        BTPhoneNum,
        BTState,
        BTZip,
        ShortChar01,
        Comment
    }
    public enum CustGrup
    {
      Company ,
      GroupCode ,
      GroupDesc ,
      SalesCatID ,
      SuperGroup,
      SortOrder,
      filler
    }
    public enum Part
    {
        Company,
        partNum,
        PartDescription,
        ProdCode,
        BasePart,
        PrintType,
        UnitPrice,
        RunOut,
        SearchWord,
        TypeCode,
        Inactive,
        ClassID,
        SellingFactor,
        LOC,
        AICDesc,
        Brand,
        CasePack,
        ColorAssortment,
        DirectShip,
        ListPrice,
        Flyer,
        FlyerName,
        TeamSpirit,
        OrderingType,
        PrintOptions,
        MaximumWOS,
        MinimumWOS,
        League,
        TeamPartDescrption,
        ARCoating,
        CoordinatedCase,
        RxAdaptable,
        SpringHinge,
        Program,
        ProgramLOC,
        SalesUM,
        RetailPrice,
        filler
    }
    public enum PartBin
    {
    Company ,
    partNum ,
    WarehouseCode ,
    BinNum ,
    OnhandQty ,
    LotNum 
    }
    public enum ProdGrup
    {
        Company,
        ProdCode,
        Description,
        Burden,
        Duty,
        RetailFlag
    }
    public enum ShipTo
    {
        Company,
        CustNum,
        ShipToNum,
        Name,
        Address1,
        Address2,
        Address3,
        City,
        State,
        ZIP,
        PhoneNum,
        Country,
        TerritoryID,
        CountryNum,
        SalesRepCode,
        ShipViaCode
    }
    public enum ShipHead
    {
        Company,
        CustNum,
        PackNum,
        ReadyToInvoice,
        Invoiced,
        FreightedShipViaCode,
        EntryPerson,
        ShipDate,
        Voided,
        TrackingNumber,
        PayBTAddress1,
        PayBTAddress2,
        PayBTCity,
        PayBTState,
        PayBTZip,
        PayBTCountry,
        PayBTPhone,
        ShipToNum,
        ShipViaCode
    }
    public enum ShipDtl
    {
        Company,
        PackNum,
        PackLine,
        OrderNum,
        OrderLine,
        OrderRelNum,
        OurInventoryShipQty,
        OurJobShipQty,
        JobNum,
        PartNum,
        ShipCmpl,
        WarehouseCode,
        BinNum,
        UpdatedInventory,
        Invoiced,
        CustNum,
        ShipToNum,
        ReadyToInvoice,
        ChangedBy,
        ChangeDate
    }
    public enum RlsHead
    {
      Company,
      RlsClassCode,
      TopCustNum,
      CustNum
    }
    public enum POHeader
    {
        Company,
        PONum,
        OrderDate,
        ApprovalStatus,
        Approve,
        ApprovedBy,
        ApprovedDate,
        BuyerID,
        Confirmed,
        EntryPerson,
        Linked,
        OpenOrder,
        VendorNum,
        VendorId
    }
    public enum PODetail
    {
        Company,
        OpenLine,
        VoidLine,
        PONUM,
        POLine,
        LineDesc,
        IUM,
        UnitCost,
        OrderQty,
        XOrderQty,
        Taxable,
        PUM,
        CostPerCode,
        PartNum,
        VenPartNum,
        AdvancePayBal,
        Confirmed,
        DateChgReq,
        ConfirmDate,
        OrderNum,
        OrderLine,
        Linked,
        CustomerShipDate,
        ReqDeliveryDate

    }
    public enum PORel
    {
        Company,
        PONum,
        POLine,
        PORelNum,
        DueDate,
        XRelQty,
        RelQty,
        WarehouseCode,
        ReceivedQty,
        PromiseDt,
        ShippedQty,
        ReqChgDate,
        ShippedDate,
        ContainerID,
        ExAsiaDate,
        ExpressDate,
        OpenRelease
    }
    public enum Vendor
    {
        Company,
        VendorID,
        Name,
        VendorNum,
        Address1,
        Address2,
        Address3,
        City,
        State,
        ZIP,
        Country
    }
    public enum ShipVia
    {
        Company,
        Description,
        ShipViaCode,
        Fill
    }
    public enum Terms
    {
        Company,
        TermsCode,
        Description
    }
    public enum SalesTer
    {
        Company,
        ConsToPrim,
        DefTaskSetID,
        Inactive,
        PrimeSalesRepCode,
        RegionCode,
        TerritoryDesc,
        TerritoryID,
        OverrideCommRate
    }
    public enum SalesRep
    {
        Company,
        SalesRepCode,
        Name,
        CommissionPercent,
        CommissionEarnedAt,
        AlertFlag,
        EMailAddress,
        WebSaleGetsCommission,
        bgCommRate,
        BonusCalcRate,
        ReaderRate,
        InActive,
        RunCommReport,
        OfficePhoneNum,
        CellPhoneNum,
        HomePhoneNum
    }
    public enum UDCodes
    {
        Company,
        CodeTypeID,
        CodeID,
        IsActive,
        CodeDesc,
        LongDesc
    }
    public enum Warehse
    {
        WarehouseCode,
        Description
    }
}