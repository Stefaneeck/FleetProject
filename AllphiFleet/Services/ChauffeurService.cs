﻿using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReadServices.Interfaces;

namespace ReadServices
{
    public class ChauffeurService : IChauffeurService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Chauffeur> _repository;
        public ChauffeurService(IMapper mapper, IDataReadRepository<Chauffeur> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
     
        //filter nullable maken?
        public IEnumerable<ChauffeurDTO> GetChauffeurs(DriverFilter filter)
        {
            //eager loading door include erbij te zetten, standaard haalt hij gerelateerde data niet op (dus geen adressen van chauffeurs bvb)
            var results = _repository.GetAll()
                .Include(c => c.Adres)
                .Include(c => c.Tankkaart);


            /*
            
            if (!string.IsNullOrWhiteSpace(filter.Name))
                results = results.Where(x => x.Naam.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.st))
                results = results.Where(x => x.Adres.Contains(filter.st));

            */


            //omzetten naar chauffeurDTOs en dan returnen
            //tolist = niet meer werken met abstracte query, maar forceren om met concrete data te werken
            return _mapper.Map<IEnumerable<ChauffeurDTO>>(results.ToList());           
        }

        public ChauffeurDTO GetChauffeur(long id)
        {
            return _mapper.Map<ChauffeurDTO>(_repository.Get(id));
        }
    }

    public class DriverFilter
    {
        public string Name { get; set; }
        public string st { get; set; }
    }
}