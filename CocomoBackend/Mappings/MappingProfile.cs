using AutoMapper;
using CocomoBackend.Models;
using CocomoBackend.DTOs;


namespace CocomoBackend.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CocomoHead
            CreateMap<CocomoHead, CocomoHeadReadDTO>();
            CreateMap<CocomoHeadCreateDTO, CocomoHead>();
            CreateMap<CocomoHeadUpdateDTO, CocomoHead>();
            //CocomoState
            CreateMap<CocomoState, CocomoStateReadDTO>();
            CreateMap<CocomoStateCreateDTO, CocomoState>();
            CreateMap<CocomoStateUpdateDTO, CocomoState>();
            
            //CocomoVersion
            CreateMap<CocomoVersion, CocomoVersionReadDTO>();
            CreateMap<CocomoVersionCreateDTO, CocomoVersion>();
            CreateMap<CocomoVersionUpdateDTO, CocomoVersion>();

            //CocomoDetail
            CreateMap<CocomoDetail, CocomoDetailReadDTO>();
            CreateMap<CocomoDetailCreateDTO, CocomoDetail>();
            CreateMap<CocomoDetailUpdateDTO, CocomoDetail>();

            //CocomoStateVersion
            CreateMap<CocomoStateVersion, CocomoStateVersionReadDTO>();
            CreateMap<CocomoStateVersionCreateDTO, CocomoStateVersion>();
            CreateMap<CocomoStateVersionUpdateDTO, CocomoStateVersion>();

            //Customer
            CreateMap<Customer, CustomerReadDTO>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDTO, Customer>();

            //PlatformObjectTime
            CreateMap<PlatformObjectTime, PlatformObjectTimeReadDTO>();
            CreateMap<PlatformObjectTimeCreateDTO, PlatformObjectTime>();
            CreateMap<PlatformObjectTimeUpdateDTO, PlatformObjectTime>();


            //Module
            CreateMap<Module, ModuleReadDTO>();
            CreateMap<ModuleCreateDTO, Module>();
            CreateMap<ModuleUpdateDTO, Module>();

            //Vertical
            CreateMap<Vertical, VerticalReadDTO>();
            CreateMap<VerticalCreateDTO, Vertical>();
            CreateMap<VerticalUpdateDTO, Vertical>();

            //TypeComplexity
            CreateMap<TypeComplexity, TypeComplexityReadDTO>();
            CreateMap<TypeComplexityCreateDTO, TypeComplexity>();
            CreateMap<TypeComplexityUpdateDTO, TypeComplexity>();


            //TypeComplexity
            CreateMap<TypeRequirement, TypeRequirementReadDTO>();
            CreateMap<TypeRequirementCreateDTO, TypeRequirement>();
            CreateMap<TypeRequirementUpdateDTO, TypeRequirement>();


            //TypeProyect
            CreateMap<TypeProyect, TypeProyectReadDTO>();
            CreateMap<TypeProyectCreateDTO, TypeProyect>();
            CreateMap<TypeProyectUpdateDTO, TypeProyect>();

            //TypeFactor
            CreateMap<TypeFactor, TypeFactorReadDTO>();
            //CreateMap<TypeProyectCreateDTO, TypeProyect>();
            //CreateMap<TypeProyectUpdateDTO, TypeProyect>();

            //TypeFactorDetail
            CreateMap<TypeFactorDetail, TypeFactorDetailReadDTO>();
            CreateMap<TypeFactorDetail, TypeFactorDetailCreateDTO>();
            //CreateMap<TypeProyectUpdateDTO, TypeProyect>();
           

        }
    }
}


