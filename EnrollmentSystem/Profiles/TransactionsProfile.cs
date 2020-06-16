using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Profiles
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            CreateMap<Entities.Transaction, Models.TransactionDto>();
            CreateMap<Models.TransactionForCreationDto, Entities.Transaction>();
        }
    }
}
