using System;
using System.Diagnostics;
using EPiCode.GoogleAnalyticsTracking;
using EPiCode.GoogleAnalyticsTracking.FieldObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GATests
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public void Id_And_Brand_Is_Converted_Correctly()
        {
            // Arrange
            ProductFieldObject product = new ProductFieldObject();
            product.Id = "code123";
            product.Brand = "EPiServer";

            // Act
            string json = product.ToString();

            // Assert
            Assert.AreEqual(@"{""id"":""code123"",""brand"":""EPiServer""}", json);
        }
        [TestMethod]
        public void Position_Is_Included_When_Not_Default_Value()
        {
            // Arrange
            ProductFieldObject product = new ProductFieldObject();
            product.Id = "code";
            product.Position = 1;

            // Act
            string json = product.ToString();

            // Assert
            Assert.AreEqual(@"{""id"":""code"",""position"":1}", json);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Missing_Id_Or_Name_Throws_Exception()
        {
            // Arrange
            ProductFieldObject product = new ProductFieldObject();
            product.Brand = "EPiServer";

            // Act
            string json = product.ToString();
              
        }

        [TestMethod]
        public void Verify_Formatting_Of_Action()
        {
            // Arrange
            ProductFieldObject product = new ProductFieldObject();
            product.Id = "code";
            product.Position = 1;

            // Act
            string json = product.ToString("ec:addProduct");
            
            // Inspect
            Debug.Write(json);
            
            // Assert
            Assert.AreEqual(@"ga(""ec:addProduct"",{""id"":""code"",""position"":1});", json);
            
        }

        [TestMethod]
        public void Verify_Formatting_Of_SetActionEnum()
        {
            // Arrange
            Tracking tracking = new Tracking();

            // Act
            string json = tracking.SetAction(EnhancedEcommerceActions.detail);

            // Inspect
            Debug.Write(json);

            // Assert
            Assert.AreEqual(@"ga(""ec:setAction"",""detail"");", json);

        }

        [TestMethod]
        public void Verify_Formatting_Of_SetAction_Without_FieldObject()
        {
            // Arrange
            Tracking tracking = new Tracking();

            // Act
            string json = tracking.SetAction("test");

            // Inspect
            Debug.Write(json);

            // Assert
            Assert.AreEqual(@"ga(""ec:setAction"",""test"");", json);

        }

        [TestMethod]
        public void Verify_Formatting_Of_SetAction_With_FieldObject()
        {
            // Arrange
            Tracking tracking = new Tracking();

            // Act
            string fieldObject = "{\"a\":1}";
            string json = tracking.SetAction("test", fieldObject);

            // Inspect
            Debug.Write(json);

            // Assert
            Assert.AreEqual(@"ga(""ec:setAction"",""test""," + fieldObject + ");", json);

        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Verify_That_Action_Without_Id_Throws_Exception()
        {
            // Arrange
            var action = new ActionFieldObject();
            action.List = "List";

            // Act
            string json = action.ToString();
        }

        [TestMethod]
        public void Verify_Product_Add_Action_Is_Formatted_Correctly()
        {
            // Arrange
            Tracking tracking = new Tracking();

            // Act
            string json = tracking.TrackProductAdd(
                code: "P12345", name: "Android Warhol T-Shirt",
                category: "Apparel", brand: "Google", coupon: null,
                variant: "Black",
                position: 1, price: 32, quantity: 1);

            // Inspect
            Debug.WriteLine(json);

            // Assert
            string fact =
                "ga(\"ec:addProduct\",{\"id\":\"P12345\",\"name\":\"Android Warhol T-Shirt\",\"brand\":\"Google\",\"category\":\"Apparel\",\"variant\":\"Black\",\"price\":32.0,\"quantity\":1,\"position\":1});";
            Assert.AreEqual(fact, json);

        }

        [TestMethod]
        public void Verify_Full_Promotion_Impression_Is_Formatted_Correctly()
        {
            // Arrange
            Tracking tracking = new Tracking();

            // Act
            string json = tracking.TrackPromotionImpression("PROMO1", "Summer Sale", "summer_banner_1", "top");

            // Inspect
            Debug.WriteLine(json);

            // Assert
            string fact =
                "ga(\"ec:addPromo\",{\"id\":\"PROMO1\",\"name\":\"Summer Sale\",\"creative\":\"summer_banner_1\",\"position\":\"top\"});";
            Assert.AreEqual(fact, json);

        }
        
        [TestMethod]
        public void Verify_Partial_Promotion_Impression_Is_Formatted_Correctly()
        {
            // Arrange
            Tracking tracking = new Tracking();

            // Act
            string json = tracking.TrackPromotionImpression("PROMO1", "Summer Sale", "summer_banner_1");

            // Inspect
            Debug.WriteLine(json);

            // Assert
            string fact =
                "ga(\"ec:addPromo\",{\"id\":\"PROMO1\",\"name\":\"Summer Sale\",\"creative\":\"summer_banner_1\"});";
            Assert.AreEqual(fact, json);
        }


        [TestMethod]
        public void Verify_Full_Promotion_Click_Is_Formatted_Correctly()
        {
            // Arrange
            Tracking tracking = new Tracking();

            // Act
            string json = tracking.TrackPromotionClick("PROMO1", "Summer Sale", "summer_banner_1", "top", "My Promos");

            // Inspect
            Debug.WriteLine(json);

            // Assert
            string fact =
                "ga(\"ec:addPromo\",{\"id\":\"PROMO1\",\"name\":\"Summer Sale\",\"creative\":\"summer_banner_1\",\"position\":\"top\"});";
            fact = fact + "\r\n";
            fact = fact + "ga(\"ec:setAction\",\"promo_click\");";
            fact = fact + "\r\n";
            fact = fact + "ga(\"send\", \"event\", \"My Promos\", \"click\", \"Summer Sale\");";

            Assert.AreEqual(fact, json);

        }

    }
}
