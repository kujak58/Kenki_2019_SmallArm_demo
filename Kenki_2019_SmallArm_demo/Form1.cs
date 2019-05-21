using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Management;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace Kenki_2019_SmallArm_demo
{
    public partial class Form1 : Form
    {
        SerialPort serialPort1 = new SerialPort();

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadCOMPortNum()
        {
            try
            {
                string[] PortList = SerialPort.GetPortNames();
                foreach (string PortNum in PortList)
                {
                    comboBox1.Items.Add(PortNum);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadBaudrateList()
        {
            int[] bpsList = { 9600, 57600, 115200, 500000 };
            foreach (int bpsNo in bpsList)
            {
                comboBox2.Items.Add(bpsNo);
            }
        }
        // "ID:\r\nhoge\r\nModel Number:\r\nFirmware version:";

        private void SendSerial(byte[] buffer, int start, int count)
        {
            Send_textBox.Text = "";
            for (int i = 0; i < count; i++)
            {
                try
                {
                    Send_textBox.Text += buffer[start + i].ToString("X2");
                    Send_textBox.Text += " ";
                }
                catch (Exception ex) { MessageBox.Show("Sending Error"); return; };
            }
            //temp
            try { serialPort1.Write(buffer, start, count); }
            catch (Exception ex) { MessageBox.Show("Serial Error");};

        }

        private void Ping(byte id = 254)
        {
            byte buffer_length = 10;
            byte[] buffer = new byte[buffer_length];

            /*PING (for check)
            Header : 0xFF 0xFF 0xFD 0x00
            ID: 0x01
            Length: 0x03 0x00(LSB MSB)
            Inst. : 0x01(PING)
            CRC: 0x19 0x4E(LSB MSB)
            */

            buffer[0] = 0xFF;                       // Header
            buffer[1] = 0xFF;                       // Header
            buffer[2] = 0xFD;                       // Header
            buffer[3] = 0x00;                       // Header
            buffer[4] = id;                         // ID
            buffer[5] = 0x03;                       // length (LSB) : 5-7
            buffer[6] = 0x00;
            buffer[7] = 0x01;                       // Inst
            ushort crc_accum = update_crc(buffer);  
            buffer[8] = (byte)(crc_accum & 0x00FF); // CRC (LSB)
            buffer[9] = (byte)(crc_accum>>8 & 0x00FF);
            SendSerial(buffer, 0, buffer_length);
        }




        // Useful fucntions
        private void WriteData(byte id, ushort address, byte[] param)
        {
            int buffer_len = 12 + param.Length;
            int inst_len = 5 + param.Length;
            byte[] buffer = new byte[buffer_len];

            buffer[0] = 0xFF;                       // Header
            buffer[1] = 0xFF;                       // Header
            buffer[2] = 0xFD;                       // Header
            buffer[3] = 0x00;                       // Header
            buffer[4] = id;                         // ID
            buffer[5] = (byte)(inst_len & 0x00FF);  // length (LSB)
            buffer[6] = (byte)(inst_len >> 8 & 0x00FF);
            buffer[7] = 0x03;                       // Inst (Write)
            buffer[8] = (byte)(address & 0x00FF);  // address (LSB)
            buffer[9] = (byte)(address >> 8 & 0x00FF);

            for (int i = 0; i < param.Length; i++) // Write to [i]th address
            {
                buffer[i + 10] = param[i];
            }
            ushort crc_accum = update_crc(buffer);
            buffer[buffer_len - 2] = (byte)(crc_accum & 0x00FF);
            buffer[buffer_len - 1] = (byte)(crc_accum >> 8 & 0x00FF);
            Read_textBox.Text = "";
            SendSerial(buffer, 0, buffer_len);
        }

        private void SyncWriteData(byte[] id, ushort address, byte[] param)
        {
            int buffer_len = 14 + param.Length + id.Length;
            int inst_len = buffer_len - 7;
            byte[] buffer = new byte[buffer_len];
            int each_len = ((inst_len - 5 - 2) / id.Length) - 1;

            //DEBUG
            //label1.Text = "buffer_len:" + buffer_len.ToString();
            //label2.Text = "inst_len:" + inst_len.ToString();
            //label3.Text = "each_len:" + each_len.ToString();


            buffer[0] = 0xFF;                       // Header
            buffer[1] = 0xFF;                       // Header
            buffer[2] = 0xFD;                       // Header
            buffer[3] = 0x00;                       // Header
            buffer[4] = 0xFE;                       // ID (all?)
            buffer[5] = (byte)(inst_len & 0x00FF);  // length (LSB)
            buffer[6] = (byte)(inst_len >> 8 & 0x00FF);
            buffer[7] = 0x83;                       // Inst (Write)
            buffer[8] = (byte)(address & 0x00FF);  // address (LSB)
            buffer[9] = (byte)(address >> 8 & 0x00FF);
            buffer[10] = (byte)(each_len & 0x00FF);
            buffer[11] = (byte)(each_len >> 8 & 0x00FF);

            int id_packet_len = each_len + 1;
            for (int i = 0; i < id.Length; i++) // Write to [i]th address
            {
                buffer[(i * id_packet_len) + 12] = id[i];
                for (int j = 1; j < id_packet_len; j++)
                {
                    buffer[(i * id_packet_len) + 12 + j] = param[(i * (each_len)) + (j - 1)];
                    //int temp = (i * (each_len)) + (j - 1);
                    //label6.Text += "buffer["+((i * id_packet_len) + 12 + j).ToString()+"]=param["+ temp.ToString() + "],";
                }
                //label6.Text += "\r\n";
            }
            ushort crc_accum = update_crc(buffer);
            buffer[buffer_len - 2] = (byte)(crc_accum & 0x00FF);
            buffer[buffer_len - 1] = (byte)(crc_accum >> 8 & 0x00FF);
            Read_textBox.Text = "";
            /*label6.Text = "";
            for (int k = 0; k < buffer_len; k++)
            {
                label6.Text += (buffer[k].ToString("X2"));
            }*/


            SendSerial(buffer, 0, buffer_len);
        }

        
        //new code (use hash) , http://emanual.robotis.com/docs/en/dxl/crc/
        //ref : https://qiita.com/tobira-code/items/dbcffc41f54201130b6c

        private ushort update_crc(byte[] buffer)
        {
            ushort i, j;
            ushort crc_accum = 0;
            ushort[] crc_table = new ushort[256] { 0x0000, 0x8005, 0x800F, 0x000A, 0x801B, 0x001E, 0x0014, 0x8011,
            0x8033, 0x0036, 0x003C, 0x8039, 0x0028, 0x802D, 0x8027, 0x0022,
            0x8063, 0x0066, 0x006C, 0x8069, 0x0078, 0x807D, 0x8077, 0x0072,
            0x0050, 0x8055, 0x805F, 0x005A, 0x804B, 0x004E, 0x0044, 0x8041,
            0x80C3, 0x00C6, 0x00CC, 0x80C9, 0x00D8, 0x80DD, 0x80D7, 0x00D2,
            0x00F0, 0x80F5, 0x80FF, 0x00FA, 0x80EB, 0x00EE, 0x00E4, 0x80E1,
            0x00A0, 0x80A5, 0x80AF, 0x00AA, 0x80BB, 0x00BE, 0x00B4, 0x80B1,
            0x8093, 0x0096, 0x009C, 0x8099, 0x0088, 0x808D, 0x8087, 0x0082,
            0x8183, 0x0186, 0x018C, 0x8189, 0x0198, 0x819D, 0x8197, 0x0192,
            0x01B0, 0x81B5, 0x81BF, 0x01BA, 0x81AB, 0x01AE, 0x01A4, 0x81A1,
            0x01E0, 0x81E5, 0x81EF, 0x01EA, 0x81FB, 0x01FE, 0x01F4, 0x81F1,
            0x81D3, 0x01D6, 0x01DC, 0x81D9, 0x01C8, 0x81CD, 0x81C7, 0x01C2,
            0x0140, 0x8145, 0x814F, 0x014A, 0x815B, 0x015E, 0x0154, 0x8151,
            0x8173, 0x0176, 0x017C, 0x8179, 0x0168, 0x816D, 0x8167, 0x0162,
            0x8123, 0x0126, 0x012C, 0x8129, 0x0138, 0x813D, 0x8137, 0x0132,
            0x0110, 0x8115, 0x811F, 0x011A, 0x810B, 0x010E, 0x0104, 0x8101,
            0x8303, 0x0306, 0x030C, 0x8309, 0x0318, 0x831D, 0x8317, 0x0312,
            0x0330, 0x8335, 0x833F, 0x033A, 0x832B, 0x032E, 0x0324, 0x8321,
            0x0360, 0x8365, 0x836F, 0x036A, 0x837B, 0x037E, 0x0374, 0x8371,
            0x8353, 0x0356, 0x035C, 0x8359, 0x0348, 0x834D, 0x8347, 0x0342,
            0x03C0, 0x83C5, 0x83CF, 0x03CA, 0x83DB, 0x03DE, 0x03D4, 0x83D1,
            0x83F3, 0x03F6, 0x03FC, 0x83F9, 0x03E8, 0x83ED, 0x83E7, 0x03E2,
            0x83A3, 0x03A6, 0x03AC, 0x83A9, 0x03B8, 0x83BD, 0x83B7, 0x03B2,
            0x0390, 0x8395, 0x839F, 0x039A, 0x838B, 0x038E, 0x0384, 0x8381,
            0x0280, 0x8285, 0x828F, 0x028A, 0x829B, 0x029E, 0x0294, 0x8291,
            0x82B3, 0x02B6, 0x02BC, 0x82B9, 0x02A8, 0x82AD, 0x82A7, 0x02A2,
            0x82E3, 0x02E6, 0x02EC, 0x82E9, 0x02F8, 0x82FD, 0x82F7, 0x02F2,
            0x02D0, 0x82D5, 0x82DF, 0x02DA, 0x82CB, 0x02CE, 0x02C4, 0x82C1,
            0x8243, 0x0246, 0x024C, 0x8249, 0x0258, 0x825D, 0x8257, 0x0252,
            0x0270, 0x8275, 0x827F, 0x027A, 0x826B, 0x026E, 0x0264, 0x8261,
            0x0220, 0x8225, 0x822F, 0x022A, 0x823B, 0x023E, 0x0234, 0x8231,
            0x8213, 0x0216, 0x021C, 0x8219, 0x0208, 0x820D, 0x8207, 0x0202 };

            ushort buffer_size = (ushort)(buffer.Length-2); //Exclude CRC bytes
            for (j = 0; j < buffer_size; j++)
            {
                //crc_accum = (ushort)(crc_table[(crc_accum ^ buffer[j]) & 0xFF] ^ (crc_accum >> 8));
                i = (ushort)(((ushort)(crc_accum >> 8) ^ buffer[j]) & 0xFF);
                crc_accum = (ushort)((crc_accum << 8) ^ crc_table[i]);
            }
            return crc_accum;
        }

        private byte SmallArmIK(double x_mm, double y_mm, double z_mm, int[] result)
        {
            //x_mm = 0; //temp
            double r_mm = Math.Sqrt(x_mm * x_mm + y_mm * y_mm);               //平面の距離
            double l_mm = Math.Sqrt(x_mm * x_mm + y_mm * y_mm + z_mm * z_mm); //立体の距離
            double link1 = 81;      //リンク1
            double link2 = 95.5;    //リンク2

            double theta0a = x_mm / r_mm;
            double theta0 = Math.Asin(theta0a);    //ID1 角度

            double theta1a = l_mm * l_mm + link1 * link1 - link2 * link2;
            double theta1b = 2 * link1 * l_mm;
            double theta1c = z_mm / r_mm;
            double theta1d = Math.Acos(theta1a / theta1b);
            double theta1e = Math.Atan(theta1c);
            double theta1f = Math.Atan(z_mm / r_mm);
            double theta1 = theta1d + theta1f;

            double theta2a = z_mm - link1 * Math.Sin(theta1);
            double theta2b = r_mm - link1 * Math.Cos(theta1);
            double theta2c = Math.Atan(theta2a / theta2b);
            double theta2 = theta2c - theta1;

            label6.Text = "r=" + r_mm + ",l=" + l_mm + "\r\ntheta0a=" + theta0a + ",theta0=" + theta0 + "\r\ntheta1a=" + theta1a + ",theta1b=" + theta1b + ",theta1c=" + theta1c + ",theta1d" + Math.Acos(theta1a / theta1b) + ",theta1e=" + Math.Atan(theta1c);


            result[0] = (int)(theta0 * 180 / Math.PI);
            result[1] = (int)(theta1 * 180 / Math.PI);
            result[2] = (int)(theta2 * 180 / Math.PI);


            // check the calculation
            if ((l_mm >= link1 + link2) | (l_mm < link2 - link1))
            {
                return 1;
            }

            if (Double.IsNaN(theta1d) | Double.IsNaN(theta1e) | Double.IsNaN(theta2c))
            {
                return 2;
            }

            return 0;
        }



        


        private ushort Servo_deg2val(int servo_deg)
        {
            ushort servo_pos = 0;
            servo_pos = (ushort)(servo_deg * 4096 / 360); // Tips : /360を先にするとdoubleじゃないのでバグる(それはそう)
            return servo_pos;
        }


        // often use
        private void Servo_TorqueOnOff(byte id, bool on)
        {
            byte[] param = new byte[1];
            if (on) param[0] = 0x01; else param[0] = 0x00; //MSB
            WriteData(id, 0x0040, param);
        }
        private void Servo_LEDOnOff(byte id, bool on)
        {
            byte[] param = new byte[1];
            if (on) param[0] = 0x01; else param[0] = 0x00; //MSB
            WriteData(id, 0x0041, param);
        }
        private void Servo_DriveMode_Timebased(byte id)
        {
            byte[] param = new byte[1];
            param[0] = 0x04; //Set as Time-based Profile;
            WriteData(id, 0x000A, param);
        }
        private void Servo_DriveMode_Velocitybased(byte id)
        {
            byte[] param = new byte[1];
            param[0] = 0x00; //Set as Velocity-based Profile;
            WriteData(id, 0x000A, param);
        }

        private void Servo_Move(byte id, ushort position)
        {
            servoInfo1.Text = position.ToString();
            byte[] param = new byte[4];
            param[0] = (byte)(position & 0x00FF); // LSB
            param[1] = (byte)((position >> 8) & 0x00FF);
            param[2] = 0x00;
            param[3] = 0x00; // MSB

            WriteData(id, 0x0074, param);
        }


        // 
        private void Servo_Move_with_param(byte id, ushort position, ushort time_ms)
        {
            servoInfo1.Text = position.ToString();
            byte[] param = new byte[8];
            param[0] = (byte)(time_ms & 0x00FF);
            param[1] = (byte)((time_ms >> 8) & 0x00FF);
            param[2] = 0x00;
            param[3] = 0x00;
            param[4] = (byte)(position & 0x00FF); // LSB
            param[5] = (byte)((position >> 8) & 0x00FF);
            param[6] = 0x00;
            param[7] = 0x00; // MSB

            WriteData(id, 0x0070, param);
        }


        private void Servo_SyncMove(byte[] id, ushort[] pos)
        {
            int inst_len = 4; // Profile Velocity(112) + Goal Position (116)

            int param_num = id.Length * inst_len;
            byte[] param = new byte[param_num];
            label6.Text += "\r\n" + param_num.ToString() + "\r\n";

            for (int k = 0; k < id.Length; k++)
            {
                int j = id[k] - 1;
                // Goal Position (116)
                param[(inst_len * k)] = (byte)(pos[j] & 0x00FF); // (116) LSB
                param[(inst_len * k + 1)] = (byte)((pos[j] >> 8) & 0x00FF); // (116+1)
                param[(inst_len * k + 2)] = (byte)((pos[j] >> 16) & 0x00FF); // (116+2)
                param[(inst_len * k + 3)] = (byte)((pos[j] >> 24) & 0x00FF); // (116+3) MSB

            }

            for (int k = 0; k < param_num; k++)
            {
                label6.Text += (param[k].ToString("X2"));
            }

            SyncWriteData(id, 0x0074, param);
        }
        private void Servo_SyncMove(byte[] id, ushort[] pos, ushort time_ms)
        {
            int inst_len = 4 + 4; // Profile Velocity(112) + Goal Position (116)

            int param_num = id.Length * inst_len;
            byte[] param = new byte[param_num];
            //label6.Text += "\r\n"+param_num.ToString()+"\r\n";

            for (int k = 0; k < id.Length; k++)
            {
                int j = id[k]-1;
                // Profile Velocity (112)
                param[(inst_len * k)] = (byte)(time_ms & 0x00FF); // (112) LSB
                param[(inst_len * k + 1)] = (byte)((time_ms >> 8) & 0x00FF); // (112+1)
                param[(inst_len * k + 2)] = (byte)((time_ms >> 16) & 0x00FF); // (112+2)
                param[(inst_len * k + 3)] = (byte)((time_ms >> 24) & 0x00FF); // (112+3) MSB

                // Goal Position (116)
                param[(inst_len * k + 4)] = (byte)(pos[j] & 0x00FF); // (116) LSB
                param[(inst_len * k + 5)] = (byte)((pos[j] >> 8) & 0x00FF); // (116+1)
                param[(inst_len * k + 6)] = (byte)((pos[j] >> 16) & 0x00FF); // (116+2)
                param[(inst_len * k + 7)] = (byte)((pos[j] >> 24) & 0x00FF); // (116+3) MSB

            }

            for (int k = 0; k < param_num; k++)
            {
                label6.Text += (param[k].ToString("X2"));
            }

            SyncWriteData(id, 0x0070, param);
        }
        private void Servo_ALLTorqueOnOff(byte[] id, int on)
        {
            int inst_len = 1; // Torque

            int param_num = id.Length * inst_len;
            byte[] param = new byte[param_num];

            for (int k = 0; k < id.Length; k++)
            {
                int j = id[k] - 1;
                // Profile Velocity (112)
                param[(inst_len * k)] = (byte)(on & 0x0001); // 
            }

            for (int k = 0; k < param_num; k++)
            {
                label6.Text += (param[k].ToString("X2"));
            }

            SyncWriteData(id, 0x0040, param);
        }










        /** Form Functions **/

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            LoadCOMPortNum();
            LoadBaudrateList();

            servoInfo1.Text = "Unknown";
            label_TB1.Text = "Deg: ,Position:";


            // select COM port
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = true;
                comboBox2.SelectedIndex = 2;
                comboBox2.Enabled = true;
                Open_button.Enabled = true;
                
                // Set Port
                /*for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    item = (ComComboItem)comboBox1.Items[i];
                    if (item.COM == Properties.Settings.Default.ComPortNumber)
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }*/
            }
            else
            {
                comboBox1.Items.Add("-");
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = false;
                comboBox2.SelectedIndex = 2;
                comboBox2.Enabled = false;
                Open_button.Enabled = false;
                //InitやTrackbarなどもここで切り替え
            }
        }


        private void Open_button_Click(object sender, EventArgs e)
        {
            string portName = "COM11";
            serialPort1.BaudRate = 115200;
            serialPort1.PortName = portName;
            //serialPort1.NewLine = "\r\n";
            try
            {
                serialPort1.Open();
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }



            Open_button.Text = "Close";
            Open_button.Enabled = false;

            /*if (serialPort1.IsOpen == true)
            {
                try
                {
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                serialPort1.PortName = comboBox1.Text;

                try
                {
                    serialPort1.BaudRate = int.Parse(comboBox2.Text);
                    serialPort1.Open();
                    serialPort1.ReadExisting();
                    ServoMove(1, 4000);
                }
                catch (Exception ex)
                {
                    serialPort1.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }

                Open_button.Text = "Close";
            }*/
        }

        private void Init_button_Click(object sender, EventArgs e)
        {
            //Ping(1);//154?
            //Servo_LEDOnOff(1, true);
            Servo_DriveMode_Timebased(1);
            Task.Delay(50);
            //Servo_LEDOnOff(2, true);
            Servo_DriveMode_Timebased(2);
            Task.Delay(50);
            //Servo_LEDOnOff(3, true);
            Servo_DriveMode_Timebased(3);
            Task.Delay(50);
            Servo_DriveMode_Timebased(4);
            Task.Delay(50);
            Servo_DriveMode_Timebased(5);
            Task.Delay(50);
        }
        
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            int servo_deg = trackBar1.Value;
            ushort servo_pos = Servo_deg2val(servo_deg);

            label_TB1.Text = "Deg:" + servo_deg.ToString("D3") + ",Position:" + servo_pos.ToString("D4");
            
            if (Write_mode_checkBox.Checked) Servo_Move(1, servo_pos);  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x_mm = Int32.Parse(textBox1.Text);
            int y_mm = Int32.Parse(textBox2.Text);
            int z_mm = Int32.Parse(textBox3.Text);
            int[] result = new int[3];
            byte flag = 0;
            flag = SmallArmIK(x_mm, y_mm, z_mm, result);
            // Switchにしたほうがいいかも
            if (flag == 1)
            {
                Theta0_textBox.Text = "OUT OF RANGE";
                Theta1_textBox.Text = "OUT OF RANGE";
                Theta2_textBox.Text = "OUT OF RANGE";
            }
            else if (flag == 2)
            {
                Theta0_textBox.Text = "ERROR";
                Theta1_textBox.Text = "ERROR";
                Theta2_textBox.Text = "ERROR";
            }
            else if (flag == 0)
            {
                Theta0_textBox.Text = result[0].ToString();
                Theta1_textBox.Text = result[1].ToString();
                Theta2_textBox.Text = result[2].ToString();
                ID1_textBox.Text = (180 - result[0]).ToString();
                ID2_textBox.Text = (90 + result[1]).ToString();
                ID3_textBox.Text = (180 - result[2]).ToString();
            }
            
        }

        private void AM_Sendbutton_Click(object sender, EventArgs e)
        {
            byte[] id = { 1, 2, 3 };
            ushort[] pos = new ushort[3];
            pos[0] = Servo_deg2val(Int32.Parse(ID1_textBox.Text)); //360 ->4096
            pos[1] = Servo_deg2val(Int32.Parse(ID2_textBox.Text));
            pos[2] = Servo_deg2val(Int32.Parse(ID3_textBox.Text));
            Servo_SyncMove(id, pos, 500);


            /*ushort pos1 = Servo_deg2val(Int32.Parse(ID1_textBox.Text));
            ushort pos2 = Servo_deg2val(Int32.Parse(ID2_textBox.Text));
            ushort pos3 = Servo_deg2val(Int32.Parse(ID3_textBox.Text));

            byte[] id = { 1, 2, 3};

            byte[] param = new byte[12];
            param[0] = (byte)(pos1 & 0x00FF); // LSB
            param[1] = (byte)((pos1 >> 8) & 0x00FF);
            param[2] = 0x00;
            param[3] = 0x00;
            param[4] = (byte)(pos2 & 0x00FF); // LSB
            param[5] = (byte)((pos2 >> 8) & 0x00FF);
            param[6] = 0x00;
            param[7] = 0x00;
            param[8] = (byte)(pos3 & 0x00FF); // LSB
            param[9] = (byte)((pos3 >> 8) & 0x00FF);
            param[10] = 0x00;
            param[11] = 0x00;

            for (int k = 0; k < 12; k++)
            {
                label6.Text += (param[k].ToString());
            }

            SyncWriteData(id, 0x0074, param);*/
        }

        private void DataReceivedHandler(object sender,SerialDataReceivedEventArgs e)
        {
            int count = 0;
            byte[] buffer = new byte[128];
            // Receive Data
            try
            {
                count = serialPort1.Read(buffer, 0, 128);
            }
            catch (Exception ex) { }

            for (int i = 0; i<count; i++)
            {
               this.Invoke(new MethodInvoker(delegate { Read_textBox.Text += buffer[i].ToString("X") + " "; }));   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] id = { 1, 2, 3, 4, 5 };
            if(button2.Text == "Torque : Off")
            {
                Servo_ALLTorqueOnOff(id, 0x01);
                button2.Text = "Torque : On";
            }
            else
            {
                Servo_ALLTorqueOnOff(id, 0x00);
                button2.Text = "Torque : Off";
            }
                  
            /*Servo_TorqueOnOff(1, true);
            Task.Delay(50);
            Servo_TorqueOnOff(2, true);
            Task.Delay(50);
            Servo_TorqueOnOff(3, true);
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] id = { 1, 2 };
            ushort[] pos = new ushort[3];
            pos[0] = 2048;
            pos[1] = 512;
            pos[2] = 2048;
            //Servo_SyncMove(id, pos);
            //Servo_DriveMode_Velocitybased(1);
            //Servo_Move_with_param(1, 2048, 256);
        }
    }
}
