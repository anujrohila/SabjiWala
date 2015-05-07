using OrderWala.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderWala.DAL
{
   public class LanguageRepository
    {
        /// <summary>
        /// Language Save
        /// </summary>
        /// <param name="statedto"></param>
        /// <returns></returns>
        public int LanguageSave(tblLanguageDTO  languagedto)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateLanguage(languagedto.LanguageName, languagedto.LanguageId))
                {
                    return 1;
                }

                if (languagedto.LanguageId == 0)
                {
                    OrderWalaContext.tblLanguages.Add(languagedto.ToEntity());
                }
                else
                {

                    var Langdata = OrderWalaContext.tblLanguages.Where(st => st.LanguageId == languagedto.LanguageId).FirstOrDefault();

                    Langdata.LanguageName = languagedto.LanguageName;
                }

                if (OrderWalaContext.SaveChanges() > 0)
                {
                    return 0;
                }
                else
                {
                    return 2;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Statename"></param>
        /// <param name="languageID"></param>
        /// <returns></returns>
        public bool IsDuplicateLanguage(string languageName, int languageID)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {


                var lagncount = OrderWalaContext.tblLanguages.Where(st => string.Compare(st.LanguageName, languageName) == 0 && st.LanguageId != languageID).ToList();

                return lagncount.Count > 0 ? true : false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LanguageId"></param>
        /// <returns></returns>
        public tblLanguageDTO GetLanguageById(int LanguageId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {              
                return OrderWalaContext.tblLanguages.Where(lg => lg.LanguageId == LanguageId).FirstOrDefault().ToDTO();
            }
        }
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public List<tblLanguageDTO> GetAllLanguage()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblLanguages.ToList().ToDTOs();
            }
        }


       /// <summary>
       /// 
       /// </summary>
       /// <param name="LanguageId"></param>
       /// <returns></returns>
        public bool Languagedelete(int LanguageId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var Lang = OrderWalaContext.tblLanguages.Where(lg => lg.LanguageId == LanguageId).FirstOrDefault();
                OrderWalaContext.tblLanguages.Remove(Lang);
                if (OrderWalaContext.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}
