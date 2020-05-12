using symulator_rejestru.Intel8086;
using symulator_rejestru.Intel8086.Instructions;
using System.Windows.Forms;

namespace symulator_rejestru
{
    public partial class MainForm : Form
    {
        private Processor mProc;
        public MainForm()
        {
            InitializeComponent();
            mProc = new Processor();
            field_ax.Text = field_bx.Text = field_cx.Text = field_dx.Text = "0";
        }

        private void onType(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                processCommand(text_input.Text);
                e.Handled = true;
            }
        }

        private void processCommand(string text)
        {
            AssemblerInstruction instruction = Processor.ParseInstruction(text);
            mProc.ExecuteCommand(instruction);
            UpdateRegisters();
        }

        private void UpdateRegisters()
        {
            field_ax.Text = mProc.GetRegister().GetRegister(Register.REGISTERS.A) + "";
            field_bx.Text = mProc.GetRegister().GetRegister(Register.REGISTERS.B) + "";
            field_cx.Text = mProc.GetRegister().GetRegister(Register.REGISTERS.C) + "";
            field_dx.Text = mProc.GetRegister().GetRegister(Register.REGISTERS.D) + "";
        }
    }
}
