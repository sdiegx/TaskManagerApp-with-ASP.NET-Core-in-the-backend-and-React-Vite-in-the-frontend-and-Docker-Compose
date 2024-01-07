using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IPersona
    {
        List<Persona> GetPersonas();
        Persona GetPersona(int id);
        void AddPersona(Persona nuevaPersona);
        void UpdatePersona(Persona nuevaPersona);
        void DeletePersona(int id);
    }
}
