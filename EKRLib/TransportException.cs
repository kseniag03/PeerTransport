using System;
using System.Runtime.Serialization;

namespace EKRLib
{
    /// <summary>
    /// Класс исключения, которое выбрасывается при попытке создать транспортное средство
    /// с некорректными параметрами.
    /// </summary>
    [Serializable]
    public class TransportException : Exception
    {
        /// <summary>
        /// Пустой конструктор исключения.
        /// </summary>
        public TransportException() { }

        /// <summary>
        /// Конструктор, который инициализирует новый экземпляр исключения с указанной ошибкой.
        /// </summary>
        /// <param name="message"> Текст ошибки </param>
        public TransportException(string message) : base(message) { }

        /// <summary>
        /// Конструктор, который инициализирует новый экземпляр исключения с указанной ошибкой
        /// и ссылкой на внутреннее исключение.
        /// </summary>
        /// <param name="message"> Текст ошибки </param>
        /// <param name="innerException"> Исключение, являющееся причиной текущего исключения
        /// (или нулевая ссылка, если внутреннее исключение не указано) </param>
        public TransportException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Конструктор, который инициализирует новый экземпляр исключения с сериализованными данными.
        /// </summary>
        /// <param name="info"> Сериализованные данные о создаваемом исключении </param>
        /// <param name="context"> Контекстная информация об источнике или точке назначения </param>
        protected TransportException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}