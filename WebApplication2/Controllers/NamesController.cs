using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NamesController : ControllerBase
    {



        private static List<string> Names = new List<string>() { "Vighneshwar", "Ritiwik", "Siraj" ,"govind","shivam","ashok"};
        private static List<string> error = new List<string>() { " Bad request " };
        private static List<string> errorEmpty = new List<string>() { " name not found  " };
        [HttpGet]
        public List<string> GetNames() { return Names; }

        [HttpGet("{id}")]
        public string GetName(int id )
        {
                        
            if (id >= 0 && id < Names.Count) return Names[id];
            else return "Badrequest";
        }

        [HttpPost("{fullName}")]
        public List<string>GetNames(string fullName)
        {
           
            if (fullName != "" )
            {
                string name = fullName;
                Names.Add(name);
                return Names;
            }
            else return error;
            
        }

        [HttpPut("{name},{uFirstName},{uSecondName}")]
        public List<string> GetNames(string name, string uFirstName, string uSecondName)
        {
            if (uFirstName != "" && uSecondName != "")
            {
                if (Names.Contains(name)) {
                    int id = Names.IndexOf(name);
                    string updatename = uFirstName + " " + uSecondName;
                    Names[id] = updatename;
                    return Names;
                }
                else return errorEmpty;
            }
                
            else return error;
            
        }

        [HttpDelete]
        public List<string> Delete(int? id , string? name )
        {
            if (Names.Contains(name)) {
                Names.Remove(name);
                return Names;

            }
          
            else if ( id >= 0 && id < Names.Count )
            {
 
                 Names.RemoveAt(id.Value);
        
                return Names;
            }
            else return error;

        }
    }
}
