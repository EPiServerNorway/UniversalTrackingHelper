namespace EPiCode.GoogleAnalyticsTracking
{
    /// <summary>
    /// Actions used with the ec:setAction command.
    /// </summary>
    /// <see cref="https://developers.google.com/analytics/devguides/collection/analyticsjs/enhanced-ecommerce#action-types"/>
    public enum EnhancedEcommerceActions
    {
        // ReSharper disable InconsistentNaming

        /// <summary>
        /// A click on a product or product link for one or more products.
        /// </summary>
        click,
        /// <summary>
        /// A view of product details.
        /// </summary>
        detail,
        /// <summary>
        /// Adding one or more products to a shopping cart.
        /// </summary>
        add,
        /// <summary>
        /// Remove one or more products from a shopping cart.
        /// </summary>
        remove,
        //	Initiating the checkout process for one or more products.
        /// <summary>
        /// The checkout
        /// </summary>
        checkout,
        /// <summary>
        /// Sending the option value for a given checkout step.
        /// </summary>
        checkout_option,
        /// <summary>
        /// The sale of one or more products.
        /// </summary>
        purchase,
        /// <summary>
        /// The refund of one or more products.
        /// </summary>
        refund,
        /// <summary>
        /// A click on an internal promotion.
        /// </summary>
        promo_click 
        // ReSharper restore InconsistentNaming
    }
}