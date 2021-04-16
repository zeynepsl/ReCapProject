using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OperationClaimsDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
