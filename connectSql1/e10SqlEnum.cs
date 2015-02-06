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

}