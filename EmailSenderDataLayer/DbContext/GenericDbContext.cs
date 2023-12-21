using EmailSenderDataLayer.Dto;
using EmailSenderDataLayer.Interfaces;
using EmailSenderDataLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace EmailSenderDataLayer.DbContext
{

    public class GenericDbContext<T, TResponse> : DbContext
       where T : class, new()
       where TResponse : IDto<T>, new()
    {
        public List<TResponse> Data { get; set; }
        public List<T> _dataFromCsv {  get; set; }
        private string _path;
        private string _config;
        private readonly MyServiceSettings _configuration;


        public GenericDbContext(IOptions<MyServiceSettings> myserviceSetting) : base()
        {

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            _configuration = myserviceSetting.Value;
            _config = Path.Combine(baseDirectory, _configuration.FilePath);
            _path = Path.Combine(_config, typeof(T).Name.ToString() + ".csv");

            Initialize(_path);
        }

        private void Initialize(string path)
        {
            if (File.Exists(path))
            {
                var dataFromCsv = ReadDataFromCsv<T>(path);
                _dataFromCsv = dataFromCsv ?? new List<T>();
                var count = _dataFromCsv.Count;

                Data = new List<TResponse>();

                Data = _dataFromCsv.Select(entity =>
                {
                    var dto = new TResponse();
                    dto.initializeFromEntity(entity);
                    return dto;
                }).ToList();


                var length = Data.Count;
            }
            else
            {
                _dataFromCsv = new List<T>();
                Data = new List<TResponse>();
            }
        }


        public void SaveChanges()
        {
            WriteDataToCsv(_dataFromCsv, _path);
        }

        public void Add(IDto<T> dto)
        {
            T entity = ConvertDtoToEntity(dto);

            _dataFromCsv.Add(entity);
            SaveChanges();
        }

        public T ConvertDtoToEntity(IDto<T> dto)
        {
            T entity = new T();
            var dtoProperties = dto.GetType().GetProperties();
            var entityProperties = typeof(T).GetProperties();

            foreach (var dtoProp in dtoProperties)
            {
                var entityProp = entityProperties.FirstOrDefault(p => p.Name == dtoProp.Name && p.PropertyType == dtoProp.PropertyType);
                if (entityProp != null && entityProp.CanWrite)
                {
                    var value = dtoProp.GetValue(dto);
                    entityProp.SetValue(entity, value);
                }
            }

            return entity;
        }


        




    }

}

