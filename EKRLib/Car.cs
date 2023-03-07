namespace EKRLib
{
    /// <summary>
    /// Класс Car, описывающий автомобиль.
    /// </summary>
    public class Car : Transport
    {
        /// <summary>
        /// Конструктор автомобиля.
        /// </summary>
        /// <param name="model"> Наименование модели </param>
        /// <param name="power"> Мощность в лошадиных силах </param>
        public Car(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Переопределённый метод ToString().
        /// </summary>
        /// <returns> Строку, содержащую наименование модели автомобиля и его мощность </returns>
        public override string ToString()
        {
            return "Car. " + base.ToString();
        }

        /// <summary>
        /// Переопределённый метод StartEngine().
        /// </summary>
        /// <returns> Строку, содержащую звук автомобиля </returns>
        public override string StartEngine()
        {
            return $"{Model}: Vroom";
        }
    }
}