using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Semana05.ViewModel
{
    public class ListaCategoriaViewModel : ViewModelBase
    {
        public ObservableCollection<Categoria> Categorias { get; set; }

        public ICommand Nuevocommand { get; set; }

        public ICommand ConsultarCommand { get; set; }

        public ListaCategoriaViewModel()
        {
            Categorias = new Model.CategoriaModel().Categorias;

            Nuevocommand = new RelayCommand<Window>(
                param => Abrir()
                );

            ConsultarCommand = new RelayCommand<object>(
                o => { Categorias = (new Model.CategoriaModel()).Categorias; }
                );

            void Abrir()
            {
                ManCategoria window = new ManCategoria();
                window.ShowDialog();
            }
        }
    }
}
