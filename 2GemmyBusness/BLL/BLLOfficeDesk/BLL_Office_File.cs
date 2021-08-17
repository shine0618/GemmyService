using _1GemmyModel;
using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficeDesk
{
   public class BLL_Office_File:BLLBase
    {

        public BLL_Office_File()
        {
            bll_desk = new BLL_Office_desk();

        }
        public BLL_Office_desk bll_desk = null;

        /// <summary>
        /// 获取全部文件
        /// </summary>
        /// <returns></returns>
        public List<T_Office_Files> GetAllFiles()
        {
            var entity = read_db.T_Office_Files.ToList();
            return entity;
        }

        /// <summary>
        /// 根据桌子查找所有的资料
        /// </summary>
        /// <param name="deskid"></param>
        /// <returns></returns>
        public List<T_Office_Files> GetT_Office_Files(int deskid)
        {
            //先获取桌子
            T_Product_office_desk_detail desk = bll_desk.GetT_Product_office_desk_detail(deskid,"");

            //再获取这个桌子的所有文件
            var query = from x in read_db.T_Office_Files
                        where x.Mode == desk.Mode || x.Mode == desk.ColumnType || x.Mode == desk.FootType || x.Mode == desk.SideBracketType || x.Mode == desk.FrameType ||x.Mode==desk.HandsetType ||x.Mode==desk.ControlboxType
                        select x;

            List<T_Office_Files> flist = new List<T_Office_Files>();
            foreach(T_Office_Files f in query)
            {
                if(string.IsNullOrEmpty( f.thumbnailImg))
                {
                    if(f.Type.Replace(".","").ToLower().Contains("doc"))
                    {
                        f.thumbnailImg = "/resourse/Img/word_icon.png";
                    }
                    if(f.Type.Replace(".", "").ToLower().Contains("excel"))
                    {
                        f.thumbnailImg = "/resourse/Img/excel_icon.png";
                    }
                    if (f.Type.Replace(".", "").ToLower().Contains("png"))
                    {
                        f.thumbnailImg = "/resourse/Img/png_icon.png";
                    }
                    if(f.Type.Replace(".", "").ToLower().Contains("pdf"))
                    {
                        f.thumbnailImg = "/resourse/Img/pdf_icon.png";
                    }
                    if (f.Type.Replace(".", "").ToLower().Contains("mp4"))
                    {
                        f.thumbnailImg = "/resourse/Img/mp4_icon.png";
                    }
                    if (f.Type.Replace(".", "").ToLower().Contains("jpg"))
                    {
                        f.thumbnailImg = "/resourse/Img/jpg_icon.png";
                    }
                }

                flist.Add(f);
            }


            return query.ToList();
        }


  

        public List<T_Office_Files> GetAllFilesByDetail(string parttype,string nature,string mode)
        {
            if (string.IsNullOrEmpty(parttype) && string.IsNullOrEmpty(nature) && string.IsNullOrEmpty(mode))
            {
                return null;
            }
            else
            {
                var query = from x in read_db.T_Office_Files                            
                            select x;
                if (!string.IsNullOrEmpty(parttype))
                {
                    query = query.Where(m => m.partType == parttype);
                }
                if (!string.IsNullOrEmpty(mode))
                {
                    query = query.Where(m => m.Mode == mode);
                }
                if (!string.IsNullOrEmpty(nature))
                {
                    if (nature.Contains("|"))
                    {
                        var q = nature.Split('|');
                        var a = new List<T_Office_Files>();
                        var b = new List<T_Office_Files>();
                        var c = new List<T_Office_Files>();
                        var d = new List<T_Office_Files>();
                        var e = new List<T_Office_Files>();
                        //IQueryable<T_Office_Files> a;
                        //IQueryable<T_Office_Files> b;
                        //IQueryable<T_Office_Files> c;
                        //IQueryable<T_Office_Files> d;
                        //IQueryable<T_Office_Files> e;
                        for (int i = 0; i < q.Length; i++)
                        {
                            switch (q[i])
                            {
                                case "文件资料":a = query.Where(m => m.Nature == "文件资料").ToList();
                                    break;
                                case "认证":
                                    b = query.Where(m => m.Nature == "认证").ToList();
                                    break;
                                case "产品图3D":
                                    c = query.Where(m => m.Nature == "产品图3D").ToList();
                                    break;
                                case "产品图2D":
                                    d = query.Where(m => m.Nature == "产品图2D").ToList();
                                    break;
                                case "产品介绍":
                                    e = query.Where(m => m.Nature == "产品介绍").ToList();
                                    break;
                            }
                        }
                        a.AddRange(b);
                        a.AddRange(c);
                        a.AddRange(e);
                        a.AddRange(d);
                        return a;
                    }
                    else
                    {
                        query = query.Where(m => m.Nature == nature);
                    }
                    
                }
                
                return query.ToList();
            }
            
        }

        #region ADD

        public int AddT_Office_Files(T_Office_Files model)
        {
            //有效性检查
            try
            {
                using (DBGemmyService2 d = new DBGemmyService2())
                {
                    d.T_Office_Files.Add(model);
                    return d.SaveChanges();
                }
            }
            catch (Exception)
            {

                return 0;
            }

            

        }

        #endregion
    }
}
