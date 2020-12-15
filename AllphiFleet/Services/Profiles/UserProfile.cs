using AutoMapper;
using DTO.IdentityResources;
using Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadServices.Profiles
{
    //mapping for identity
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Note that UserName is mapped from Email. 
            //That is needed because there’s a method that we are going to use later for signing in that requires UserName
            CreateMap<UserSignUpResource, User>().ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}
