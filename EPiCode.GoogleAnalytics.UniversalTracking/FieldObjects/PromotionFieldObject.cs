using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPiCode.GoogleAnalyticsTracking.FieldObjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <see cref="https://developers.google.com/analytics/devguides/collection/analyticsjs/enhanced-ecommerce#promotion-data"/>
    public class PromotionFieldObject : BaseFieldObject
    {
        /*
            id	        String	Yes*	The promotion ID (e.g. PROMO_1234). *Either this field or name must be set.
            name	    String	Yes*	The name of the promotion (e.g. Summer Sale). *Either this field or id must be set.
            creative	String	No	    The creative associated with the promotion (e.g. summer_banner2).
            position	String	No	    The position of the creative (e.g. banner_slot_1).
         */
        public string Id { get; set; }
        public string Name { get; set; }
        public string Creative { get; set; }
        public string Position { get; set; }

        /*
            ga('ec:addPromo', {               // Promo details provided in a promoFieldObject.
              'id': 'PROMO_1234',             // Promotion ID. Required (string).
              'name': 'Summer Sale',          // Promotion name (string).
              'creative': 'summer_banner2',   // Creative (string).
              'position': 'banner_slot1'      // Position  (string).
            });         
        */

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException("Id","Id or Name must be set");
            }

            return base.ToString();
        }


    }
}
