﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StartUpMentor.Model.Common;
using StartUpMentor.DAL.Models;

namespace StartUpMentor.Model.AutoMapperModelLayerMapping
{
    public class MappingConfiguration : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AnswerEntity, IAnswer>().ReverseMap();
            Mapper.CreateMap<AnswerEntity, Answer>().ReverseMap();
            Mapper.CreateMap<Answer, IAnswer>().ReverseMap();

            Mapper.CreateMap<FieldEntity, IField>().ReverseMap();
            Mapper.CreateMap<FieldEntity, Field>().ReverseMap();
            Mapper.CreateMap<Field, IField>().ReverseMap();

            Mapper.CreateMap<InfoEntity, IInfo>().ReverseMap();
            Mapper.CreateMap<InfoEntity, Info>().ReverseMap();
            Mapper.CreateMap<Info, IInfo>().ReverseMap();

            Mapper.CreateMap<QuestionEntity, IQuestion>().ReverseMap();
            Mapper.CreateMap<QuestionEntity, Question>().ReverseMap();
            Mapper.CreateMap<Question, IQuestion>().ReverseMap();

            Mapper.CreateMap<StartUpMentor.DAL.Models.ApplicationUser, IApplicationUser>().ReverseMap();
            Mapper.CreateMap<StartUpMentor.DAL.Models.ApplicationUser, ApplicationUser>().ReverseMap();
            Mapper.CreateMap<ApplicationUser, IApplicationUser>().ReverseMap();
        }

        //public override string ProfileName
        //{
        //    get
        //    {
        //        return this.GetType().Name;
        //    }
        //}
    }
}