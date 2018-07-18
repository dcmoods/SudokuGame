/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: ZeroToEmptyConverter.cs
*     Creation Date: 7/11/2018
*            Author: M. Moody
*  
*       Description: This class converts any illegal value (non-numeric)
*       input to a cell to an empty string.
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Windows.Data;

namespace Sudoku.Client.Converter
{
    public class ZeroToEmptyConverter : IValueConverter
    {
        public int EmptyStringValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            else if (value is string)
                return value;
            else if (value is int && (int)value == EmptyStringValue)
                return string.Empty;
            else
                return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                string s = (string)value;
                if (IsNumeric(s))
                    return System.Convert.ToInt32(s);
                else
                    return EmptyStringValue;
            }
            return value;
        }

        private bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }
    }
}
