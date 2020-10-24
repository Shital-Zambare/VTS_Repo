using System;
using System.Collections.Generic;

namespace DemoProject.DatabaseContext
{
    public partial class Vehicle
    {

        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string ManufacturingYear { get; set; }
        public string LoadCarryingCapacity { get; set; }
        public string MakeOfVehicle { get; set; }
        public string ModelNumber { get; set; }
        public string BodyType { get; set; }
        public string OrganisationName { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
