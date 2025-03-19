using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WASSPRO_WS
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
        CAPNUOC_LDGEntities db = new CAPNUOC_LDGEntities();

        [WebMethod]
        public string Lawaco_ImportAndPublishInv(string acc_admin, string pass_admin, string xml, string acc_service, string pass_service, string pattern, string serial, int i)
        {
            WASSPRO_WS.Lawaco_Publish.PublishService ws = new Lawaco_Publish.PublishService();
            
            string result = "";
            result = ws.ImportAndPublishInv(acc_admin, pass_admin, xml, acc_service, pass_service, pattern, serial, 0);
            if (result.Substring(0, 2) == "OK")
            {
                StringParserToInv(result);
                result = "OK";
            }
            else
            {
                
                HOADON_LOG hd = new HOADON_LOG();
                hd.xml = xml;
                hd.ngay = DateTime.Now;
                db.HOADON_LOG.Add(hd);
                db.SaveChanges();
            }
            return result;
        }

        private void StringParserToInv(string result)
        {
            string[] patterns;
            string pattern, Serialno;
            //Lấy phần parrten
            patterns = result.Split(';');
            if (patterns.Length > 0)
            {
                //Lấy phần Serialno
                pattern = patterns[0];
                pattern = pattern.Substring(3, pattern.Length - 3);
                //Serialnos = patterns[1].Split('-');

                //Xử lý tách khóa key và số hóa đơn
                int index = patterns[1].IndexOf("-");
                Serialno = patterns[1].Substring(0, index);
                string Data = patterns[1].Substring(index + 1);
                ImportInvoices(pattern, Serialno, Data);
                //seachButton.PerformClick();
            }
        }
        private void ImportInvoices(string pattern, string Serialno, string Data)
        {
            string[] KeyInv;
            KeyInv = Data.Split(',');
            if (KeyInv.Length > 0)
            {
                for (int IdexArr = 0; IdexArr <= KeyInv.Length - 1; IdexArr++)
                {
                    string[] DataArr = KeyInv[IdexArr].Split('_');
                    if (DataArr.Length > 0)
                    {
                        string key = DataArr[0];
                        decimal? id = Convert.ToDecimal(key);
                        string so_hd = DataArr[1];
                        // Update HOADON 
                        var hoadon = (from a in db.HOADONs where a.ID_HD == id select a).FirstOrDefault();
                        hoadon.IsInHD = true;
                        hoadon.KY_HIEU_HD = Serialno;
                        hoadon.MAU_HD = pattern;
                        hoadon.SO_HD = so_hd;
                        hoadon.keys = key;
                        hoadon.ArisingDate = DateTime.Now;
                        db.SaveChanges();

                        // Insert PublishedInvoices
                        var csn = (from a in db.HOADONs
                                   from b in db.CHISONUOCs
                                   where a.ID_KH == b.ID_KH
                                   where a.kyghi == b.ID_kyghi
                                   where a.ID_HD == id
                                   select b).FirstOrDefault();
                        string xml = "select (select diengiai ProdName,null ProdUnit, soluong ProdQuantity,	round(dongia0v,4) ProdPrice, null VATRate, null as VATAmount, CAST(round(thanhtien0v,4) as numeric(18,4)) Amount, null Remark";
                        xml += " from CHITIET_HD Product";
                        xml += " where id_hd=" + hoadon.ID_HD;
                        xml += " order by Product.dongia0v";
                        xml += " FOR XML PATH('Product'), type)	FOR XML PATH ('Products') , type";
                        var xmlProduct = (db.Database.SqlQuery<string>(xml)).ToList();
                        var result = db.Database.ExecuteSqlCommand("exec InsPublishedInvoice @KEY,@IDKH,@KYHD,@SOPHIEU,@SO_HD,@KY_HIEU_HD,@MAU_HD,@SODB,@HOTEN,@DIACHI,@MST,@GIANK,@CSCU,@CSMOI,@M3TT,@PRODUCTS,@CONGTHANHTIEN,@TIENLUUBO,@VAT,@TIENVAT,@GIABVMT,@PBVMT4M3,@TIENPBVMT,@GiaNthai,@PNT4M3,@TIENPNT,@TienthueDH,@TienvthueDH,@TONGCONG,@MAHTTT,@ma_tuyen_cuoc",
                                                new SqlParameter("@KEY", key)
                                                , new SqlParameter("@IDKH", hoadon.ID_KH)
                                                , new SqlParameter("@KYHD", hoadon.kyghi)
                                                , new SqlParameter("@SOPHIEU", hoadon.KHACHHANG.stt_thu)
                                                , new SqlParameter("@SO_HD", so_hd)
                                                , new SqlParameter("@KY_HIEU_HD", Serialno)
                                                , new SqlParameter("@MAU_HD", pattern)
                                                , new SqlParameter("@SODB", hoadon.KHACHHANG.madanhbo)
                                                , new SqlParameter("@HOTEN", hoadon.KHACHHANG.hoten_KH)
                                                , new SqlParameter("@DIACHI", hoadon.KHACHHANG.diachi)
                                                , new SqlParameter("@MST", hoadon.KHACHHANG.MST_KH == null ? "" : hoadon.KHACHHANG.MST_KH)
                                                , new SqlParameter("@GIANK", hoadon.KHACHHANG.maDT + ";" + hoadon.KHACHHANG.soNK.ToString())
                                                , new SqlParameter("@CSCU", csn.chisocu)
                                                , new SqlParameter("@CSMOI", csn.chisomoi)
                                                , new SqlParameter("@M3TT", csn.luongtieuthu)
                                                , new SqlParameter("@PRODUCTS", xmlProduct.FirstOrDefault())
                                                , new SqlParameter("@CONGTHANHTIEN", hoadon.IsLuuBo == true ? 0 : hoadon.tongtien0VAT)
                                                , new SqlParameter("@TIENLUUBO", hoadon.IsLuuBo == true ? hoadon.tongtien0VAT : 0)
                                                , new SqlParameter("@VAT", hoadon.VAT)
                                                , new SqlParameter("@TIENVAT", hoadon.tienvat)
                                                , new SqlParameter("@GIABVMT", hoadon.giabvmt)
                                                , new SqlParameter("@PBVMT4M3", hoadon.tien_V_BVMT)
                                                , new SqlParameter("@TIENPBVMT", hoadon.tienBVMT)
                                                , new SqlParameter("@GiaNthai", hoadon.giaNthai)
                                                , new SqlParameter("@PNT4M3", hoadon.tien_V_NThai)
                                                , new SqlParameter("@TIENPNT", hoadon.tien_NThai)
                                                , new SqlParameter("@TienthueDH", hoadon.tienthueDH)
                                                , new SqlParameter("@TienvthueDH", hoadon.tienvthueDH)
                                                , new SqlParameter("@TONGCONG", hoadon.tongtien)
                                                , new SqlParameter("@MAHTTT", hoadon.KHACHHANG.MA_HTTT.ToString())
                                                , new SqlParameter("@ma_tuyen_cuoc", hoadon.KHACHHANG.maLT.ToString()));
                    }

                }
            }
        }
    }
}