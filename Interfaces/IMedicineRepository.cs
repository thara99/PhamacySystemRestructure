using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhamacySystemRestructure.Model;

namespace PhamacySystemRestructure.Interfaces
{
    public interface IMedicineRepository
    {

        List<Medicine> GetMedicines();

        Medicine GetMedicine(int id);

        Medicine AddMedicine(Medicine medicine);

        void DeleteMedicine(Medicine medicine);

        Medicine EditMedicine(Medicine medicine);

    }
}
