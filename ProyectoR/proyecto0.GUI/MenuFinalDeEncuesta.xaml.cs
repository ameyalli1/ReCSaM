using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace proyecto0.GUI
{
    /// <summary>
    /// Lógica de interacción para MenuFinalDeEncuesta.xaml
    /// </summary>
    public partial class MenuFinalDeEncuesta : Window
    {
        public MenuFinalDeEncuesta()
        {
            InitializeComponent();
        }

        private void btnReiniciar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("La encuesta se reiniciara", "Finalización de Encuesta", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //la otra interfaz
                EncuestaFormulario encuestas = new EncuestaFormulario();
                encuestas.Show();
                this.Close();
            }
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("La encuesta se inicializara", "Finalización de Encuesta", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //la otra interfaz
                Encuestas encuestas = new Encuestas();
                encuestas.Show();
                this.Close();
            }
        }

    }
}
