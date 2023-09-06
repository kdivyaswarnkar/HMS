﻿using HMS.Areas.Dashboard.ViewModels;
using HMS.Entities;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();
        // GET: Dashboard/AccomodationTypes
        public ActionResult Index(string searchTerm)
        {
            AccomodationTypesListingModel model = new AccomodationTypesListingModel();
            model.SearchTerm = searchTerm;
            model.AccomodationTypes = accomodationTypesService.SearchAccomodationTypes(searchTerm);

            //  model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();
            // return PartialView("_Listing", model);
            return View(model);
        }

        //public ActionResult Listing()
        //{
        //    AccomodationTypesListingModel model = new AccomodationTypesListingModel();
        //    model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();
        //    return PartialView("_Listing",model);
        //}

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();

            if(ID.HasValue) // we are trying to edit a record
            {
                var accoodationType = accomodationTypesService.GetAccomodationTypeByID(ID.Value);
                model.ID = accoodationType.ID;
                model.Name = accoodationType.Name;
                model.Description = accoodationType.Description;
            }
            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationTypeActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if(model.ID>0) //we are trying to edit record
            {
                var accomodationType = accomodationTypesService.GetAccomodationTypeByID(model.ID);
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;
                result = accomodationTypesService.UpdateAccomodationType(accomodationType);

            }
            else  //we are trying to create a record
            {
                AccomodationType accomodationType = new AccomodationType();

                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                result = accomodationTypesService.SaveAccomodationType(accomodationType);

            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation Type." };
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();

            var accomodationType = accomodationTypesService.GetAccomodationTypeByID(ID);

            model.ID = accomodationType.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationTypeActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodationType = accomodationTypesService.GetAccomodationTypeByID(model.ID);

            result = accomodationTypesService.DeleteAccomodationType(accomodationType);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation Types." };
            }

            return json;
        }
    }
}