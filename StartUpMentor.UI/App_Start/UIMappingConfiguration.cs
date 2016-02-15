using AutoMapper;
using StartUpMentor.Model;
using StartUpMentor.Model.Common;
using StartUpMentor.UI.Models;
using StartUpMentor.UI.Models.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartUpMentor.UI.App_Start
{
    public class UIMappingConfiguration : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<IAnswer, AnswerViewModel>().ReverseMap();
            Mapper.CreateMap<Answer, AnswerViewModel>().ReverseMap();

            Mapper.CreateMap<IField, FieldViewModel>().ReverseMap();
            Mapper.CreateMap<Field, FieldViewModel>().ReverseMap();

            Mapper.CreateMap<IInfo, InfoViewModel>().ReverseMap();
            Mapper.CreateMap<Info, InfoViewModel>().ReverseMap();

            Mapper.CreateMap<IQuestion, QuestionViewModel>().ReverseMap();
            Mapper.CreateMap<Question, QuestionViewModel>().ReverseMap();
            Mapper.CreateMap<IQuestion, QuestionAddViewModel>().ReverseMap();
            Mapper.CreateMap<Question, QuestionAddViewModel>().ReverseMap();
            Mapper.CreateMap<IQuestion, QuestionIndexViewModel>().ReverseMap();
            Mapper.CreateMap<Question, QuestionIndexViewModel>().ReverseMap();

            Mapper.CreateMap<IApplicationUser, UserViewModel>().ReverseMap();
            Mapper.CreateMap<StartUpMentor.Model.ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}