using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLLL
{
    public class LevelBLL
    {
        LevelAccessDAL lv_access = new LevelAccessDAL();
        public string[] GetUserLevel()
        {
            return lv_access.GetUserLevel();
        }

        public int Level2ID(string t)
        {
            return lv_access.Level2ID(t);
        }
    }
}
