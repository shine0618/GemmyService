using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class T_Base
    {
        public T_Base()
        {
            deleteSign = 0;//1代表删除
            UpdateTime = DateTime.Now;

        }
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 数据验证机制
        /// </summary>
        public string verificationCode { get; set; }


        public int deleteSign { get; set; }


        public DateTime? UpdateTime { get; set; }


        public DateTime? CreateTime { get; set; }

        public string deletePerson { get; set; }

        public string CreatePerson { get; set; }

        public string UpdatePerson { get; set; }

        public string Remark { get; set; }

    

    }
}
