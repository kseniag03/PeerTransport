namespace EKRLib
{
    /// <summary>
    /// Класс MotorBoat, описывающий моторную лодку.
    /// </summary>
    public class MotorBoat : Transport
    {
        /// <summary>
        /// Конструктор моторной лодки.
        /// </summary>
        /// <param name="model"> Наименование модели </param>
        /// <param name="power"> Мощность в лошадиных силах </param>
        public MotorBoat(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Переопределённый метод ToString().
        /// </summary>
        /// <returns> Строку, содержащую наименование модели моторной лодки и её мощность </returns>
        public override string ToString()
        {
            return "MotorBoat. " + base.ToString();
        }

        /// <summary>
        /// Переопределённый метод StartEngine().
        /// </summary>
        /// <returns> Строку, содержащую звук моторной лодки </returns>
        public override string StartEngine()
        {
            return $"{Model}: Brrrbrr";
        }
    }
}