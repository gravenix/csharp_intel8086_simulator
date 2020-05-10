using System;
using System.Linq;
using System.Windows.Forms;

namespace symulator_rejestru
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            field_ax.Text = field_bx.Text = field_cx.Text = field_dx.Text = "0";
        }

        private void onType(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                processCommand(text_input.Text);
            }
        }

        private void processCommand(string text)
        {
            string[] parts = text.Split(' ');
            if (parts[0] != "MOV")
            {
                MessageBox.Show("The only supported command is 'MOV'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string source = "", destination = "";
            if (parts[1].Contains(','))
            {
                string[] subparts = parts[1].Split(',');
                if (subparts.Length == 1) destination = subparts[0];
                else
                {
                    destination = subparts[0];
                    if (subparts[1].Length > 0) source = subparts[1];
                    else source = parts[2];
                }
            }
            if (destination == "")
            {
                destination = parts[1];
            }
            short val = 0;
            if (short.TryParse(source, out short n))
            {
                val = Convert.ToInt16(source);
            }
            else
            {
                val = getRegister(source);
            }
            setRegister(destination, val);
        }

        private short getRegister(string reg)
        {
            char[] str = reg.ToCharArray();
            short val = -1;
            switch (str[0])
            {
                case 'A':
                    val = Convert.ToInt16(field_ax.Text);
                    break;
                case 'B':
                    val = Convert.ToInt16(field_bx.Text);
                    break;
                case 'C':
                    val = Convert.ToInt16(field_cx.Text);
                    break;
                case 'D':
                    val = Convert.ToInt16(field_dx.Text);
                    break;
            }
            if (str[1] == 'X') return val;
            else if (str[1] == 'H') return (short)(val >> 8);
            else if (str[1] == 'L') return (short)(val << 8 >> 8);
            throw new Exception("Wrong register name");
        }

        private void setRegister(string reg, short val)
        {
            char[] str = reg.ToCharArray();
            short register = getRegister(str[0] + "X");
            switch (str[1])
            {
                case 'H':
                    val = (short)((register & 0x00FF) + (val << 8));
                    break;
                case 'L':
                    val = (short)((register & 0xFF00) + val);
                    break;
            }
            switch (str[0])
            {
                case 'A':
                    field_ax.Text = val.ToString();
                    break;
                case 'B':
                    field_bx.Text = val.ToString();
                    break;
                case 'C':
                    field_cx.Text = val.ToString();
                    break;
                case 'D':
                    field_dx.Text = val.ToString();
                    break;
            }
        }
    }
}
