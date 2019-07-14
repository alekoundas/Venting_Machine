using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontEnd.Repository;
using FrontEnd.SqlTools;
using FrontEnd.Transactions;


namespace FrontEnd
{
    public partial class VentingMachineForm : Form
    {

        BindingSource StoreItemsBinding = new BindingSource();
        BindingSource CartItemsBinding = new BindingSource();
        public VentingMachineForm()
        {
            InitializeComponent();
            DataBase.dbGetStartUpData();//Connect to db and fill product queue and Customer
            SetBalanceLabelByChange();//Refrece balance 
            RefreshAvailableProductsListBoxByChange();
        }


        private void AddToCartOnClick(object sender, EventArgs e)
        {
            VentingMachine.Instance.CartQueue.Enqueue((Iproduct)AvailableProductsListBox.SelectedItem);
            SetTotalLabelByChange();           
            RefreshCartListBoxByChange();
        }



        private void Purchace(object sender, EventArgs e)
        {
            //Sum of the Cart Items
            double TotalCartValue = VentingMachine.Instance.CartQueue.Sum(x => x.Price);
            if (Customer.Instance.Money >= TotalCartValue)
            {
                VentingMachine.Instance.CartQueue.Clear();
                MessageBox.Show("Thank You For The Purchace");
                Customer.Instance.Money -= TotalCartValue;
                SetBalanceLabelByChange();
            }
            else
            {
                MessageBox.Show("Not Enougth Balance");
            }
            RefreshCartListBoxByChange();
        }


        private void RefreshCartListBoxByChange()
        {
            //Distinct cart Items by Title (so the items inside are unique to display)
            CartItemsBinding.DataSource = VentingMachine.Instance.CartQueue.GroupBy(x => x.Title).ToList().Select(x => x.FirstOrDefault()).ToList();
            CartListBox.DataSource = CartItemsBinding;
            CartListBox.DisplayMember = "OutputCart";
            CartListBox.ValueMember = "OutputCart";
        }
        private void RefreshAvailableProductsListBoxByChange()
        {
            StoreItemsBinding.DataSource = VentingMachine.Instance.ProductQueue.GroupBy(x=>x.Title).Select(x=>x.FirstOrDefault()).ToList();
            AvailableProductsListBox.DataSource = StoreItemsBinding;
            AvailableProductsListBox.DisplayMember = "OutputAvailable";
            AvailableProductsListBox.ValueMember = "OutputAvailable";
        }
        private void SetBalanceLabelByChange()
        {
            BalanceLabel.Text = "Balance: " + Customer.Instance.Money;
        }
        private void SetTotalLabelByChange()
        {
            TotalLabel.Text = "Total Cost: " + VentingMachine.Instance.CartQueue.Sum(x => x.Price);
        }

        private void RemoveFromCartClick(object sender, EventArgs e)
        {

            if (VentingMachine.Instance.CartQueue.Count>0)
            {
                Repository<Iproduct>.RemoveFromVentingMachine(VentingMachine.Instance.CartQueue, (Iproduct)CartListBox.SelectedItem);
                RefreshCartListBoxByChange();
                SetTotalLabelByChange();
            }          
        }

        private void ClearCartClick(object sender, EventArgs e)
        {
            VentingMachine.Instance.CartQueue.Clear();
            RefreshCartListBoxByChange();
            SetTotalLabelByChange();
        }

    }
}
