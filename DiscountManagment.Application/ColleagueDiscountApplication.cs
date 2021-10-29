using System;
using System.Collections.Generic;
using _0_Framework.Application;
using DiscountManagment.Application.Contract.ColleagueDiscount;

namespace DiscountManagment.Application
{
    class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        public OperationResult Define(DefineColleagueDiscount command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            throw new NotImplementedException();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel command)
        {
            throw new NotImplementedException();
        }
    }
}
