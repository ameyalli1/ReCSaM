using MongoDB.Bson;
using proyecto.DAL;
using proyector.BIZ;
using proyector.COMMON.Entidad;
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
    /// Lógica de interacción para Configuracion.xaml
    /// </summary>
    public partial class Configuracion : Window
    {
        enum opcion
        {
            Nuevo,
            Edita
        }
        opcion opciones;
        IManejadorEmpresa manejadorEmpresa;
        IManejadorMesero manejadorMesero;
        IManejadorPregunta manejadorPregunta;
      //  IManejadorRespuesta manejadorRespuesta;
        IManejadorRespu manejadorRespu;
        IManejadorEncuesta manejadorEncuesta;
        List<ClaseGenera> respuesta;
        ObjectId ID ;
        public Configuracion()
        {
            InitializeComponent();
            manejadorEmpresa = new ManejadorEmpresa(new RepositorioGenerico<Empresa>());
            manejadorMesero = new ManejadorMesero(new RepositorioGenerico<Mesero>());
           //manejadorRespuesta = new ManejadorRespuesta(new RepositorioGenerico<Respuesta>());
            manejadorRespu = new ManejadorRespu(new RepositorioGenerico<Respu>());
            manejadorEncuesta = new ManejadorEncuesta(new RepositorioGenerico<Encuesta>());
            // manejadorEmpresa = new ManejadorEmpresa(new RepositorioEmpresa());
            ActualizarTabla();
            HabilitarBotones(false);
            HabilitarLimpiarCajas();

            //PARA USUARIOAS
            ActualizarTabla();
            HabilitarBotonesUsuario(false);
            HabilitarLimpiarCajas(false);

            //PARA PREGUNTAS
            manejadorPregunta = new ManejadorPregunta(new RepositorioGenerico<Pregunta>());
            ActualizarTablaPreguntas();
            HabilitarBotonesPreguntas(false);
            HabilitarLimpiarCajasPreguntas();
            respuesta = new List<ClaseGenera>();

            //PARA ENCUESTA
            HabilitarEdicionEncuesta(false);
            HabilitarCamposEncuesta(false);
        }



        private void HabilitarLimpiarCajas(bool habilitar)
        {
            txtNombreEmpresa.Clear();
        }

        private void ActualizarTabla()
        {
            ListEmpresa.ItemsSource = null;
            ListEmpresa.ItemsSource = manejadorEmpresa.Lista;

            //PARA USUARIOS
            ListUsuarioMeseros.ItemsSource = null;
            ListUsuarioMeseros.ItemsSource = manejadorMesero.Lista;

            //PARA EMPRESA
            cmbEmpresaUsuarios.ItemsSource = null;
            cmbEmpresaUsuarios.ItemsSource = manejadorEmpresa.Lista;

            //Para Respuestas
            dtgRespuestasForm.ItemsSource = null;
            dtgRespuestasForm.ItemsSource = manejadorRespu.Lista;

            //PARA ENCUESTA
            listEncuesta.ItemsSource = null;
            listEncuesta.ItemsSource = manejadorEncuesta.Lista;
            CmbNombreEncuesta.ItemsSource = null;
            CmbNombreEncuesta.ItemsSource = manejadorMesero.Lista;
        }

        private void HabilitarBotones(bool botones)
        {
            txtNombreEmpresa.IsEnabled = botones;

            btnNuevoEmpresa.IsEnabled = !botones;
            btnEliminarEmpresa.IsEnabled = !botones;
            btnGuardarEmpresa.IsEnabled = botones;
            btnCancelarEmpresa.IsEnabled = botones;
            btnEditarEmpresa.IsEnabled = !botones;
        }

        private void btnNuevoEmpresa_Click(object sender, RoutedEventArgs e)
        {
            HabilitarLimpiarCajas(true);
            opciones = opcion.Nuevo;
            HabilitarBotones(true);
        }

        private void btnGuardarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreEmpresa.Text))
            {
                MessageBox.Show("Favor de llenar el campo de Nombre de la Empresa", "Empresa", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (opciones == opcion.Nuevo)
            {
                Empresa empresa = new Empresa();
                empresa.Nombre = txtNombreEmpresa.Text.ToUpper();
                empresa.FechaHora = DateTime.Now;
                if (manejadorEmpresa.Agregar(empresa))
                {
                    MessageBox.Show("Empresa: " + empresa.Nombre + " agregada Correctamente", "Empresa", MessageBoxButton.OK, MessageBoxImage.Information);
                    HabilitarLimpiarCajas(false);
                    ActualizarTabla();
                    HabilitarBotones(false);
                }
                else
                {
                    MessageBox.Show("Error al agregar la empresa: " + empresa.Nombre, "Empresa", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Empresa empresa = ListEmpresa.SelectedItem as Empresa;
                empresa.Nombre = txtNombreEmpresa.Text.ToUpper();
                empresa.FechaHora = DateTime.Now;
                if (manejadorEmpresa.Modificar(empresa))
                {
                    MessageBox.Show("Empresa: " + empresa.Nombre + " modificada Correctamente", "Empresa", MessageBoxButton.OK, MessageBoxImage.Information);
                    HabilitarLimpiarCajas(false);
                    ActualizarTabla();
                    HabilitarBotones(false);
                }
                else
                {
                    MessageBox.Show("Error al modificar datos de la empresa: " + empresa.Nombre, "Empresa", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if (ListEmpresa.SelectedItem != null)
            {
                try
                {
                    Empresa empresa = ListEmpresa.SelectedItem as Empresa;
                    txtNombreEmpresa.Text = empresa.Nombre;
                    opciones = opcion.Edita;
                    HabilitarBotones(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puede realizar la operación", "Registro de Empresas", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un dato de la tabla Empresas", "Empresa", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            Empresa empresa = ListEmpresa.SelectedItem as Empresa;
            if (empresa != null)
            {
                if (MessageBox.Show("Realmente esta seguro de eliminar la empresa: " + empresa.Nombre, "Registro de Empresas", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) { }
                if (manejadorEmpresa.Eliminar(empresa.Id))
                {
                    MessageBox.Show("Empresa eliminada correctamente", "Registro de Empresas", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(false);
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemnento de la tabla de Empresas", "Registro de Empresas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Empresa", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                HabilitarBotones(true);
                HabilitarLimpiarCajas(false);
            }
        }
        //codigo para usuarios

        private void HabilitarLimpiarCajas()
        {
            txtTurnoUsuarios.Clear();
            txtPasswordsuarios.Clear();
            txtNombreUsuarios.Clear();
            txtHorarioUsuarios.Clear();
            txtCorreoUsuarios.Clear();
            txtApellidoUsuarios.Clear();
            cmbEmpresaUsuarios.Text = "";
            ActualizarTabla();
        }

        private void HabilitarBotonesUsuario(bool habilitar)
        {
            txtApellidoUsuarios.IsEnabled = habilitar;
            txtCorreoUsuarios.IsEnabled = habilitar;
            txtHorarioUsuarios.IsEnabled = habilitar;
            txtNombreUsuarios.IsEnabled = habilitar;
            txtPasswordsuarios.IsEnabled = habilitar;
            txtTurnoUsuarios.IsEnabled = habilitar;
            cmbEmpresaUsuarios.IsEnabled = habilitar;

            btnNuevoUsuario.IsEnabled = !habilitar;
            btnEliminarUsuario.IsEnabled = !habilitar;
            btnGuardarUsuario.IsEnabled = habilitar;
            btnCancelarUsuario.IsEnabled = habilitar;
            btnEditarUsuario.IsEnabled = !habilitar;
        }



        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            HabilitarLimpiarCajas();
            opciones = opcion.Nuevo;
            HabilitarBotonesUsuario(true);
        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtApellidoUsuarios.Text) || string.IsNullOrEmpty(txtCorreoUsuarios.Text) || string.IsNullOrEmpty(txtHorarioUsuarios.Text) || string.IsNullOrEmpty(txtNombreUsuarios.Text) || string.IsNullOrEmpty(txtPasswordsuarios.Password) || string.IsNullOrEmpty(txtTurnoUsuarios.Text) || string.IsNullOrEmpty(cmbEmpresaUsuarios.Text))
            {
                MessageBox.Show("No ha llenado todos los campos", "Registro de Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (opciones == opcion.Nuevo)
            {
                Mesero mesero = new Mesero();
                mesero.Apellidos = txtApellidoUsuarios.Text.ToUpper();
                mesero.Correo = txtCorreoUsuarios.Text.ToUpper();
                mesero.Empresa = cmbEmpresaUsuarios.Text.ToUpper();
                mesero.Horario = txtHorarioUsuarios.Text.ToUpper();
                mesero.Nombres = txtNombreUsuarios.Text.ToUpper();
                mesero.Password = txtPasswordsuarios.Password;
                mesero.Turno = txtTurnoUsuarios.Text.ToUpper();
                mesero.FechaHora = DateTime.Now;
                if (manejadorMesero.Agregar(mesero))
                {
                    MessageBox.Show("Usuario : " + mesero.Nombres + " agregada Correctamente", "Registro de Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    HabilitarLimpiarCajas();
                    ActualizarTabla();
                    HabilitarBotonesUsuario(false);
                }
                else
                {
                    MessageBox.Show("Error al agregar al Usuario: " + mesero.Nombres, "Registro de Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                foreach (var item in manejadorMesero.Lista)
                {
                    if (item.Id == ID)
                    {
                        item.Apellidos = txtApellidoUsuarios.Text.ToUpper();
                        item.Correo = txtCorreoUsuarios.Text.ToUpper();
                        item.Empresa = cmbEmpresaUsuarios.Text.ToUpper();
                        item.Horario = txtHorarioUsuarios.Text.ToUpper();
                        item.Nombres = txtNombreUsuarios.Text.ToUpper();
                        item.Password = txtPasswordsuarios.Password;
                        item.Turno = txtTurnoUsuarios.Text.ToUpper();
                        item.FechaHora = DateTime.Now;
                        if (manejadorMesero.Modificar(item))
                        {
                            MessageBox.Show("Usuario: " + item.Nombres + " modificada Correctamente", "Registro de Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                            HabilitarLimpiarCajas();
                            ActualizarTabla();
                            HabilitarBotonesUsuario(false);
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar datos del Usuario: " + item.Nombres, "Registro de Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        private void btnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (ListUsuarioMeseros.SelectedItem != null)
            {
                try
                {
                    Mesero mesero = ListUsuarioMeseros.SelectedItem as Mesero;
                    txtApellidoUsuarios.Text = mesero.Apellidos;
                    txtCorreoUsuarios.Text = mesero.Correo;
                    txtHorarioUsuarios.Text = mesero.Horario;
                    txtNombreUsuarios.Text = mesero.Nombres;
                    cmbEmpresaUsuarios.Text = mesero.Empresa;
                    txtPasswordsuarios.Password = mesero.Password;
                    ID = mesero.Id;
                    txtTurnoUsuarios.Text = mesero.Turno;
                    opciones = opcion.Edita;
                    HabilitarBotonesUsuario(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puede realizar la operación", "Registro de Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un dato de la tabla Usuarios", "Registro de Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Mesero mesero = ListUsuarioMeseros.SelectedItem as Mesero;
            if (mesero != null)
            {
                if (MessageBox.Show("Esta seguro de eliminar al mesero: " + mesero.Nombres, "Empresa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    manejadorMesero.Eliminar(mesero.Id);
                    ActualizarTabla();
                }
            }
            else
            {
                MessageBox.Show("Favor de Seleccionar un dato de la tabla", "Empresa", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Usuarios", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                HabilitarBotonesUsuario(false);
                HabilitarLimpiarCajas();
            }
        }


        //PARA PREGUNTAS

        private void HabilitarLimpiarCajasPreguntas()
        {
            txtPregunta.Clear();
            txtValorMaximo.Clear();
            txtValorMinimo.Clear();
            txtRespuesta.Clear();
            dtgRespuestas.ItemsSource = null;
        }

        private void HabilitarBotonesPreguntas(bool habilitar)
        {
            txtPregunta.IsEnabled = habilitar;
            txtValorMaximo.IsEnabled = habilitar;
            txtValorMinimo.IsEnabled = habilitar;
            txtRespuesta.IsEnabled = habilitar;

            btnNuevoPreguntas.IsEnabled = !habilitar;
            btnEliminarPreguntas.IsEnabled = !habilitar;
            btnGuardarPreguntas.IsEnabled = habilitar;
            btnCancelarPrguntas.IsEnabled = habilitar;
            btnEditarPreguntas.IsEnabled = !habilitar;
            btnAgregarRespuestas.IsEnabled = habilitar;

            dtgRespuestas.IsEnabled = habilitar;
        }

        private void ActualizarTablaPreguntas()
        {
            ListPreguntas.ItemsSource = null;
            ListPreguntas.ItemsSource = manejadorPregunta.Lista;
        }



        private void btnNuevoPreguntas_Click(object sender, RoutedEventArgs e)
        {
            HabilitarLimpiarCajasPreguntas();
            opciones = opcion.Nuevo;
            HabilitarBotonesPreguntas(true);
            respuesta = new List<ClaseGenera>();
        }

        private void btnGuardarPreguntas_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPregunta.Text) || string.IsNullOrEmpty(txtValorMaximo.Text) || string.IsNullOrEmpty(txtValorMinimo.Text))
            {
                MessageBox.Show("Favor de llenar los datos que faltan", "Registro de preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (manejadorPregunta.VerificarSiEsNumero(txtValorMaximo.Text) == true || manejadorPregunta.VerificarSiEsNumero(txtValorMinimo.Text) == true)
            {
                MessageBox.Show("Los campos valor minimo y valor maximo deben ser numericos", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (opciones == opcion.Nuevo)
            {
                if (respuesta.Count == 0)
                {
                    MessageBox.Show("Favor de agregar una respuesta a la pregunta", "Registro de preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Pregunta preguntas = new Pregunta()
                {
                    Text = txtPregunta.Text.ToUpper(),
                    ValorMaximo = txtValorMaximo.Text,
                    ValorMinimo = txtValorMinimo.Text,
                    Respuestas = respuesta,
                    FechaHora = DateTime.Now,
                };

                if (manejadorPregunta.Agregar(preguntas))
                {
                    MessageBox.Show("Pregunta agregada correctamente", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Information);
                    HabilitarLimpiarCajasPreguntas();
                    ActualizarTablaPreguntas();
                    HabilitarBotonesPreguntas(false);
                }
                else
                {
                    MessageBox.Show("Error al agregar la pregunta", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Pregunta preguntas = ListPreguntas.SelectedItem as Pregunta;
                preguntas.FechaHora = DateTime.Now;
                preguntas.Text = txtPregunta.Text.ToUpper();
                preguntas.ValorMaximo = txtValorMaximo.Text;
                preguntas.ValorMinimo = txtValorMinimo.Text;
                if (manejadorPregunta.Modificar(preguntas))
                {
                    MessageBox.Show("Pregunta modificada Correctamente", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Information);
                    HabilitarLimpiarCajasPreguntas();
                    ActualizarTablaPreguntas();
                    HabilitarBotonesPreguntas(false);
                }
                else
                {
                    MessageBox.Show("Error al modificar la pregunta ", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditarPreguntas_Click(object sender, RoutedEventArgs e)
        {
            if (ListPreguntas.SelectedItem != null)
            {
                try
                {
                    HabilitarLimpiarCajasPreguntas();
                    Pregunta empresa = ListPreguntas.SelectedItem as Pregunta;
                    txtPregunta.Text = empresa.Text;
                    txtValorMaximo.Text = empresa.ValorMaximo;
                    txtValorMinimo.Text = empresa.ValorMinimo;
                    dtgRespuestas.ItemsSource = empresa.Respuestas;
                    respuesta = empresa.Respuestas;
                    opciones = opcion.Edita;
                    HabilitarBotonesPreguntas(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Algo salio mal no se puede editar la pregunta", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un dato de la tabla Pregunta", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminarPreguntas_Click(object sender, RoutedEventArgs e)
        {
            Pregunta pregunta = ListPreguntas.SelectedItem as Pregunta;
            if (pregunta != null)
            {
                try
                {
                    if (MessageBox.Show("Esta seguro de eliminar la pregunta ", "Registro de Preguntas", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (manejadorPregunta.Eliminar(pregunta.Id))
                        {
                            MessageBox.Show("Pregunta eliminada con Éxito", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTablaPreguntas();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puede eliminar Pregunta", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Favor de Seleccionar un dato de la tabla", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarPrguntas_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("¿Esta realmente seguro de cancelar la operación?", "Registro de Preguntas", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                HabilitarBotonesPreguntas(false);
                HabilitarLimpiarCajasPreguntas();
            }
        }

        private void btnAgregarRespuestas_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtRespuesta.Text))
            {
                MessageBox.Show("No ha llenado la casilla de Respuesta", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ClaseGenera a = new ClaseGenera();
            a.Datos = txtRespuesta.Text.ToUpper();
            respuesta.Add(a);
            dtgRespuestas.ItemsSource = null;
            dtgRespuestas.ItemsSource = respuesta;
            txtRespuesta.Clear();
        }

        private void dtgRespuestas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgRespuestas.SelectedItem != null)
            {
                try
                {
                    ClaseGenera a = dtgRespuestas.SelectedItem as ClaseGenera;
                    txtRespuesta.Text = a.Datos;
                    respuesta.Remove(a);
                }
                catch (Exception)
                {
                    MessageBox.Show("Algo ha salido mal, Vuelva a intentarlo", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna respuesta para editar\nSeleccione una", "Registro de Preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tabRegresarAMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Encuestas encuesta = new Encuestas();
            encuesta.Show();
            this.Close();
        }

        private void btnEliminarUnElementoRespuestas_Click(object sender, RoutedEventArgs e)
        {
            proyector.COMMON.Entidad.Respu respu = dtgRespuestasForm.SelectedItem as proyector.COMMON.Entidad.Respu;
            if (respu != null)
            {
                try
                {
                    if (MessageBox.Show("Esta seguro de eliminar la respuesta ", "Registro de Respuestas", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (manejadorRespu.Eliminar(respu.Id))
                        {
                            MessageBox.Show("Respuesta eliminada con Éxito", "Registro de Respuestas", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTablaPreguntas();
                            ActualizarTabla();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puede eliminar Respuestas", "Registro de Respuestas", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor de Seleccionar un dato de la tabla", "Registro de Respuestas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminarTodoRespuestas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Realmente esta seguro de eliminar todo", "Respuestas", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    foreach (var item in manejadorRespu.Lista)
                    {
                        manejadorRespu.Eliminar(item.Id);
                    }
                    MessageBox.Show("Respuestas eliminadas Correctamente", "Respuestas", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Algo salio mal, Vuelva a intentarlo", "Respuestas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }


        //PARA ENCUESTA

        private void HabilitarEdicionEncuesta(bool habilitar)
        {
            btnCancelarEncuesta.IsEnabled = habilitar;
            btnEditarEncuesta.IsEnabled = !habilitar;
            btnEliminarEncuesta.IsEnabled = !habilitar;
            btnGuardarEncuesta.IsEnabled = habilitar;
        }

        private void HabilitarCamposEncuesta(bool habilitar)
        {
            txtDuenoEncuesta.IsEnabled = habilitar;
            CmbNombreEncuesta.IsEnabled = habilitar;
            txtObjetivoEncuesta.IsEnabled = habilitar;
            txtDuenoEncuesta.Clear();
            CmbNombreEncuesta.ItemsSource = "";
            txtObjetivoEncuesta.Clear();
            ActualizarTabla();

        }

        private void btnGuardarEncuesta_Click(object sender, RoutedEventArgs e)
        {
            if (opciones == opcion.Edita)
            {
                foreach (var item in manejadorEncuesta.Lista)
                {
                    if (item.Id==ID)
                    {
                        item.FechaHora = DateTime.Now;
                        item.Nombre = CmbNombreEncuesta.Text;
                        item.Objetivo = txtObjetivoEncuesta.Text;
                        item.Duenio = txtDuenoEncuesta.Text;

                        if (manejadorEncuesta.Modificar(item))
                        {
                            MessageBox.Show("Encuesta modificada Correctamente", "Registro de Encuesta", MessageBoxButton.OK, MessageBoxImage.Information);
                            HabilitarCamposEncuesta(false);
                            ActualizarTabla();
                            HabilitarEdicionEncuesta(false);
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar la Encuesta ", "Registro de Encuesta", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        private void btnEditarEncuesta_Click(object sender, RoutedEventArgs e)
        {
            if (listEncuesta.SelectedItem != null)
            {
                try
                {
                    Encuesta encuesta = listEncuesta.SelectedItem as Encuesta;
                    HabilitarCamposEncuesta(true);
                    ID = encuesta.Id ;
                    txtDuenoEncuesta.Text = encuesta.Duenio;
                    CmbNombreEncuesta.Text = encuesta.Nombre;
                    txtObjetivoEncuesta.Text = encuesta.Objetivo;
                    opciones = opcion.Edita;
                    HabilitarEdicionEncuesta(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Algo salio mal no se puede editar la encuesta", "Registro de Encuesta", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un dato de la tabla Encuesta", "Registro de Encuesta", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminarEncuesta_Click(object sender, RoutedEventArgs e)
        {
            Encuesta encuesta = listEncuesta.SelectedItem as Encuesta;
            if (encuesta != null)
            {
                try
                {
                    if ((MessageBox.Show("Esta seguro de eliminar la encuesta ", "Registro de Encuesta", MessageBoxButton.YesNo, MessageBoxImage.Question)) == (MessageBoxResult.Yes))
                    {
                        if (manejadorEncuesta.Eliminar(encuesta.Id))
                        {
                            MessageBox.Show("Encuesta eliminada con Éxito", "Registro de Encuesta", MessageBoxButton.OK, MessageBoxImage.Information);
                            //HabilitarCamposEncuesta(false);
                            ActualizarTabla();
                            //HabilitarEdicionEncuesta(false);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puede eliminar Encuesta", "Registro de Encuesta", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor de Seleccionar un dato de la tabla", "Registro de Encuesta", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarEncuesta_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("¿Esta realmente seguro de cancelar la operación?", "Registro de Preguntas", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                HabilitarEdicionEncuesta(false);
                HabilitarCamposEncuesta(false);
            }
        }






      
    }
}
