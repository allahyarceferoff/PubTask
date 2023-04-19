using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlinePub.Commands;
using OnlinePub.Models;

namespace OnlinePub.ViewModels
{
    public class HistoryViewModel
    {
        private ObservableCollection<Beer> purchased;

        public ObservableCollection<Beer> ShowPurchased
        {
            get { return purchased; }
            set { purchased = value; }
        }
        public HistoryViewModel()
        {
            ShowPurchased = new ObservableCollection<Beer>();
        }
    }
}
