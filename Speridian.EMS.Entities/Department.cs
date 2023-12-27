using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Speridian.EMS.Entities
{
    public class Department
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}