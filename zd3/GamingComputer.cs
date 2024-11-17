using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public GamingComputer(string name, int frequency, int volume, int year, string condition,int volumeVin, string type, int volumeSSD, string backlight)
            : base(name, frequency, volume, year, condition)
        {
            VolumeVin = volumeVin;
            Type = type;
            VolumeSSD = volumeSSD;
            Backlight = backlight; 
        }
        public double Qp()
        {
            return Q() + (0.5 * VolumeVin);
        }
        public override string ToString()
        {
            return base.ToString() + $",Объем винчестера:{VolumeVin},Тип видеокарты:{Type}," +
                $"Объем SSD:{VolumeSSD},Подстветка:{Backlight},Qp:{Math.Round(Qp(), 2)}";
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
