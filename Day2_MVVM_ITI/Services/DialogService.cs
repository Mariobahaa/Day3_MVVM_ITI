using Day2_MVVM_ITI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Day2_MVVM_ITI
{
 public   class DialogService
    {
        Window Dialog = null;
        public void ShowDialog()
        {
            Dialog = new DetailsView();
            Dialog.Show();
        }

        public void Close()
        {
            if(Dialog !=null)
            Dialog.Close();
        }

    }
}
