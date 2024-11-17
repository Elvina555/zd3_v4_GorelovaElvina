using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace zd3
{
    public class GamingComputer:Computer
    {
        private Queue<string> history = new Queue<string>();
        public int VolumeVin { get; set;}//Объем винчестера
        public string Type { get; set;}//Тип видеокарты
        public int VolumeSSD { get; set;}//Объем SSD
        public string Backlight { get; set;}//Подстветка
        //конструктор
        public GamingComputer(string name, int frequency, int volume, int year, string condition,int volumeVin, string type, int volumeSSD, string backlight)
            : base(name, frequency, volume, year, condition)
        {
            VolumeVin = volumeVin;
            Type = type;
            VolumeSSD = volumeSSD;
            Backlight = backlight; 
        }
        //метод который определяет «качество» объекта класса потомка
        public double Qp()
        {
            return Q() + (0.5 * VolumeVin);
        }
        //метод для корректного вывода строки 
        public override string ToString()
        {
            return base.ToString() + $",Объем винчестера:{VolumeVin},Тип видеокарты:{Type},Объем SSD:{VolumeSSD},Подстветка:{Backlight},Qp:{Math.Round(Qp(), 2)}";
        }
        // Метод для редактирования свойств игрового компьютера
        public void Edit(string type, int volumeVin, int volumeSSD, string backlight)
        {
            Type = type;
            VolumeVin = volumeVin;
            VolumeSSD = volumeSSD;
            Backlight = backlight;
        }
       
    }
}
