using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Bet_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rand = new Random();
        int picksNumbers = 0;
        string betRange;

        // Button that generates a quantity of pseudo-random numbers
        private void button1_Click(object sender, EventArgs e)
        {
            // Handling to ensure that a null value is not passed to an important variable
            if (betRange != null)
            {
                // Creating a list of strings to store the numbers
                List<string> numbers = new List<string> { };
                // The drawn numbers will be stored in this list
                List<string> picks = new List<string> { };

                int range = Convert.ToInt16(betRange.Substring(6));

                // Filling the list with numbers within the chosen range
                for (int i = 0; i <= range; i++)
                {
                    // Adding the numbers to the list formatted with two decimal places (with a leading zero, if necessary)
                    numbers.Add(i.ToString("00"));
                }
                // Generating the indexes of the drawn numbers
                for (int i = 0; i <= picksNumbers; i++)
                {
                    int drawnNumber = rand.Next(0, numbers.Count);

                    // Adding the drawn numbers by index
                    picks.Add(numbers[drawnNumber]);
                    // Deleting the drawn numbers from the first list
                    numbers.RemoveAt(drawnNumber);
                }
    
                
                // Organizes the display of the numbers
                picks.Sort();
                string result = string.Join(" - ", picks);
                textBox1.Text = result;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            betRange = cmb.SelectedItem.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            picksNumbers = Convert.ToInt16(cmb.SelectedItem);
        }
    }
}
