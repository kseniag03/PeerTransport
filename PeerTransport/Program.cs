using System;
using System.Collections.Generic;
using System.IO;
using EKRLib;

namespace PeerTransport
{
    /// <summary>
    /// Класс с основной программой.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Поле, содержащее объект для генерации случайных чисел.
        /// </summary>
        private static readonly Random Random = new();
        /// <summary>
        /// Поле, содержащее путь к файлу с информацией о сгенерированных автомобилях.
        /// </summary>
        private static readonly string PathCar = "../../../Cars.txt";
        /// <summary>
        /// Поле, содержащее путь к файлу с информацией о сгенерированных моторных лодках.
        /// </summary>
        private static readonly string PathBoat = "../../../MotorBoats.txt";

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        private static void Main()
        {
            while (true)
            {
                try
                {
                    File.WriteAllText(PathCar, string.Empty);
                    File.WriteAllText(PathBoat, string.Empty);
                    int length = Random.Next(6, 10);
                    // Для проверки кол-ва сгенерированных объектов.
                    Console.WriteLine($"Кол-во объектов в массиве: {length}");
                    Transport[] transports = new Transport[length];
                    FullArray(ref transports);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                Console.WriteLine('\n' + "Если хотите запустить ещё раз, нажмите R.");
                var input = Console.ReadKey(true).Key.ToString();
                if (input == "R")
                {
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Метод, заполняющий массив ссылками на случайным образом сгенерированные объекты Car и MotorBoat.
        /// </summary>
        /// <param name="transportArray"> Массив транспортных средств </param>
        private static void FullArray(ref Transport[] transportArray)
        {
            for (var i = 0; i < transportArray.Length; i++)
            {
                int obj = Random.Next(0, 2);
                string model = "";
                uint power = 0;
                do
                {
                    if (power < 20 && !Transport.CheckModel(model))
                    {
                        model = GetModel();
                        power = (uint)Random.Next(10, 100);
                    }
                    else if (power < 20)
                    {
                        power = (uint)Random.Next(10, 100);
                    }
                    else
                    {
                        model = GetModel();
                    }
                    try
                    {
                        transportArray[i] = obj == 0 ? new Car(model, power) : new MotorBoat(model, power);
                    }
                    catch (TransportException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                } while (power < 20 || !Transport.CheckModel(model));
                Console.WriteLine(transportArray[i].StartEngine());
                WriteTransportInfo(obj, transportArray[i]);
            }
        }

        /// <summary>
        /// Метод, гененирующий случайным образом наименование модели транспортного средства.
        /// </summary>
        /// <returns> Строку, содержащую наименование модели </returns>
        private static string GetModel()
        {
            List<int> alphabetList = new();
            for (var c = 'A'; c <= 'Z'; c++)
            {
                alphabetList.Add(c);
            }
            for (var c = '0'; c <= '9'; c++)
            {
                alphabetList.Add(c);
            }
            int[] alphabet = alphabetList.ToArray();
            string model = "";
            for (var i = 0; i < 5; i++)
            {
                model += (char)alphabet[Random.Next(0, alphabet.Length)];
            }
            return model;
        }

        /// <summary>
        /// Метод, записывающий информацию о транспортном средстве
        /// в соответствующий текстовый файл.
        /// </summary>
        /// <param name="obj"> Параметр, определяющий, в какой текстовый файл 
        /// записать текущее транспортное средство (0 – Car, 1 – MotorBoat) </param>
        /// <param name="transport"> Текущее транспортное средство </param>
        private static void WriteTransportInfo(int obj, Transport transport)
        {
            if (obj == 0)
            {
                using var writer = new StreamWriter(PathCar, true, System.Text.Encoding.Unicode);
                writer.WriteLine(transport.ToString());
            }
            else
            {
                using var writer = new StreamWriter(PathBoat, true, System.Text.Encoding.Unicode);
                writer.WriteLine(transport.ToString());
            }
        }
    }
}