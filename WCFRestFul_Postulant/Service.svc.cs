using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WCFRestFul_Postulant
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        public void Add(Postulant postulant) => PostulantDAO.Add(postulant);

        public int Count()
        {
            return GetAll().Count();
        }

        public void Delete(string id)
        {
            PostulantDAO.Delete(id);
        }

        public List<Postulant> GetAll()
        {
            return PostulantDAO.GetAll();
        }

        public Postulant GetById(string id)
        {
            return PostulantDAO.GetById(id);
        }

        public List<Postulant> GetByLangages(string nb, string lPostes)
        {
            if (!Int32.TryParse(nb, out int nbMatch))
                return null;
            return PostulantDAO.GetByLangages(nbMatch, lPostes);
        }

        public void Update(string id, Postulant postulant)
        {
            PostulantDAO.Update(id, postulant);
        }
    }
}
