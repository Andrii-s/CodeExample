using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infocom.TruckRegistration.HMI.Models
{
    public class TechnologMealViewModel
    {
        [Display(Name = "Дата початку")]
        public DateTime DateBegin { get; set; }
        [Display(Name = "час початку")]
        public DateTime TimeBegin { get; set; }

        [Display(Name = "Дата закінчення")]
        public DateTime DateFinish { get; set; }
        [Display(Name = "час закінчення")]
        public DateTime TimeFinish { get; set; }

        public List<BunkerViewModel> Bunkers = new List<BunkerViewModel>();
        public TechnologMealCurrentActivitiesPerShift TechnologMealCurrentShift = new TechnologMealCurrentActivitiesPerShift();
        public List<CarOnAriaInfo> IncomingCarList = new List<CarOnAriaInfo>();
        public List<CarOnAriaInfo> CarShipmentList = new List<CarOnAriaInfo>();
        public List<CarOnAriaInfo> CarShipmentList2 = new List<CarOnAriaInfo>();
        public List<IndicatorsForPeriod> IndicatorsForPeriodList { get; set; }
        public CurrentStorageState CurrentStorageState = new CurrentStorageState();

        public List<TechnologMealCurrentActivitiesPerShift> MealShifts = new List<TechnologMealCurrentActivitiesPerShift>();

        public string Quantity { get; set; }

        public DateTime TransactionDate { get; set; }

        public long ProductFromId { get; set; }

        public List<ListItemModel> Products = new List<ListItemModel>();

        public long SilageFromId { get; set; }

        public List<ListItemViewModern> BunkersTo = new List<ListItemViewModern>();

        public List<ListItemViewModern> BunkersFrom = new List<ListItemViewModern>();

        public long ProductToId { get; set; }

        public long SilageToId { get; set; }

        public long ClassificationFromId { get; set; }

        public long ClassificationToId { get; set; }

        public List<ListItemModel> Classifications = new List<ListItemModel>();

        public List<ListItemModel> Shifts = new List<ListItemModel>();

        public long ShiftId { get; set; }
    }
}