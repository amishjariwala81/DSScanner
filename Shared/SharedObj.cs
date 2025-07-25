//using Bumptech.Glide.Util;
using JSCoreLibRazor;
using SQLite;
using Syncfusion.Blazor.Buttons;
using Syncfusion.Blazor.Calendars;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSScanner.Shared
{
    public class Global
    {
#if DEBUG
         public static string APIURL = "http://192.168.1.66:44333/api";
       //  public static string APIURL = "http://115.96.27.178:44333/api";
#else
        public static string APIURL = "http://115.96.27.178:44333/api";
#endif
        public static string MobileNo = String.Empty;
        public static string AppType = "DSScanner";
        public static string SYSAdminMob = "9998970699";
        //public static string UserName = String.Empty;
        public static string AppVersion = "1.1.1";        
        public static int SaudId = 0;
        public static int SaudDetId = 0;
        public static string EntryNo = string.Empty;
        public static bool IsInterNetConnected = false;
        public static SQLConnStr MainDBConnStr = new()
        { 
            AppType = "DSScanner", 
            DBServer = "(local)\\SQL2016", 
            DBName = "DreamSmart", 
            UserName = "sa", 
            Password = "Jupiter@304#" 
        };
        public static SQLConnStr PtyDBConnStr = new();
        public static string PtyAPIURL = "";
        public static string UserName = "";
        public static string UserType = "";
        public static string ItemType = "GREY";
        public static string SaudaType = "1";
        public static string UnitType = string.Empty;
        //public static string MainDB = "";
        public static void ExitApp()
        {
            Environment.Exit(0);
        }
    }    

    public class ProductionTbl
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string SrNo { get; set; }
        public string EntryNo { get; set; }
        public int SadaId { get; set; }
        public int SadaDetId { get; set; }
        public string PDate { get; set; }
        public string TakaNo { get; set; }
        public double Pcs { get; set; }
        public double NetWt { get; set; }
        public double Meters { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public string MergeNo { get; set; }
        public int MergeNoId { get; set; }
        public string Grade { get; set; }
        public string Shade { get; set; }
        public int GradeId { get; set; }        
        public int PlantId { get; set; }
        public string Plant { get; set; }
        public string ShadeId { get; set; }        
        public string ChlnNo { get; set; }        
        public string ChlnDate { get; set; }
        public string Exported { get; set; }
        public int EntSr { get; set; }
    }

    public class SaudTbl
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int DetId { get; set; }
        public string SNo {  get; set; }
        public string DoNo { get; set; }
        public string SDate { get; set; }
        public double OrdQty { get; set; }  
        public double DevQty { get; set; } // -> Mobile ScanQty.
        public double BalQty { get; set; }
        public double DelQty { get; set; }
        public double Meters { get; set; }
        public double NetWt { get; set; }
        public string ItemName { get; set; }
        public string MergeNo { get; set; }
        public string Grade { get; set; }
        public string Shade { get; set; }
        public string UOM { get; set; }
        public string Plant { get; set; }
        public int ItemId { get; set; }
        public int MergeNoId { get; set; }
        public int GradeId { get; set; }
        public int PlantId { get; set; }
        public int ShadeId { get; set; }
        public string Scanned { get; set; }
        public string Exported { get; set; }                      
        public string ItemCode { get; set; }        
        public string SaudaType { get; set; }
    }
}