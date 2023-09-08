using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationTypesService
    {
        public IEnumerable<AccomodationType> GetAllAccomodationTypes()
        {
            var context = new HMSContext();

            return context.AccomodationTypes.ToList();
        }
        public AccomodationType GetAccomodationTypeByID(int ID)
        {
            var context = new HMSContext();

            return context.AccomodationTypes.Find(ID);
        }

        public bool SaveAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.AccomodationTypes.Add(accomodationType);

            return context.SaveChanges() > 0;
        }
        public bool UpdateAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.Entry(accomodationType).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.Entry(accomodationType).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }

        public IEnumerable<AccomodationType> SearchAccomodationTypes(string searchTerm, int page, int recordSize)
        {
            var context = new HMSContext();

            var accomodationTypes = context.AccomodationTypes.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationTypes = accomodationTypes.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }
            var skip = (page - 1) * recordSize;
            //  skip = (1    -  1) = 0 * 3 = 0
            //  skip = (2    -  1) = 1 * 3 = 3
            //  skip = (3    -  1) = 2 * 3 = 6

          //  return accomodationTypes.ToList();
            return accomodationTypes.OrderBy(x=>x.ID).Skip(skip).Take(recordSize).ToList();
         
        }
        public int SearchAccomodationTypeCount(string searchTerm,int? accomodationTypeID)
        {
            var context = new HMSContext();

            var accomodationTypes = context.AccomodationTypes.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationTypes = accomodationTypes.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (accomodationTypeID.HasValue && accomodationTypeID.Value > 0)
            {
                accomodationTypes = accomodationTypes.Where(a => a.ID == accomodationTypeID.Value);
            }

            return accomodationTypes.Count();
        }

    }
}
