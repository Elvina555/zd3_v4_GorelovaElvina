using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using zd3;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Computer computerStore;
        [TestInitialize]
        //тест проверяет добавление одного компьютера в список
        [TestMethod]
        public void TestMethod1()
        {
            var computers = new List<Computer>();
            var computer = new Computer("Мощный", 500, 1000, 2010, "Новый");
            computer.AddComputer(computer);

            Assert.AreEqual(1, computer.GetAllCompute().Count);
            Assert.AreEqual("Мощный", computer.GetAllCompute()[0].name);
        }
        // тест проверяет можно ли заносить несколько компьютеров в список
        [TestMethod]
        public void TestMethod2()
        {
            var computers = new List<Computer>();
            var computer1 = new Computer("Мощный", 500, 1000, 2010, "Новый");
            var computer2 = new Computer("Слабый", 200, 500, 2015, "Б/У");

            var newComputers = new List<Computer> { computer1, computer2 };
            computer1.AddComputer(newComputers);

            Assert.AreEqual(2, computer1.GetAllCompute().Count);
        }
        //тест проверяет,удаления компьютера по объекту
        [TestMethod]
        public void TestMethod3()
        {
            var computer1 = new Computer("Мощный", 500, 1000, 2010, "Новый");
            var computer2 = new Computer("Слабый", 200, 500, 2015, "Б/У");

            computer1.AddComputer(computer2);
            computer1.RemoveComputer(computer2);

            Assert.AreEqual(0, computer1.GetAllCompute().Count);
        }
        //тест проверяет удаление компьютера по имени
        [TestMethod]
        public void TestMethod4()
        {
            var computer1 = new Computer("Мощный", 500, 1000, 2010, "Новый");
            var computer2 = new Computer("Слабый", 200, 500, 2015, "Б/У");

            computer1.AddComputer(computer2);
            computer1.RemoveComputer("Слабый");

            Assert.AreEqual(0, computer1.GetAllCompute().Count);
        }
        //тест проверяет удаление компьютера по частоте
        [TestMethod]
        public void TestMethod5()
        {
            var computer1 = new Computer("Мощный", 500, 1000, 2010, "Новый");
            var computer2 = new Computer("Слабый", 200, 500, 2015, "Б/У");

            computer1.AddComputer(computer2);
            computer1.RemoveComputer(200);

            Assert.AreEqual(0, computer1.GetAllCompute().Count);
        }
        //тест проверяет, что метод Q() вычисляет значение на основе предоставленной формулы.
        [TestMethod]
        public void TestMethod6()
        {
            var computer1 = new Computer("Мощный", 500, 1000, 2010, "Новый");
            double result = computer1.Q();
            Assert.AreEqual(1150, result);
        }
        //тест проверяет, что метод Qр() вычисляет значение на основе предоставленной формулы.
        [TestMethod]
        public void TestMethod7()
        {
            var computer1 = new GamingComputer("Мощный", 500, 1000, 2010, "Новый",500,"Гибридная",512,"Нет");
            double result = computer1.Qp();
            Assert.AreEqual(1400, result);
        }
        //метод для проверки корректности ввода информации о компьютере
        [TestMethod]
        public void TestMethod8()
        {
            var computer1 = new Computer("Мощный", 500, 1000, 2010, "Новый");
            string rezult = $"Наименование:Мощный,Частота:500,Объем оперативной памяти:1000,Год выпуска:2010," +
                $"Состояние:Новый,Q:{Math.Round(computer1.Q(), 2)}";
            string rez= computer1.ToString() ;
            Assert.AreEqual(rezult, rez, "Метод должен возвращать коррекную инормацию");
        }
       // тест для проверки корректности ввода информации о игровом компьютере
        [TestMethod]
        public void TestMethod9()
        {
            var computer1 = new GamingComputer("Мощный", 500, 1000, 2010, "Новый", 500, "Гибридная", 512, "Нет");
            string rezult = $"Наименование:Мощный,Частота:500,Объем оперативной памяти:1000,Год выпуска:2010,Состояние:" +
                $"Новый,Q:{Math.Round(computer1.Q(), 2)},Объем винчестера:500,Тип видеокарты:Гибридная,Объем SSD:512," +
                $"Подстветка:Нет,Qp:{Math.Round(computer1.Qp(), 2)}";
            string rez = computer1.ToString();
            Assert.AreEqual(rezult, rez, "Метод должен возвращать коррекную инормацию");
        }
        // тест для проверки корректности редактирования информации
        [TestMethod]
        public void TestMethod10()
        {
            string newType = "";
            int newVolumeVin = 1500;
            int newVolumeSSD = 256;
            string newBacklight = "None";
            var computer1 = new GamingComputer("Мощный", 500, 1000, 2010, "Новый", 500, "Гибридная", 512, "Нет");
            computer1.Edit(newType, newVolumeVin, newVolumeSSD, newBacklight);
            Assert.AreEqual(newType, computer1.Type);
            Assert.AreEqual(newVolumeVin, computer1.VolumeVin);
            Assert.AreEqual(newVolumeSSD, computer1.VolumeSSD);
            Assert.AreEqual(newBacklight, computer1.Backlight);
        }
        // тест проверяет добавлен ли в список компьютер, и проверяет корректность данных.
        public void TestMethod11()
        {
            string name = "Новый";
            int frequency = 3200; 
            int volume = 1000; 
            int year = 2024;
            string condition = "Нет";
            var computer1 = new Computer("Мощный", 500, 1000, 2010, "Новый");
            computer1.AddComputer(name, frequency, volume, year, condition);
            var computers = computer1.GetAllCompute();
            Assert.AreEqual(1, computers.Count);
            Assert.AreEqual(name, computers[0].name);
            Assert.AreEqual(frequency, computers[0].frequency);
            Assert.AreEqual(volume, computers[0].volume);
            Assert.AreEqual(year, computers[0].year);
            Assert.AreEqual(condition, computers[0].condition);
        }
    }
}
