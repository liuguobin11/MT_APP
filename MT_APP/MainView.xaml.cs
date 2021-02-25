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
using MahApps.Metro.Controls;
using MT_APP.View;
using System.Reflection;
using MT_APP.ViewModel;

namespace MT_APP
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : MetroWindow
    {
        BrushConverter conv;
        Brush bru;
        MainViewModel model;

        public MainView()
        {
            InitializeComponent();
            conv = new BrushConverter();
            bru = conv.ConvertFromInvariantString("#FFF9BC44") as Brush;
        }


        #region Button Events

        void ChangeBtnColor()
        {
            btnAutomatic.Background = Brushes.White;
            btnFunction.Background = Brushes.White;
            btnManual.Background = Brushes.White;
            btnMES.Background = Brushes.White;
            btnIO.Background = Brushes.White;
            btnSetting.Background = Brushes.White;
            btnReport.Background = Brushes.White;

        }

        private void btnToolFuc_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ChangeBtnColor();
            switch (btn.Name)
            {
                case "btnAutomatic":
                    break;
                case "btnManual":
                    break;
                case "btnIO":

                    break;
                case "btnMainIO":

                    break;
            }
            btn.Background = (System.Windows.Media.Brush)bru;
            //this.frmMain.Navigate(new Uri(btn.Tag.ToString() + ".xaml", UriKind.Relative));
            model = new MainViewModel(btn.Tag.ToString());
            this.DataContext = model;

        }
        #endregion


        private void Navigate(string path)
        {
            string uri = "MT_APP." + path;
            Type type = Type.GetType(uri);
            if (type != null)
            {
                //实例化Page页
                object obj = type.Assembly.CreateInstance(uri);
                UserControl control = obj as UserControl;
                //this.frmMain.Content = control;
                PropertyInfo[] infos = type.GetProperties();
                foreach (PropertyInfo info in infos)
                {
                    //将MainWindow设为page页的ParentWin
                    if (info.Name == "ParentWindow")
                    {
                        info.SetValue(control, this, null);
                        break;
                    }
                }
            }
        }

        private void imgLogo_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            SupplierView supplierView = new SupplierView();
            supplierView.Show();
        }
    }
}
