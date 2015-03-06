using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;

namespace connectSql1
{
    class DataMan
    {
        // private static string connectionString = ConfigurationManager.AppSettings.Get("connectionstring");
        string connectionString = "Persist Security Info=False; Integrated Security=true; Database=Epicor10Production; server=ITSQL";
        
        string transfer_out_base = @"Z:/e10/transfer";
        public DataMan()
        {
            run_Vendor();
            run_SalesRep();
            run_SalesTer();
            run_ShipVia();
            run_Terms();
            run_CustGrup();
            run_Part();
            run_ShipTo();
            run_Customer();
            run_SalesTer();
            run_SalesRep();
            run_ShipHead();
            run_ShipDtl();

            run_InvcHeadEx();            
            run_InvcDtl();
            run_InvcMisc();
            run_InvcTax();

            run_OrderHed();
            run_OrderDtl();
            run_OrderRel();
            run_PartBin();
            run_ProdGrup();
            run_POHeader();
            run_PODetail();
            run_PORel();
            run_RlsHead();

            run_ContainerHeader();
            run_ContainerDetail();


            /*   
            
            
            run_Customer();
            run_Part();          
             * */
        }
        private void run_ContainerHeader()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "ContainerHeader.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_ContainerHeader(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)ContainerHeader.Company] + "\t";
                    row += reader[(int)ContainerHeader.ContainerID] + "\t";
                    row += DateToString(reader[(int)ContainerHeader.ShipDate].ToString()) + "\t";
                    row += boolstr_to_int(reader[(int)ContainerHeader.Shipped].ToString()) + "\t";
                    row += reader[(int)ContainerHeader.ContainerClass] + "\t";
                    row += reader[(int)ContainerHeader.ContainerCost] + "\t";
                    row += reader[(int)ContainerHeader.ShippingDays] + "\t";
                    row += reader[(int)ContainerHeader.ContainerDescription] + "\t";
                    row += reader[(int)ContainerHeader.Volume] + "\t";
                    row += reader[(int)ContainerHeader.ContainerReference] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_ContainerDetail()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "ContainerDetail.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_ContainerDetail(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)ContainerDetail.Company] + "\t";
                    row += reader[(int)ContainerDetail.ContainerID] + "\t";
                    row += reader[(int)ContainerDetail.ContainerShipQty] + "\t";
                    row += reader[(int)ContainerDetail.PONum] + "\t";
                    row += reader[(int)ContainerDetail.POLine] + "\t";
                    row += reader[(int)ContainerDetail.PORelNum] + "\t";
                    row += reader[(int)ContainerDetail.PackSlip] + "\t";
                    row += reader[(int)ContainerDetail.Volume] + "\t";
                    row += reader[(int)ContainerDetail.VendorNum] + "\t";
                    row += reader[(int)ContainerDetail.OurUnitCost] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_OrderHed()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "OrderHed.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_OrderHed(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)OrderHed.Company] + "\t";
                    row += reader[(int)OrderHed.OrderNum] + "\t";
                    row += reader[(int)OrderHed.CustNum] + "\t";
                    row += boolstr_to_int(reader[(int)OrderHed.OpenOrder].ToString()) + "\t";
                    row += DateToString(reader[(int)OrderHed.OrderDate].ToString()) + "\t";
                    row += reader[(int)OrderHed.PONum] + "\t";
                    row += DateToString(reader[(int)OrderHed.NeedByDate].ToString()) + "\t";
                    row += DateToString(reader[(int)OrderHed.RequestDate].ToString()) + "\t";
                    row += reader[(int)OrderHed.ShipToNum] + "\t";
                    row += reader[(int)OrderHed.ShipViaCode] + "\t";
                    row += reader[(int)OrderHed.OrderType] + "\t";
                    row += reader[(int)OrderHed.ShortChar02] + "\t";
                    row += reader[(int)OrderHed.ShortChar03] + "\t";
                    row += reader[(int)OrderHed.TermsCode] + "\t";
                    row += reader[(int)OrderHed.TotalCharges] + "\t";
                    row += reader[(int)OrderHed.TotalComm] + "\t";
                    row += reader[(int)OrderHed.TotalInvoiced] + "\t";
                    row += reader[(int)OrderHed.TotalLines] + "\t";
                    row += reader[(int)OrderHed.TotalMisc] + "\t";
                    row += reader[(int)OrderHed.TotalInvoiced] + "\t";
                    row += reader[(int)OrderHed.TotalLines] + "\t";
                    row += reader[(int)OrderHed.TotalMisc] + "\t";
                    row += reader[(int)OrderHed.TotalReleases] + "\t";
                    row += reader[(int)OrderHed.TotalTax] + "\t";
                    row += boolstr_to_int(reader[(int)OrderHed.VoidOrder].ToString()) + "\t";
                    row += reader[(int)OrderHed.PickListComment] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_OrderDtl()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "OrderDtl.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);
                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_OrderDtl(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)OrderDtl.Company] + "\t";
                    row += reader[(int)OrderDtl.OrderLine] + "\t";
                    row += reader[(int)OrderDtl.OrderNum] + "\t";
                    row += boolstr_to_int(reader[(int)OrderDtl.OpenLine].ToString()) + "\t";
                    row += reader[(int)OrderDtl.OrderQty] + "\t";
                    row += reader[(int)OrderDtl.OverridePriceList] + "\t";
                    row += reader[(int)OrderDtl.PartNum] + "\t";
                    row += reader[(int)OrderDtl.PriceGroupCode] + "\t";
                    row += reader[(int)OrderDtl.PriceGroupCode] + "\t";
                    row += reader[(int)OrderDtl.PricingQty] + "\t";
                    row += reader[(int)OrderDtl.ProdCode] + "\t";
                    row += DateToString(reader[(int)OrderDtl.NeedByDate].ToString()) + "\t";
                    row += DateToString(reader[(int)OrderDtl.RequestDate].ToString()) + "\t";
                    row += reader[(int)OrderDtl.SalesCatID] + "\t";
                    row += reader[(int)OrderDtl.ShortChar01] + "\t";
                    row += reader[(int)OrderDtl.ShortChar02] + "\t";
                    row += reader[(int)OrderDtl.ShortChar03] + "\t";
                    row += reader[(int)OrderDtl.UnitPrice] + "\t";
                    row += reader[(int)OrderDtl.VoidLine] + "\t";
                    row += reader[(int)OrderDtl.SellingFactor] + "\t";
                    row += reader[(int)OrderDtl.XPartNum] + "\t";
                    row += reader[(int)OrderDtl.Discount] + "\t";
                    row += reader[(int)OrderDtl.DiscountPercent] + "\t";
                    row += reader[(int)OrderDtl.EDIPOlineNum] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_InvcDtl()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "InvcDtl.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_InvcDtl(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)InvcDtl.FiscalYear] + "\t";
                    row += reader[(int)InvcDtl.FiscalPeriod] + "\t";
                    row += reader[(int)InvcDtl.InvoiceNum] + "\t";
                    row += reader[(int)InvcDtl.InvoiceLine] + "\t";
                    row += DateToString(reader[(int)InvcDtl.InvoiceDate].ToString()) + "\t";
                    row += reader[(int)InvcDtl.PackNum] + "\t";
                    row += reader[(int)InvcDtl.PackLine] + "\t";
                    row += reader[(int)InvcDtl.OrderNum] + "\t";
                    row += reader[(int)InvcDtl.OrderLine] + "\t";
                    row += DateToString(reader[(int)InvcDtl.ShipDate].ToString()) + "\t";
                    row += reader[(int)InvcDtl.SellingShipQty] + "\t";
                    row += reader[(int)InvcDtl.UnitPrice] + "\t";
                    row += reader[(int)InvcDtl.TotalDollars] + "\t";
                    row += reader[(int)InvcDtl.ExtPrice] + "\t";
                    row += reader[(int)InvcDtl.SoldToCustID] + "\t";
                    row += reader[(int)InvcDtl.ShipToNum] + "\t";
                    row += reader[(int)InvcDtl.BillToCustID] + "\t";
                    row += reader[(int)InvcDtl.PartNum] + "\t";
                    row += reader[(int)InvcDtl.PartDescription] + "\t";
                    row += reader[(int)InvcDtl.SalesRepList] + "\t";
                    row += reader[(int)InvcDtl.BillToCustNum] + "\t";
                    row += reader[(int)InvcDtl.SoldToCustNum] + "\t";
                    row += reader[(int)InvcDtl.MtlUnitCost] + "\t";
                    row += reader[(int)InvcDtl.LbrUnitCost] + "\t";
                    row += reader[(int)InvcDtl.BurUnitCost] + "\t";
                    row += reader[(int)InvcDtl.SubUnitCost] + "\t";
                    row += reader[(int)InvcDtl.MtlUnitCost] + "\t";
                    row += reader[(int)InvcDtl.Discount] + "\t";
                    row += reader[(int)InvcDtl.DiscountPercent] + "\t";
                    row += reader[(int)InvcDtl.SellingFactor] + "\t";
                    row += reader[(int)InvcDtl.SellingFactorDirection] + "\t";
                    row += reader[(int)InvcDtl.filler] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_InvcHeadEx()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "InvcHeadEx.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_InvcHeadEx(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)InvcHeadEx.FiscalYear] + "\t";
                    row += reader[(int)InvcHeadEx.FiscalPeriod] + "\t";
                    row += reader[(int)InvcHeadEx.SoldToCustNum] + "\t";
                    row += reader[(int)InvcHeadEx.CustNum] + "\t";
                    row += reader[(int)InvcHeadEx.InvoiceNum] + "\t";
                    row += reader[(int)InvcHeadEx.OrderNum] + "\t";
                    row += DateToString(reader[(int)InvcHeadEx.InvoiceDate].ToString()) + "\t";
                    row += boolstr_to_int(reader[(int)InvcHeadEx.CreditMemo].ToString()) + "\t";
                    row += reader[(int)InvcHeadEx.DocInvoiceAmt] + "\t";
                    row += reader[(int)InvcHeadEx.InvoiceAmt] + "\t";
                    row += reader[(int)InvcHeadEx.EntryPerson] + "\t";
                    row += reader[(int)InvcHeadEx.SalesRepList] + "\t";
                    row += boolstr_to_int(reader[(int)InvcHeadEx.StartUp].ToString()) + "\t";
                    row += boolstr_to_int(reader[(int)InvcHeadEx.Posted].ToString()) + "\t";
                    row += reader[(int)InvcHeadEx.InvoiceBal] + "\t";
                    
                    row += boolstr_to_int(reader[(int)InvcHeadEx.UnappliedCash].ToString()) + "\t";
                    row += boolstr_to_int(reader[(int)InvcHeadEx.DebitNote].ToString()) + "\t";

                    row += reader[(int)InvcHeadEx.InvoiceSuffix] + "\t";
                    row += reader[(int)InvcHeadEx.CheckBox01] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_InvcMisc()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "InvcMisc.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_InvcMisc(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)InvcMisc.Company] + "\t";
                    row += reader[(int)InvcMisc.InvoiceNum] + "\t";
                    row += reader[(int)InvcMisc.InvoiceLine] + "\t";
                    row += reader[(int)InvcMisc.MiscCode] + "\t";
                    row += reader[(int)InvcMisc.Description] + "\t";
                    row += reader[(int)InvcMisc.DocMiscAmt] + "\t";
                    row += reader[(int)InvcMisc.MiscAmt] + "\t";
                    // row += reader[(int)InvcMisc.PackNum] + "\t";
                    // row += reader[(int)InvcMisc.TrackingNum] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_InvcTax()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "InvcTax.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_InvcTax(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)InvcTax.Company] + "\t";
                    row += reader[(int)InvcTax.InvoiceNum] + "\t";
                    row += reader[(int)InvcTax.InvoiceLine] + "\t";
                    row += reader[(int)InvcTax.TaxCode] + "\t";
                    row += reader[(int)InvcTax.ReportableAmt] + "\t";
                    row += reader[(int)InvcTax.DocReportableAmt] + "\t";
                    row += reader[(int)InvcTax.TaxableAmt] + "\t";
                    row += reader[(int)InvcTax.TaxAmt] + "\t";
                    row += reader[(int)InvcTax.Manual] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_OrderRel()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "OrderRel.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_OrderRel(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)OrderRel.Company] + "\t";
                    row += reader[(int)OrderRel.OrderNum] + "\t";
                    row += reader[(int)OrderRel.OrderLine] + "\t";
                    row += reader[(int)OrderRel.OrderRelNum] + "\t";
                    row += reader[(int)OrderRel.OpenRelease] + "\t";
                    row += reader[(int)OrderRel.FirmRelease] + "\t";
                    row += reader[(int)OrderRel.VoidRelease] + "\t";
                    row += reader[(int)OrderRel.RevisionNum] + "\t";
                    row += DateToString(reader[(int)OrderRel.NeedByDate].ToString()) + "\t";
                    row += reader[(int)OrderRel.MarkForNum] + "\t";
                    row += reader[(int)OrderRel.WarehouseCode] + "\t";
                    row += reader[(int)OrderRel.OurJobShippedQty] + "\t";
                    row += reader[(int)OrderRel.SellingStockQty] + "\t";
                    row += reader[(int)OrderRel.SellingJobQty] + "\t";
                    row += reader[(int)OrderRel.SellingStockShippedQty] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_InvcDtlOld()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "InvcDtl.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_InvcDtl(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)InvcDtl.FiscalPeriod] + "\t";
                    row += reader[(int)InvcDtl.FiscalYear] + "\t";
                    row += reader[(int)InvcDtl.InvoiceNum] + "\t";
                    row += reader[(int)InvcDtl.InvoiceLine] + "\t";
                    row += DateToString(reader[(int)InvcDtl.InvoiceDate].ToString()) + "\t";
                    row += reader[(int)InvcDtl.PackNum] + "\t";
                    row += reader[(int)InvcDtl.OrderNum] + "\t";
                    row += reader[(int)InvcDtl.OrderLine] + "\t";
                    row += DateToString(reader[(int)InvcDtl.ShipDate].ToString()) + "\t";
                    row += reader[(int)InvcDtl.SellingShipQty] + "\t";
                    row += reader[(int)InvcDtl.UnitPrice] + "\t";
                    row += reader[(int)InvcDtl.TotalDollars] + "\t";
                    row += reader[(int)InvcDtl.ExtPrice] + "\t";
                    row += reader[(int)InvcDtl.SoldToCustID] + "\t";
                    row += reader[(int)InvcDtl.ShipToNum] + "\t";
                    row += reader[(int)InvcDtl.BillToCustID] + "\t";
                    row += reader[(int)InvcDtl.PartNum] + "\t";
                    row += reader[(int)InvcDtl.PartDescription] + "\t";
                    row += reader[(int)InvcDtl.SalesRepList] + "\t";
                    row += reader[(int)InvcDtl.BillToCustNum] + "\t";
                    row += reader[(int)InvcDtl.SoldToCustNum] + "\t";
                    row += reader[(int)InvcDtl.MtlUnitCost] + "\t";
                    row += reader[(int)InvcDtl.LbrUnitCost] + "\t";
                    row += reader[(int)InvcDtl.BurUnitCost] + "\t";
                    row += reader[(int)InvcDtl.SubUnitCost] + "\t";
                    row += reader[(int)InvcDtl.MtlBurUnitCost] + "\t";
                    row += reader[(int)InvcDtl.Discount] + "\t";
                    row += reader[(int)InvcDtl.DiscountPercent] + "\t";
                    row += reader[(int)InvcDtl.SellingFactor] + "\t";
                    row += reader[(int)InvcDtl.SellingFactorDirection] + "\t";
                    row += reader[(int)InvcDtl.filler];
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_RlsHead()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "RlsHead.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_RlsHead(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)RlsHead.Company] + "\t";
                    row += reader[(int)RlsHead.RlsClassCode] + "\t";
                    row += reader[(int)RlsHead.TopCustNum] + "\t";
                    row += reader[(int)RlsHead.CustNum] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_ProdGrup()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "ProdGrup.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_ProdGrup(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)ProdGrup.Company] + "\t";
                    row += reader[(int)ProdGrup.Description] + "\t";
                    row += reader[(int)ProdGrup.ProdCode] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_ShipTo()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "ShipTo.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_ShipTo(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)ShipTo.Company] + "\t";
                    row += reader[(int)ShipTo.CustNum] + "\t";
                    row += reader[(int)ShipTo.ShipToNum] + "\t";
                    row += reader[(int)ShipTo.Name] + "\t";
                    row += reader[(int)ShipTo.Address1] + "\t";
                    row += reader[(int)ShipTo.Address2] + "\t";
                    row += reader[(int)ShipTo.Address3] + "\t";
                    row += reader[(int)ShipTo.City] + "\t";
                    row += reader[(int)ShipTo.State] + "\t";
                    row += reader[(int)ShipTo.ZIP] + "\t";
                    row += reader[(int)ShipTo.PhoneNum] + "\t";
                    row += reader[(int)ShipTo.Country] + "\t";
                    row += reader[(int)ShipTo.TerritoryID] + "\t";
                    row += reader[(int)ShipTo.CountryNum] + "\t";
                    row += reader[(int)ShipTo.SalesRepCode] + "\t";
                    row += reader[(int)ShipTo.ShipViaCode] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_ShipHead()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "ShipHead.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_ShipHead(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)ShipHead.Company] + "\t";
                    row += reader[(int)ShipHead.CustNum] + "\t";
                    row += reader[(int)ShipHead.PackNum] + "\t";
                    row += reader[(int)ShipHead.ReadyToInvoice] + "\t";
                    row += reader[(int)ShipHead.Invoiced] + "\t";
                    row += reader[(int)ShipHead.FreightedShipViaCode] + "\t";
                    row += reader[(int)ShipHead.EntryPerson] + "\t";
                    row += DateToString(reader[(int)ShipHead.ShipDate].ToString()) + "\t";
                    row += reader[(int)ShipHead.Voided] + "\t";
                    row += reader[(int)ShipHead.TrackingNumber] + "\t";
                    row += reader[(int)ShipHead.PayBTAddress1] + "\t";
                    row += reader[(int)ShipHead.PayBTAddress2] + "\t";
                    row += reader[(int)ShipHead.PayBTCity] + "\t";
                    row += reader[(int)ShipHead.PayBTState] + "\t";
                    row += reader[(int)ShipHead.PayBTZip] + "\t";
                    row += reader[(int)ShipHead.PayBTCountry] + "\t";
                    row += reader[(int)ShipHead.PayBTPhone] + "\t";
                    row += reader[(int)ShipHead.ShipToNum] + "\t";
                    row += reader[(int)ShipHead.ShipViaCode] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_ShipDtl()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "ShipDtl.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_ShipDtl(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)ShipDtl.Company] + "\t";
                    row += reader[(int)ShipDtl.PackNum] + "\t";
                    row += reader[(int)ShipDtl.PackLine] + "\t";
                    row += reader[(int)ShipDtl.OrderNum] + "\t";
                    row += reader[(int)ShipDtl.OrderLine] + "\t";
                    row += reader[(int)ShipDtl.OrderRelNum] + "\t";
                    row += reader[(int)ShipDtl.OurInventoryShipQty] + "\t";
                    row += reader[(int)ShipDtl.OurJobShipQty] + "\t";
                    row += reader[(int)ShipDtl.JobNum] + "\t";
                    row += reader[(int)ShipDtl.PartNum] + "\t";
                    row += reader[(int)ShipDtl.ShipCmpl] + "\t";
                    row += reader[(int)ShipDtl.WarehouseCode] + "\t";
                    row += reader[(int)ShipDtl.BinNum] + "\t";
                    row += reader[(int)ShipDtl.UpdatedInventory] + "\t";
                    row += reader[(int)ShipDtl.Invoiced] + "\t";
                    row += reader[(int)ShipDtl.CustNum] + "\t";
                    row += reader[(int)ShipDtl.ShipToNum] + "\t";
                    row += reader[(int)ShipDtl.ReadyToInvoice] + "\t";
                    row += reader[(int)ShipDtl.ChangedBy] + "\t";
                    row += DateToString(reader[(int)ShipDtl.ChangeDate].ToString()) + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_PartBin()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "PartBin.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_PartBin(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)PartBin.Company] + "\t";
                    row += reader[(int)PartBin.partNum] + "\t";
                    row += reader[(int)PartBin.WarehouseCode] + "\t";
                    row += reader[(int)PartBin.BinNum] + "\t";
                    row += reader[(int)PartBin.OnhandQty] + "\t";

                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_CustGrup()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "CustGrup.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_CustGrup(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)CustGrup.Company] + "\t";
                    row += reader[(int)CustGrup.GroupCode] + "\t";
                    row += reader[(int)CustGrup.GroupDesc] + "\t";
                    row += reader[(int)CustGrup.SalesCatID] + "\t";
                    row += reader[(int)CustGrup.SuperGroup] + "\t";

                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_POHeader()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "POHeader.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_POHeader(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)POHeader.Company] + "\t";
                    row += reader[(int)POHeader.PONum] + "\t";
                    row += DateToString(reader[(int)POHeader.OrderDate].ToString()) + "\t";
                    row += reader[(int)POHeader.ApprovalStatus] + "\t";
                    row += boolstr_to_int(reader[(int)POHeader.Approve].ToString()) + "\t";
                    row += reader[(int)POHeader.ApprovedBy] + "\t";
                    row += DateToString(reader[(int)POHeader.ApprovedDate].ToString()) + "\t";
                    row += reader[(int)POHeader.BuyerID] + "\t";
                    row += boolstr_to_int(reader[(int)POHeader.Confirmed].ToString()) + "\t";
                    row += reader[(int)POHeader.EntryPerson] + "\t";
                    row += boolstr_to_int(reader[(int)POHeader.Linked].ToString()) + "\t";
                    row += boolstr_to_int(reader[(int)POHeader.OpenOrder].ToString()) + "\t";
                    row += reader[(int)POHeader.VendorNum] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_PODetail()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "PODetail.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_PODetail(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)PODetail.Company] + "\t";

                    row += boolstr_to_int(reader[(int)PODetail.OpenLine].ToString()) + "\t";
                    row += boolstr_to_int(reader[(int)PODetail.VoidLine].ToString()) + "\t";
                    
                    row += reader[(int)PODetail.PONUM] + "\t";
                    row += reader[(int)PODetail.POLine] + "\t";
                    row += reader[(int)PODetail.LineDesc] + "\t";
                    row += reader[(int)PODetail.IUM] + "\t";
                    row += reader[(int)PODetail.UnitCost] + "\t";
                    row += reader[(int)PODetail.OrderQty] + "\t";
                    row += reader[(int)PODetail.XOrderQty] + "\t";
                    row += reader[(int)PODetail.Taxable] + "\t";
                    row += reader[(int)PODetail.PUM] + "\t";
                    row += reader[(int)PODetail.CostPerCode] + "\t";
                    row += reader[(int)PODetail.PartNum] + "\t";
                    row += reader[(int)PODetail.VenPartNum] + "\t";
                    row += reader[(int)PODetail.AdvancePayBal] + "\t";
                    row += boolstr_to_int(reader[(int)PODetail.Confirmed].ToString()) + "\t";
                    row += DateToString(reader[(int)PODetail.DateChgReq].ToString()) + "\t";
                    row += DateToString(reader[(int)PODetail.ConfirmDate].ToString()) + "\t";
                    row += reader[(int)PODetail.OrderNum] + "\t";
                    row += reader[(int)PODetail.OrderLine] + "\t";
                    row += boolstr_to_int(reader[(int)PODetail.Linked].ToString()) + "\t";
                    row += DateToString(reader[(int)PODetail.CustomerShipDate].ToString()) + "\t";
                    row += DateToString(reader[(int)PODetail.ReqDeliveryDate].ToString()) + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_PORel()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "PORel.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_PORel(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)PORel.Company] + "\t";
                    row += reader[(int)PORel.PONum] + "\t";
                    row += reader[(int)PORel.POLine] + "\t";
                    row += reader[(int)PORel.PORelNum] + "\t";
                    row += DateToString(reader[(int)PORel.DueDate].ToString()) + "\t";
                    row += reader[(int)PORel.XRelQty] + "\t";
                    row += reader[(int)PORel.RelQty] + "\t";
                    row += reader[(int)PORel.WarehouseCode] + "\t";
                    row += reader[(int)PORel.ReceivedQty] + "\t";
                    row += DateToString(reader[(int)PORel.PromiseDt].ToString()) + "\t";
                    row += reader[(int)PORel.ShippedQty] + "\t";
                    row += DateToString(reader[(int)PORel.ReqChgDate].ToString()) + "\t";
                    row += DateToString(reader[(int)PORel.ShippedDate].ToString()) + "\t";
                    row += reader[(int)PORel.ContainerID] + "\t";
                    row += DateToString(reader[(int)PORel.ExAsiaDate].ToString()) + "\t";
                    row += boolstr_to_int(reader[(int)PORel.OpenRelease].ToString()) + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_Vendor()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "Vendor.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_Vendor(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)Vendor.Company] + "\t";
                    row += reader[(int)Vendor.VendorID] + "\t";
                    row += reader[(int)Vendor.Name] + "\t";
                    row += reader[(int)Vendor.VendorNum] + "\t";
                    row += reader[(int)Vendor.Address1] + "\t";
                    row += reader[(int)Vendor.Address2] + "\t";
                    row += reader[(int)Vendor.Address3] + "\t";
                    row += reader[(int)Vendor.City] + "\t";
                    row += reader[(int)Vendor.State] + "\t";
                    row += reader[(int)Vendor.ZIP] + "\t";
                    row += reader[(int)Vendor.Country] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_Part()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "Part.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_Part(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)Part.Company] + "\t";
                    row += reader[(int)Part.partNum] + "\t";
                    string partDescr = reader[(int)Part.PartDescription].ToString();
                    row += partDescr.Trim() + "\t";
                    row += reader[(int)Part.ProdCode] + "\t";
                    row += reader[(int)Part.BasePart] + "\t";
                    row += reader[(int)Part.PrintType] + "\t";
                    row += reader[(int)Part.UnitPrice] + "\t";
                    row += boolstr_to_int(reader[(int)Part.RunOut].ToString()) + "\t";                    
                    row += reader[(int)Part.SearchWord] + "\t";
                    row += reader[(int)Part.TypeCode] + "\t";
                    row += boolstr_to_int(reader[(int)Part.Inactive].ToString()) + "\t";
                    row += reader[(int)Part.ClassID] + "\t";
                    row += reader[(int)Part.SellingFactor] + "\t";
                    row += reader[(int)Part.LOC] + "\t";
                    row += reader[(int)Part.AICDesc] + "\t";
                    row += reader[(int)Part.Brand] + "\t";
                    row += reader[(int)Part.CasePack] + "\t";
                    row += reader[(int)Part.ColorAssortment] + "\t";
                    row += reader[(int)Part.DirectShip] + "\t";
                    row += reader[(int)Part.ListPrice] + "\t";
                    row += reader[(int)Part.Flyer] + "\t";
                    row += reader[(int)Part.FlyerName] + "\t";
                    row += reader[(int)Part.TeamSpirit] + "\t";
                    row += reader[(int)Part.OrderingType] + "\t";
                    row += reader[(int)Part.PrintOptions] + "\t"; 
                    row += reader[(int)Part.MinimumWOS] + "\t";
                    row += reader[(int)Part.MaximumWOS] + "\t";
                    row += reader[(int)Part.League] + "\t";
                    row += reader[(int)Part.TeamPartDescrption] + "\t";
                    row += reader[(int)Part.ARCoating] + "\t";
                    row += reader[(int)Part.CoordinatedCase] + "\t";
                    row += reader[(int)Part.RxAdaptable] + "\t";
                    row += reader[(int)Part.SpringHinge] + "\t";
                    row += reader[(int)Part.Program] + "\t";
                    row += reader[(int)Part.ProgramLOC] + "\t";
                    row += reader[(int)Part.SalesUM] + "\t";
                    row += reader[(int)Part.RetailPrice] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_Customer()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "Customer.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_Customer(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)Customer.CustID] + "\t";
                    row += reader[(int)Customer.CustNum] + "\t";
                    row += reader[(int)Customer.Name] + "\t";
                    row += reader[(int)Customer.Address1 ] + "\t";
                    row += reader[(int)Customer.Address2] + "\t";
                    row += reader[(int)Customer.Address3] + "\t";
                    row += reader[(int)Customer.City] + "\t";
                    row += reader[(int)Customer.State] + "\t";
                    row += reader[(int)Customer.Zip] + "\t";
                    row += reader[(int)Customer.Country] + "\t";
                    row += reader[(int)Customer.TerritoryID] + "\t";
                    row += reader[(int)Customer.SalesRepCode] + "\t";
                    row += reader[(int)Customer.TermsCode] + "\t";
                    row += reader[(int)Customer.ShipViaCode] + "\t";
                    row += reader[(int)Customer.GroupCode] + "\t";
                    row += reader[(int)Customer.SalesCatID] + "\t";
                    row += reader[(int)Customer.CreditHold] + "\t";
                    row += reader[(int)Customer.ResaleID] + "\t";
                    row += reader[(int)Customer.PrintStatements] + "\t";
                    row += reader[(int)Customer.TaxExempt] + "\t";
                    row += reader[(int)Customer.TaxRegionCode] + "\t";
                    row += reader[(int)Customer.CreditLimit] + "\t";
                    row += reader[(int)Customer.PhoneNum] + "\t";
                    row += reader[(int)Customer.BuyGroupCustID] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_ShipVia()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "ShipVia.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_ShipVia(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)ShipVia.Company] + "\t";
                    row += reader[(int)ShipVia.Description] + "\t";
                    row += reader[(int)ShipVia.ShipViaCode] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_Terms()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "Terms.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_Terms(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)Terms.Company] + "\t";
                    row += reader[(int)Terms.TermsCode] + "\t";
                    row += reader[(int)Terms.Description] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_SalesRep()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "SaleRep.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_SalesRep(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)SalesRep.Company] + "\t";
                    row += reader[(int)SalesRep.SalesRepCode] + "\t";
                    row += reader[(int)SalesRep.Name] + "\t";
                    row += reader[(int)SalesRep.CommissionPercent] + "\t";
                    row += reader[(int)SalesRep.CommissionEarnedAt] + "\t";
                    row += boolstr_to_int(reader[(int)SalesRep.AlertFlag].ToString()) + "\t";
                    row += reader[(int)SalesRep.EMailAddress] + "\t";
                    row += reader[(int)SalesRep.WebSaleGetsCommission] + "\t";
                    row += reader[(int)SalesRep.bgCommRate] + "\t";
                    row += reader[(int)SalesRep.BonusCalcRate] + "\t";
                    row += reader[(int)SalesRep.ReaderRate] + "\t";
                    row += boolstr_to_int(reader[(int)SalesRep.InActive].ToString()) + "\t";
                    row += boolstr_to_int(reader[(int)SalesRep.RunCommReport].ToString()) + "\t";
                    row += reader[(int)SalesRep.OfficePhoneNum] + "\t";
                    row += reader[(int)SalesRep.CellPhoneNum] + "\t";
                    row += reader[(int)SalesRep.HomePhoneNum] + "\t";
                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_SalesTer()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "SaleTer.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_SalesTer(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)SalesTer.Company] + "\t";
                    row += reader[(int)SalesTer.ConsToPrim] + "\t";
                    row += reader[(int)SalesTer.DefTaskSetID] + "\t";
                    row += boolstr_to_int(reader[(int)SalesTer.Inactive].ToString()) + "\t";
                    row += reader[(int)SalesTer.PrimeSalesRepCode] + "\t";
                    row += reader[(int)SalesTer.RegionCode] + "\t";
                    row += reader[(int)SalesTer.TerritoryDesc] + "\t";
                    row += reader[(int)SalesTer.TerritoryID] + "\t";
                    row += reader[(int)SalesTer.OverrideCommRate] + "\t";

                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private void run_OrderxxxRel()
        {
            using (SqlConnection connection = new SqlConnection(
                this.connectionString))
            {
                string file_name = "OrderRel.txt";
                string file = Path.Combine(transfer_out_base, file_name);
                var writer = File.CreateText(file);

                sql_select select = new sql_select();

                SqlCommand command = new SqlCommand(select.Sql_OrderRel(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string row = counter.ToString() + "\t";
                    row += reader[(int)OrderRel.Company] + "\t";

                    row += "fill\n";
                    writer.Write(row);
                }
                writer.Close();
            }
        }
        private string DateToString(string fullDate)
        {
            string yyyymmdd_Date = "";
            if (fullDate.Length > 10)
            {
                string justDate = fullDate.Substring(0, 10).Trim();
                char[] delimiterChars = { ' ', '/' };
                string[] date_array = justDate.Split(delimiterChars);
                yyyymmdd_Date = System.Convert.ToInt32(date_array[2]).ToString("D4");
                yyyymmdd_Date += System.Convert.ToInt32(date_array[0]).ToString("D2");
                yyyymmdd_Date += System.Convert.ToInt32(date_array[1]).ToString("D2");
            }
            else
            {
                yyyymmdd_Date = fullDate;
            }
            return yyyymmdd_Date;
        }
        private int boolstr_to_int(string value)
        {
            int row = 1;
            if (value.Equals("False"))
            {
                row = 0;
            }
            else
            {
                row = 1;
            }
            return row;
        }
    }
}