using PersonRepository.CSV;
using PersonRepository.Interface;
using PersonRepository.Service;
using PersonRepository.SQL;
using System;

namespace PersonRepository.Factory
{
    public static class RepositoryFactory
    {
        public static IPersonRepository GetRepository(string repositoryType)
        {
            IPersonRepository personRepository = null;

            switch (repositoryType)
            {
                case "Service":
                    personRepository = new ServiceRepository();
                    break;
                case "CSV":
                    personRepository = new CSVRepository();
                    break;
                case "SQL":
                    personRepository = new SQLRepository();
                    break;
                default:
                    throw new ArgumentException("Argument not valid");
             
            }

            return personRepository;
        }
    }
}
