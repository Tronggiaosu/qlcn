using System.Collections.Generic;
using System.Linq;

namespace QLCongNo.Data
{
    internal class DataDanhMuc
    {
        public static List<NHANVIEN> getDSNhanvien(decimal? TOID)
        {
            CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
            List<NHANVIEN> data = new List<NHANVIEN>();
            var dsNhanvien = db.NHANVIENs.ToList();
            if (Common.ChucvuID != 4 && Common.ChucvuID == 1)
                dsNhanvien = dsNhanvien.Where(x => x.TO_ID != 0 && x.TO_ID == TOID).OrderBy(x => x.maNV).ToList();
            else if (Common.ChucvuID != 4 && Common.ChucvuID != 1)
            {
                data.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
                dsNhanvien = dsNhanvien.Where(x => x.TO_ID != 0 && (x.TO_ID == TOID || TOID == -1)).OrderBy(x => x.maNV).ToList();
            }
            else
                dsNhanvien = dsNhanvien.Where(x => x.NV_ID == Common.NVID).ToList();
            data.AddRange(dsNhanvien);
            return data;
        }

        public static List<DM_TO> getDSTo(decimal? TOID)
        {
            CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
            var dsTo = db.DM_TO.ToList();
            List<DM_TO> data = new List<DM_TO>();
            if (Common.ChucvuID != 4 && Common.ChucvuID == 1)
                dsTo = dsTo.Where(x => x.TO_ID != 0 && (x.TO_ID == TOID)).OrderBy(x => x.TENTO).ToList();
            else if (Common.ChucvuID != 4 && Common.ChucvuID != 1)
            {
                data.Add(new DM_TO() { TO_ID = -1, TENTO = "Tất cả" });
                dsTo = dsTo.Where(x => x.TO_ID != 0 && (x.TO_ID == TOID || TOID == -1)).OrderBy(x => x.TENTO).ToList();
            }
            else
            {
                if (Common.TOID == -1)
                    dsTo = dsTo.Where(x => x.TO_ID == 0).ToList();
            }

            data.AddRange(dsTo);
            return data;
        }
    }
}