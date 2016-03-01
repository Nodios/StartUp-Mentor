using AutoMapper;
using StartUpMentor.Model.Common;
using StartUpMentor.DAL.Models;
using System.Collections.Generic;

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

            Mapper.CreateMap<StartUpMentor.DAL.Models.UserEntity, IUser>().ReverseMap();
            Mapper.CreateMap<StartUpMentor.DAL.Models.UserEntity, User>().ReverseMap();
            Mapper.CreateMap<User, IUser>().ReverseMap();

			Mapper.CreateMap<ISecurityEntity, TokenEntity>();
			Mapper.CreateMap<TokenEntity, ISecurityEntity>();

			//Mapper.CreateMap<IRole, RoleEntity>();
			Mapper.CreateMap<IRole, RoleEntity>().ReverseMap();

			Mapper.CreateMap<IRole, string>().ConvertUsing(source => source.roleName ?? string.Empty);
			Mapper.CreateMap<ICollection<Role>, ICollection<string>>();

		
            Mapper.CreateMap<StartUpMentor.DAL.Models.ApplicationUser, IApplicationUser>().ReverseMap();
            Mapper.CreateMap<StartUpMentor.DAL.Models.ApplicationUser, ApplicationUser>().ReverseMap();
            Mapper.CreateMap<ApplicationUser, IApplicationUser>().ReverseMap();

            Mapper.CreateMap<ApplicationUser, IApplicationUser>().ReverseMap();
            Mapper.CreateMap<ApplicationUser, ApplicationUser>().ReverseMap();
            Mapper.CreateMap<ApplicationUser, IApplicationUser>().ReverseMap();

            Mapper.CreateMap<VideoEntity, IVideo>().ReverseMap();
            Mapper.CreateMap<VideoEntity, Video>().ReverseMap();
            Mapper.CreateMap<Video, IVideo>().ReverseMap();

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
