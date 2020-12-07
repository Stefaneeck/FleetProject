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

            //omzetten naar chauffeurDTOs en dan returnen
            //tolist = niet meer werken met abstracte query, maar forceren om met concrete data te werken
            return _mapper.Map<IEnumerable<ChauffeurDTO>>(results.ToList());

            /*
            
            if (!string.IsNullOrWhiteSpace(filter.Name))
                results = results.Where(x => x.Naam.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.st))
                results = results.Where(x => x.Adres.Contains(filter.st));

            */
        }

        public ChauffeurDTO GetChauffeur(long id)
        {
            //niet ideaal, want eerst alles ophalen.. hoe oplossen?
            var result = _repository.GetAll()
                .Include(c => c.Adres)
                .Include(c => c.Tankkaart)
                .FirstOrDefault(e => e.Id == id);

            return _mapper.Map<ChauffeurDTO>(result);

            //include gaat niet op een domeinobject, enkel op iquerable
            /*
            return _mapper.Map<ChauffeurDTO>(_repository.Get(id)
                .Include(c => c.Adres)
                .Include(c => c.Tankkaart));
            */
        }
    }

    public class DriverFilter
    {
        public string Name { get; set; }
        public string st { get; set; }
    }
}
