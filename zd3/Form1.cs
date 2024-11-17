using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zd3
{
    public partial class Form1 : Form
    {
        Computer com = new Computer("", 0, 0, 0, "");
        private List<Computer> computers = new List<Computer>();
        private List<GamingComputer> game = new List<GamingComputer>();
        private Queue<string> history = new Queue<string>();
        public Form1()
        {
            InitializeComponent();
        }
        // Метод для добавления истории
        public void AddHistory(string name)
        {
            history.Enqueue($"{name}");
        }

        // Метод для вывода истории в listBox
        public void ShowHistory(ListBox listBox)
        {
            listBox3.Items.Clear();
            foreach (var entry in history)
            {
                listBox.Items.Add(entry);
            }
        }
        //метод для реализации всего списка
        public Queue<string> GetHistoryQueue()
        {
            return history;
        }
        //метод для проверки, что только буквы
        private bool IsAllLetters(string inp)
        {
            foreach (var ch in inp)
            {
                if (!char.IsLetter(ch))
                {
                    return false;
                }
            }
            return true;
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "")//проверка напустые поля
            {
                string name = textBox1.Text;
                int frequency = Convert.ToInt32(numericUpDown1.Value);
                int volume = Convert.ToInt32(numericUpDown2.Value);
                int year = Convert.ToInt32(numericUpDown3.Value);
                string condition = comboBox1.Text;
    

                if (IsAllLetters(name))//проверка, что в наименновании толко буквы
                {
                    if (IsUniqueName(name)) //проверка на уникальность
                    {
                        Computer newComputer = new Computer(name, frequency, volume, year, condition);
                        computers.Add(newComputer);
                        listBox1.Items.Add(newComputer.ToString());
                        AddHistory(name);
                        ShowHistory(listBox3);


                        MessageBox.Show("Компьютер добавлен");
                    }
                    else
                    {
                        MessageBox.Show("Компьютер с таким именем уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("В наименовании должны быть только буквы");
                    
                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }

        }
        //метод с проверкой на уникальность 
        private bool IsUniqueName(string name)
        {
            foreach (var computer in computers)
            {
                if (computer.name.Equals(name))
                {
                    return false; 
                }
            }
            return true; 
        }
        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")//проверка на пустые поля
            {
               
                    string name = textBox1.Text;
                    int frequency = Convert.ToInt32(numericUpDown1.Value);
                    int volume = Convert.ToInt32(numericUpDown2.Value);
                    int year = Convert.ToInt32(numericUpDown3.Value);
                    string condition = comboBox1.Text;
                    int volumeVin = Convert.ToInt32(numericUpDown4.Value);
                    string type = comboBox2.Text;
                    int volumeSSD = Convert.ToInt32(numericUpDown5.Value);
                    string backlight = comboBox3.Text;
                if (IsAllLetters(name))//проверка, что в наименновании толко буквы
                {
                    if (IsUniqueName(name))// проверка на уникальность
                    {
                        GamingComputer newGamingComputer = new GamingComputer(name, frequency, volume, year, condition, volumeVin, type, volumeSSD, backlight);
                        game.Add(newGamingComputer);
                        listBox2.Items.Add(newGamingComputer.ToString());
                        MessageBox.Show("Игровой компьютер добавлен");
                    }
                    else
                    {
                        MessageBox.Show("Компьютер с таким именем уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("В наименовании должны быть только буквы");

                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }
        //удаление компьютера
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)///проверка на то что компьютер сущестыует
            {
                string selectedComputer = listBox1.SelectedItem.ToString();
                computers.RemoveAll(c => c.ToString().Contains(selectedComputer));
                listBox1.Items.Remove(listBox1.SelectedItem);
                MessageBox.Show("Компьютер удален");
            }
            else
            {
                MessageBox.Show("Выберите компьютер для удаления");
            }
        }
        //редактирование игрового компьютера
        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                GamingComputer selectedGamingComputer = game[listBox2.SelectedIndex];
                string newType = comboBox2.Text;
                int newVolumeVin = Convert.ToInt32(numericUpDown4.Value);
                int newVolumeSSD = Convert.ToInt32(numericUpDown5.Value);
                string newBacklight = comboBox3.Text;

                // Редактируем выбранный игровой компьютер
                selectedGamingComputer.Edit(newType, newVolumeVin, newVolumeSSD, newBacklight);

                // Обновляем ListBox
                listBox2.Items[listBox2.SelectedIndex] = selectedGamingComputer.ToString();
                MessageBox.Show("Игровой компьютер обновлен");
            }
            else
            {
                MessageBox.Show("Выберите игровой компьютер для редактирования");
            }
        }
        //удаление игрового компьютера 
        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)//проверка на то что компьютер сущестыует
            {
                string selectedGamingComputer = listBox2.SelectedItem.ToString();
                game.RemoveAll(gc => gc.ToString().Contains(selectedGamingComputer));
                listBox2.Items.Remove(listBox2.SelectedItem);
                MessageBox.Show("Игровой компьютер удален");
            }
            else
            {
                MessageBox.Show("Выберите игровой компьютер для удаления");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
