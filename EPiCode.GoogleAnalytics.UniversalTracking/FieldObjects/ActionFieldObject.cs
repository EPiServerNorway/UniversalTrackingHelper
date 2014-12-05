using System;
using System.ComponentModel;

namespace EPiCode.GoogleAnalyticsTracking.FieldObjects
{
    /// <summary>
    /// Corresponds to the Action Data object.
    /// </summary>
    /// <see cref="https://developers.google.com/analytics/devguides/collection/analyticsjs/enhanced-ecommerce#action-data" />
    public class ActionFieldObject : BaseFieldObject
    {
        /*
        id	        String	    Yes*	The transaction ID (e.g. T1234). *Required if the action type is purchase or refund.
        affiliation	String	    No	The store or affiliation from which this transaction occurred (e.g. Google Store).
        revenue	    Currency	No	Specifies the total revenue or grand total associated with the transaction (e.g. 11.99). This value may include shipping, tax costs, or other adjustments to total revenue that you want to include as part of your revenue calculations. Note: if revenue is not set, its value will be automatically calculated using the product quantity and price fields of all products in the same hit.
        tax	        Currency	No	The total tax associated with the transaction.
        shipping	Currency	No	The shipping cost associated with the transaction.
        coupon	    String	    No	The transaction coupon redeemed with the transaction.
        list	    String	    No	The list that the associated products belong to. Optional on click or detail actions.
        step	    Number	    No	A number representing a step in the checkout process. Optional on checkout actions.
        option	    String	    No	Additional field for checkout and checkout_option actions that can describe option information on the checkout page, like selected payment method. 
         */

        /// <summary>
        /// The transaction ID (e.g. T1234). *Required if the action type is purchase or refund.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The store or affiliation from which this transaction occurred (e.g. Google Store).
        /// </summary>
        public string Affiliation { get; set; }

        /// <summary>
        /// Specifies the total revenue or grand total associated with the transaction (e.g. 11.99). 
        /// This value may include shipping, tax costs, or other adjustments to total revenue that 
        /// you want to include as part of your revenue calculations. Note: if revenue is not set, 
        /// its value will be automatically calculated using the product quantity and price fields 
        /// of all products in the same hit.
        /// </summary>
        [DefaultValue(0.0)]
        public double Revenue { get; set; }

        /// <summary>
        /// Gets or sets the tax.
        /// </summary>
        [DefaultValue(0.0)]
        public double Tax { get; set; }

        /// <summary>
        /// The shipping cost associated with the transaction.
        /// </summary>
        [DefaultValue(0.0)]
        public double Shipping { get; set; }

        /// <summary>
        /// The transaction coupon redeemed with the transaction.
        /// </summary>
        public string Coupon { get; set; }

        /// <summary>
        /// The list or collection to which the product belongs (e.g. Search Results)
        /// </summary>
        public string List { get; set; }

        /// <summary>
        /// A number representing a step in the checkout process. Optional on checkout actions.
        /// </summary>
        [DefaultValue(0)]
        public int Step { get; set; }

        /// <summary>
        /// Additional field for checkout and checkout_option actions that can 
        /// describe option information on the checkout page, like selected payment method.
        /// </summary>
        public string Option { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new ArgumentNullException("Id must be set");
            }

            return base.ToString();
        }


    }
}