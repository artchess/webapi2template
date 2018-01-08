using System.Collections.Generic;

namespace WebApiTemplate.Models
{
    public class ResultadoPaginado<TEntity>
    {
        public List<TEntity> Data { get; set; }
        public int Draw { get; set; }
        public long RecordsTotal { get; set; }
        public long RecordsFiltered { get; set; }
    }
}