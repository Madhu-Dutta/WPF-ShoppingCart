using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfShoppingCart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listName;
        List<double> listCost;
        double budget;
        public MainWindow()
        {
            InitializeComponent();
            listName = new List<string>();
            listCost = new List<double>();
            //Variable to store budget
            budget = 0;
        }

        private void BtnBudget_Click(object sender, RoutedEventArgs e)
        {
           if(!double.TryParse(txtBudget.Text, out budget))
            {
                MessageBox.Show("Error: Enter a valid number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            budget = double.Parse(txtBudget.Text);
            //Budget Conditions
            if (budget < getTotal())
            {
                budgetcondDisplay.Text = "Exceeds Budget";
            }
            else
            {
                budgetcondDisplay.Text = "WIthin Budget";
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Variables
            string name = txtName.Text;
            double cost;
            //Validate number entered is integer/double
            if (!double.TryParse(txtCost.Text, out cost))
            {
                MessageBox.Show("Cost be a number greater than zero cannot be empty");
                return;
            }
            //Name field is not blank/Empty
            else if (name == string.Empty)
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            //Number cannot be negetive/less than 0
            else if (cost <= 0)
            {
                MessageBox.Show("Cost be a number greater than zero cannot be empty");
                return;
            }
            //DisplayList Add
            listDisplay.Items.Add(name + "          $" + cost);
            //Add
            listName.Add(name);
            listCost.Add(cost);
            //Clear input text after adding
            txtName.Text = "";
            txtCost.Text = "";
            //Budget Conditions
            if (budget < getTotal())
            {
                budgetcondDisplay.Text = "Exceeds Budget";
            }
            else
            {
                budgetcondDisplay.Text = "WIthin Budget";
            }
            //SumDisplay
            totalValDisplay.Text = "$" + getTotal().ToString();
            
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            //Variables
            string name = txtName.Text;
            double cost;
            //Validate number entered is integer/double
            if (!double.TryParse(txtCost.Text, out cost))
            {
                MessageBox.Show("Cost be a number greater than zero cannot be empty");
                return;
            }
            //validate if the input is blank
            else if (name == string.Empty)
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            //validate if the number entered is in the list
            else if (!listName.Contains(name) || (!listCost.Contains(cost)))
            {
                MessageBox.Show("Item does not exist");
                return;
            }
            //DisplayList Remove
            listDisplay.Items.Remove(name + "          $" + cost);
            //Remove
            listName.Remove(name);
            listCost.Remove(cost);
            //Budget Conditions
            if (budget <= getTotal())
            {
                budgetcondDisplay.Text = "Exceeds Budget";
            }
            else
            {
                budgetcondDisplay.Text = "WIthin Budget";
            }
            //SumDisplay
            totalValDisplay.Text = "$" + getTotal().ToString();       

        }

        private void BtnRemoveSel_Click(object sender, RoutedEventArgs e)
        {
            //Index
            int index = listDisplay.SelectedIndex;
            //Validate if an item / index is not selected
            if (index == -1)
            {
                return;
            }
            //Display RemoveAt(index)
            listDisplay.Items.RemoveAt(index);
            //Remove(index)
            listName.RemoveAt(index);
            listCost.RemoveAt(index);
            //Budget Conditions
            if (budget <= getTotal())
            {
                budgetcondDisplay.Text = "Exceeds Budget";
            }
            else
            {
                budgetcondDisplay.Text = "WIthin Budget";
            }
            //SumDisplay
            totalValDisplay.Text = "$" + getTotal().ToString();            
        }
        public double getTotal()
        {
            //Sum
            double total = 0;
            total = listCost.Sum();
            return total;
        }

    }
}
