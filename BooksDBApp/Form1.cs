﻿
using LibraryNetFramework.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksDBApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book book = new Book();

            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.Price = decimal.Parse(txtPrice.Text);
            book.Describe = txtDescribe.Text;
            book.CountryId = (int)cmbCountry.SelectedValue;

            BookRepo repo = new BookRepo();

            int lastId = repo.AddBookReturnId(book);

            
            MessageBox.Show(lastId.ToString());

            FillListBox();

            //MessageBox.Show(id.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Country> countries = new List<Country>();
            CountryRepo countryRepo = new CountryRepo();
            countries = countryRepo.GetAllCountries();

            this.cmbCountry.Items.Clear();
            cmbCountry.DisplayMember = "Name";
            cmbCountry.ValueMember = "Id";
            cmbCountry.DataSource = countries;

            FillListBox();
        }

        private void FillListBox()
        {
            List<Book> list = new List<Book>();
            BookRepo repo = new BookRepo();
            list = repo.GetAllBooks();
            this.lstBooks.Items.Clear();
            foreach (var item in list)
            {
                lstBooks.Items.Add(item);
            }
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbCountry.SelectedValue.ToString());
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book = (Book)lstBooks.SelectedItem;
            BookRepo bookRepo = new BookRepo();
            bookRepo.DeleteBookById(book.Id);
            FillListBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BookRepo bookRepo = new BookRepo();
                Book book = new Book();
                book.Title = txtTitle.Text;
                book.Author = txtAuthor.Text;
                book.Price = decimal.Parse(txtPrice.Text);
                book.Describe = txtDescribe.Text;
                book.Id = int.Parse(txtId.Text);
                book.CountryId = (int)cmbCountry.SelectedValue;
                bookRepo.UpdateBook(book);
                FillListBox();
            }
            catch (Exception)
            {
                lblError.Visible = true;
                this.lblError.Text = "There was a problem";
            }
            

        }
        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
            Book book = new Book();
            book = (Book)lstBooks.SelectedItem;
            txtTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtPrice.Text = book.Price.ToString();
            txtDescribe.Text = book.Describe;
            txtId.Text = book.Id.ToString();
            cmbCountry.SelectedValue = book.CountryId;
            
           
        }
    }
}
