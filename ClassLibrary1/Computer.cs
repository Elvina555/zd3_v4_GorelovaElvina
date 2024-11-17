using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
        public void AddComputer(List<Computer> newComputers)
        {
            foreach (var computer in newComputers)
            {
                computers.Add(computer);
            }
        }
        public void AddComputer(Computer comp)
        {
                computers.Add(comp);
        }
        public void AddComputer(string name, int frequency, int volume, int year, string condition)
        {
            Computer сomputer = new Computer(name,frequency,volume,year,condition);
            AddComputer(сomputer);
        }
        public double Q()
        {
            return (0.3 * frequency) + volume;
        }
        public override string ToString()
        {

            return ($"Наименование:{name},Частота:{frequency},Объем оперативной памяти:{volume},Год выпуска:{year},Состояние:{condition},Q:{Math.Round(Q(), 2)}");
        }
        // Метод для удаления компьютера по объекту
        public void RemoveComputer(Computer computer)
        {
            computers.Remove(computer);
            
        }

        // Перегрузка для удаления компьютера по имени
        public void RemoveComputer(string name)
        {
            var computerToRemove = computers.FirstOrDefault(c => c.name == name);
            if (computerToRemove != null)
            {
                computers.Remove(computerToRemove);
            }
        }

        // Перегрузка для удаления компьютера по частоте
        public void RemoveComputer(int frequency)
        {
            var computerToRemove = computers.FirstOrDefault(c => c.frequency == frequency);
            if (computerToRemove != null)
            {
                computers.Remove(computerToRemove);
            }
        }

        
    }

}
