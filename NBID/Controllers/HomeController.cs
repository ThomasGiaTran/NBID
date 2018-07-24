using NBID.Core;
using NBID.Models;
using System.Web.Mvc;

namespace NBID.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            LoginViewModel vm = new LoginViewModel();
            string s = User.Identity.Name.ToString();
            AccountManager mgr = new AccountManager();
            vm = mgr.getUserNames(s);
            ViewBag.name = vm.userFullName;

            return View();
        }

        //[HttpPost]
        //public ActionResult Index(HomeViewModels vm)
        //{
        //    LoginViewModel lvm = new LoginViewModel();
        //    string s = User.Identity.Name.ToString();
        //    AccountManager mgr = new AccountManager();
        //    lvm = mgr.getUserNames(s);
        //    ViewBag.name = lvm.userFullName;

        //    ModelState.Clear();
        //    return View(vm);
        //}

        public PartialViewResult Details(HomeViewModels vm)
        {
            DetailsManager mgr = new DetailsManager();
            if (vm.Dmode == "ACIS_Historical")
            {
                vm.Details_ACIS_Historical = mgr.GetDetails_ACIS_Historical(vm.detailsID_1, vm.detailsID_2);
            }
            if (vm.Dmode == "Alarm_Billing")
            {
                vm.Details_Alarm_Billing = mgr.GetDetails_Alarm_Billing(vm.detailsID_1);
            }
            if (vm.Dmode == "Business_License")
            {
                vm.Details_Business_License = mgr.GetDetails_Business_License(vm.detailsID_1);
            }
            if (vm.Dmode == "LEADS")
            {
                vm.Details_LEADS = mgr.GetDetails_LEADS(vm.detailsID_1);
            }
            if (vm.Dmode == "UB_MUNIS")
            {
                vm.Details_UB = mgr.GetDetails_UB_Munis(vm.detailsID_1);
            }
            if (vm.Dmode == "Vendors_MUNIS")
            {
                vm.Details_MUNIS_VENDORS = mgr.GetDetails_Vendors_Munis(vm.detailsID_1);
            }
            if (vm.Dmode == "GB_MUNIS")
            {
                vm.Details_GB = mgr.GetDetails_GB_Munis(vm.detailsID_1);
            }

            return PartialView("_Details",vm);
        }

        public ActionResult SearchResults(HomeViewModels vm) //Partial View
        {
            QueryManager mgr = new QueryManager();
            vm.queryList = mgr.Get(vm);

            return PartialView("_SearchResults", vm);
        }

        public PartialViewResult Results(HomeViewModels vm) //Partial View
        {
            ResultsManager mgr = new ResultsManager();

            vm.notesList = mgr.Get_Notes(vm.queryID);
            vm.UB_Munis_List = mgr.Get_UB_Munis(vm.queryID);
            vm.UB_ComPlus_List = mgr.Get_UB_ComPlus(vm.queryID);
            vm.APVendors_FinPlus_List = mgr.Get_APVendors_FinPlus(vm.queryID);
            vm.Alarm_Billing_ComPlus_List = mgr.Get_Alarm_Billing_ComPlus(vm.queryID);
            vm.BL_ComPlus_List = mgr.Get_BL_ComPlus(vm.queryID);
            vm.LEADS_PermPlus_List = mgr.Get_LEADS_PermPlus(vm.queryID);
            vm.GB_Munis_List = mgr.Get_GB_Munis(vm.queryID);
            vm.APVendors_Munis_List = mgr.Get_APVendors_Munis(vm.queryID);
            vm.Turbo_Citations_List = mgr.Get_Turbo_Citations(vm.queryID);

            return PartialView("_Results", vm);
        }

        //public ActionResult TopMerge()
        //{
        //    HomeViewModels vm = new HomeViewModels();
        //    return View(vm);
        //}

        //[HttpPost]
        //public ActionResult TopMerge(HomeViewModels vm, int? id1, int? id2)
        //{
        //    MergeManager mgr = new MergeManager();
        //    if (id1 == null || id2 == null || id1 == id2)
        //    {
        //        vm.ErrorMessage = true;
        //        return View(vm);
        //    }
        //    vm.SuccessMessage = true;
        //    //mgr.MergedIds(vm.Selected_MCB);
        //    return View(vm);
        //}


        public void Merge(int id1, int id2)
        {
            MergeManager mgr = new MergeManager();
            mgr.mergeAll(id1, id2);
        }


        [HttpGet]
        public PartialViewResult Get_NewNBID()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Get_newNBID(HomeViewModels vm)
        {
            NewIDManager mgr = new NewIDManager();
            ViewBag.newNBID = mgr.Get_newNBID();
            return PartialView();
        }

        public PartialViewResult AddNotes(HomeViewModels vm, string Command)
        {
            LoginViewModel lvm = new LoginViewModel();
            string s = User.Identity.Name.ToString();
            AccountManager mgrr = new AccountManager();
            lvm = mgrr.getUserNames(s);
            ViewBag.name = lvm.userFullName;

            NoteManager mgr = new NoteManager();
            if (Command == "AddNotes")
            {
                mgr.AddNotes(vm);
                vm.SuccessMessage = true;
            }

                return PartialView("_AddNotes", vm);
        }

        [HttpGet]
        public PartialViewResult _Uncluster(string queryID)
        {
            ViewBag.success = false;
            ResultsManager mgr = new ResultsManager();
            HomeViewModels vm = new HomeViewModels();

            vm.notesList = mgr.Get_Notes(queryID);
            vm.UB_Munis_List = mgr.Get_UB_Munis(queryID);
            vm.UB_ComPlus_List = mgr.Get_UB_ComPlus(queryID);
            vm.APVendors_FinPlus_List = mgr.Get_APVendors_FinPlus(queryID);
            vm.Alarm_Billing_ComPlus_List = mgr.Get_Alarm_Billing_ComPlus(queryID);
            vm.BL_ComPlus_List = mgr.Get_BL_ComPlus(queryID);
            vm.LEADS_PermPlus_List = mgr.Get_LEADS_PermPlus(queryID);
            vm.GB_Munis_List = mgr.Get_GB_Munis(queryID);
            vm.APVendors_Munis_List = mgr.Get_APVendors_Munis(queryID);
            vm.Turbo_Citations_List = mgr.Get_Turbo_Citations(queryID);
            vm.queryID = queryID;

            return PartialView(vm);
        }

        [HttpPost]
        public PartialViewResult _Uncluster(HomeViewModels vm)
        {

            ViewBag.success = false;

            ResultsManager rmgr = new ResultsManager();
            HomeViewModels tempVM = new HomeViewModels();
            tempVM.notesList = rmgr.Get_Notes(vm.queryID);
            tempVM.UB_Munis_List = rmgr.Get_UB_Munis(vm.queryID);
            tempVM.UB_ComPlus_List = rmgr.Get_UB_ComPlus(vm.queryID);
            tempVM.APVendors_FinPlus_List = rmgr.Get_APVendors_FinPlus(vm.queryID);
            tempVM.Alarm_Billing_ComPlus_List = rmgr.Get_Alarm_Billing_ComPlus(vm.queryID);
            tempVM.BL_ComPlus_List = rmgr.Get_BL_ComPlus(vm.queryID);
            tempVM.LEADS_PermPlus_List = rmgr.Get_LEADS_PermPlus(vm.queryID);
            tempVM.GB_Munis_List = rmgr.Get_GB_Munis(vm.queryID);
            tempVM.APVendors_Munis_List = rmgr.Get_APVendors_Munis(vm.queryID);
            tempVM.Turbo_Citations_List = rmgr.Get_Turbo_Citations(vm.queryID);
            tempVM.queryID = vm.queryID;
            tempVM.newQueryID = vm.newQueryID;
            UnclusterManager umgr = new UnclusterManager();

            if(!string.IsNullOrEmpty(vm.newQueryID))
            {
                //UB MUNIS
                for (int i = 0; i < vm.UB_Munis_List.Count; i++)
                {
                    if (vm.UB_Munis_List[i].isChecked)
                    {
                        tempVM.UB_Munis_List[i].isChecked = true;
                        tempVM.CustomerNo = tempVM.UB_Munis_List[i].cust_ser;
                        umgr.Uncluster_UB_Munis(tempVM);                                    
                    }
                }
                //GB MUNIS
                for (int i = 0; i < vm.GB_Munis_List.Count; i++)
                {
                    if (vm.GB_Munis_List[i].isChecked)
                    {
                        tempVM.GB_Munis_List[i].isChecked = true;
                        tempVM.CustomerNo = tempVM.GB_Munis_List[i].cust_ser;
                        umgr.Uncluster_GB_Munis(tempVM);
                    }
                }
                //APVendors MUNIS
                for (int i = 0; i < vm.APVendors_Munis_List.Count; i++)
                {
                    if (vm.APVendors_Munis_List[i].isChecked)
                    {
                        tempVM.APVendors_Munis_List[i].isChecked = true;
                        tempVM.VendorNo = tempVM.APVendors_Munis_List[i].AccountNo;
                        umgr.Uncluster_APVendors_Munis(tempVM);
                    }
                }
                //UB COMPLUS
                for (int i = 0; i < vm.UB_ComPlus_List.Count; i++)
                {
                    if (vm.UB_ComPlus_List[i].isChecked)
                    {
                        tempVM.UB_ComPlus_List[i].isChecked = true;
                        tempVM.AccountNo = tempVM.UB_ComPlus_List[i].AccountNo;
                        tempVM.CustomerNo = tempVM.UB_ComPlus_List[i].cust_ser;
                        umgr.Uncluster_UB_ComPlus(tempVM);
                    }
                }
                //ALARM BILLING COMPLUS
                for (int i = 0; i < vm.Alarm_Billing_ComPlus_List.Count; i++)
                {
                    if (vm.Alarm_Billing_ComPlus_List[i].isChecked)
                    {
                        tempVM.Alarm_Billing_ComPlus_List[i].isChecked = true;
                        tempVM.CustomerNo = tempVM.Alarm_Billing_ComPlus_List[i].cust_ser;
                        umgr.Uncluster_Alarm_Billing_ComPlus(tempVM);
                    }
                }
                //BUSINESS LICENSE COMPLUS
                for (int i = 0; i < vm.BL_ComPlus_List.Count; i++)
                {
                    if (vm.BL_ComPlus_List[i].isChecked)
                    {
                        tempVM.BL_ComPlus_List[i].isChecked = true;
                        tempVM.CustomerNo = tempVM.BL_ComPlus_List[i].cust_ser;
                        umgr.Uncluster_Business_License_ComPlus(tempVM);
                    }
                }
                //AP VENDORS FINPLUS
                for (int i = 0; i < vm.APVendors_FinPlus_List.Count; i++)
                {
                    if (vm.APVendors_FinPlus_List[i].isChecked)
                    {
                        tempVM.APVendors_FinPlus_List[i].isChecked = true;
                        tempVM.AccountNo = tempVM.APVendors_FinPlus_List[i].AccountNo;
                        umgr.Uncluster_APVendors_FinPlus(tempVM);
                    }
                }
                //LEADS PERMITS PLUS
                for (int i = 0; i < vm.LEADS_PermPlus_List.Count; i++)
                {
                    if (vm.LEADS_PermPlus_List[i].isChecked)
                    {
                        tempVM.LEADS_PermPlus_List[i].isChecked = true;
                        tempVM.AccountNo = tempVM.LEADS_PermPlus_List[i].AccountNo;
                        umgr.Uncluster_LEADS_PermPlus(tempVM);
                    }
                }

                //TURBO JASMINE
                for (int i = 0; i < vm.Turbo_Citations_List.Count; i++)
                {
                    if (vm.Turbo_Citations_List[i].isChecked)
                    {
                        tempVM.Turbo_Citations_List[i].isChecked = true;
                        tempVM.AccountNo = tempVM.Turbo_Citations_List[i].AccountNo;
                        umgr.Uncluster_Turbo_Citations(tempVM);
                        umgr.Uncluster_Turbo_Temp_Tables(tempVM);
                    }
                }

                ViewBag.success = true;
            }

            return PartialView(tempVM);
        }

        public PartialViewResult EditNotes(int id)
        {
            LoginViewModel lvm = new LoginViewModel();
            string s = User.Identity.Name.ToString();
            AccountManager mgrr = new AccountManager();
            lvm = mgrr.getUserNames(s);
            ViewBag.name = lvm.userFullName;

            NoteManager mgr = new NoteManager();
            HomeViewModels vm = new HomeViewModels();
            vm.notes = mgr.FindNotes(id);

            return PartialView("_EditNotes", vm);
        }

        [HttpPost]
        public PartialViewResult EditNotes(HomeViewModels vm, string Command)
        {
            NoteManager mgr = new NoteManager();
            if (Command == "Edit")
            {
                mgr.EditNotes(vm);
                vm.SuccessMessage = true;
            }
            if (Command == "Delete")
            {
                mgr.DeleteNotes(vm.notes.note_id);
                vm.SuccessMessage = true;
            }

            return PartialView("_EditNotes", vm);
        }

        public void DeleteNotes(int id)
        {
            NoteManager mgr = new NoteManager();
            mgr.DeleteNotes(id);
        }

        public ActionResult About()
        {
            //get user full name
            LoginViewModel vm = new LoginViewModel();
            string s = User.Identity.Name.ToString();
            AccountManager mgr = new AccountManager();
            vm = mgr.getUserNames(s);
            ViewBag.name = vm.userFullName;

            return View();
        }

        public ActionResult Contact()
        {
            //get user full name
            LoginViewModel vm = new LoginViewModel();
            string s = User.Identity.Name.ToString();
            AccountManager mgr = new AccountManager();
            vm = mgr.getUserNames(s);
            ViewBag.name = vm.userFullName;

            return View();
        }
    }
}