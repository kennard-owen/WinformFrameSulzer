using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DataProcess
    {
        public static byte[] GetBytes(this byte[] arr, int start, int count)
        {
            byte[] result = new byte[count];
            int index = 0;
            int total = start + count;
            for (int i = start; i < total; i++)
            {
                result[index++] = arr[i];
            }
            return result;
        }
    }
}
