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
using MoonlakeTools.Comcell;

namespace MT_APP.View
{
    /// <summary>
    /// MESView.xaml 的交互逻辑
    /// </summary>
    public partial class MESView : UserControl
    {
        BrushConverter conv;
        Brush bru;
        GHPAction ghpAction;
        string errorMsg;
        string sHostIp;
        int iPort;
        string sEquipId;
        int timeout;

        public MESView()
        {
            InitializeComponent();
            ghpAction = new GHPAction();
            conv = new BrushConverter();
            bru = conv.ConvertFromInvariantString("#FFF7F7F7") as Brush;

            sHostIp = txtIP.Text;
            iPort = int.Parse(txtPort.Text);
            timeout = int.Parse(txtTimeout.Text);
            sEquipId = txtEquipmentName.Text;
            EllipseMESStatus.Fill = Brushes.Red;
            txtMESReminder.Text = "";
            // The Tag is used to handle closing
        }//0606070122102231309
        private void btnToolFuc_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btnMESConnect":
                    sHostIp = txtIP.Text;
                    iPort = int.Parse(txtPort.Text);
                    timeout = int.Parse(txtTimeout.Text);
                    sEquipId = txtEquipmentName.Text;
                    if (ghpAction.Init(sHostIp, iPort, sEquipId, timeout))
                    {
                        EllipseMESStatus.Fill = Brushes.Green;
                        if (btn.Content.ToString() == "连接")
                        {
                            btn.Content = "已连接";
                            btn.Background = Brushes.Green;
                        }
                        else if (btn.Content.ToString() == "已连接")
                        {
                            btn.Content = "连接";
                            btn.Background = (System.Windows.Media.Brush)bru;
                        }
                    }

                    break;
                case "btnMESPing":
                    ghpAction.Ping(out errorMsg);
                    break;
                case "btnMESIdentification":
                    ghpAction.Identification(out errorMsg);
                    break;
                case "btnMESReqTimeDate":
                    string timeStamp;
                    ghpAction.ReqTimeDate(out timeStamp, out errorMsg);
                    break;
                case "btnMESSetupChange":
                    ghpAction.SetupChange("A3C0452200222", out errorMsg);
                    break;
                case "btnMESUnitCheckin":
                    string materialOut;
                    ghpAction.UnitCheckin("0606070122102231309", out materialOut, out errorMsg);
                    break;
                case "btnMESUnitCheckout":
                    ghpAction.UnitCheckout("A3C0116680091", true, out errorMsg);
                    //带参数的： nokReason_val="0" nest_number="101"
                    string xmlMsg = string.Concat(new string[]
                    {
                        "nokReason_val=\"",
                        "0",
                        "\" nest_number=\"",
                        "101",
                        "\""
                    });
                    ghpAction.UnitCheckout("A3C0116680091", true, xmlMsg, out errorMsg);
                    break;
                case "btnMESCheckMaterial":
                    string matExp;
                    string matPN;
                    string matQtyAvail;
                    ghpAction.CheckMaterial("00000A2C5335640549@0702014476@UCCQ004933821", out matExp, out matPN, out matQtyAvail, out errorMsg);
                    break;
                case "btnMESReqRunText":
                    string responseXML;
                    ghpAction.ReqRunText("153343040120092106787", "CGQ", "A2C1996900391", "10006", out responseXML, out errorMsg);
                    break;
                case "btnMESReqUintInfo":
                    string material;
                    string location;
                    int quantity;
                    string lastOperationTime;
                    string orderName;
                    ghpAction.ReqUnitInfo("CGQ", "153343040120092106787", out material, out location, out quantity, out lastOperationTime, out orderName);
                    break;
                case "btnMESReqAllIds":
                    ghpAction.ReqAllIds("0606070122102231309", "CGQ", out responseXML, out errorMsg);
                    break;
            }
            txtMESSendMsg.Text = ghpAction.msgRequest;
            txtMESRevMsg.Text = ghpAction.msgResponse;
            //或者
            //txtMESRevMsg.Text = errorMsg;


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
