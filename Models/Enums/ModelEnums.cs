using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;

namespace BabyTracker.Models
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Length > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs[0]).Description;
                }
                
            }
            return GenericEnum.ToString();
        }
    }
    
    public enum DiaperEnum
    {
        Poo, 
        Pee, 
        [Description("Pee and Poo")]
        PeeAndPoo
    }
    public enum FeedEnum
    {
        [Description("Left Breast")]
        LeftBreast, 
        [Description("Right Breast")]
        RightBreast, 
        Meal, 
        Bottle
    }
    public enum MedicationEnum
    {
        Medicine, 
        Vaccination
    }
    public enum GrowthEnum
    {
        Height, 
        Weight
    }
}