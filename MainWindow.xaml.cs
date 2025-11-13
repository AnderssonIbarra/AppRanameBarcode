using Microsoft.WindowsAPICodePack.Dialogs;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;


namespace AppRanameBarcode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDirectorioOrigen_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Selecione la carpeta de origen"
            };
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtDirectorioOrigen.Text = dialog.FileName;
            }
        }

        private void btnDirectorioDestino_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Selecione la carpeta de destino"
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtDirectorioDestino.Text = dialog.FileName;
            }
        }

        // Logica para empezar el proceso de renombrado de archivos
        private void btnProcesar_Click(object sender, RoutedEventArgs e)
        {
            string txtOrigen = txtDirectorioOrigen.Text;
            string txtDestino = txtDirectorioDestino.Text;
            
            //Validaciones de rutas
            if (string.IsNullOrEmpty(txtOrigen) || !Directory.Exists(txtOrigen))
            {

                MessageBox.Show("El directorio de origen no es valido.", "Error de ruta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDestino) || !Directory.Exists(txtDestino))
            {

                MessageBox.Show("El directorio de destino no es valido.", "Error de ruta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Inicio del proceso
            MessageProceso.Text = "Procesando archivos...";
            MessageProceso.Visibility = Visibility;
            btnProcesar.IsEnabled = false;

            try
            {
                string[] archivos = Directory.GetFiles(txtOrigen, "*.*", SearchOption.TopDirectoryOnly);
                int contadorExitosos = 0;
                int contadorFallidos = 0;

                foreach (string rutaOrigen in archivos)
                {
                    string extension = Path.GetExtension(rutaOrigen).ToLower();
                    if (extension != ".jpg" && extension != ".png" && extension != ".jpeg" && extension != ".bmp")
                    {
                        continue;
                    }
                    imgProcesando.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(rutaOrigen));

                    try
                    {
                        BitmapImage bitmapSource = new BitmapImage(new Uri(rutaOrigen));
                        string valorCodigoLeido = LeerCodigoDeBarra(bitmapSource);

                        if (!string.IsNullOrEmpty(valorCodigoLeido))
                        {
                            string nuevoNombre = valorCodigoLeido + extension;
                            string rutaDestino = Path.Combine(txtDestino, nuevoNombre);

                            if (File.Exists(rutaDestino))
                            {
                                MessageBox.Show($"El archivo '{nuevoNombre}' ya existe. Saltado", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                                contadorFallidos++;
                                continue;
                            }

                            File.Copy(rutaOrigen, rutaDestino);
                            contadorExitosos++;
                        }
                        else
                        {
                            contadorFallidos++;
                        }
                    }
                    catch (Exception exProceso)
                    {
                        MessageBox.Show($"Error al procesar {Path.GetFileName(rutaOrigen)}: {exProceso.Message}", "Error Individual", MessageBoxButton.OK, MessageBoxImage.Warning);
                        contadorFallidos++;
                    }
                }
                MessageBox.Show($"Proceso completado. \nExitos: {contadorExitosos}\nFallidos: {contadorFallidos}", "Finalizado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exGeneral)
            {
                MessageBox.Show($"Ocurrio un error inesperado: {exGeneral.Message}", "Error Fatal", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            finally
            {
                btnProcesar.IsEnabled = true;
                MessageProceso.Visibility = Visibility.Hidden;
            }
        }

        private string LeerCodigoDeBarra(BitmapSource source)
        {
            var reader = new BarcodeReader
            {
                Options = new DecodingOptions{ TryHarder = true}
            };

            Result result = reader.Decode(source);

            if(result != null)
            {
                return result.Text;
            }
            else
            {
                var entradaManual = new ManualEntryWindow();

                bool? dialogResult = entradaManual.ShowDialog();
                if (dialogResult == true)
                {
                    return entradaManual.CodigoIngresado;
                }
                else
                {
                    return null; 
                }
            }
        }
    }
}