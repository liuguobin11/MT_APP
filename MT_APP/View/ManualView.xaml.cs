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
    /// ManualView.xaml 的交互逻辑
    /// </summary>
    public partial class ManualView : UserControl
    {
        public ManualView()
        {
            InitializeComponent();
        }
        private void CountingButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.CountingBadge.Badge == null || Equals(this.CountingBadge.Badge, ""))
            {
                this.CountingBadge.Badge = 0;
            }
            var next = int.Parse(this.CountingBadge.Badge.ToString()) + 1;
            this.CountingBadge.Badge = next < 43 ? (object)next : null;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("2");
        }
    }
}
