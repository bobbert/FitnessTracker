using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FitnessTracker.Models
{
    public class GenericFormViewModel
    {

        public FitnessTrackerDataContext dataContext { get; protected set; }

        // Constructors

        public GenericFormViewModel() { }

        // Methods invoked within view

        protected SelectList CreateNumericalSelectList(int firstNum, int lastNum, int stepByNum, string dataFieldName)
        {
            List<int> numbers = new List<int>();
            for (int i = firstNum; i <= lastNum; i += stepByNum) numbers.Add(i);
            IQueryable query = (from i in numbers select i).AsQueryable();
            return new SelectList(query, dataFieldName);
        }

        protected SelectList CreateYesNoSelectList(string dataFieldName)
        {
            List<string> yesNoValues = new List<string>() { "Y", "N" };
            IQueryable query = (from val in yesNoValues select val).AsQueryable();
            return new SelectList(query,  dataFieldName);
        }
    }
}
