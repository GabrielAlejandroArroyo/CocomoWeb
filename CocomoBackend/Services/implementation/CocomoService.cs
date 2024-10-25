using AutoMapper;
using CocomoBackend.Data;
using CocomoBackend.DTOs;
using CocomoBackend.Models;
using CocomoBackend.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using Prospection.Models.Response;

namespace CocomoBackend.Services.implementation
{
    public class CocomoService : ICocomoService
    {
        private readonly AppDbContext _context;
        private readonly ICocomoHeadService _headService;
        private readonly ICocomoVersionService _versionService;
        private readonly IMapper _mapper;

        //public CocomoService(AppDbContext context, CocomoHeadService headService, CocomoVersionService versionService, IMapper mapper)
        public CocomoService(AppDbContext context, ICocomoHeadService headService, ICocomoVersionService versionService, IMapper mapper)
        {
            _context = context;
            _headService = headService;
            _versionService = versionService;
            _mapper = mapper;

        }

        public async Task<CocomoReadDTO> CreateCocomoAsync(CocomoHeadCreateDTO cocomoHeadlDTO)
        {
            using (var transaccion = await _context.Database.BeginTransactionAsync())
            {
                try
                {

                    var head = await _headService.CreateCocomoHeadAsync(cocomoHeadlDTO);
                    
                    //CocomoVersionCreateDTO newVersionDTO = new CocomoVersionCreateDTO();
                    //newVersionDTO.IdCocomoHead = head.Id;
                    //newVersionDTO.Version = "1";
                    //newVersionDTO.IdCocomoStateVersion = 1;


                    //var version = await _versionService.CreateCocomoVersionAsync(newVersionDTO);


                    await transaccion.CommitAsync();

                    CocomoReadDTO cocomoReadDTO = new CocomoReadDTO();
                    cocomoReadDTO.CocomoHead = head;
                    //cocomoReadDTO.CocomoVersion = version;
                    return cocomoReadDTO;
                }
                catch (Exception ex)
                {
                    await transaccion.RollbackAsync();
                    throw;
                }

            }
            throw new NotImplementedException();
        }

        public Task<CocomoReadDTO> GetCococmoByIdAsync(int idhead, int idversion)
        {
            throw new NotImplementedException();
        }

        public Task<CocomoReadDTO> NewVersionCocomoAsync(int idhead, int idversion)
        {
            throw new NotImplementedException();
        }


    }

}
