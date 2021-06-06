using Newtonsoft.Json;

namespace Domain.Helpers
{
    public static class JSONHelper
    {
        public static T AsObjectList<T>(string tt)
        {            
            return JsonConvert.DeserializeObject<T>(tt);
        }     
    }
}