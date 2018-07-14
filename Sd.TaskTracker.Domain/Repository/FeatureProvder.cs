using AutoMapper;
using SD.TaskTracker.Data.Interface.Query;
using SD.TaskTracker.Data.Model;
using SD.TaskTracker.Domain.Interface;
using SD.TaskTracker.Domain.Model;
using System.Collections.Generic;

namespace SD.TaskTracker.Domain.Repository
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Feature, FeatureRecord>();
            CreateMap<FeatureRecord, Feature>();
        }
    }
    public class FeatureProvder : IFeatureProvider
    {
        private readonly IMapper _mapper;
        //public FeatureProvder(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}
        private IFeatureQuery _featureQuery;
        public FeatureProvder(IFeatureQuery featureQuery, IMapper mapper)
        {
            _mapper = mapper;
            _featureQuery = featureQuery;
        }

        public List<Feature> Get()
        {
            var features = _mapper.Map<List<FeatureRecord>, List<Feature>>(_featureQuery.Get());
            return features;
        }
    }
}
