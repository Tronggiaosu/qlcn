using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WASSPRO_TDC_WEBSERVICE
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        Entities db = new Entities();
        public static DataTable ListToDataTable<T>(List<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dataTable = new DataTable();

            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }

                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
        [WebMethod]
        public string CapNhatThanhToan(string UserID, string Password, decimal ID_HD, string madanhbo, string magiaodich, DateTime thoigianthu)
        {
            if (Password != "Vnpt@2018")
                return "Invalid password";
            else
            {
                try
                {
                    var user = db.DM_NGANHANG.Where(x => x.MA_NGANHANG == UserID).FirstOrDefault();
                    if (user == null) return "Invalid UserID";
                    else
                    {
                        
                        var pub = db.PublishedInvoices.Where(x => x.IDHD == ID_HD).FirstOrDefault();
                        if (pub.GACH_NO == "1") return "Invalid Invoice";
                        else
                        {
                            var hoadon = db.HOADONs.Where(x => x.ID_HD == ID_HD).FirstOrDefault();
                            if (hoadon == null) return "Invalid Invoice";
                            else
                            {
                                var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == madanhbo).FirstOrDefault();
                                if (khachhang == null) return "Invalid Customer";
                                else
                                {
                                    pub.GACH_NO = "1";
                                    db.SaveChanges();
                                    db.GACHNOes.Add(new GACHNO()
                                    {
                                        ID_HD = hoadon.ID_HD,
                                        ID_KH = hoadon.ID_KH,
                                        DOT_ID = hoadon.DOT_ID,
                                        ID_KYGHI = hoadon.kyghi,
                                        KYHIEU = hoadon.KY_HIEU_HD,
                                        MALOAI = user.LOAI,
                                        MALT = hoadon.MaLT,
                                        MAUSO = hoadon.MAU_HD,
                                        NGAYTHANHTOAN = DateTime.Now,
                                        NV_ID_NOP = user.NGANHANG_ID,
                                        SOHD = hoadon.SO_HD,
                                        TIENTHUE_GTGT = hoadon.tienvat,
                                        TONGTIENBVMT = hoadon.tienBVMT,
                                        TONGTIEN = hoadon.tongtien0VAT,
                                        TONGTHANHTOAN = hoadon.tongtien,
                                        NAM_ID = hoadon.nam,
                                        DATE_CREATE = DateTime.Now,
                                        STATUS = false, 
                                        PRODUCTS = magiaodich
                                    });
                                    db.SaveChanges();
                                    return "OK";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "Error " + ex;
                }
            }
            
        }
        [WebMethod]
        public string CapNhatThanhToan_List(string UserID, string Password, decimal[] ID_HD_List, string madanhbo, string magiaodich, DateTime thoigianthu)
        {
            string kq = "";
            if (Password != "Vnpt@2018")
                return "Invalid password";
            else
            {
                try
                {                   
                    var user = db.DM_NGANHANG.Where(x => x.MA_NGANHANG == UserID).FirstOrDefault();
                    if (user == null) return "Invalid UserID";
                    else
                    {
                        string result = "";
                        foreach (decimal ID_HD in ID_HD_List)
                        {
                            string strIDHD = ID_HD.ToString();
                            var pub = db.PublishedInvoices.Where(x => x.KEY == strIDHD && x.GACH_NO == "1").FirstOrDefault();
                            if (pub != null) result = "Invalid Invoice";
                            else
                            {
                                var hoadon = db.HOADONs.Where(x => x.ID_HD == ID_HD).FirstOrDefault();
                                if (hoadon == null) result= "Invalid Invoice";
                                else
                                {
                                    var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == madanhbo).FirstOrDefault();
                                    if (khachhang == null) result= "Invalid Customer";
                                }
                            }
                        }
                        if (result == "")
                        {

                            List<GACHNO> listGachno = new List<GACHNO>();
                            List<PublishedInvoice> listPublish = new List<PublishedInvoice>();
                            foreach (decimal ID_HD in ID_HD_List)
                            {
                                var hoadon = db.HOADONs.Where(x => x.ID_HD == ID_HD && x.gachno == false).FirstOrDefault();
                                var published = db.PublishedInvoices.Where(x => x.IDHD == ID_HD && (x.GACH_NO == null || x.GACH_NO == "0")).FirstOrDefault();
                                listPublish.Add(published);
                                listGachno.Add(new GACHNO()
                                {
                                    ID_HD = hoadon.ID_HD,
                                    ID_KH = hoadon.ID_KH,
                                    DOT_ID = hoadon.DOT_ID,
                                    ID_KYGHI = hoadon.kyghi,
                                    KYHIEU = hoadon.KY_HIEU_HD,
                                    MALOAI = user.LOAI,
                                    MALT = hoadon.MaLT,
                                    MAUSO = hoadon.MAU_HD,
                                    NGAYTHANHTOAN = thoigianthu,
                                    NV_ID_NOP = user.NGANHANG_ID,
                                    SOHD = hoadon.SO_HD,
                                    TIENTHUE_GTGT = hoadon.tienvat,
                                    TONGTIENBVMT = hoadon.tienBVMT,
                                    TONGTIEN = hoadon.tongtien0VAT,
                                    TONGTHANHTOAN = hoadon.tongtien,
                                    NAM_ID = hoadon.nam,
                                    DATE_CREATE = thoigianthu,
                                    STATUS = false,
                                    PRODUCTS = magiaodich
                                });
                            }
                            db.GACHNOes.AddRange(listGachno);
                            listPublish.ForEach(x => x.GACH_NO = "1");
                            db.SaveChanges();
                            return "OK";
                        }
                        else return result;
                    }                    
                }
                catch (Exception ex)
                {
                    return "Error " + ex;
                }
            }

        }
        [WebMethod]
        public string XoaThanhToan(string UserID, string Password, decimal ID_HD, string madanhbo)
        {
            if (Password != "Vnpt@2018")
                return "Invalid password";
            else
            {
                try
                {
                    var user = db.DM_NGANHANG.Where(x => x.MA_NGANHANG == UserID).FirstOrDefault();
                    if (user == null) return "Invalid UserID";
                    else
                    {
                        string strIDHD = ID_HD.ToString();
                        var pub = db.CHUNGTU_HOADON.Where(x => x.ID_HD == ID_HD).FirstOrDefault();
                        if (pub != null) return "Invalid Invoice";
                        else
                        {  
                            var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == madanhbo).FirstOrDefault();
                            if (khachhang == null) return "Invalid Customer";
                            else
                            {
                                db.XoaNothuHo(ID_HD, Convert.ToInt32(user.NGANHANG_ID));                              
                                return "OK";
                            }
                          
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "Error " + ex;
                }
            }

        }
        [WebMethod]
        public string KiemTraHoaDon(string UserID, string Password, decimal ID_HD, string madanhbo)
        {            
            if (Password != "Vnpt@2018")
                return "Invalid password";
            else
            {
                try
                {
                    var user = db.DM_NGANHANG.Where(x => x.MA_NGANHANG == UserID).FirstOrDefault();
                    if (user == null) return "Invalid UserID";
                    else
                    {
                        var parIDHD = new SqlParameter("@IDHD", ID_HD);
                        return db.Database.SqlQuery<string>("getStatusInvoices @IDHD", parIDHD).FirstOrDefault();
                    }
                }
                catch
                {
                    return "Error";
                }
            }
        }
        [WebMethod]
        public string KiemTraHoaDon_List(string UserID, string Password, decimal[] ID_HD_List, string madanhbo)
        {
            string kq = "";
            if (Password != "Vnpt@2018")
                return "Invalid password";
            else
            {
                try
                {
                    var user = db.DM_NGANHANG.Where(x => x.MA_NGANHANG == UserID).FirstOrDefault();
                    if (user == null) return "Invalid UserID";
                    else
                    {
                        for (int i = 0; i < ID_HD_List.Count(); i++)              
                        {
                            decimal ID_HD = ID_HD_List[i];
                            var hoadon = db.HOADONs.Where(x => x.ID_HD == ID_HD).FirstOrDefault();
                            if (hoadon == null) return "Invalid Invoice";
                            else
                            {
                                var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == madanhbo).FirstOrDefault();
                                if (khachhang == null) return "Invalid Customer";
                                else
                                {
                                    var parIDHD = new SqlParameter("@IDHD", hoadon.ID_HD);
                                    kq += db.Database.SqlQuery<string>("getStatusInvoices @IDHD", parIDHD).FirstOrDefault();
                                    if (i < ID_HD_List.Count() - 1)
                                    {
                                        kq += ";";
                                    }
                                }
                            }
                        }
                        return kq;
                    }
                }
                catch
                {
                    return "Error";
                }
            }
        }
        [WebMethod]
        public string TraCuuKhachHang(string UserID, string Password, string madanhbo)
        {
            if (Password != "Vnpt@2018")
                return "Invalid password";
            else
            {
                try
                {
                    var user = db.DM_NGANHANG.Where(x => x.MA_NGANHANG == UserID).FirstOrDefault();
                    if (user == null) return "Invalid UserID";
                    else
                    {   
                        var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == madanhbo).FirstOrDefault();
                        if (khachhang == null) return "Invalid Customer";
                        else
                        {
                            return khachhang.madanhbo + "|" + khachhang.hoten_KH + "|" + khachhang.sonha + "|" + khachhang.diachi + "|" + db.DM_PHUONG.Where(x => x.maPhuong == khachhang.maphuong).FirstOrDefault().tenPhuong
                                + "|" + db.DM_QUAN.Where(x => x.maQuan == khachhang.maquan).FirstOrDefault().tenQuan + "|" + khachhang.MST_KH + "|" + khachhang.maLT + "|" + khachhang.maDT;
                        }                        
                    }
                }
                catch
                {
                    return "Error";
                }
            }
        }
        [WebMethod]
        public DataTable TraCuuHoaDon(string UserID, string Password, string madanhbo)
        {
            DataTable table = new DataTable(); // Creating datatable.
            table.Columns.Add("Nam", typeof(int));
            table.Columns.Add("Ky", typeof(string));
            table.Columns.Add("SoHD", typeof(string));
            table.Columns.Add("CSCu", typeof(int));
            table.Columns.Add("CSMoi", typeof(int));
            table.Columns.Add("TongTien", typeof(decimal));           
            if (Password != "Vnpt@2018")
                table.Rows.Add(0, "", "Invalid password", 0, 0, 0);
            else
            {  
                var user = db.DM_NGANHANG.Where(x => x.MA_NGANHANG == UserID).FirstOrDefault();
                if (user == null) table.Rows.Add(0, "", "Invalid UserID", 0, 0, 0);
                else
                {
                    var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == madanhbo).FirstOrDefault();
                    if (khachhang == null) table.Rows.Add(0, "", "Invalid Customer", 0, 0, 0);
                    else
                    {
                        var hoadon = db.HOADONs.Where(x => x.gachno == false && x.KHACHHANG.madanhbo == madanhbo).Select(x => new { x.nam, x.kyghi, x.SO_HD, x.CSCu, x.CSMoi, x.tongtien });
                        table = ListToDataTable(hoadon.OrderByDescending(x=>x.kyghi).ToList());
                    }
                }              
            }
            table.TableName = "KetQua";
            return table;
        }
        [WebMethod]
        public DataTable DSHoaDon(string madanhbo)
        {
            DataTable table = new DataTable();
            var ds = db.listInvByCus(madanhbo);
            table = ListToDataTable(ds.OrderByDescending(x => x.kyghi).ToList());            
            table.TableName = "KetQua";
            return table;
        }
    }
}