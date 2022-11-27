using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Logic.Classes
{
    public class PersonLogic : IPersonLogic
    {
        IRepository<Person> repository;
        public PersonLogic(IRepository<Person> repository)
        {
            this.repository = repository;
        }

        public void Create(Person person)
        {
            if (person.FirstName == null && person.LastName == null)
                throw new ArgumentNullException("You must need to give a first and last name");
            else
                repository.Create(person);
        }
        public Person Read(int id)
        {
            var person = repository.Read(id);
            if (person == null)
                throw new ArgumentNullException("Person not exists");
            else
                return person;
        }
        public void Delete(int id)
        {
            var person = repository.Read(id);
            if (person == null)
                throw new ArgumentNullException($"Person with {id} not exist");
            else
                repository.Delete(id);
        }
        public IEnumerable<Person> ReadAll()
        {
            return repository.ReadAll();
        }
        public void Update(Person person)
        {
            repository.Update(person);
        }
    }
}
