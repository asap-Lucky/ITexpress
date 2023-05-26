﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abstraction.Interfaces;
using BLL.Services;
using BLL.Models;
using BLL.Singleton;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Presentation.Customer;
using BLL.Facader;

namespace Presentation.All
{
    public partial class ConsultantMessage_Form : Form
    {
        IMessage CustomerMessage { get; set; }
        List<ICustomer> Customers { get; set; }
        BLL.Facader.CustomerService CustomerService { get; set; }

        public  ConsultantMessage_Form()
        {
            InitializeComponent();          
            buttonRespond.Visible = false;
            labelFrom.Visible = false;
            tb_From.Visible = false;
            CustomerService = new BLL.Facader.CustomerService(new BLL.Services.CustomerService());
            Customers = CustomerService.GetAllCustomers();
            comboBoxTo.DisplayMember = "Email";
            comboBoxTo.ValueMember = "ICustomer";
            comboBoxTo.DataSource = Customers;
        }

        public ConsultantMessage_Form(IMessage message)
        {
            InitializeComponent();
            CustomerMessage = message;
            buttonSend.Enabled = false;
            labelTo.Visible = false;
            comboBoxTo.Visible = false;
            tb_Title.Text = message.Header;
            tb_Title.Enabled = false;
            tb_Title.Text = message.Body;
            tb_Title.Enabled = false;
            tb_From.Text = message.Customer.GetFullName;
            tb_From.Enabled = false;
            tb_BodyMessage.Text = message.Body;
            tb_BodyMessage.Enabled = false;
        }

        private void bt_GoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MessageRespond()
        {
            buttonRespond.Enabled = false;
            buttonSend.Enabled = true;
            labelFrom.Visible = false;
            tb_From.Visible = false;
            comboBoxTo.Visible = true;
            comboBoxTo.Enabled = false;
            comboBoxTo.Text = CustomerMessage.Customer.Email;
            tb_Title.Text = "Re: " + tb_Title.Text;
            tb_BodyMessage.Enabled = true;
            tb_BodyMessage.Clear();
        }

        private void buttonRespond_Click(object sender, EventArgs e)
        {
            ConsultantMessage_Form consultantMessage_Form = new ConsultantMessage_Form();
            consultantMessage_Form.MessageRespond();
            consultantMessage_Form.ShowDialog();
        }
    }
}



