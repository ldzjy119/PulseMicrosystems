using PulseMicrosystemsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PulseMicrosystemsMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SelectListItem> templates = new List<SelectListItem>();

            // Set the default Template and you can change it through database
            int templateID = 1;

            using (TemplateContext templateContext = new TemplateContext())
            {
                foreach (Template template in templateContext.Templates)
                {
                    SelectListItem selectItem = new SelectListItem
                    {
                        Text = template.Name,
                        Value = template.ID.ToString(),
                        Selected = template.IsSelected.HasValue ? (bool)template.IsSelected : false
                    };

                    if (template.IsSelected.HasValue && (bool)template.IsSelected)
                        templateID = template.ID;

                    templates.Add(selectItem);
                }
            }

            ViewBag.Templates = templates;

            return View(GetCurrentModel(templateID));
        }

        public PartialViewResult GetTemplateFields(string templateID)
        {
            int id = Convert.ToInt32(templateID);

            return PartialView(GetCurrentModel(id));
        }

        private ViewModel GetCurrentModel(int id)
        {
            ViewModel model = new ViewModel();

            using (TemplateContext templateContext = new TemplateContext())
            {
                Template currentTemplate = templateContext.Templates.Find(id);

                model.UserAddress = string.Empty;
                model.UserName = string.Empty;
                model.TemplateFields = currentTemplate.TemplateFields;
                model.TemplateName = currentTemplate.Name;
                model.TemplateID = id;
            }

            return model;
        }

        [HttpPost]
        public ActionResult SaveData(ViewModel model)
        {
            int userID = -1;

            try
            {
                using (TemplateContext templateContext = new TemplateContext())
                {
                    User user = templateContext.Users.FirstOrDefault(u => u.Name.ToLower() == model.UserName.ToLower()
                                                                        && u.Address.ToLower() == model.UserAddress.ToLower());
                    // Check if user already exists
                    if (user == null)
                    {
                        // Insert new user into the Users table
                        User newUser = new User { Name = model.UserName, Address = model.UserAddress };
                        templateContext.Users.Add(newUser);
                        templateContext.SaveChanges();

                        userID = newUser.ID;
                    }
                    else
                    {
                        userID = user.ID;
                    }

                    UserData userData = templateContext.UserData.FirstOrDefault(u => u.UserID == userID);

                    if (userData == null)
                    {
                        userData = new UserData();
                        switch (model.TemplateID)
                        {
                            case 1:
                                if (model.TemplateFields[0].Name != "" && model.TemplateFields[1].Name != "")
                                    userData.Template1ID = CreateTemplate1(model.TemplateFields[0].Name, model.TemplateFields[1].Name);
                                break;
                            case 2:
                                if (model.TemplateFields[0].Name != "")
                                    userData.Template2ID = CreateTemplate2(model.TemplateFields[0].Name);
                                break;
                            case 3:
                                if (model.TemplateFields[0].Name != "" && model.TemplateFields[1].Name != ""
                                                                       && model.TemplateFields[2].Name != "")
                                    userData.Template3ID = CreateTemplate3(model.TemplateFields[0].Name, model.TemplateFields[1].Name, model.TemplateFields[2].Name);
                                break;
                        }

                        userData.UserID = userID;
                        templateContext.UserData.Add(userData);
                        templateContext.SaveChanges();
                    }
                    else
                    {
                        switch (model.TemplateID)
                        {
                            case 1:
                                if (userData.Template1ID == null)
                                {
                                    if (model.TemplateFields[0].Name != "" && model.TemplateFields[1].Name != "")
                                    {
                                        userData.Template1ID = CreateTemplate1(model.TemplateFields[0].Name, model.TemplateFields[1].Name);
                                        templateContext.SaveChanges();
                                    }
                                }
                                else
                                {
                                    UpdateTemplate1((int)userData.Template1ID, model.TemplateFields[0].Name, model.TemplateFields[1].Name);
                                }
                                break;
                            case 2:
                                if (userData.Template2ID == null)
                                {
                                    if (model.TemplateFields[0].Name != "")
                                    {
                                        userData.Template2ID = CreateTemplate2(model.TemplateFields[0].Name);
                                        templateContext.SaveChanges();
                                    }
                                }
                                else
                                {
                                    UpdateTemplate2((int)userData.Template2ID, model.TemplateFields[0].Name);
                                }
                                break;
                            case 3:
                                if (userData.Template3ID == null)
                                {
                                    if (model.TemplateFields[0].Name != "" && model.TemplateFields[1].Name != ""
                                                                           && model.TemplateFields[2].Name != "")
                                    {
                                        userData.Template3ID = CreateTemplate3(model.TemplateFields[0].Name, model.TemplateFields[1].Name, model.TemplateFields[2].Name);
                                        templateContext.SaveChanges();
                                    }
                                }
                                else
                                {
                                    UpdateTemplate3((int)userData.Template3ID, model.TemplateFields[0].Name, model.TemplateFields[1].Name, model.TemplateFields[2].Name);
                                }
                                break;
                        }
                    }
                }
                ViewBag.Result = "Data has been saved!";
            }
            catch (Exception ex)
            {
                ViewBag.Result = "Save has been failed!: " + ex.Message;
            }

            return View();
        }

        private int CreateTemplate1(string firstName, string lastName)
        {
            Template1 template1Value = new Template1 { FirstName = firstName, LastName = lastName };
            int id = -1;
            using (TemplateContext templateContext = new TemplateContext())
            {
                templateContext.Template1Values.Add(template1Value);
                templateContext.SaveChanges();
                id = template1Value.ID;
            }

            return id;
        }

        private void UpdateTemplate1(int id, string firstName, string lastName)
        {
            using (TemplateContext templateContext = new TemplateContext())
            {
                Template1 template = templateContext.Template1Values.FirstOrDefault(u => u.ID == id);
                template.FirstName = firstName;
                template.LastName = lastName;
                templateContext.SaveChanges();
            }
        }

        private int CreateTemplate2(string hometown)
        {
            Template2 template2Value = new Template2 { Hometown = hometown };
            int id = -1;
            using (TemplateContext templateContext = new TemplateContext())
            {
                templateContext.Template2Values.Add(template2Value);
                templateContext.SaveChanges();
                id = template2Value.ID;
            }

            return id;
        }

        private void UpdateTemplate2(int id, string hometown)
        {
            using (TemplateContext templateContext = new TemplateContext())
            {
                Template2 template = templateContext.Template2Values.FirstOrDefault(u => u.ID == id);
                template.Hometown = hometown;
                templateContext.SaveChanges();
            }
        }

        private int CreateTemplate3(string spouseName, string kidName1, string kidName2 )
        {
            Template3 template3Value = new Template3 { SpouseName = spouseName, KidName1 = kidName1, KidName2 = kidName2 };
            int id = -1;
            using (TemplateContext templateContext = new TemplateContext())
            {
                templateContext.Template3Values.Add(template3Value);
                templateContext.SaveChanges();
                id = template3Value.ID;
            }

            return id;
        }

        private void UpdateTemplate3(int id, string spouseName, string kidName1, string kidName2)
        {
            using (TemplateContext templateContext = new TemplateContext())
            {
                Template3 template = templateContext.Template3Values.FirstOrDefault(u => u.ID == id);
                template.SpouseName = spouseName;
                template.KidName1 = kidName1;
                template.KidName2 = kidName2;
                templateContext.SaveChanges();
            }
        }
    }
}
