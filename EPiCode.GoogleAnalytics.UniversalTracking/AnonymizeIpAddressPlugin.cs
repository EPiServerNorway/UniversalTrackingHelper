namespace EPiCode.GoogleAnalytics.UniversalTracking.Analytics
{
    /// <summary>
    /// Tells Google Anayltics to anonymize IP address if the
    /// appSetting GoogleAnalytics.AnonymizeIpAddress is set to true.
    /// </summary>
    public class AnonymizeIpAddressScipt
    {
        public string GetScript()
        {
            string settingString = "true"; // ConfigurationManager.AppSettings["GoogleAnalytics.AnonymizeIpAddress"];
            bool useAnonIp;
            if (bool.TryParse(settingString, out useAnonIp))
            {
                if (useAnonIp)
                {
                    return "ga('set', 'anonymizeIp', true);";
                }
            }
            return string.Empty;
        }
    }
}