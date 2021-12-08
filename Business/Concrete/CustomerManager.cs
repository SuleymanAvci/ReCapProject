using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {

            _customerDal.Add(customer);
            return new SuccessResult(Messages.UnitAdded);
        }


        public IResult Update(Customer customer)
        {
            if (customer.CompanyName.Length < 1)
            {
                return new ErrorResult(Messages.UnitNameInvalid);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.UnitUpdated);
        }


        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.UnitDeleted);
        }


        public IDataResult<Customer> GetCustomerById(int id)
        {
            if (_customerDal.Get(c => c.Id == id) != null)
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));
            }
            return new ErrorDataResult<Customer>(Messages.UnitNotFound);
        }


        public IDataResult<List<Customer>> GetAll()
        {
            if (_customerDal.GetAll() == null)
            {
                return new ErrorDataResult<List<Customer>>(Messages.UnitNotFound);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

    }
}
