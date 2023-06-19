using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2KnowledgeCheck1
{
    public class Contruction
    {
        public void CreateApartment(Apartment apartment, List<Building> Buildings)
        {
            // Get materials
            var materialRepo = new MaterialsRepo();
            var materialsNeeded = materialRepo.GetMaterials();

            var permitRepo = new ZoningAndPermitRepo();

            var buildingWasMade = ConstructBuilding<Apartment>(materialsNeeded, permitRepo.GetPermit(), permitRepo.ZoningApproves());

            if (buildingWasMade)
            {
                Buildings.Add(apartment);
            }
        }
        public bool ConstructBuilding<T>(List<Material> materials, bool permit, bool zoning) where T : Building
        {
            if (permit && zoning)
            {
                foreach (var material in materials)
                {
                   
                        var firstStep = material.MaterialContructionFirstStep();
                        Console.WriteLine(firstStep);

                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
