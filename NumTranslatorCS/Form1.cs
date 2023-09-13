using System.Windows.Forms;
using System.Xml;

namespace NumTranslatorCS
{
  public partial class mainForm : Form
  {
    private static int sum;
    private static char flag;
    public mainForm()
    {
      InitializeComponent();
      errorHandler.getFormObj(this);
      sum = -1;
      flag = 'u';
    }
    public static void getOutput(int op)
    {
      sum = op;
      flag = 'c';
    }
    private void label1_Click(object sender, System.EventArgs e)
    {

    }

    // TRANSLATE button
    private void button1_Click(object sender, System.EventArgs e)
    {
      if (textBox1.Text != "")
      {
        numTranslator nt = new numTranslator(textBox1.Text.ToLower(), this);
        
        if ((flag == 'c')&&(sum != -1))
        {
          textBox2.Text = sum.ToString();
        }
      }
      else
      {
        errorHandler.errorEmptyTransField();
      }
    }

    // CLEAR ALL button
    private void button2_Click(object sender, System.EventArgs e)
    {
      if ((textBox1.Text == "") && (textBox2.Text == ""))
      {
        errorHandler.infoNoNeedToClearAll();
      }
      else
      {
        textBox1.Text = "";
        textBox2.Text = "";
      }
      flag = 'u';
      sum = -1;
    }

    private void textBox1_TextChanged(object sender, System.EventArgs e)
    {
      flag = 'u';
      sum = -1;
    }
  }
}
