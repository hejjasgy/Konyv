using System;

namespace Osztal_Konyv.Exceptions{
    public class HibasIsbnSzamException:Exception{
        
        private String konyvCim;
        private String isbnSzam;
        
        public string KonyvCim{
            get{return this.konyvCim;}
            set{this.konyvCim = value;}
        }
        
        public string IsbnSzam{
            get{return this.isbnSzam;}
            set{this.isbnSzam = value;}
        }

        public HibasIsbnSzamException(String konyvCim, String isbnSzam){
            this.KonyvCim = konyvCim;
            this.IsbnSzam = isbnSzam;

            this.Message = "Hiba történt a(z) " + (Program.bekertKonyvek+1) + " könyvnél (" + this.KonyvCim + "): a megadott ISBN szám érvénytelen: " + this.IsbnSzam;

        }


        public override string Message{get;}
    }
}