using Newtonsoft.Json;
using PersonRepository.Interface;
using System;
using System.Collections.Generic;
using System.Net;

namespace PersonRepository.Service
{
    public class ServiceRepository : IPersonRepository
    {

        WebClient webClient = new WebClient();
        string baseUri = "http://localhost:9874/api/people"; 

        public IEnumerable<Person> GetPeople()
        {
            string result = webClient.DownloadString(baseUri);
            IEnumerable<Person> people = JsonConvert.DeserializeObject<IEnumerable<Person>>(result);
            return people;
        }

        public Person GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public void AddPerson(Person newPerson)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

    

        public void UpdatePerson(int id, Person updatedPerson)
        {
            throw new NotImplementedException();
        }
    }
}
