﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;
using TownComparisons.Domain.WebServices.Models;

namespace TownComparisons.Domain.Abstract
{
    public interface ITownWebService : IDisposable
    {
        string GetName();
        List<OrganisationalUnit> GetAllOrganisationalUnits(string municipalityId);
        List<OrganisationalUnit> GetOrganisationalUnitByMunicipalityAndCategory(string municipalityId, Category category);
        OrganisationalUnit GetOrganisationalUnitByID(string id);
        List<KpiGroup> TempGetKpiGroupByCategory(Category category);
        List<KpiAnswer> GetKpiAnswersByKpiQuestionAndOrganisationalUnits(List<KpiQuestion> kpiQuestion, List<OrganisationalUnit> organisationalUnits);
        List<PropertyQueryGroup> GetAllPropertyQueries();
        //string GetMunicipalityId();
    }
}
