using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paste
{
    public partial class MainForm : Form
    {
        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        private const int WM_CREATE = 0x1; //窗口消息：创建
        private const int WM_DESTROY = 0x2; //窗口消息：销毁

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref System.Windows.Forms.Message msg)
        {
            base.WndProc(ref msg);
            switch (msg.Msg)
            {
                case WM_HOTKEY: //窗口消息：热键
                    HotKeyEnum tmpWParam = (HotKeyEnum)(msg.WParam.ToInt32());

                    if (tmpWParam == HotKeyEnum.HotKeyID1)
                    {
                        Console.WriteLine("ctrl 1 is clicked");
                    }
                    else if(tmpWParam == HotKeyEnum.HotKeyID2)
                    {
                        Console.WriteLine("ctrl 2 is clicked");
                    }
                    else if (tmpWParam == HotKeyEnum.HotKeyID3)
                    {
                        Console.WriteLine("ctrl 3 is clicked");
                    }
                    else if (tmpWParam == HotKeyEnum.HotKeyID4)
                    {
                        Console.WriteLine("ctrl 4 is clicked");
                    }
                    break;
                case WM_CREATE: //窗口消息：创建
                    SystemHotKey.registerHotKeys(this.Handle, true);
                    break;
                case WM_DESTROY: //窗口消息：销毁
                    SystemHotKey.deregisterHotKeys(this.Handle, true);
                    break;
                default:
                    break;
            }
        }
    }

}
