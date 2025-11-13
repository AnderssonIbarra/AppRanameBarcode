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
