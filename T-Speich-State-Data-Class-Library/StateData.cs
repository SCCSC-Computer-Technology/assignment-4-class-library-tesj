// Thomas Speich
// CPT-206-A01S
// Lab 4
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace T_Speich_State_Data_Class_Library
{
    public partial class StateData : StateInfoDataContext 
    {
        public string Filter;
        public string FilterValue;
        public string SortColumn;
        public string SortOrder;
        public StateData() 
        {
            Filter = "TRUE"; //returns all records
            FilterValue = "";
            SortColumn = "State_Name"; //sort by the state name column
            SortOrder = "ASC"; //sort by ascending
        }


        //calls the where method, then orderby; passes the filter and order properties as arguments
        //returns an enumerable containing the filtered states in the specified order
        public IOrderedQueryable GetFilteredAndSortedStates() => States.Where(Filter, FilterValue).OrderBy($"{SortColumn} {SortOrder}");

        //calls the where method to find a matching stateID (primary key)
        //returns a state entity object
        public State GetStateByID(int stateID) => States.Where(x => x.State_ID == stateID).Single();

        //simplifies inserting a state
        public void InsertAndSubmitState(State state)
        {
            States.InsertOnSubmit(state);
            SubmitChanges();
        }

        //simplifies deleting a state by using the ID
        public void RemoveAndSubmitState(int stateID)
        {
            States.DeleteOnSubmit(States.Where(x => x.State_ID == stateID).Single());
            SubmitChanges();
        }
    }
}
