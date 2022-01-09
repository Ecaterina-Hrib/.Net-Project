//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using Microsoft.ML.Data;

namespace HousePrice.Model
{
    public class ModelInput
    {
        [ColumnName("date"), LoadColumn(0)]
        public string Date { get; set; }


        [ColumnName("price"), LoadColumn(1)]
        public float Price { get; set; }


        [ColumnName("bedrooms"), LoadColumn(2)]
        public float Bedrooms { get; set; }


        [ColumnName("bathrooms"), LoadColumn(3)]
        public float Bathrooms { get; set; }


        [ColumnName("sqft_living"), LoadColumn(4)]
        public float Sqft_living { get; set; }


        [ColumnName("sqft_lot"), LoadColumn(5)]
        public float Sqft_lot { get; set; }


        [ColumnName("floors"), LoadColumn(6)]
        public float Floors { get; set; }


        [ColumnName("view"), LoadColumn(7)]
        public float View { get; set; }


        [ColumnName("condition"), LoadColumn(8)]
        public float Condition { get; set; }


        [ColumnName("grade"), LoadColumn(9)]
        public float Grade { get; set; }


        [ColumnName("sqft_basement"), LoadColumn(10)]
        public float Sqft_basement { get; set; }


        [ColumnName("yr_built"), LoadColumn(11)]
        public float Yr_built { get; set; }


        [ColumnName("yr_renovated"), LoadColumn(12)]
        public float Yr_renovated { get; set; }


        [ColumnName("zipcode"), LoadColumn(13)]
        public float Zipcode { get; set; }


        [ColumnName("lat"), LoadColumn(14)]
        public float Lat { get; set; }


        [ColumnName("long"), LoadColumn(15)]
        public float Long { get; set; }


    }
}
