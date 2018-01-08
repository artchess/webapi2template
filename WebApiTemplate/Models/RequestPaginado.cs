using System.Collections.Generic;
using WebApiTemplate.Controllers.v1;

namespace WebApiTemplate.Models
{
    public class RequestPaginado
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public SearchCol Search { get; set; }
        public List<DataTableOrder> Order { get; set; }
        public List<DataTableColums> Columns { get; set; }

    }

    public class DataTableOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }

    public class DataTableColums
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Orderable { get; set; }
        public bool Searchable { get; set; }
        public SearchCol Search { get; set; }
    }

    public class SearchCol
    {
        public bool Regex { get; set; }
        public string Value { get; set; }
    }
}