using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace karthickSpecflowCourse_linux_gl.models
{
    public class ReqresPage
    {
        JObject _response;
        public class Person{
            public int id;
            public string email;
            public string first_name;
            public string last_name;
            public string avatar;
        }

        public int per_page { 
            get{ 
                return _response["per_page"].Value<int>(); 
            } 
        }

        public List<Person> people{
            get{
                JArray jArray = (JArray) _response["data"];
                List<Person> people = new List<Person>();
                foreach(JObject jObject in jArray){
                    people.Add(jObject.ToObject<Person>());
                }
                return people;
            }
        }
        public ReqresPage(JObject response){
            _response = response;
        }
    }
}