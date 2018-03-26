using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {

            BusinessLayerBefore businessLayerBefore = new BusinessLayerBefore();
            businessLayerBefore.CheckForShoe("Nike", 1);


            BusinessLayer businessLayer = new BusinessLayer(new DataAccessLayer1());
            businessLayer.CheckForShoe("Nike");

            Console.WriteLine();
            Console.Read();
        }
    }

    // DIP states that
    // 1. High level modules should not depend upon low-level modules. Both should depend upon abstractions.
    // 2. Abstractions should never depend upon details. Details should depend upon abstractions.
    // In below implementation DIP is not followed as High level module(DataAccess layer) is 
    // dependent on low level module(Buisness layer)) along with this OCP will not be followed if we have new requirement.
    public class BusinessLayerBefore
    {
        public string ShoeType { get; set; }

        public void CheckForShoe(string shoeType,int DbType)
        {
            if (DbType == 1)
            {
                var dataAccessLayer = new DataAccessLayerBefore1();
                dataAccessLayer.CheckInDb(shoeType);
            }
            else
            {
                var dataAccessLayer = new DataAccessLayerBefore2();
                dataAccessLayer.CheckInDb(shoeType);
            }
        }
    }

    public class DataAccessLayerBefore1
    {
        public void CheckInDb(string shoeType)
        {
            //DB call
        }
    }

    public class DataAccessLayerBefore2
    {
        public void CheckInDb(string shoeType)
        {
            //DB call
        }
    }


    // In below implementation DIP is followed as High level module(DataAccess layer) is  not 
    // dependent on low level module(Buisness layer)) and both of them are dependent on Abstraction(i.e IDataAccessLayer interface).
    public class BusinessLayer
    {
        public string ShoeType { get; set; }
        public IDataAccessLayer DataAccessLayer { get; set; }

        public BusinessLayer(IDataAccessLayer dataAccessLayer)
        {
            this.DataAccessLayer = dataAccessLayer;
        }

        public void CheckForShoe(string shoeType)
        {
            DataAccessLayer.CheckInDb(shoeType);
        }
    }

    public interface IDataAccessLayer
    {
        void CheckInDb(string shoeType); 
    }

    public class DataAccessLayer1 : IDataAccessLayer
    {
        public void CheckInDb(string shoeType)
        {
            //DB call
        }
    }

    public class DataAccessLayer2 : IDataAccessLayer
    {
        public void CheckInDb(string shoeType)
        {
            //DB call
        }
    }
}