using System.Windows;

// Ventana para la entrada manual de codigo de barras
namespace AppRanameBarcode
{
    public partial class ManualEntryWindow : Window
    {
        public string CodigoIngresado { get; private set; }
        public ManualEntryWindow()
        {
            InitializeComponent();

            this.Loaded += ManualEntryWindow_Loaded;
        }

        private void ManualEntryWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Establece el foco en el TextBox cuando la ventana se carga
            txtCodigoManual.Focus();
        }
        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            // Guarda el valor del TextBox y establece DialogResult en true
            this.CodigoIngresado = txtCodigoManual.Text.Trim();
            this.DialogResult = true;
        }
    }
}
