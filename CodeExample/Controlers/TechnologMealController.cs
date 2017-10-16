using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;
using DataModel.Objects;
using Devices.ServiceLibrary.Logic;
using HMI.Helpers;
using HMI.Models;
using System.Security.Principal;

namespace HMI.Controllers
{
    [Authorize(Roles = "DOMAIN-NAME\\TechnologMeal")]
    public class TechnologMealController : Controller
    {
        private ServiceCallLogic _omsService = new ServiceCallLogic();

        public ActionResult Index(TechnologMealViewModel model)
        {
            var newModel = new TechnologMealViewModel();
            long dayShiftId = DatabaseHelper.GetCurrentDayShiftId();
            var d = DateTime.Now.Date;
            var bd = d.Date;
            if (model.DateBegin == DateTime.MinValue)
            {
                newModel.DateBegin = new DateTime(bd.Year, bd.Month, bd.Day, 7, 0, 0);
            }
            else
            { newModel.DateBegin = model.DateBegin; }

            if (model.TimeBegin == DateTime.MinValue)
            {
                newModel.TimeBegin = new DateTime(bd.Year, bd.Month, bd.Day, 7, 0, 0);
            }
            else
            { newModel.TimeBegin = model.TimeBegin; }


            if (model.DateFinish == DateTime.MinValue)
            {
                newModel.DateFinish = new DateTime(d.Year, d.Month, d.Day, 19, 00, 00);
            }
            else
            { newModel.DateFinish = model.DateFinish; }


            if (model.TimeFinish == DateTime.MinValue)
            {
                newModel.TimeFinish = new DateTime(d.Year, d.Month, d.Day, 19, 00, 00);
            }
            else
            { newModel.TimeFinish = model.TimeFinish; }

            if (model.ShiftId == 0)
            {
                newModel.ShiftId = dayShiftId;
            }
            else
            {
                newModel.ShiftId = model.ShiftId;
            }

            newModel.Shifts.Add(new ListItemModel { Id = 0, Name = "Виберіть зміну" });

            newModel.Shifts.AddRange(DatabaseHelper.GetDayShifts());

            var activeCars = DatabaseHelper.GetActualCarInfo().Where(c => c.ProcessStatus == "Прийом насіння");

            newModel.Bunkers = DatabaseHelper.GetBunkersState();
            DateTime startPeriod =
            new DateTime(newModel.DateBegin.Year,
                newModel.DateBegin.Month,
                newModel.DateBegin.Day,
                newModel.TimeBegin.Hour,
                newModel.TimeBegin.Minute,
                newModel.TimeBegin.Second);

            DateTime finishPeriod =
                new DateTime(newModel.DateFinish.Year,
                    newModel.DateFinish.Month,
                    newModel.DateFinish.Day,
                    newModel.TimeFinish.Hour,
                    newModel.TimeFinish.Minute,
                    newModel.TimeFinish.Second);
            var mealShifts = DatabaseHelper.GetMealShiftsInfo(startPeriod, finishPeriod);

           foreach (var item in mealShifts)
           {
               newModel.MealShifts.Add(new TechnologMealCurrentActivitiesPerShift
               {
                   ShiftDate = item.StartShift.HasValue ? string.Format("{0:dd.MM.yyyy}", item.StartShift.Value) : "",
                   ShiftName = item.ShiftName,
                   StoragedHusk = item.StoragedHusk.HasValue ? item.StoragedHusk.Value : 0,
                   StoragedHuskGran = item.StoragedHuskGran.HasValue ? item.StoragedHuskGran.Value : 0,
                   PackedHusk = item.PackedHusk.HasValue ? item.PackedHusk.Value : 0,
                   PackedSchrotte = item.PackedSchrotte.HasValue ? item.PackedSchrotte.Value : 0,
                   StoragedSchrotte = item.StoragedSchrotte.HasValue ? item.StoragedSchrotte.Value : 0,
                   StoragedSchrotteGran = item.StoragedSchrotteGran.HasValue ? item.StoragedSchrotteGran.Value : 0
               });
           }
           var shiftInfo = DatabaseHelper.GetMealShiftInfo(newModel.ShiftId);

            newModel.TechnologMealCurrentShift.AmountCarsBeforeTruck = shiftInfo.AmountCarsBeforeTruck.Value;
            newModel.TechnologMealCurrentShift.AmountExpectedRevenuesByTTN = shiftInfo.AmountExpectedRevenuesByTTN.HasValue?shiftInfo.AmountExpectedRevenuesByTTN.Value:0;
            newModel.TechnologMealCurrentShift.AmountGoOnProduction = shiftInfo.AmountGoOnProduction.HasValue ? shiftInfo.AmountGoOnProduction.Value : 0;
            newModel.TechnologMealCurrentShift.PackedHusk = shiftInfo.PackedHusk.HasValue ? shiftInfo.PackedHusk.Value : 0;
            newModel.TechnologMealCurrentShift.PackedSchrotte = shiftInfo.PackedSchrotte.HasValue ? shiftInfo.PackedSchrotte.Value : 0;
            newModel.TechnologMealCurrentShift.PackedHuskGran = shiftInfo.PackedHuskGran.HasValue ? shiftInfo.PackedHuskGran.Value : 0;
            newModel.TechnologMealCurrentShift.PackedSchrotteGran = shiftInfo.PackedSchrotteGran.HasValue ? shiftInfo.PackedSchrotteGran.Value : 0;

            newModel.TechnologMealCurrentShift.StoragedHusk = shiftInfo.StoragedHusk.HasValue ? shiftInfo.StoragedHusk.Value : 0;
            newModel.TechnologMealCurrentShift.StoragedHuskGran = shiftInfo.StoragedHuskGran.HasValue ? shiftInfo.StoragedHuskGran.Value : 0;
            newModel.TechnologMealCurrentShift.StoragedSchrotte = shiftInfo.StoragedSchrotte.HasValue ? shiftInfo.StoragedSchrotte.Value : 0;
            newModel.TechnologMealCurrentShift.StoragedSchrotteGran = shiftInfo.StoragedSchrotteGran.HasValue ? shiftInfo.StoragedSchrotteGran.Value : 0;
            newModel.TechnologMealCurrentShift.StoragedCake = shiftInfo.StoragedCake.HasValue ? shiftInfo.StoragedCake.Value : 0;

            newModel.CurrentStorageState.OilCakesWeight = DatabaseHelper.GetOilCakesWeight();
            newModel.CurrentStorageState.HuskCharacteristicWeight = DatabaseHelper.GetHuskCharacteristicWeight();
            newModel.CurrentStorageState.HuskCharacteristicGranWeight = DatabaseHelper.GetHuskCharacteristicGranWeight();
            newModel.CurrentStorageState.SchrothGranWeight = DatabaseHelper.GetSchrothGranWeight();
            newModel.CurrentStorageState.SchrothWeight = DatabaseHelper.GetSchrothWeight();
            newModel.CurrentStorageState.BigbagBunker1 = DatabaseHelper.GetBigbagWeight(1,newModel.ShiftId);
            newModel.CurrentStorageState.BigbagBunker2 = DatabaseHelper.GetBigbagWeight(2, newModel.ShiftId);
            newModel.CurrentStorageState.BigBagStorage = DatabaseHelper.GetBigBagStorage();

            newModel.BunkersFrom = DatabaseHelper.GetBunkerForMoving().Where(b => b.ParentId > 0 
                && (b.Id != 119 || b.Id != 120)).OrderBy(b => b.Id).ToList();

            newModel.BunkersTo = DatabaseHelper.GetBunkerForMoving().OrderBy(b => b.Id).ToList();

            newModel.Products = DatabaseHelper.GetMealProducts();
            newModel.TransactionDate = d;
            newModel.Classifications.Add(new ListItemModel { Id = 8, Name = "Не гранульований" });
            newModel.Classifications.Add(new ListItemModel { Id = 7, Name = "Гранульований" });

            var mealIncomingCars = DatabaseHelper.GetActualCarInfo().Where(c => c.OrderTypeId == 4);
            foreach (var item in mealIncomingCars)
            {
                var order = DatabaseHelper.GetOrderById(item.OrderId);
                var deliveryNote = DatabaseHelper.GetDeliveryNoteBy(item.OrderId);

                newModel.IncomingCarList.Add(
                        new CarOnAriaInfo { 
                        CarNumber = item.CarNumber,
                        Characteristic = item.ClassificationName,
                        GrossWeight = order.GrossWeight.HasValue?order.GrossWeight.Value:0,
                        Product = item.ProductName,
                        Proccess = item.CarPlaceName,
                        WeightOnTTN = deliveryNote.TtnNettoWeight.HasValue ? deliveryNote.TtnNettoWeight.Value : 0,
                    });
            }

            var carShipmentList = DatabaseHelper.GetActualCarInfo().Where(c => c.OrderTypeId == 5|| c.OrderTypeId ==8 ||  c.OrderTypeId == 12 );
            foreach (var item in carShipmentList)
            {
                var order = DatabaseHelper.GetOrderById(item.OrderId);
                var deliveryNote = DatabaseHelper.GetDeliveryNoteBy(item.OrderId);
                if (item.ElevatorNUmber == 1)
                {
                    newModel.CarShipmentList.Add(
                            new CarOnAriaInfo
                            {
                                CarNumber = item.CarNumber,
                                Characteristic = item.ClassificationName,
                            //GrossWeight = order.GrossWeight.HasValue ? order.GrossWeight.Value : 0,
                            Product = item.ProductName,
                                Proccess = item.CarPlaceName,
                                NetWeight = double.Parse(item.Weight),
                                WeightOnTTN = deliveryNote.TtnNettoWeight.HasValue ? deliveryNote.TtnNettoWeight.Value : 0,
                            });
                }
                if (item.ElevatorNUmber == 2)
                {
                    newModel.CarShipmentList2.Add(
                      new CarOnAriaInfo
                      {
                          CarNumber = item.CarNumber,
                          Characteristic = item.ClassificationName,
                          //GrossWeight = order.GrossWeight.HasValue ? order.GrossWeight.Value : 0,
                          Product = item.ProductName,
                          Proccess = item.CarPlaceName,
                          NetWeight = double.Parse(item.Weight),
                          WeightOnTTN = deliveryNote.TtnNettoWeight.HasValue ? deliveryNote.TtnNettoWeight.Value : 0,
                      });
                }

            }

            return View(newModel);
        }

        public ActionResult SwitchMealLine(SwitchMealViewModel model)
        {
            var newModel = new SwitchMealViewModel();
            newModel.Bunkers.Add(new ListItemViewModern { Id=0,Name="Не обранний"});
            newModel.Bunkers.AddRange(
                DatabaseHelper.GetBunkerForMoving().Where(b=>b.Id!=14).ToList());

            newModel.FlowmeterPreparatoryHuskWay.Products
                .Add(new ListItemViewModern { Id = 0, Name = "Не обранний" });
            newModel.FlowmeterPreparatoryMealWay.Products
                .Add(new ListItemViewModern { Id = 0, Name = "Не обранний" });
            newModel.FlowmeterPreparatoryOilCakeWay.Products
                .Add(new ListItemViewModern { Id = 0, Name = "Не обранний" });

            newModel.FlowmeterPreparatoryHuskWay.Products.AddRange(
                DatabaseHelper.GetProductsForSwitchLine(ProductTypeEnum.HUSK));
            newModel.FlowmeterPreparatoryMealWay.Products.AddRange(
                DatabaseHelper.GetProductsForSwitchLine(ProductTypeEnum.SHROT));
             newModel.FlowmeterPreparatoryMealWay.Products.AddRange(
                  DatabaseHelper.GetProductsForSwitchLine(ProductTypeEnum.OILCAKE));
            newModel.FlowmeterPreparatoryOilCakeWay.Products.AddRange(
                DatabaseHelper.GetProductsForSwitchLine(ProductTypeEnum.OILCAKE));

            var huskWay = DatabaseHelper.GetFlowmeterPreparatoryProductId(ProductTypeEnum.HUSK);
            var mealWay = DatabaseHelper.GetFlowmeterPreparatoryProductId(ProductTypeEnum.SHROT);
            var oilCakeWay = DatabaseHelper.GetFlowmeterPreparatoryOilCakeProductId();
            
            newModel.FlowmeterPreparatoryHuskWay.ProductId = huskWay.ProductId;
            newModel.FlowmeterPreparatoryMealWay.ProductId = mealWay.ProductId;
            newModel.FlowmeterPreparatoryOilCakeWay.ProductId = oilCakeWay.ProductId;

            newModel.FlowmeterPreparatoryHuskWay.BunkerToId = huskWay.DestinationStorageTypeId.HasValue?huskWay.DestinationStorageTypeId.Value:0;
            newModel.FlowmeterPreparatoryMealWay.BunkerToId = mealWay.DestinationStorageTypeId.HasValue? mealWay.DestinationStorageTypeId.Value:0;
            newModel.FlowmeterPreparatoryOilCakeWay.BunkerToId = oilCakeWay.SourceStorageTypeId;

            return View(newModel);
        }

        public ActionResult LaboratoryValidation(string carNumber)
        {
            var newModel = new LaboratoryViewModel();

            newModel = GetLaboratoryModelForCarnumber(carNumber);
            DatabaseHelper.SetUnlockForControls(newModel);
            DatabaseHelper.SetModelCollections(newModel);
            DatabaseHelper.GetAnalisisProperty(newModel);
            ViewData["read"] = true;
            newModel.IsOnAnalyzes = true;


            return View(newModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Moving(TechnologMealViewModel model)
        {
            if (string.IsNullOrEmpty(model.Quantity))
            {
                return RedirectToAction("Index");
            }
            var quantity =
                decimal.Parse(model.Quantity.Replace(".", ","));

            DatabaseHelper.CreateMealStorageMoving(
                DateTime.Now,
                model.ProductFromId,
                model.ProductFromId,
                model.ClassificationFromId,
                model.ClassificationToId,
                model.SilageFromId,
                model.SilageToId,
                quantity);

            DatabaseHelper.SetUserChangesLog(User.Identity.Name, "Перемещение на элеваторе", 0);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ChangeSwitchHuskLine(long huskProductId, long huskBunkerToId)
        {
            DatabaseHelper.UpdateMealSwitchLineIn
                ( 
                    ProductTypeEnum.HUSK,
                    huskProductId, huskBunkerToId
                );

            DatabaseHelper.SetUserChangesLog(User.Identity.Name, "Зміна напрямку потоків лушпіння на силосному складі", 0);

            return RedirectToAction("SwitchMealLine");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ChangeSwitchMealLine(long mealProductId, long mealBunkerToId)
        {
            switch (mealProductId)
            {
                case 3:
                case 13:
                case 31:
                    DatabaseHelper.UpdateMealSwitchLineIn
                    (
                        ProductTypeEnum.OILCAKE,
                        mealProductId, mealBunkerToId
                    );
                    break;
                case 7:
                case 16:
                case 18:
                case 34:
                    DatabaseHelper.UpdateMealSwitchLineIn
                    (
                        ProductTypeEnum.SHROT,
                        mealProductId, mealBunkerToId
                    );
                        break;
                case 0:
                     DatabaseHelper.UpdateMealSwitchLineIn
                    (
                        ProductTypeEnum.SHROT,
                        mealProductId, mealBunkerToId
                    );
                        break;
            }
                
            DatabaseHelper.SetUserChangesLog(User.Identity.Name, "Зміна напрямку потоків шрота на силосному складі", 0);

            return RedirectToAction("SwitchMealLine");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ChangeSwitchOilCakeLine(long oilCakeProductId, long oilCakeBunkerToId)
        {
            DatabaseHelper.UpdateMealSwitchLineOut
                (
                    ProductTypeEnum.OILCAKE,
                    oilCakeProductId, oilCakeBunkerToId
                );

            DatabaseHelper.SetUserChangesLog(User.Identity.Name, "Зміна напрямку потоків макухи на силосному складі", 0);

            return RedirectToAction("SwitchMealLine");
        }

        private LaboratoryViewModel GetLaboratoryModelForCarnumber(string carNumber)
        {
            var model = new LaboratoryViewModel();
            
            using (var dl = new OMS())
            {
                var order = DatabaseHelper.GetOrderByCarNumber(carNumber);
                if (order != null)
                {
                    Product product = dl.Products.FirstOrDefault(p => p.Id == order.ProductId);

                    model.OrderId = order.Id;
                    model.OrderTypeId = order.OrderTypeId;
                    model.Barcode = order.Barcode;
                    model.CarNumber = carNumber;
                    model.TruckNumber = order.TrailerNumber;
                    model.ProductId = order.ProductId;
                    model.ClassificationId = order.ClassificationId;
                    model.Placards = order.Placards;
                    switch (order.OrderTypeId)
                    {
                        case 2:
                        case 3:
                            model.Silage =order.TankNumber.HasValue ?order.TankNumber.Value:0;
                            break;
                        case 4:
                        case 6:
                            model.Tank = order.TankNumber.HasValue ? order.TankNumber.Value : 0;
                            break;
                        default:
                            break;
                    }
                    model.Comment = order.Comment;
                    if (product != null)
                    {
                        model.ProductName = product.Name;
                    }
                    model.ClassificationName = dl.Classifications.Single(c=>c.Id == order.ClassificationId).Name;

                }
            }
            return model;
        }

        public void ValidationSuccess(long orderId)
        {
            try
            {

                _omsService.SetOrderValidationResult(orderId, ValidationEnum.VALIDATED);
                var code = Helpers.DatabaseHelper.GetNextOperationCodeBy(orderId);
                _omsService.StopOrderOperation(orderId, "CONCLUSION_LABORATORY");

                var order = DatabaseHelper.GetOrderById(orderId);
                var userInfo = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                DatabaseHelper.SetUserChangesLog(userInfo.Identity.Name, "Підтвердження аналізів технологом склада шрота", orderId);

                _omsService.SendAnalysisTo1C((ActionTypeEnum)order.OrderType.ActionTypeID, orderId);
                _omsService.StartOrderOperation(orderId, code);
            }
            catch (Exception ex)
            {
                if (Request.IsAjaxRequest())
                {
                    Response.StatusCode = 505; // Or any other proper status code.
                    Response.Write(ex.Message + " &");
                }
            }
        }

        public void ValidationNotSuccess(long orderId)
        {
            try
            {
                _omsService.SetOrderValidationResult(orderId, ValidationEnum.NOVALIDATED);
                _omsService.StopOrderOperation(orderId, "CONCLUSION_LABORATORY");
                _omsService.StartOrderOperation(orderId, "CANCELLATION_CARD_IN_SINGLE_WINDOW");
                var userInfo = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                DatabaseHelper.SetUserChangesLog(userInfo.Identity.Name, "Відмовлення технолога склада шрота", orderId);
            }
            catch (Exception ex)
            {
                if (Request.IsAjaxRequest())
                {
                    Response.StatusCode = 505; // Or any other proper status code.
                    Response.Write(ex.Message + " &");
                }
            }
        }

        public ActionResult ReportProductMovementForm(ReportProductMovementViewModel model)
        {
            List<Silage> siloses = new List<Silage>();
            ReportProductMovementViewModel newModel = new ReportProductMovementViewModel();

            var d = DateTime.Now.Date;
            var bd = d.AddDays(-1).Date;
            if (model.DateBegin == DateTime.MinValue)
            {
                newModel.DateBegin = new DateTime(bd.Year, bd.Month, bd.Day, 7, 0, 0);
            }
            else
            {
                newModel.DateBegin = new DateTime(model.DateBegin.Year,
                    model.DateBegin.Month, model.DateBegin.Day, 7, 0, 0);
            }

            if (model.TimeBegin == DateTime.MinValue)
            {
                newModel.TimeBegin = new DateTime(bd.Year, bd.Month, bd.Day, 7, 0, 0);
            }
            else
            { newModel.TimeBegin = model.TimeBegin; }


            if (model.DateFinish == DateTime.MinValue)
            {
                newModel.DateFinish = new DateTime(d.Year, d.Month, d.Day, 19, 00, 00);
            }
            else
            {
                newModel.DateFinish = new DateTime(model.DateFinish.Year,
                      model.DateFinish.Month, model.DateFinish.Day, 7, 0, 0);
            }

            if (model.TimeFinish == DateTime.MinValue)
            {
                newModel.TimeFinish = new DateTime(d.Year, d.Month, d.Day, 19, 00, 00);
            }
            else
            { newModel.TimeFinish = model.TimeFinish; }


            using (var dl = new OMS())
            {
                newModel.IsPrint = true;

                var elevatorMovingView = dl.vwStorageMovingOperations.
                    Where(m => m.OperationDate >= model.DateBegin
                        && m.OperationDate <= model.DateFinish && m.Weight > 5 &&
                        ((m.SilageToId >= 28
                          && m.SilageToId <= 105
                          || m.SilageToId == 115)
                          &&
                          (m.SilageFromId != 24 && m.SilageFromId != 25 && m.SilageFromId != 26
                          && m.SilageToId != 24 && m.SilageToId != 25 && m.SilageToId != 26)
                         
                        ))
                        .Select(m => new ElevatorMovingItemViewModel
                        {
                            ProductName = m.ProductName,
                            ClassificationFromName = m.ClassificationFromName,
                            ClassificationToName = m.ClassificationToName,
                            Date = m.OperationDate,
                            SilageFromName = m.SilageFrom,
                            SilageToName = m.SilageTo,
                            Weight = m.Weight,
                            OperatorLogin = m.UserLogin
                        });

                newModel.ElevatorMovingItems.AddRange(elevatorMovingView);

            }
            return View(newModel);
        }
    }
}
