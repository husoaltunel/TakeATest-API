using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class ResultUtil<TEntity>
    {
        public static bool IsDataExist(TEntity data)
        {
            if (data != null)
            {
                return true;
            }
            return false;
        }
        public static bool IsResultSuccees(int result)
        {
            if (result != 0)
            {
                return true;
            }
            return false;
        }

        
    }
}
