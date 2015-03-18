using System;
using EPiCode.GoogleAnalyticsTracking.FieldObjects;

namespace EPiCode.GoogleAnalyticsTracking
{
    public class Tracking
    {
        public string SetAction(EnhancedEcommerceActions action)
        {
            return SetAction(action.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// Creates a setAction script with an optional fieldObject
        /// </summary>
        /// <param name="action">The action use for the setAction script.</param>
        /// <param name="fieldObject">The field object as a javascript object (not enclosed in quotes).</param>
        public string SetAction(string action, string fieldObject = null)
        {
            if (string.IsNullOrEmpty(fieldObject))
            {
                return string.Format("ga(\"ec:setAction\",\"{0}\");", action);   
            }
            else
            {
                return string.Format("ga(\"ec:setAction\",\"{0}\",{1});", action, fieldObject);   
            }
        }

        public string Require(string library)
        {
            return string.Format("ga(\"require\",\"{0}\");", library);
        }

        /// <summary>
        /// Sends the event.
        /// </summary>
        /// <param name="category">The category. Example: "button"</param>
        /// <param name="action">The action. Example: "click"</param>
        /// <param name="label">The label. Example: "nav buttons"</param>
        /// <param name="value">The value. Must be a positive numbers. Negative numbers are stripped from the call</param>
        /// <returns></returns>
        public string SendEvent(string category, string action, string label = null, int value = -1)
        {
            if (category == null) throw new ArgumentNullException("category");
            if (action == null) throw new ArgumentNullException("action");
            /*
                Category	String	Yes	Typically the object that was interacted with (e.g. button)
                Action	String	Yes	The type of interaction (e.g. click)
                Label	String	No	Useful for categorizing events (e.g. nav buttons)
                Value	Number	No	Values must be non-negative. Useful to pass counts (e.g. 4 times)
            */
            string parameters = string.Format("\"event\", \"{0}\", \"{1}\"", category, action);
            if(string.IsNullOrEmpty(label) == false)
            {
                parameters = parameters + ", \"" + label + "\"";
            }
            if (value >= 0)
            {
                parameters = parameters + ", " + value.ToString();
            }
            return string.Format("ga(\"send\", {0});", parameters);
        }


        /// <summary>
        /// Tracks one product impression using the addImpression command for
        /// Google Analytics. See https://developers.google.com/analytics/devguides/collection/analyticsjs/enhanced-ecommerce#product-impression
        /// </summary>
        /// <example>
        /// Example on how the script code will look like
        /// ga('ec:addImpression', {
        ///   'id': 'P12345',                   // Product details are provided in an impressionFieldObject.
        ///   'name': 'Android Warhol T-Shirt',
        ///   'category': 'Apparel/T-Shirts',
        ///   'brand': 'Google',
        ///   'variant': 'black',
        ///   'list': 'Search Results',
        ///   'position': 1                     // 'position' indicates the product position in the list.
        /// });
        /// </example>
        /// <see cref="https://developers.google.com/analytics/devguides/collection/analyticsjs/enhanced-ecommerce#product-impression"/>
        public string TrackProductImpression(string code, string name, string category = null, string brand = null, string variant = null, string list = null, int position = 0)
        {
            ImpressionFieldObject impression = new ImpressionFieldObject()
            {
                Id = code,
                Name = name,
                Category = category,
                Brand = brand,
                Variant = variant,
                List = list,
                Position = position
            };

            return impression.ToString("ec:addImpression");
        }

        /// <summary>
        /// Tracks a product add command.
        /// </summary>
        /// <remarks>
        /// Typically used in combination with the click, detail, add, 
        /// remove, checkout, purchase and refund actions
        /// </remarks>
        /// <example>
        /// ga('ec:addProduct', {               // Provide product details in an productFieldObject.
        ///   'id': 'P12345',                   // Product ID (string).
        ///   'name': 'Android Warhol T-Shirt', // Product name (string).
        ///   'category': 'Apparel',            // Product category (string).
        ///   'brand': 'Google',                // Product brand (string).
        ///   'variant': 'black',               // Product variant (string).
        ///   'price': '29.20',                 // Product price (currency).
        ///   'coupon': 'APPARELSALE',          // Product coupon (string).
        ///   'quantity': 1                     // Product quantity (number).
        /// });
        /// </example>
        /// <see cref="https://developers.google.com/analytics/devguides/collection/analyticsjs/enhanced-ecommerce#action-types"/>
        public string TrackProductAdd(string code, string name, string category = null, string brand = null, string variant = null, string coupon = null, int position = 0, double price = 0, int quantity = 0)
        {
            ProductFieldObject impression = new ProductFieldObject()
            {
                Id = code,
                Name = name,
                Category = category,
                Brand = brand,
                Variant = variant,
                Coupon = coupon,
                Position = position,
                Price = price,
                Quantity = quantity
            };

            return impression.ToString("ec:addProduct");
        }


        /// <summary>
        /// Tracks a promotion impression.
        /// </summary>
        /// <remarks>
        /// id or name must be provided.
        /// </remarks>
        /// <param name="id">The promotion identifier.</param>
        /// <param name="name">The promotion name.</param>
        /// <param name="creative">The creative name of the promotion, typically a banner id. Optional</param>
        /// <param name="position">The promotion position on the page. Optional</param>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/analytics/devguides/collection/analyticsjs/enhanced-ecommerce#measuring-promos"/>
        public string TrackPromotionImpression(string id, string name, string creative = null, string position = null)
        {
            PromotionFieldObject impression = new PromotionFieldObject()
            {
                Id = id,
                Name = name,
                Creative = creative,
                Position = position
            };

            return impression.ToString("ec:addPromo");
        }

        public string TrackPromotionClick(string id, string name, string creative = null, string position = null, string eventName = "Internal Promotions")
        {
            string impression = TrackPromotionImpression(id, name, creative, position);
            string action = SetAction(EnhancedEcommerceActions.promo_click);
            // ga('send', 'event', 'Internal Promotions', 'click', 'Summer Sale');
            string sendEvent = SendEvent(eventName, "click", name);
            return string.Format("{0}\r\n{1}\r\n{2}", impression, action, sendEvent);
        }
    }
}
