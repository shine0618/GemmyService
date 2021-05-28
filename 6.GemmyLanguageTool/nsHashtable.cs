using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.GemmyLanguageTool
{
   public class nsHashtable:Hashtable
    {
        public ArrayList list = new ArrayList();
        public override void Add(object key, object value)
        {
            base.Add(key, value);
            list.Add(key);
        }
        public override void Clear()
        {
            base.Clear();
            list.Clear();
        }
        public override void Remove(object key)
        {
            base.Remove(key);
            list.Remove(key);
        }
        public override ICollection Keys
        {
            get
            {
                return list;
            }
        }
        public ArrayList getList()
        {
            ArrayList stempList = new ArrayList();
            foreach (object it in base.Keys)
            {
                stempList.Add(it.ToString());
            }
            return stempList;
        }
    }
}
