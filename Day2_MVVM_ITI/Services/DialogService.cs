using Day2_MVVM_ITI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Day2_MVVM_ITI
{
 public  static class DialogService
    {
        static Window Dialog = null;
        public static void ShowDialog()
        {
            Dialog = new DetailsView();
            Dialog.Show();
        }

        public static void Close()
        {
            if(Dialog !=null)
            Dialog.Close();
        }

    }
}
