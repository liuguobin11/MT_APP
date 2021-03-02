using MahApps.Metro.Controls;
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
    /// MESView.xaml 的交互逻辑
    /// </summary>
    public partial class MESView : UserControl
    {


        public MESView()
        {
            InitializeComponent();

            // The Tag is used to handle closing
        }//0606070122102231309
        private void btnToolFuc_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btnMESConnect":

                    break;
                case "btnMESPing":
                    
                    break;
                case "btnMESIdentification":
                   
                    break;
                case "btnMESReqTimeDate":
              
                    break;
                case "btnMESSetupChange":
                  
                    break;
                case "btnMESUnitCheckin":
                
                    break;
                case "btnMESUnitCheckout":

                    break;
                case "btnMESCheckMaterial":
              
                    break;
                case "btnMESReqRunText":
          
                    break;
                case "btnMESReqUintInfo":
        
                    break;
                case "btnMESReqAllIds":
                   
                    break;
            }
   


        }
        private void Splitview_PaneClosing(object sender, SplitViewPaneClosingEventArgs e)
        {
            var splitView = sender as SplitView;

            if (splitView == null)
                return;

            e.Cancel = (bool)splitView.Tag;
        }
    }
}
