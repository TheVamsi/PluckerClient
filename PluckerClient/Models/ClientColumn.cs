using System;
using System.Collections.Generic;

namespace PluckerClient.Models
{
    public partial class ClientColumn
    {
        public int ClientId { get; set; }
        public int ColumnId { get; set; }
        public int ColOrder { get; set; }
    }
}
