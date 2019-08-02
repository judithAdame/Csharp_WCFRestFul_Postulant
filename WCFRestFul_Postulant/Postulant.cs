using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFRestFul_Postulant
{
    [DataContract]
    public class Postulant
    {
        private string nom;
        private string courriel;
        private string langages;

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nom
        {
            get
            {
                return nom.Trim();
            }
            set
            {
                nom = value.Trim();
            }
        }
        [DataMember]
        public string Courriel
        {
            get
            {
                return courriel.Trim();
            }
            set
            {
                courriel = value.Trim();
            }
        }
        [DataMember]
        public string Langages
        {
            get
            {
                return langages.Trim();
            }
            set
            {
                langages = value.Trim();
            }
        }

        public Postulant(string nom, string courriel, string langages)
        {
            Nom = nom;
            Courriel = courriel;
            Langages = langages;
        }
        public Postulant()        {        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool IsMatch(int nbMath, string postes) {
            int i = 0;
            List<string> lPostes= StringtoList(postes);
            List<string> lPostulants = StringtoList(Langages);
            nbMath = ValiderNbMatch(nbMath, lPostulants.Count(), lPostes.Count());
            if (nbMath == -1)
                return false;
            foreach (string lpostulant in lPostulants)
            {
                string lpostulant2 = lpostulant.ToUpper().Trim();
                foreach (string lposte in lPostes)
                {
                    string lposte2 = lposte.ToUpper().Trim();
                    if (lposte2.Equals(lpostulant2))
                    {
                        i++;
                    }
                }
            }
            return ((i >= nbMath));
        }
        private List<string> StringtoList(string str)
        {
            return str.Split(',').ToList();
        }

        private int ValiderNbMatch(int nb, int nbPostulants, int nbPoste)
        {
            int nbValide = -1;
            if (nb < 0)
            {
                nbValide = -1;
            }
            else if (nb > nbPoste)
            {
                nbValide = nbPoste;
            }
            else if (nb > nbPostulants)
            {
                nbValide = -1;
            }
            else
                nbValide = nb;
            return nbValide;
        }
    }
}