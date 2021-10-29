using System.Collections.Generic;
using _0_Framework.Application;
using DiscountManagment.Application.Contract.ColleagueDiscount;
using DiscountManagment.Domain.ColleagueDiscountAgg;

namespace DiscountManagment.Application
{
    class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var oprationResult = new OperationResult();
            if (_colleagueDiscountRepository.Exist(x => x.ProductId == command.ProductId))
            {
                return oprationResult.Failed(Messages.FailedOpration_Duplicate);
            }
            var _colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);

            _colleagueDiscountRepository.Create(_colleagueDiscount);
            _colleagueDiscountRepository.SaveChanges();
            return oprationResult.Succeeded();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var oprationResult = new OperationResult();
            var _colleagueDiscount = _colleagueDiscountRepository.Get(command.Id);
            if (_colleagueDiscount == null)
            {
                return oprationResult.Failed(Messages.FailedOpration_Null);
            }

            _colleagueDiscount.Edit(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.SaveChanges();
            return oprationResult.Succeeded();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public OperationResult Remove(long Id)
        {
            var oprationResult = new OperationResult();
            var _colleagueDiscount = _colleagueDiscountRepository.Get(Id);
            if (_colleagueDiscount == null)
            {
                return oprationResult.Failed(Messages.FailedOpration_Null);
            }

            _colleagueDiscount.Remove();
            _colleagueDiscountRepository.SaveChanges();
            return oprationResult.Succeeded();

        }

        public OperationResult Restore(long Id)
        {
            var oprationResult = new OperationResult();
            var _colleagueDiscount = _colleagueDiscountRepository.Get(Id);
            if (_colleagueDiscount == null)
            {
                return oprationResult.Failed(Messages.FailedOpration_Null);
            }

            _colleagueDiscount.Restore();
            _colleagueDiscountRepository.SaveChanges();
            return oprationResult.Succeeded();

        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel command)
        {
            return _colleagueDiscountRepository.Search(command);
        }
    }
}
