using System.Threading.Tasks;

namespace WinFormsAppPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                textBox1.Text = "Ok";
            });
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Invoke is blocking, synchronous way to update the UI from another thread
            await Task.Run(() => this.Invoke(() => textBox1.Text = "Ok"));
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            // BeginInvoke is blocking, synchronous way to update the UI from another thread
            await Task.Run(() => this.BeginInvoke(() => textBox1.Text = "Ok"));
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WindowsMessages.WM_NULL)
            {
                MessageBox.Show("WM_NULL message received!");
            }
            base.WndProc(ref m);
        }
    }
}
