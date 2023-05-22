using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Enums
{
    public enum ResultModelEnum
    {
        Transaction_Success = 1,
        Transaction_Failed = 2,
        Model_Invalid = 3,

        Phone_Number_In_Use = 4,
        Email_Address_In_Use = 5,

        User_Not_Found = 6,

        Access_Denied = 9998,
        Server_Error = 9999,
    }
}
