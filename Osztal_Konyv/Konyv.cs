using System;
using Osztal_Konyv.Exceptions;

namespace Osztal_Konyv{
    public class Konyv{
        public String isbnSzam;
        public String szerzo;
        public String cim;
        public int kiadasEve;
        public String nyelv;
        public Boolean enciklopedia;
        public char ebook;

        public String IsbnSzam{
            get{return this.isbnSzam;}
            set{this.isbnSzam = value;}
        }

        public String Szerzo{
            get{return this.szerzo;}
            set{this.szerzo = value;}
        }

        public String Cim{
            get{return this.cim;}
            set{this.cim = value;}
        }

        public int KiadasEve{
            get{return this.kiadasEve;}
            set{this.kiadasEve = value;}
        }

        public String Nyelv{
            get{return this.nyelv;}
            set{this.nyelv = value;}
        }

        public Boolean Enciklopedia{
            get{return this.enciklopedia;}
            set{this.enciklopedia = value;}
        }

        public char Ebook{
            get{return this.ebook;}
            set{this.ebook = value;}
        }

        public Konyv(){

        }

        public Konyv(String isbnSzam, String szerzo, String cim, int kiadasEve, String nyelv, Boolean enciklopedia, char ebook){
            this.IsbnSzam = isbnSzam;
            this.Szerzo = szerzo;
            this.Cim = cim;
            this.KiadasEve = kiadasEve;
            this.Nyelv = nyelv;
            this.Enciklopedia = enciklopedia;
            this.Ebook = ebook;

            if(!isIsbnValid()){
                throw new HibasIsbnSzamException(cim, this.isbnSzam);
            }
        }

        ~Konyv(){ //destruktor <--> kontstruktor
            Console.WriteLine("Az objektum felszabadítva");
        }

        public Boolean isIsbnValid(){
            if(this.IsbnSzam.Length==10){
                
                int sumElso = 0;
                for (int i = 0; i < this.IsbnSzam.Length; i++){
                    sumElso += (i + 1) * Int32.Parse(this.IsbnSzam[i].ToString());
                }

                if (sumElso % 11 == 0){
                    Console.WriteLine("Az ISBN szám érvényes (az első módszerrel ellenőrizve).");
                }else{
                    Console.WriteLine("Az ISBN szám érvénytelen (az első módszerrel ellenőrizve).");
                }
                
                
                int sum = 0;
                for(int i = 0; i < 9; i++){
                    int digit = Int32.Parse(this.IsbnSzam[i].ToString());
                    sum += digit * (10 - i);
                }

                char lastChar = this.IsbnSzam[9];
                int lastDigit = Int32.Parse(lastChar.ToString());
                sum += lastDigit;
                return sum % 11==0;
            }
            
            if(this.IsbnSzam.Length==13){
                int sum = 0;
                for(int i = 0; i < 12; i++){
                    int digit = Int32.Parse(this.IsbnSzam[i].ToString());
                    sum += i % 2==0?digit * 1:digit * 3;
                }
                int checkDigit = Int32.Parse(this.IsbnSzam[12].ToString());
                int calculatedCheckDigit = 10 - (sum % 10);
                if(calculatedCheckDigit==10){
                    calculatedCheckDigit = 0;
                }
                return checkDigit==calculatedCheckDigit;
            }

            return false;
        }
    }
}