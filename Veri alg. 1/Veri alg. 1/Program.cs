using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_alg._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            liste tekyonbaglıListe = new liste();
            int seçim = menu();
            int sayi;
            int indis;
            while (seçim != 0)
            {
                switch (seçim)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Sayı Giriniz: ");
                        sayi = int.Parse(Console.ReadLine());
                        tekyonbaglıListe.basaEkle(sayi);
                        break;
                    case 2:
                        Console.WriteLine("Sayı Giriniz:");
                        sayi = int.Parse(Console.ReadLine());
                        tekyonbaglıListe.sonaEkle(sayi);
                        break;
                    case 3:
                        Console.WriteLine("İndis giriniz");
                        indis = int.Parse(Console.ReadLine());
                        Console.WriteLine("Sayı giriniz:");

                        sayi = int.Parse(Console.ReadLine());
                        tekyonbaglıListe.arayaEkle(indis, sayi);
                        break;
                    case 4:
                        Console.WriteLine("İndisini bulmak istediğiniz sayıyı giriniz:");
                        sayi = int.Parse(Console.ReadLine());
                        tekyonbaglıListe.sayiIndisBul(sayi);
                        break;
                    case 5:
                        tekyonbaglıListe.bastanSil();
                        break;
                    case 6:
                        tekyonbaglıListe.sondanSil();
                        break;
                    case 7:
                        Console.WriteLine("İndis giriniz:");
                        indis= int.Parse(Console.ReadLine());
                        tekyonbaglıListe.aradanSil(indis);
                        break;
                    case 8:
                        tekyonbaglıListe.elemanSayisi();
                        break;
                }
                tekyonbaglıListe.yazdir();
                seçim = menu();
            }

        }

        private static int menu()
        {
            int seçim;
            Console.WriteLine("Seçiminizi yapınız:");
            Console.WriteLine("1-Başa Ekle");
            Console.WriteLine("2-Sona Ekle");
            Console.WriteLine("3-Araya Ekleme");
            Console.WriteLine("4-Sayının İndisini Bulma");
            Console.WriteLine("5-Baştan sil");
            Console.WriteLine("6-Sondan sil");
            Console.WriteLine("7-Aradan sil");
            Console.WriteLine("8-Eleman Sayısı");
            Console.WriteLine("0-Çıkış");
            seçim = int.Parse(Console.ReadLine());
            return seçim;
        }
    }

    class node
    {
        public int data;
        public node next;

        public node(int d)
        {
            data = d;
            next = null;
        }
    }

    class liste
    {
        node head;
        public liste()
        {
            head = null;
        }

        public void basaEkle(int d)
        {
            node eleman = new node(d);
            if (head == null)
            {
                head = eleman;
                Console.WriteLine("Liste Oluşturuldu ve ilk düğüüm eklendi");
            }
            else if (head != null)
            {
                eleman.next = head;
                head = eleman;
                Console.WriteLine("Başa Düğüm Eklendi");
            }

        }
        public void sonaEkle(int d)
        {
            node eleman = new node(d);

            if (head == null)
            {
                head = eleman;
                Console.WriteLine("Liste Oluşturuldu ve ilk Düğüm Eklendi");
            }
            else
            {
                node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;

                }
                temp.next = eleman;
            }
        }
        public void arayaEkle(int indis, int d)
        {
            node eleman = new node(d);
            bool islemgerceklestimi = false;
            if (head == null && indis == 0)
            {
                head = eleman;
                Console.WriteLine("Liste oluşturuldu ve İlk Düğüm Eklendi");
                islemgerceklestimi = true;
            }
            else if (head == null && indis != 0)
            {
                Console.WriteLine("Hatalı indis seçimi");
            }
            else if (head != null && indis == 0)
            {
                basaEkle(d);
                Console.WriteLine("Listenin Başa düğüm eklendi");
                islemgerceklestimi = true;
            }
            else
            {
                int i = 0;
                node temp = head;
                node tempinoncesi = temp;
                while (temp.next != null)
                {
                    if (i == indis)
                    {
                        tempinoncesi.next = eleman;
                        islemgerceklestimi = true;
                        eleman.next = temp;
                        i++;
                        Console.WriteLine("Listenin" + i + ".indisine düğüm eklendi.");
                        break;
                    }
                    tempinoncesi = temp;
                    temp = temp.next;
                    i++;
                }
                if (i == indis)
                {
                    tempinoncesi.next = eleman;
                    islemgerceklestimi = true;
                    eleman.next = temp;
                }
                if (temp.next == null && i + 1 == indis)
                {
                    sonaEkle(d);
                    islemgerceklestimi = true;
                }
                if (islemgerceklestimi == false)
                {
                    Console.WriteLine("Hatalı indis seçimi yaptınız !!!!!!");
                }
            }
        }
        public void bastanSil()
        {
            if(head== null)
            {
                Console.WriteLine("Liste Boş.");
            }
            else if (head.next == null)
            {
                head = null;
                Console.WriteLine("Listedeki son düğüm silindi.");
            }
            else
            {
                head = head.next;
                Console.WriteLine("Baştaki düğüm silindi.");
            }
        }
        public void sondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste Boş.");
            }
            else if (head.next==null)
            {
                head = null;
                Console.WriteLine("Listedeki son düğüm silindi.");
            }
            else
            {
                node temp = head;
                node tempinoncesi=temp;
                while (temp.next != null)
                {
                    tempinoncesi= temp;
                    temp = temp.next;
                }
                tempinoncesi.next = null;
                Console.WriteLine("Son düğüm silindi.");
                
            }
        }
        public void aradanSil (int indis)
        {
            bool islemgerceklestimi = false;
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
            }
            else if(head.next == null && indis==0)
            {
                islemgerceklestimi = true;
                head = null;
                Console.WriteLine("Son düğüm silindi.");
            }
            else if( head.next != null && indis==0)
            {
                islemgerceklestimi= true;
                bastanSil();
            } 
            else if (head.next==null && indis != 0)
            {
                Console.WriteLine("Hatalı indis seçimi.");
            }
            else
            {
                int sayac = 0;
                node temp= head;
                node tempinoncesi = temp;
                while (temp.next != null)
                {
                    if( sayac==indis )
                    {
                        islemgerceklestimi = true;
                        tempinoncesi.next = temp.next;
                        Console.WriteLine(indis +". indisteki düğüm silindi.");
                        sayac++;
                        break;
                    }
                    tempinoncesi = temp;
                    temp = temp.next;
                    sayac++;
                }
                if ( sayac==indis )
                {
                    islemgerceklestimi = true;
                    tempinoncesi.next = null;
                    Console.WriteLine("Sondaki düğüm silindi.");
                    sayac++;
                }
            }
            if (islemgerceklestimi = false)
            {
                Console.WriteLine("Hatalı indis seçimi.");
            }
        }
        public void elemanSayisi()
        {
            int sayac = 0;
            node temp = head;
            if(head==null)
            {
                Console.WriteLine("Liste boş.");
            }
            else
            {
                while (temp.next != null)
                {
                    temp = temp.next;
                    sayac++;
                }
                Console.WriteLine("Listedeki eleman sayısı" + sayac + 1);
            }

        }
        public void sayiIndisBul(int d)
        {
            int i = 0;
            node temp = head;


            if (head == null)
            {
                Console.WriteLine("Liste Boştur.");
                return;
            }


            while (temp != null)
            {

                if (temp.data == d)
                {
                    Console.WriteLine(d + " sayısının indisi: " + i);
                    return;
                }
                temp = temp.next;
                i++;
            }

            Console.WriteLine(d + " sayısı listede bulunamadı.");
        }
        public void yazdir()
        {
            node temp = head;
            if (head == null)
            {
                Console.WriteLine("Liste Boştur");
            }
            else
            {
                Console.Write("Baş -> ");
                while (temp.next != null)
                {

                    Console.Write(temp.data + " ->");
                    temp = temp.next;
                }
                Console.WriteLine(temp.data + " -> Bitti");
            }

        }
        
    }   
}
