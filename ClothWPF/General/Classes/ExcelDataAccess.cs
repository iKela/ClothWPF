using System;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Windows.Data;
using ClothWPF.Entities;
using System.Transactions;
using System.Collections.Generic;
using ClothWPF.Authorization.Loading;


namespace ClothWPF.General.Classes
{
    public class ExcelItem
    {
        public Int64 UId { get; set; } //Уникальный_идентификатор
        public string Code { get; set; } //Код_товара
        public string Name { get; set; } //Название_позиции
        public double? PriceUah { get; set; } //Цена
        public double? PriceWholesale { get; set; } //Оптовая_цена
        public int? Count { get; set; } //Количество
        public string Country { get; set; } //Страна_производитель
        //public double ItemDiscount { get; set; } //Скидка
    }

    public class DataAccess
    {
        private  EfContext context;

        OleDbConnection Conn;
        OleDbCommand Cmd;
       

        public DataAccess(EfContext context)
        {
           this.context = context;
            try
            {
                Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\koval\\Downloads\\Exoirt.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"");
            }
            catch (Exception ex)
            {
                //Dispatcher.BeginInvoke(new Action(() =>
                //{
                //    int a=25;
                //}));
                int a = 23;


            }
        }
        public async Task<ObservableCollection<ExcelItem>> GetDataFormExcelAsync()
        {
            // this.context = context;
            //ObservableCollection<ExcelItem> Items = new ObservableCollection<ExcelItem>();
            await Conn.OpenAsync();
            Cmd = new OleDbCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from [Export Products Sheet$]";
            var Reader = await Cmd.ExecuteReaderAsync();    
            
            try
            {
                
                //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Product]");
                while (Reader.Read())
                {
                    var data = new ExcelItem()
                    {
                        //Місце для присвоєння інформації з Ексель до локальних змінних в класі ExcelItem
                        UId = Convert.ToInt64((Reader["Уникальный_идентификатор"].ToString() != "") ? Reader["Уникальный_идентификатор"] : 0),
                        Code = Reader["Код_товара"].ToString(),
                        Name = Reader["Название_позиции"].ToString(),
                        PriceUah = Convert.ToDouble((Reader["Цена"].ToString() != "") ? Reader["Цена"] : 0),
                        PriceWholesale = Convert.ToDouble((Reader["Оптовая_цена"].ToString() != "") ? Convert.ToDouble(Reader["Оптовая_цена"].ToString().Replace(".", ",").Substring(0, 5 /*Довжина символів після ких буде все обрізатись виставлена в ручну!!!Потрібно визначити щоб обраізало після ;*/)) : 0), // 
                        Count = Convert.ToInt32((Reader["Количество"].ToString() != "") ? Reader["Количество"] : 0),
                        Country = Reader["Страна_производитель"].ToString(),
                        //ItemDiscount = Convert.ToInt32(Reader["Скидка"])      
                    };
                    var uid = ConstList._FullInfo.Find(a => a.Uid == data.UId);
                    if(uid!=null)
                        ConstList.excelItems.Add(data);
                }
                    Reader.Close();
                    Conn.Close();
                //using (TransactionScope scope = new TransactionScope())
                //{
                
                //    context.Configuration.AutoDetectChangesEnabled = false;
                //    context.Configuration.ValidateOnSaveEnabled = false;
                //int i = 0;
                //foreach (var Eitem in Items)
                //{
                //    i++;
                //    var d = context.Products
                //        .SingleOrDefault(a => a.Uid == Eitem.UId);
                //    if (d != null )
                //    {
                //        context.Products.Add(new Product
                //        {
                //            Uid = Eitem.UId,
                //            Name = Eitem.Name,
                //            Code = Eitem.Code,
                //            Count = Eitem.Count,
                //            PriceUah = Eitem.PriceUah,
                //            PriceWholesale = Eitem.PriceWholesale,
                //            Country = Eitem.Country
                //            // Idgroup = 2
                //        });
                //    }

                //}
                //    context.SaveChanges();
                //    context.Configuration.AutoDetectChangesEnabled = true;
                //    context.Configuration.ValidateOnSaveEnabled = true;
                ////    scope.Complete();
             //   }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ConstList.GetExcelItems;
        }
        //public async Task<bool> InsertOrUpdateRowInExcelAsync(ExcelItem item)
        //{
        //    bool IsSave = false;
        //    //S1
        //    if (item.ItemCode != 0)
        //    {
        //        await Conn.OpenAsync();
        //        Cmd = new OleDbCommand();
        //        Cmd.Connection = Conn;
        //        Cmd.Parameters.AddWithValue("@Уникальный_идентификатор", item.UId);
        //        Cmd.Parameters.AddWithValue("@Код_товара", item.ItemCode);
        //        Cmd.Parameters.AddWithValue("@Название_позиции", item.ItemName);
        //        Cmd.Parameters.AddWithValue("@Цена", item.ItemPrice);
        //        Cmd.Parameters.AddWithValue("@Оптовая_цена", item.ItemWholeSalePrice);
        //        Cmd.Parameters.AddWithValue("@Количество", item.ItemCount);
        //        Cmd.Parameters.AddWithValue("@Страна_производитель", item.ItemCountry);
        //        Cmd.Parameters.AddWithValue("@Скидка", item.ItemDiscount);
        //        //S2
        //        if (!CheckIfRecordExistAsync(item).Result)
        //        {
        //            Cmd.CommandText = "Insert into [Sheet1$] values (@EmpNo,@EmpName,@Salary,@DeptName)";
        //        }
        //        else
        //        {
        //            if (item.ItemName != String.Empty || item.ItemName != String.Empty)
        //            {
        //                Cmd.CommandText = "Update [Export Products Sheet$] set EmpNo=@EmpNo,EmpName=@EmpName,Salary=@Salary,DeptName=@DeptName where EmpNo=@EmpNo";
        //            }
        //        }
        //        int result = await Cmd.ExecuteNonQueryAsync();
        //        if (result > 0)
        //        {
        //            IsSave = true;
        //        }
        //        Conn.Close();
        //    }
        //    return IsSave;

        //}
        //private async Task<bool> CheckIfRecordExistAsync(ExcelItem item)
        //{
        //    bool IsRecordExist = false;
        //    Cmd.CommandText = "Select * from [Export Products Sheet$] where ItemCode=@Код_товара";
        //    var Reader = await Cmd.ExecuteReaderAsync();
        //    if (Reader.HasRows)
        //    {
        //        IsRecordExist = true;
        //    }

        //    Reader.Close();
        //    return IsRecordExist;
        //}
    }

}
