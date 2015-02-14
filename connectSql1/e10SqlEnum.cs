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
        CreditHold
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
        TaxDivision,
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
        ShortChar01,
        ShortChar02,
        ShortChar03,
        UnitPrice,
        VoidLine,
        SellingFactor,
        XPartNum,
        Discount,
        DiscountPercent,
        EDIPOlineNum
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
        ShortChar01,
        ShortChar02,
        ShortChar03,
        TermsCode,
        TotalCharges,
        TotalComm,
        TotalInvoiced,
        TotalLines,
        TotalMisc,
        TotalReleases,
        TotalTax,
        VoidOrder,
        CheckBox04,
        CheckBox07,
        CheckBox03
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
      Character01 ,
      CheckBox01 ,
      Number01 ,
      filler
    }
    public enum Part
    {
      Company ,
      partNum ,
      PartDescription ,
      ProdCode ,
      BasePart ,
      PrintType,
      UnitPrice ,
      RunOut ,
      SearchWord ,
      TypeCode ,
      Inactive ,
      ClassID ,
      SellingFactor ,
      LOC,
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
        Description
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
        SalesRepCode
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

}