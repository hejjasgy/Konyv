using System;
using System.Collections.Generic;
using System.IO;

namespace Osztal_Konyv{
    internal class Program{
        private static List<Konyv> konyvekList = new List<Konyv>();
        private static List<String> exceptionList = new List<String>();
        public static int bekertKonyvek = 0;

        public static void Main(string[] args){
            
            //Konyv osztály
            //isbnSzam
            //szerzo_k
            //muCime
            //kiadasiEv
            //nyelv
            //enciklopedia - Boolean
            //ebook - i/n

            while (true){
                String isbn = isbnBekeres();
                if (String.IsNullOrEmpty(isbn)) break;
                
                String szerzo = szerzoBekeres();

                String cim = cimBekeres();

                int kiadasiEv = evBekeres();

                String nyelv = nyelvBekeres();

                
                Boolean enciklopedia = enciklopediaBekeres();

                char ebook = ebookBekeres();

                try{
                    konyvekList.Add(new Konyv(isbn, szerzo, cim, kiadasiEv, nyelv, enciklopedia, ebook));

                }catch(Exception e){
                    exceptionList.Add(e.Message);
                }
                bekertKonyvek++;
            }
           
            File.WriteAllLines("hibak.txt", exceptionList);
            
        }

        static String isbnBekeres(){
            
            while (true){
                try{
                    Console.Write("ISBN szám: ");
                    String isbn = Console.ReadLine();

                    foreach(char t in isbn){
                        if(!Char.IsDigit(t)){
                            throw new Exception("Az ISBN számok nem tartalmazhatnak nem számokat!");
                        }
                    }
                    
                    return isbn;
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
           
        }    
        
        static String szerzoBekeres(){
            while (true){
                try{
                    Console.Write("Szerző: ");
                    String szerzo = Console.ReadLine();
                    if(String.IsNullOrEmpty(szerzo)){
                        throw new Exception("Nincs olyan, hogy nincs szerző, ha a szerző ismeretlen, add meg azt értéknek!");
                    }
                    return szerzo;
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
        }     
        
        static String cimBekeres(){
            while (true){
                try{
                    Console.Write("Cím: ");
                    String cim = Console.ReadLine();
                    if(String.IsNullOrEmpty(cim)){
                        throw new Exception("Nem hiányozhat a könyv címe, hiszen mindegyiknek van!");
                    }
                    return cim;
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
        }   
        
        static int evBekeres(){
            while (true){
                try{
                    Console.Write("Kiadási év: ");
                    return Int32.Parse(Console.ReadLine());
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
        }  
        
        static String nyelvBekeres(){
            while (true){
                try{
                    Console.Write("Nyelv: ");
                    String nyelv = Console.ReadLine();
                    if(String.IsNullOrEmpty(nyelv)){
                        throw new Exception("Egy nyelven csak meg kellett íródnia a könyvnek. Miért nem adod meg azt?");
                    }
                    return nyelv;
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
        }     
        
        static Boolean enciklopediaBekeres(){
            while (true){
                try{
                    Console.Write("Enciklopédia (i/n): ");
                    String enciklopedia = Console.ReadLine().ToLower();
                    if(enciklopedia.Equals("i") || enciklopedia.Equals("n")){
                        return enciklopedia.Equals("i");
                    }
                    throw new Exception("Az elfogadott értékek: \"i\" - mint igen, \"n\" - mint nem");

                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
        }  
        
        static char ebookBekeres(){
            while (true){
                try{
                    Console.Write("E-book (i/n): ");
                    String ebook = Console.ReadLine().ToLower();
                    if(ebook.Equals("i") || ebook.Equals("n")){
                        return ebook[0];
                    }
                    throw new Exception("Az elfogadott értékek: \"i\" - mint igen, \"n\" - mint nem");
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
        }
       
    }
}