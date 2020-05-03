using GraphSystem.Core.Extensions;
using GraphSystem.Core.FittingModels;
using GraphSystem.Core.IO;
using GraphSystem.UI.Commands;
using Microsoft.Win32;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphSystem.UI.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged //: BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ICommand BrowseFileCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        public IFittingModel FittingModel { get; set; } = new LinearFittingModel();
        public IFileReader FileReader { get; set; } = new CSVFileReader();

        public MainWindowVM()
        {
            this.BrowseFileCommand = new BaseCommand(true, BrowseFileHandler);
            this.LoadCommand = new BaseCommand(true, LoadCommandHandler);
        }
        public void LoadCommandHandler()
        {
            this.InputPoints = FileReader.Points.ToObservableCollection();
            this.LinePoints = FittingModel.CalculatePoints(FileReader.Points).ToObservableCollection();

            this.OnPropertyChanged(nameof(this.InputPoints));
            this.OnPropertyChanged(nameof(this.LinePoints));
        }
        public void BrowseFileHandler()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if (FileReader.ReadFile(openFileDialog.FileName))
                {
                    this.FileName = openFileDialog.FileName;
                    this.OnPropertyChanged(nameof(this.FileName));
                }
                else
                {

                    this.FileName = string.Empty;
                    MessageBox.Show("Invalid file!");
                }
            }
        }


        public string Title { get; private set; }
        public ObservableCollection<DataPoint> InputPoints { get; private set; } = new ObservableCollection<DataPoint>();
        public ObservableCollection<DataPoint> LinePoints { get; private set; } = new ObservableCollection<DataPoint>();

        private ComboBoxItem selectedmodel;

        public ComboBoxItem SelectedModel
        {
            get { return selectedmodel; }
            set
            {
                selectedmodel = value;
                this.FittingModel = FittingModelFactory.CreateModel((FittingModelsEnum)Convert.ToInt32(this.SelectedModel.Tag));
            }
        }

        public string FileName { get; set; }
    }
}
