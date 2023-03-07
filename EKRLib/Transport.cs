namespace EKRLib
{
    /// <summary>
    /// Абстрактный класс Transport, описывающий абстрактное транспортное средство.
    /// </summary>
    public abstract class Transport
    {
        /// <summary>
        /// Поле, содержащее наименование транспортной модели.
        /// </summary>
        private string _model;
        /// <summary>
        /// Поле, содержащее мощность транспортной модели (в лошадиных силах).
        /// </summary>
        private uint _power;

        /// <summary>
        /// Наименование модели.
        /// </summary>
        protected string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (!CheckModel(value))
                {
                    throw new TransportException($"Недопустимая модель {value}");
                }
                _model = value;
            }
        }

        /// <summary>
        /// Мощность в лошадиных силах.
        /// </summary>
        protected uint Power
        {
            get
            {
                return _power;
            }
            set
            {
                if (value < 20)
                {
                    throw new TransportException("Мощность не может быть меньше 20 л.с.");
                }
                _power = value;
            }
        }

        /// <summary>
        /// Конструктор транспортного средства.
        /// </summary>
        /// <param name="model"> Наименование модели </param>
        /// <param name="power"> Мощность в лошадиных силах </param>
        protected Transport(string model, uint power)
        {
            Model = model;
            Power = power;
        }

        /// <summary>
        /// Переопределённый метод ToString().
        /// </summary>
        /// <returns> Строку, содержащую наименование модели транспортного средства и его мощность </returns>
        public override string ToString()
        {
            return $"Model: {Model}, Power: {Power}";
        }

        /// <summary>
        /// Абстрактный метод, переопределяемый в производных классах, 
        /// для получения звука транспортного средства.
        /// </summary>
        /// <returns> Строку, содержащую звук транспортного средства </returns>
        public abstract string StartEngine();

        /// <summary>
        /// Метод, проверяющий, что название модели состоит ровно из 5 символов
        /// (включающих только заглавные латинские буквы и цифры).
        /// </summary>
        /// <param name="model"> Наименование модели </param>
        /// <returns> <c>true</c>, если наименование корректно, иначе <c>false</c> </returns>
        public static bool CheckModel(string model)
        {
            if (model.Length != 5) return false;
            foreach (char symbol in model)
            {
                if (!(('A' <= symbol && symbol <= 'Z') || ('0' <= symbol && symbol <= '9')))
                {
                    return false;
                }
            }
            return true;
        }
    }
}