/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: ViewModel.cs
*     Creation Date: 7/11/2018
*            Author: M. Moody
*  
*       Description: This class defines the base ViewModel and implements 
*       INotifyPropertyChanged to assist with updating the UI when property
*       values of the Sub class change.
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sudoku.Client.Common
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        protected virtual void SetProperty<T>(ref T member, T val,
            [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion
    }
}
