using BZ2KMT_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BZ2KMT_HFT_2021222.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Car> Cars { get; set; }
        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set 
            {
                if(value != null)
                {
                    selectedCar = new Car()
                    {
                        Model = value.Model,
                        CarId = value.CarId
                    };
                    OnPropertyChanged();
                    (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }

        public MainWindowViewModel()
        { 
            Cars = new RestCollection<Car>("http://localhost:40003/", "car");

            CreateCarCommand = new RelayCommand(() => //need fix
            {
                Cars.Add(new Car()
                {
                    Model = SelectedCar.Model
                });
            });

            UpdateCarCommand = new RelayCommand(() => //need fix
            {
                Cars.Update(SelectedCar);
            });

            DeleteCarCommand = new RelayCommand(() =>
            {
                Cars.Delete(SelectedCar.CarId);
            },
            () =>
            {
                return SelectedCar != null;
            });

            SelectedCar = new Car();
        }
    }
}
