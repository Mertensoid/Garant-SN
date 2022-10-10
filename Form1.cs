using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Drawing.Printing;
using System.Globalization;

namespace Garant_SN
{
    public partial class Form1 : Form
    {

        public SerialPort port = new SerialPort();
        public int lastSerial = 0;
        public string lastCom;
        public bool checkConnection = false;

        public Form1()
        {
            InitializeComponent();
            
            lastCom = "";
            
            // Чтение последнего используемого COM-порта из файла
            try
            {
                StreamReader SW = new StreamReader(new FileStream(Directory.GetCurrentDirectory() + "/com_number.txt", FileMode.Open, FileAccess.Read));
                string comString = SW.ReadLine();
                lastCom = comString;
                SW.Close();
            }
            catch
            {
                lastCom = "";
            }

            //Поиск доступных COM-портов и заполнение списка на форме
            String[] comNames = SerialPort.GetPortNames();
            foreach (string currentPort in comNames)
            {
                comList.Items.Add(currentPort);
            }

            if (lastCom != "")
                comList.Text = lastCom;
/*
//чтение из файла последнего сохраненного серийного номера
            try
            {
                StreamReader SW = new StreamReader(new FileStream(Directory.GetCurrentDirectory()+"/serial_number.txt", FileMode.Open, FileAccess.Read));
                string snString = SW.ReadLine();
                lastSerial = Convert.ToInt32(snString);
                SW.Close();
            }
            catch
            {
                lastSerial = 0;
            }
*/            
        }

        //Обработчкик события получения нового сообщение из COM-порта
        void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (port.BytesToRead > 0)
            {
                System.Threading.Thread.Sleep(100);
                string indata = (sender as SerialPort).ReadExisting();
                this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { indata });
            }
        }

        //Делегат от COM-порта к интерфейсу
        private void si_DataReceived(string data)
        {
            data = data.Replace("\r", "\r\n");
            DateTime localTime = DateTime.Now;
            var culture = new CultureInfo("en-Gb");
            dataFromPort.Text += localTime.ToString(culture) + "\r\n";

            dataFromPort.Text += data.Trim() + "\r\n";
            lastSerial = serialParcer(data, lastSerial);
            dataFromPort.AppendText(Environment.NewLine);

            StreamWriter SW = new StreamWriter(new FileStream(Directory.GetCurrentDirectory() + "/serial_base.txt", FileMode.Append, FileAccess.Write));
            SW.WriteLine(localTime.ToString(culture) + "\r\n" + data);
            SW.Close();
        }

        private delegate void SetTextDeleg(string text);

        //Открытие/закрытие COM-порта
        private void openPort_Click(object sender, EventArgs e)
        {
            try
            {
                port.PortName = comList.Text;
                port.BaudRate = Convert.ToInt16(baudRateList.Text);
                port.Parity = Parity.None;
                port.DataBits = 8;
                port.StopBits = StopBits.One;
                port.Encoding = Encoding.GetEncoding(1251);
                
                port.Open();

                port.DataReceived += new
                    SerialDataReceivedEventHandler(DataReceivedHandler);

                if (port.IsOpen)
                {
                    label2.BackColor = Color.Green;
                    sendCommand("!test " + lastSerial.ToString() + "\r");
                    
                    //Запись последнего открытого COM-порта в файл
                    StreamWriter SW = new StreamWriter(new FileStream(Directory.GetCurrentDirectory() + "/com_number.txt", FileMode.OpenOrCreate, FileAccess.Write));
                    SW.WriteLine(comList.Text);
                    SW.Close();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно открыть COM-порт");
            }
        }

        private void closePort_Click(object sender, EventArgs e)
        {
            try
            {
                sendCommand("!reset\r");
                port.Close();
                if (!port.IsOpen)
                {
                    label2.BackColor = Color.Crimson;
                }
            }
            catch
            {
                MessageBox.Show("Невозможно закрыть COM-порт");
            }
        }

        //Кусок отвечающий за вывод на печать
        private PrintDocument docToPrint = new PrintDocument();

        private void printData_Click(object sender, EventArgs e)
        {
            printDialog1.AllowSomePages = true;
            printDialog1.ShowHelp = true;
            printDialog1.Document = docToPrint;
            docToPrint.PrintPage += new PrintPageEventHandler(document_PrintPage);
            docToPrint.Print();
        }

        //Сохранение картинки в файл
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG|*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
            }
        }

            //Отрисовка печатаемых данных
            private void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                Font drawFont = new Font("Arial", 12);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                g.DrawString(lastSerial.ToString(), drawFont, drawBrush, new Point(33, 12));


//Печать даты на этикетку
                DateTime localTime = DateTime.Now;
                var culture = "dd/MM/yy";
                //new CultureInfo("en-Gb");
                g.DrawString(localTime.ToString(culture), drawFont, drawBrush, new Point(35, 44));

            }

            e.Graphics.DrawImage(pictureBox1.Image, new Point(0, 0));

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.Clear(Color.White);
                g.DrawImage(pictureBox2.Image, new Point(0, 0));
            }
        }

        //Отправка команд на COM-порт
        private void sendCommand(string comm)
        {
            try
            {
                port.Write(comm);
            }
            catch
            {
                MessageBox.Show("Не удалось отправить команду!");
            }
        }

        //Парсер сообщений на наличие серийных номеров
        private int serialParcer(string data_fromPort, int serial)
        {
            string serialString;
            int serialNumber = serial;

            if (data_fromPort.Contains("Последний С.Н. устройства"))
            {
                if (data_fromPort.Contains("Последний С.Н. устройства выше"))
                {
                    serialString = data_fromPort.Remove(data_fromPort.IndexOf("Последний С.Н. устройства выше. Будет использован С.Н. "), 55);
                    if (serialString.Contains("Последний записанный"))
                    {
                        serialString = serialString.Remove(serialString.IndexOf("Последний записанный"));
                    }
                    serialNumber = Convert.ToInt32(serialString);
                }
                else
                {
                    serialString = data_fromPort.Remove(data_fromPort.IndexOf("Последний записанный С.Н. "), 26);
                    serialNumber = Convert.ToInt32(serialString);
                }
            }

            if (data_fromPort.Contains("Записан новый С.Н. "))
            {
                serialString = data_fromPort.Remove(data_fromPort.IndexOf("Записан новый С.Н. "), 19);
                if (serialString.Contains("Ур. сигнала"))
                {
                    serialString = serialString.Remove(serialString.IndexOf("Ур. сигнала"));
                }
                serialNumber = Convert.ToInt32(serialString);
                lastSerial = serialNumber;
                docToPrint.PrintPage += new PrintPageEventHandler(document_PrintPage);
                docToPrint.Print();
            }

            if (data_fromPort.Contains("Новый С.Н. принят. Последний записанный С.Н. "))
            {
                serialString = data_fromPort.Remove(data_fromPort.IndexOf("Новый С.Н. принят. Последний записанный С.Н. "), 45);
                serialNumber = Convert.ToInt32(serialString);
            }

            if (data_fromPort.Contains("АСК не получен"))
            {
                serialString = data_fromPort.Remove(data_fromPort.IndexOf("Передан новый С.Н. "), 19);
                serialString = serialString.Remove(serialString.IndexOf("АСК не получен"));
                if (DialogResult.No != MessageBox.Show("Сохранить серийный номер вручную?", "Ответ не получен!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    serialNumber = Convert.ToInt32(serialString);
                    sendCommand("!5 1\r");
                }
                else sendCommand("!5 0\r");          
            }

            //Запись серийного номера в файл
            StreamWriter SW = new StreamWriter(new FileStream(Directory.GetCurrentDirectory()+"/serial_number.txt", FileMode.OpenOrCreate, FileAccess.Write));
            SW.WriteLine(serialNumber.ToString());
            SW.Close();
            return serialNumber;
        }

        //Сохранить кусок лога из текст-бокса в отдельный файл.
        private void saveData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter SW = new StreamWriter(saveFileDialog1.FileName);
                SW.WriteLine(dataFromPort.Text);
                SW.Close();
            }
        }

        private void RetrySN_Click(object sender, EventArgs e)
        {
            sendCommand("!askSN\r");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                port.Write("!reset\r");
            }
            catch
            {
            }
        }
        
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //pictureBox1.Image.Save("D:/Работа/Программирование/Проекты С#/Garant-SN/Подложка.png");
        }
        
    }
}
