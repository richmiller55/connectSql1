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
                // run_ContainerDetail();
            // run_ContainerHeader();
            run_ShipTo();
            run_ShipHead();
            
            run_InvcDtl();
            run_InvcHeadEx();
            run_InvcMisc();
            run_InvcTax();
                  
            run_OrderDtl();
            run_OrderHed();
            run_OrderRel();
            
            /*   
            run_CustGrup();
            run_PartBin();
            run_Customer();
            run_Part();          
             * */
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
                    row += reader[(int)OrderHed.ShortChar01] + "\t";
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
                    row += reader[(int)OrderHed.VoidOrder] + "\t";
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
                    row += reader[(int)InvcHeadEx.CreditMemo] + "\t";
                    row += reader[(int)InvcHeadEx.DocInvoiceAmt] + "\t";
                    row += reader[(int)InvcHeadEx.InvoiceAmt] + "\t";
                    row += reader[(int)InvcHeadEx.EntryPerson] + "\t";
                    row += reader[(int)InvcHeadEx.SalesRepList] + "\t";
                    row += reader[(int)InvcHeadEx.StartUp] + "\t";
                    row += reader[(int)InvcHeadEx.Posted] + "\t";
                    row += reader[(int)InvcHeadEx.InvoiceBal] + "\t";
                    row += reader[(int)InvcHeadEx.UnappliedCash] + "\t";
                    row += reader[(int)InvcHeadEx.DebitNote] + "\t";
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
                    row += reader[(int)InvcTax.TaxDivision] + "\t";
                    row += reader[(int)InvcTax.Manual] + "\t";
                    row += DateToString(reader[(int)InvcDtl.ShipDate].ToString()) + "\t";
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
                    row += reader[(int)OrderRel.NeedByDate] + "\t";
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
                    row += reader[(int)ContainerHeader.ShipDate] + "\t";
                    row += reader[(int)ContainerHeader.Shipped] + "\t";
                    row += reader[(int)ContainerHeader.ContainerClass] + "\t";
                    row += reader[(int)ContainerHeader.ContainerCost] + "\t";
                    row += reader[(int)ContainerHeader.ShippingDays] + "\t";
                    row += reader[(int)ContainerHeader.ContainerDescription] + "\t";
                    row += reader[(int)ContainerHeader.Volume] + "\t";
                    row += reader[(int)ContainerHeader.ContainerReference] + "\t";
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
                    row += reader[(int)InvcDtl.InvoiceDate] + "\t";
                    row += reader[(int)InvcDtl.PackNum] + "\t";
                    row += reader[(int)InvcDtl.OrderNum] + "\t";
                    row += reader[(int)InvcDtl.OrderLine] + "\t";
                    row += reader[(int)InvcDtl.ShipDate] + "\t";
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
                    row += reader[(int)ShipHead.ShipDate] + "\t";
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

                SqlCommand command = new SqlCommand(select.Sql_OrderRel(), connection);
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
                    row += reader[(int)Part.PartDescription] + "\t";
                    row += reader[(int)Part.ProdCode] + "\t";
                    row += reader[(int)Part.BasePart] + "\t";
                    row += reader[(int)Part.PrintType] + "\t";
                    row += reader[(int)Part.UnitPrice] + "\t";
                    row += reader[(int)Part.RunOut] + "\t";
                    row += reader[(int)Part.SearchWord] + "\t";
                    row += reader[(int)Part.TypeCode] + "\t";
                    row += reader[(int)Part.Inactive] + "\t";
                    row += reader[(int)Part.ClassID] + "\t";
                    row += reader[(int)Part.SellingFactor] + "\t";
                    row += reader[(int)Part.LOC] + "\t";
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
            return yyyymmdd_Date;
        }
        private int boolstr_to_int(string value)
        {
            int row;
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