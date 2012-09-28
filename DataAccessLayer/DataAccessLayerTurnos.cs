using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace DataAccessLayer
{
    public interface DataAccessLayerTurnos
    {
        void Insert(Turno pTurno);

        void Update(Turno pTurno);

        void Delete(int pId);

        List<Turno> GetAll(int pId);
    }
}
