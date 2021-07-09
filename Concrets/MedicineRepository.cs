using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhamacySystemRestructure.Context;
using PhamacySystemRestructure.Interfaces;
using PhamacySystemRestructure.Model;

namespace PhamacySystemRestructure.Concrets
{
    public class MedicineRepository : IMedicineRepository
    {
        private MedicineContext _medicineContext;

        public MedicineRepository(MedicineContext context)
        {
            _medicineContext = context;
        }
        public Medicine AddMedicine(Medicine medicine)
        {
            _medicineContext.medicine.Add(medicine);
            _medicineContext.SaveChanges();
            return medicine;
        }

        public void DeleteMedicine(Medicine medicine)
        {
            _medicineContext.medicine.Remove(medicine);
            _medicineContext.SaveChanges();
        }

        public Medicine EditMedicine(Medicine medicine)
        {
            var exixtingMedicine = _medicineContext.medicine.Find(medicine.MId);
            if (exixtingMedicine != null)
            {

                exixtingMedicine.Name = medicine.Name;
                exixtingMedicine.CompanyName = medicine.CompanyName;
                exixtingMedicine.Disease = medicine.Disease;
                exixtingMedicine.Amount = medicine.Amount;
                _medicineContext.medicine.Update(exixtingMedicine);
                _medicineContext.SaveChanges();

            }
            return medicine;
        }

        public Medicine GetMedicine(int id)
        {
            var medicine = _medicineContext.medicine.Find(id);
            return medicine;
        }

        public List<Medicine> GetMedicines()
        {
            return _medicineContext.medicine.ToList();
        }
    }
}
