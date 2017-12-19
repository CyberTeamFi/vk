﻿using VkNet.Abstractions.Async;
using VkNet.Utils;

namespace VkNet.Abstractions
{
    /// <summary>
    /// Методы этого класса позволяют производить действия с универсальным методом.
    /// </summary>
    public interface IExecuteCategory: IExecuteCategoryAsync
    {
        /// <summary>
        /// Универсальный метод, который позволяет запускать последовательность других методов, сохраняя и фильтруя промежуточные результаты.
        /// </summary>
        /// <param name="code">
        /// Код алгоритма в VKScript - формате, похожем на JavaSсript или ActionScript (предполагается совместимость с ECMAScript).
        /// Алгоритм должен завершаться командой return %выражение%. Операторы должны быть разделены точкой с запятой.
        /// </param>
        /// <returns>
        /// Возвращает данные, запрошенные алгоритмом.
        /// При работе с методом execute структура ответа в XML ближе к JSON и может незначительно отличаться от стандартного представления других методов.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/execute
        /// </remarks>
        VkResponse Execute(string code);
    }
}