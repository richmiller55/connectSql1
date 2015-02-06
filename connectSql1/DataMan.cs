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
            // run_InvcDtl();
                // run_ContainerDetail();
            // run_ContainerHeader();
            run_OrderHed();
            run_InvcDtl();
            run_OrderDtl();
            run_OrderRel();
          
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
                    row += reader[(int)OrderHed.OpenOrder] + "\t";
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
                    row += reader[(int)OrderDtl.OrderQty] + "\t";
                    row += reader[(int)OrderDtl.OpenLine] + "\t";
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
        private string DateToString(string fullDate)
        {
            string yyyymmdd_Date = "";
            if (fullDate.Length > 10)
            {
                string justDate = fullDate.Substring(0, 10).Trim();
                char[] delimiterChars = { ' ', '/' };
                string[] date_array = justDate.Split(delimiterChars);
                yyyymmdd_Date = System.Convert.ToInt32(date_array[2]).ToString("D4");
                yyyymmdd_Date += System.Convert.ToInt32(date_array[1]).ToString("D2");
                yyyymmdd_Date += System.Convert.ToInt32(date_array[0]).ToString("D2"); 
            }
            return yyyymmdd_Date;
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
    }
}