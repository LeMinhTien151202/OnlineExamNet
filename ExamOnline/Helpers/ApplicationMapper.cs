using AutoMapper;

namespace ExamOnline.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Exam, ExamDTO>()
                .ReverseMap();
            CreateMap<Category, CategoryDTO>()
                .ReverseMap();
            CreateMap<Level, LevelDTO>()
                .ReverseMap();
            CreateMap<Question, QuestionDTO>()
                .ReverseMap();
            CreateMap<Result, ResultDTO>()
                .ReverseMap();
            //CreateMap<Role, RoleDTO>()
            //    .ReverseMap();
        }
    }
}
