using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Parsers
{
    public static class JsonResponses
    {
        /// <summary>
        /// Метод парсит JSON, полученный от сервера.
        /// </summary>
        /// <typeparam name="T">Модель данных, в которую нужно десериализовать.</typeparam>
        /// <param name="json">JSON строка, которую нужно десериализовать.</param>
        /// <param name="errorParse">Ошибка при десериализации.</param>
        /// <returns>Десериализованная модель данных или null, если произошла ошибка.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если переданная строка пуста.</exception>
        public static T? ParseResponse<T>(string json, out ErrorModel? errorParse)
        {
            // Проверка на пустую или только пробельную строку
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentNullException(nameof(json), "Переданная строка пуста.");

            // Попытка десериализации в модель ошибки
            ErrorModel? error = JsonConvert.DeserializeObject<ErrorModel>(json);
            if (error != null)
            {
                errorParse = error; // Устанавливаем ошибку
                return default; // Возвращаем значение по умолчанию для типа T
            }

            // Попытка десериализации в целевую модель данных
            T? model = JsonConvert.DeserializeObject<T>(json);
            if (model == null)
            {
                errorParse = new ErrorModel(
                    header: "Ошибка при получении данных",
                    content: "Возникла ошибка при получении данных с сервера."
                );
                return default; // Возвращаем значение по умолчанию для типа T
            }

            // Устанавливаем errorParse в null, если все прошло успешно
            errorParse = null;
            return model; // Возвращаем десериализованную модель
        }
    }
}
