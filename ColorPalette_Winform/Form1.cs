using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPalette_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            int redCode, greenCode, blueCode;

            redCode = trackBarRed.Value;
            mskRed.Text=redCode.ToString();

            greenCode = trackBarGreen.Value;
            mskGreen.Text=greenCode.ToString();

            blueCode = trackBarBlue.Value;
            mskBlue.Text=blueCode.ToString();   
            this.BackColor=Color.FromArgb(redCode, greenCode, blueCode);
        }

        private bool CheckColorCode(int numCode)
        {
            if (numCode >= 0 && numCode <= 255) return true;
            return false;
        }

        private bool isEmpty(string text)
        {
            if(text.Length == 0) return true;
            return false;
        }

        private void msk_TextChanged(object sender, EventArgs e)
        {
            int numRed,numGreen, numBlue; 
            if(isEmpty(mskRed.Text))numRed = 0;
            else numRed = Convert.ToInt32(mskRed.Text);

            if (isEmpty(mskGreen.Text))numGreen = 0;
            else numGreen = Convert.ToInt32(mskGreen.Text);

            if (isEmpty(mskBlue.Text))numBlue = 0;
            else numBlue = Convert.ToInt32(mskBlue.Text);


            if (CheckColorCode(numRed) && CheckColorCode(numBlue) && CheckColorCode(numGreen))
            {
                trackBarRed.Value = numRed;
                trackBarGreen.Value = numGreen;
                trackBarBlue.Value = numBlue;
                this.BackColor = Color.FromArgb(numRed, numGreen, numBlue);
            }
            else
            {
                MessageBox.Show("Color code should be between 0 and 255 !!!", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numRed = 255;numGreen = 255;numBlue = 255;
                trackBarRed.Value = numRed;
                trackBarGreen.Value = numGreen;
                trackBarBlue.Value = numBlue;
                mskRed.Text = numRed.ToString();
                mskGreen.Text = numGreen.ToString();
                mskBlue.Text = numBlue.ToString();
                this.BackColor = Color.FromArgb(numRed, numGreen, numBlue);
            }
        }
    }
}
