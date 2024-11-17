using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace zd3
{
    public class Computer
    {
        private List<Computer> computers = new List<Computer>();
        public string name; //Наименование 
        public int frequency;  //Частота
        public int volume; //Объем оперативной памяти
        public int year; //Год выпуска
        public string condition; //Состояние 

        //Конструктор
        public Computer(string name, int frequency,int volume,int year,string condition)
        {
            this.name=name;
            this.frequency = frequency;
            this.volume = volume;
            this.year = year;
            this.condition = condition;
        }
        public List<Computer> GetAllCompute()
        {
            return computers;
        }
        //Перегрузка для добавления в коллекцию компьютеров c помощью Linq
        public void AddComputer(List<Computer> newComputers)
        {
            foreach (var computer in newComputers)
            {
                computers.Add(computer);
            }
            MessageBox.Show($"{newComputers.Count} компьютеров добавлено");
        }
        //метод для добавления одного компьютера в список с помощью Linq
        public void AddComputer(Computer comp)
        {
                computers.Add(comp);
                MessageBox.Show("Компьютер добавлен добавлен");
        }
        //метод для создания и добавления компьютера в список
        public void AddComputer(string name, int frequency, int volume, int year, string condition)
        {
            Computer сomputer = new Computer(name,frequency,volume,year,condition);
            AddComputer(сomputer);
        }
        //метод, который определяет качество объекта – Q по заданной формуле
        public double Q()
        {
            return (0.3 * frequency) + volume;
        }
        //метод для корректного вывода строки 
        public override string ToString()
        {

            return ($"Наименование:{name},Частота:{frequency},Объем оперативной памяти:{volume}," +
                $"Год выпуска:{year},Состояние:{condition},Q:{Math.Round(Q(), 2)}");
        }
        // Метод для удаления компьютера по объекту c помощью Linq
        public void RemoveComputer(Computer computer)
        {
            if (computers.Remove(computer))
            {
                MessageBox.Show("Компьютер удален");
            }
            else
            {
                MessageBox.Show("Компьютер не найден");
            }
        }

        // Перегрузка для удаления компьютера по имени  c помощью Linq
        public void RemoveComputer(string name)
        {
            var computerToRemove = computers.FirstOrDefault(c => c.name.Equals(name));
            if (computerToRemove != null)
            {
                computers.Remove(computerToRemove);
                MessageBox.Show("Компьютер удален");
            }
        }

        // Перегрузка для удаления компьютера по частоте  c помощью Linq
        public void RemoveComputer(int frequency)
        {
            var computerToRemove = computers.FirstOrDefault(c => c.frequency == frequency);
            if (computerToRemove != null)
            {
                computers.Remove(computerToRemove);
                MessageBox.Show("Компьютер удален");
            }
        }
        

    }

}
