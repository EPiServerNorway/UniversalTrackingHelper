using System;
using System.ComponentModel;

namespace EPiCode.GoogleAnalyticsTracking.FieldObjects
{
    /// <summary>
    /// Product data represents individual products that were viewed, added to the shopping cart, etc. It is referred to as a productFieldObject and contains the following values:
    /// </summary>
    /// <see cref="https://developers.google.com/analytics/devguides/collection/analyticsjs/enhanced-ecommerce#product-data"/>
    public class ProductFieldObject : BaseFieldObject
    {
        /*
        id	        String	    Yes*	The product ID or SKU (e.g. P67890). *Either this field or name must be set.
        name	    String	    Yes*	The name of the product (e.g. Android T-Shirt). *Either this field or id must be set.
        brand	    String	    No	    The brand associated with the product (e.g. Google).
        category	String	    No	    The category to which the product belongs (e.g. Apparel). Use / as a delimiter to specify up to 5-levels of hierarchy (e.g. Apparel/Mens/T-Shirts).
        variant	    String	    No	    The variant of the product (e.g. Black).
        price	    Currency	No	    The price of a product (e.g. 29.20).
        quantity	Number	    No	    The quantity of a product (e.g. 2).
        coupon	    String	    No	    The coupon code associated with a product (e.g. SUMMER_SALE13).
        position	Number	    No	    The product's position in a list or collection (e.g. 2). 
         */
        public string Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Variant { get; set; }
        [DefaultValue(0.0)]
        public double Price { get; set; }
        [DefaultValue(0)]
        public int Quantity { get; set; }
        public string Coupon { get; set; }
        [DefaultValue(0)]
        public int Position { get; set; }

        /*
        // The product being viewed.
        ga('ec:addProduct', {               // Provide product details in an productFieldObject.
          'id': 'P12345',                   // Product ID (string).
          'name': 'Android Warhol T-Shirt', // Product name (string).
          'category': 'Apparel',            // Product category (string).
          'brand': 'Google',                // Product brand (string).
          'variant': 'Black',               // Product variant (string).
          'position': 1,                    // Product position (number).
        });

        ga('ec:setAction', 'detail');       // Detail action.
         */
        public override string ToString()
        {
            if(string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException("Id", "Id or Name must be set");
            }

            return base.ToString();
        }
    }
}