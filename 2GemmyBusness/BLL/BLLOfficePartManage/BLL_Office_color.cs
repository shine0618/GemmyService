using _1GemmyModel;
using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
   public class BLL_Office_color:BLLBase
    {
        public List<T_Office_Color> getColorInfo()
        {
            var t = from x in read_db.T_Office_Color
                    select x;
            if (t != null)
            {
                return t.ToList();
            }
            else
            {
                return null;
            }
        }
        public bool UpdateColorInfo(T_Office_Color t)
        {
            bool issuccess = false;
            if (t != null)
            {
                Update<T_Office_Color>(t);
                issuccess = true;
            }
            return issuccess;
        }

        public bool AddColorInfo(T_Office_Color t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                if (t != null)
                {
                    var entity = db.T_Office_Color.Any(m=>m.ColorName==t.ColorName);
                    if (entity != true)
                    {
                        db.T_Office_Color.Add(t);
                        db.SaveChanges();
                        issuccess = true;
                    }
                    
                }

            }
            return issuccess;
        }

        public bool DeleteColorInfo(T_Office_Color t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_Office_Color.Any(m => m.ColorName == t.ColorName);
                if (entity == true)
                {
                    DeleteEntityByid<T_Office_Color>(t.Id);
                    issuccess = true;
                }

            }
            return issuccess;
        }

        #region 颜色转换lab转rgb

        public static int[] LabToRGB(double l, double a, double b)
        {
            double[] lab = new double[] { l, a, b };
            var xyz = Lab2XYZ(lab);
            var rgb = XYZ2sRGB(xyz);
            return rgb;
        }

        public static double[] Lab2XYZ(double[] Lab)
        {
            double[] XYZ = new double[3];
            double L, a, b;
            double fx, fy, fz;
            double Xn, Yn, Zn;
            Xn = 95.04;
            Yn = 100;
            Zn = 108.89;

            L = Lab[0];
            a = Lab[1];
            b = Lab[2];

            fy = (L + 16) / 116;
            fx = a / 500 + fy;
            fz = fy - b / 200;

            if (fx > 0.2069)
            {
                XYZ[0] = Xn * Math.Pow(fx, 3);
            }
            else
            {
                XYZ[0] = Xn * (fx - 0.1379) * 0.1284;
            }

            if ((fy > 0.2069) || (L > 8))
            {
                XYZ[1] = Yn * Math.Pow(fy, 3);
            }
            else
            {
                XYZ[1] = Yn * (fy - 0.1379) * 0.1284;
            }

            if (fz > 0.2069)
            {
                XYZ[2] = Zn * Math.Pow(fz, 3);
            }
            else
            {
                XYZ[2] = Zn * (fz - 0.1379) * 0.1284;
            }

            return XYZ;
        }

        public static int[] XYZ2sRGB(double[] XYZ)
        {
            int[] sRGB = new int[3];
            double X, Y, Z;
            double dr, dg, db;
            X = XYZ[0];
            Y = XYZ[1];
            Z = XYZ[2];

            dr = 0.032406 * X - 0.015371 * Y - 0.0049895 * Z;
            dg = -0.0096891 * X + 0.018757 * Y + 0.00041914 * Z;
            db = 0.00055708 * X - 0.0020401 * Y + 0.01057 * Z;

            if (dr <= 0.00313)
            {
                dr = dr * 12.92;
            }
            else
            {
                dr = Math.Exp(Math.Log(dr) / 2.4) * 1.055 - 0.055;
            }

            if (dg <= 0.00313)
            {
                dg = dg * 12.92;
            }
            else
            {
                dg = Math.Exp(Math.Log(dg) / 2.4) * 1.055 - 0.055;
            }

            if (db <= 0.00313)
            {
                db = db * 12.92;
            }
            else
            {
                db = Math.Exp(Math.Log(db) / 2.4) * 1.055 - 0.055;
            }

            dr = dr * 255;
            dg = dg * 255;
            db = db * 255;

            dr = Math.Min(255, dr);
            dg = Math.Min(255, dg);
            db = Math.Min(255, db);

            sRGB[0] = (int)(dr + 0.5);
            sRGB[1] = (int)(dg + 0.5);
            sRGB[2] = (int)(db + 0.5);

            return sRGB;
        }

        public static string getHex(int[] rgb)
        {
            string hex = Rgb216(rgb[0], rgb[1], rgb[2]);
            return hex;
        }

        public static string Rgb216(int r, int g, int b)
        {
            return ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(r, g, b));
        }
        #endregion
    }
}
