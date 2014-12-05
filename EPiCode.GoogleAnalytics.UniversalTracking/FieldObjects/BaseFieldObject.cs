using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EPiCode.GoogleAnalyticsTracking.FieldObjects
{
    public abstract class BaseFieldObject
    {
        public string ToString(EnhancedEcommerceActions action)
        {
            return ToString(action.ToString().ToLowerInvariant());
        }

        public string ToString(string action)
        {
            string json = this.ToString();

            return string.Format("ga(\"{0}\",{1});", action, json);
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

        }
    }
}