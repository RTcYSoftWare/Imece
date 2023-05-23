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


        Product_Created = 7,
        Product_Updated = 8,
        Product_Deleted = 9,
        Product_Not_Found = 10,
        Product_Restore_Delete = 11,

        Product_Type_Created = 12,
        Product_Type_Updated = 13,
        Product_Type_Deleted = 14,
        Product_Type_Not_Found = 15,
        Product_Type_Restore_Delete = 16,

        Growing_Area_Created = 17,
        Growing_Area_Updated = 18,
        Growing_Area_Deleted = 19,
        Growing_Area_Not_Found = 20,
        Growing_Area_Restore_Delete = 21,

        Soil_Type_Created = 22,
        Soil_Type_Updated = 23,
        Soil_Type_Deleted = 24,
        Soil_Type_Not_Found = 25,
        Soil_Type_Restore_Delete = 26,

        Irrigation_Type_Created = 27,
        Irrigation_Type_Updated = 28,
        Irrigation_Type_Deleted = 29,
        Irrigation_Type_Not_Found = 30,
        Irrigation_Type_Restore_Delete = 31,

        Plantation_Created = 32,
        Plantation_Updated = 33,
        Plantation_Deleted = 34,
        Plantation_Not_Found = 35,
        Plantation_Restore_Delete = 36,


        Access_Denied = 9998,
        Server_Error = 9999,
    }
}
