using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFtoJson
{
    /// <summary>
    /// Клас для опису структури майбутьнього JSON файлу.
    /// </summary>
    internal class DbfJsonStructure
    {
        /// <summary>
        /// Унікальний номер листа непрацездатності
        /// </summary>
        public string WIC_NUM { get; set; }

        /// <summary>
        /// Загальна кількість днів, що підлягаюсть оплаті
        /// </summary>
        public int WIC_NUMBER_ALL { get; set; }

        /// <summary>
        /// Кількість днів, зо підлягають оплаті за рахунок коштів фонду
        /// </summary>
        public int WIC_NUMBER_PFU { get; set; }

        /// <summary>
        /// Загальна сума з копійками (в гривнях)
        /// </summary>
        public decimal WIC_SUMM_ALL { get; set; }

        /// <summary>
        /// Сума коштів за рахунок фонду (в гривнях)
        /// </summary>
        public decimal WIC_SUMM_PFU { get; set; }

        /// <summary>
        /// Кількість днів, що підлягають оплаті за рахунок фонду постраждалим в наслідок аваріі на ЧАЕС
        /// </summary>
        public int WIC_NUMBER_CHAES { get; set; }

        /// <summary>
        /// Сума коштів за рахунок фонду постраждалим в наслідок аваріі на ЧАЕС
        /// </summary>
        public decimal WIC_SUMM_CHAES { get; set; }
    }
}