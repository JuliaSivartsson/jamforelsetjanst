﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.WebServices.Models;

namespace TownComparisons.Domain.Abstract
{
    public interface IService
    {
        // Gets a list of all Organisational Units by Municipality and Category.
        List<OU> GetOrganisationalUnitByMunicipalityAndCategory(Municipality municipality, Category category);

        // Gets a list of all KpiGroups by Category.
        List<KpiGroup> GetKpiGroupByCategory(Category category);

        // Gets a list of all KpiAnswers by a list of KpiQuestions and a list of Organisational Units.
        List<KpiAnswer> GetKpiAnswersByKpiQuestionAndOrganisationalUnit(List<KpiQuestion> kpiQuestion, List<OU> organisationalUnit);
        
        // Gets a list of all KpiGroups.
        List<KpiGroup> GetAllKpiGroups();

        // Gets a Organisational Unit by ID.
        OU GetOrganisationalUnitByID(string id);



        List<OrganisationalUnitInfo> GetOrganisationalUnitInfos();
        
        // Gets a list of all Group categories (including it's categories)
        List<GroupCategory> GetAllCategories();
    }
}
