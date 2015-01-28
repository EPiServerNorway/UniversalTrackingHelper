# UniversalTrackingHelper
A small standalone C# project to help you generate valid tracking script for Universal Tracking in Google Analytics with special focus on Enhanced Ecommerce tracking.

## Example
The following example shows how to use the ActionFieldObject to generate a Enhanced Ecommerce purchase action script:
```cs
/// Tracks a purchase using the setAction and the purchase command.
/// </summary>
/// <remarks>
/// You should use <seealso cref="ProductAdd"/> in additon to this, to register all
/// the products that is part of the purchase
/// </remarks>
/// <see cref="https://developers.google.com/analytics/devguides/collection/analyticsjs/enhanced-ecommerce#measuring-transactions"/>
public void Purchase(string trackingNumber, string affiliation = null, double revenue = 0, double tax = 0, double shipping = 0, string coupon = null)
{
    /* The actionFieldObject that is part of the purchase
      'id': 'T12345',                         // (Required) Transaction id (string).
      'affiliation': 'Google Store - Online', // Affiliation (string).
      'revenue': '37.39',                     // Revenue (currency).
      'tax': '2.85',                          // Tax (currency).
      'shipping': '5.34',                     // Shipping (currency).
      'coupon': 'SUMMER2013' 
     */
    ActionFieldObject actionField = new ActionFieldObject()
    {
        Id = trackingNumber,
        Affiliation = affiliation,
        Revenue = revenue,
        Tax = tax,
        Shipping = shipping,
        Coupon = coupon
    };

    // ga('ec:setAction', 'purchase', { ... });
    Action("purchase", actionField.ToString());

}

public string Action(string action, string fieldObject = null)
{
    Tracking tracking = new Tracking();
    return tracking.SetAction(action, fieldObject);    
}

```

This should render:
```js
ga('ec:setAction', 'purchase', {          
  'id': 'T12345',                         
  'affiliation': 'Google Store - Online', 
  'revenue': '37.39',                     
  'tax': '2.85',                          
  'shipping': '5.34',                     
  'coupon': 'SUMMER2013'                  
});
```
*Note!* You need to call ```ga('ec:addProduct', {...}) ``` before you register a purchase.
