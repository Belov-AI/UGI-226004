﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    public partial class MainForm : Form
    {
        Panel parametersPanel;

        Photo originalPhoto;
        Photo resultPhoto;

        public MainForm()
        {
            InitializeComponent();

            filtersComboBox.Items.Add("Осветление/затемнение");
             
            var bmp = (Bitmap)Image.FromFile("cat.jpg");
            originalPictureBox.Image = bmp;
            originalPhoto = Convertors.BitmapToPhoto(bmp);
        }

        private void filtersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            applyButton.Visible = true;

            if(parametersPanel != null)
                this.Controls.Remove(parametersPanel);

            parametersPanel = new Panel();

            parametersPanel.Left = filtersComboBox.Left;
            parametersPanel.Top = filtersComboBox.Bottom + 13;
            parametersPanel.Width = filtersComboBox.Width;
            parametersPanel.Height = applyButton.Top - parametersPanel.Top - 13;

            this.Controls.Add(parametersPanel);

            if(filtersComboBox.SelectedItem.ToString() == "Осветление/затемнение")
            {
                var label = new Label();
                label.Left = 0;
                label.Top = 0;
                label.Width = parametersPanel.Width - 50;
                label.Height = 28;
                label.Text = "Коэффициент";
                label.Font = new Font(label.Font.FontFamily, 10);
                parametersPanel.Controls.Add(label);

                var inputBox = new NumericUpDown();
                inputBox.Left = label.Right + 5;
                inputBox.Top = label.Top;
                inputBox.Width = 45;
                inputBox.Height = label.Height;
                inputBox.Font = new Font(inputBox.Font.FontFamily, 10);
                inputBox.Minimum = 0;
                inputBox.Maximum = 10;
                inputBox.Increment = (decimal)0.05;
                inputBox.DecimalPlaces = 2;
                inputBox.Name = "coefficent";
                inputBox.Value = 1;
                parametersPanel.Controls.Add(inputBox);
            }
        } 

        private void applyButton_Click(object sender, EventArgs e)
        {
            var newPhoto = new Photo(originalPhoto.Width, originalPhoto.Height);

            if (filtersComboBox.SelectedItem.ToString() == "Осветление/затемнение")
            {
                var k = (double)((parametersPanel.Controls["coefficent"] as NumericUpDown).Value);

                for(var x = 0; x < originalPhoto.Width; x++)
                    for(var y = 0; y < originalPhoto.Height; y++)
                    {
                        newPhoto[x,y].R = Convertors.TrimChannel(originalPhoto[x, y].R * k);
                        newPhoto[x,y].G = Convertors.TrimChannel(originalPhoto[x, y].G * k);
                        newPhoto[x,y].B = Convertors.TrimChannel(originalPhoto[x, y].B * k);
                    }               
            }

            resultPhoto = newPhoto;
            resultPictureBox.Image = Convertors.PhotoToBitmap(resultPhoto);
        }
    }
}
 