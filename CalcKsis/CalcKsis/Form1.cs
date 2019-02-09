using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace CalcKsis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        uint[] ip = new uint[4];
        uint[] mask = new uint[4];
        uint[] subnet = new uint[4];
        uint[] host = new uint[4];
        string[] substrings;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateMask();
        }
        private void CreateMask()
        {
            string buff = Masks.Text;
            buff = buff.Remove(0, 5);
            buff = buff.Replace(")", "");
            substrings = buff.Split('.');
            for (int i = 0; i < 4; i++)
            {
                mask[i] = uint.Parse(substrings[i]);
            }
        }
        private void ipAdress()
        {
            substrings = Ips.Text.Split('.');
            for (int i = 0; i < 4; i++)
            {
                ip[i] = uint.Parse(substrings[i]);
                if (ip[i] > 255 || ip[i] < 0)
                {
                    MessageBox.Show("Ip Error!");
                    Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ipAdress();
            Calc();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Calc()
        {
            string OutSubNet = "";
            string OutHostId = "";
            for (int i = 0; i < ip.Length; i++)
            {
                subnet[i] = ip[i] & mask[i];
                OutSubNet += subnet[i];
                host[i] = ip[i] & ~mask[i];
                OutHostId += host[i];
                if (i != 3)
                {
                    OutSubNet += ".";
                    OutHostId += ".";
                }
            }
            MessageBox.Show($"Network ID {OutSubNet}\n" +
                $"Host ID {OutHostId}");
        }
    }
}
