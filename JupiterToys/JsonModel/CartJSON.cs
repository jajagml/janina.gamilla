using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToys.JsonModel
{
    /// <summary>
    /// Cart JSON model
    /// </summary>
    public class CartJSON
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Price of the item
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Quantity of the item
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// SubTotal of item
        /// </summary>
        public float SubTotal { get; set; }
    }
}
