using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Bai5
{
    internal class CXuLyPhieuThue
    {
        private List<CPhieuThue> dsPT;
        public CXuLyPhieuThue()
        {
            dsPT=new List<CPhieuThue>();
        }
        public List<CPhieuThue> LayDSPhieuThue()
        {
            return dsPT.ToList();
        }
        public CPhieuThue tim(string mapt)
        {
            foreach (CPhieuThue pt in dsPT)
                if (pt.MaPT == mapt)
                    return pt;
            return null;
        }
        public bool them(CPhieuThue pt)
        {
            if (tim(pt.MaPT) == null)
            {
                dsPT.Add(pt);
                return true;
            }
            return false;
        }
        public void Xoa(string mapt)
        {
            CPhieuThue pt=tim(mapt);
            if(pt!=null)
                dsPT.Remove(pt);
        }
        public void Sua(CPhieuThue updPT)
        {
            CPhieuThue pt = tim(updPT.MaPT);
            if (pt != null)
            {
                pt.TenKH=updPT.TenKH;
                pt.NgayBD=updPT.NgayBD;
                pt.NgayKT=updPT.NgayKT;
                pt.LoaiPhong=updPT.LoaiPhong;
            }
        }
        public bool DocFile(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                dsPT = (List<CPhieuThue>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }catch (Exception) { return false; }
        }
        public bool LuuFile(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, dsPT);
                fs.Close();
                return true;
            }catch(Exception) { return false; }
        }
    }
}
