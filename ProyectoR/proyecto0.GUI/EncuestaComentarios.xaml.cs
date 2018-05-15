using MongoDB.Bson;
using proyecto.DAL;
using proyector.BIZ;
using proyector.COMMON.Interfaz;
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
    /// Lógica de interacción para EncuestaComentarios.xaml
    /// </summary>
    public partial class EncuestaComentarios : Window
    {
        IManejadorRespu manejadorRespu;
        public EncuestaComentarios()
        {
            InitializeComponent();
           // manejadorRespuesta = new ManejadorRespuesta(new RepositorioGenerico<Respuesta>());

        }
        private void ObtenerLosDatosParaRegistro()
        {
            try
            {
                proyector.COMMON.Entidad.Respu respu = new proyector.COMMON.Entidad.Respu();
                respu.IdEncuesta = txtIdEncuesta.Text;
                respu.IdMesero = txtIdMesero.Text;
                respu.Respuestas = 5;
                respu.FechaHora = DateTime.Now;
                manejadorRespu.Agregar(respu);
            }
            catch (Exception)
            {
                MessageBox.Show("Vuelva a intentarlo", "Encuesta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        private void btnFinalizarEncuesta_Click(object sender, RoutedEventArgs e)
        {
            ObtenerLosDatosParaRegistro();
            MenuFinalDeEncuesta menuFinalDeEncuesta = new MenuFinalDeEncuesta();
            menuFinalDeEncuesta.Show();
            this.Close();
        }
    }
}
