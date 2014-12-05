using System;
using System.ComponentModel;

namespace EPiCode.GoogleAnalyticsTracking.FieldObjects
{
    /// <summary>
    /// Represents information about a product that has been viewed. It is referred to as an impressionFieldObject and contains the following values:
    /// </summary>
    /// <see cref="https://developers.google.com/analytics/devguides/collection/analyticsjs/enhanced-ecommerce#impression-data"/>
    public class ImpressionFieldObject : BaseFieldObject
    {
        /*
        id	        String	    Yes*	The product ID or SKU (e.g. P67890). *Either this field or name must be set.
        name	    String	    Yes*	The name of the product (e.g. Android T-Shirt). *Either this field or id must be set.
        list	    String	    No	    The list or collection to which the product belongs (e.g. Search Results)
        brand	    String	    No	    The brand associated with the product (e.g. Google).
        category	String	    No	    The category to which the product belongs (e.g. Apparel). Use / as a delimiter to specify up to 5-levels of hierarchy (e.g. Apparel/Mens/T-Shirts).
        variant	    String	    No	    The variant of the product (e.g. Black).
        position	Number	    No	    The product's position in a list or collection (e.g. 2).
        price	    Currency	No	    The price of a product (e.g. 29.20). 
         */

        /// <summary>
        /// The product ID or SKU (e.g. P67890). *Either this field or name must be set.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the product (e.g. Android T-Shirt). *Either this field or id must be set.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The brand associated with the product (e.g. Google).
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// The category to which the product belongs (e.g. Apparel). Use / as a delimiter to specify up to 5-levels of hierarchy (e.g. Apparel/Mens/T-Shirts).
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The list or collection to which the product belongs (e.g. Search Results)
        /// </summary>
        public string List { get; set; }

        /// <summary>
        ///  The variant of the product (e.g. Black).
        /// </summary>
        public string Variant { get; set; }

        /// <summary>
        /// The price of a product (e.g. 29.20). 
        /// </summary>
        [DefaultValue(0.0)]
        public double Price { get; set; }

        /// <summary>
        /// The product's position in a list or collection (e.g. 2).
        /// </summary>
        [DefaultValue(0)]
        public int Position { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException("Id or Name must be set");
            }

            return base.ToString();
        }


    }
}