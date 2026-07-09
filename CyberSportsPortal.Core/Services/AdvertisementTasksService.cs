using CyberSportsPortal.Data.Model.Views;
using System.Collections.Generic;

namespace CyberSportsPortal.Core.Services;

public class AdvertisementTasksService
{
    // Задание 7
    public List<KeyValuePair<int, int>> GetProbabilities(List<AdvertisingCompanyView> companies)
    {
        List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();

        int currentYear = System.DateTime.Now.Year;
        decimal totalPayments = 0;
        Dictionary<int, decimal> companyTotals = new Dictionary<int, decimal>();

        foreach (var company in companies)
        {
            decimal companyTotal = 0;

            foreach (var payment in company.PaymentInfo)
            {
                if (payment.PaymentDate.Year == currentYear)
                {
                    companyTotal += payment.PaymentSum;
                }
            }

            companyTotals[company.Id] = companyTotal;
            totalPayments += companyTotal;
        }

        if (totalPayments == 0)
        {
            return result;
        }

        foreach (var company in companies)
        {
            int probability = (int)(companyTotals[company.Id] / totalPayments * 100);

            if (probability < 1)
            {
                probability = 1;
            }
            result.Add(new KeyValuePair<int, int>(company.Id, probability));
        }
        return result;
    }
}