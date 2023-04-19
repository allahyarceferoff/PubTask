 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using OnlinePub.Commands;
using OnlinePub.Models;
using OnlinePub.Repositories;
using OnlinePub.Views;

namespace OnlinePub.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public FakeRepo BeerRepository { get; set; }
		private ObservableCollection<Beer> allBeers;

		public ObservableCollection<Beer>AllBeers
		{
			get { return allBeers; }
			set { allBeers = value; OnPropertyChanged(); }
		} 
		private Beer beer;

		public Beer Beer
		{
			get { return beer; }
			set { beer = value; OnPropertyChanged(); }
		}
		private ObservableCollection<Beer> purchased;

		public ObservableCollection<Beer> Purchased
		{
			get { return purchased; }
			set { purchased = value; OnPropertyChanged(); }
		}



        public RelayCommand SelectedCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand ShowCommand { get; set; }
        private int count;




        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }
        public MainViewModel()
        {
            BeerRepository = new FakeRepo();
            AllBeers = new ObservableCollection<Beer>(BeerRepository.GetAll());
            Beer = new Beer();
            
            Purchased = new ObservableCollection<Beer>();
            SelectedCommand = new RelayCommand((obj) =>
            {
                var item = obj as Beer;
                Beer = item;
            }
            );
            AddCommand = new RelayCommand((o) =>
            {
                count++;
                Count = count;
            }, (pred) =>
            {
                if (Beer != null)
                {
                    if (Beer.Id < 1)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            });
            RemoveCommand = new RelayCommand((o) =>
            {
                if (count != 0)
                {
                    count--;
                }
                Count = count;
            }, (pred) =>
            {
                if (Beer != null)
                {
                    if (Beer.Id < 1)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            });
            BuyCommand = new RelayCommand((obj) =>
            {
                if (Count > 0)
                {
                    Beer.BeerCount = Count;
                    Beer.TotalPrice = Beer.BeerCount * Beer.BeerCost;
                    purchased.Add(Beer);
                    MessageBox.Show("You've bought  the beer");
                    Count = 0;
                }
                else
                {
                    MessageBox.Show("You have to add count of beer");
                }
            }, (pred) =>
            {
                if (Beer != null)
                {
                    if (Beer.Id < 1)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            });
            ResetCommand = new RelayCommand((obj) =>
            {
                Beer = null;
                Count = 0;
            }, (pred) =>
            {
                if (Beer != null)
                {
                    if (Beer.Id < 1)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            });
            ShowCommand = new RelayCommand((obj) =>
            {
                HistoryViewModel vm = new HistoryViewModel();
                vm.ShowPurchased = Purchased;

                ShowHistory window = new ShowHistory();
                window.DataContext = vm;
                window.ShowDialog();
            }, (pred) =>
            {
                if (Beer != null)
                {
                    if (Beer.Id < 1)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            });
        }
    }
}
