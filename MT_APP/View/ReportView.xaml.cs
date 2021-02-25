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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MT_APP.View
{
    /// <summary>
    /// ReportView.xaml 的交互逻辑
    /// </summary>
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnResend_Click(object sender, RoutedEventArgs e)
        {
        }

        private void HideResend(object sender, SelectionChangedEventArgs args)
        {
            this.Mensajes.Text = string.Empty;
            this.MensajesError.Text = string.Empty;
            this.btnResend.Visibility = Visibility.Hidden;
            this.gridProduccion.DataContext = null;
            this.TxtDMC.Text = string.Empty;
        }

        // Token: 0x04000166 RID: 358
    }
}
