# Automatizirano skladište

## Sažetak 

Cilj ovog projekta je izraditi bazu podataka kojoj je glavni fokus na automatizaciju aktivnosti koje se trebaju odvijati kako bi se uspješno vodilo skladište proizvoda. Dakla, na neki način se želi smanjiti opseg poslova koje korisnik treba izvršiti kako bi upravljao podacima skladišta. Naziv teme je: "Aplikacija za vođenje statistike skladišta i planiranje zaliha (strategije upravljanja zalihama - minimalne/maksimalne količine, vremena između nabavki itd. - obavezna implementacija strategije upravljanja zalihama) - Aktivne + Temporalne baze podataka - PostgreSQL + Desktop grafičko sučelje sučelje po želji". Vrstu skladišta koje sam odabrao je skladište autodijelova. Korisnik aplikacije imat će uvid u neke aktivnosti koje su se odvijale nad skladištem i ti podaci biti će trajno spremljeni kako bi korisnik u svakom trenutku mogao imati ispis svih aktivnosti provedenih nad bazom kao što su povijest narudžbi i slično. Temporalni dio baze podataka upotpunit će i aktivne baze podataka koje će automatski provoditi neke od aktivnosti nad bazom koristeći okidače. Za izradu grafičkog sučelja koristio sam Visual Studio jer sam sa ovim alatom najviše upoznat, a baza podataka se sastoji od PostgreSQL-a te alati koje sam koristio su su pgAdmin4 i Navicat 15.



## Model baze podataka 

Na fotografiji ispod prikazan je model baze podataka **ERA** koji je korišten kako bi se izradila baza podataka, odnosno cjelokupna aplikacija. Za izradu modela korišten je alat Navicat 15 koji omogućava grafičko sučelje pri kreiranju baze.


![TBP_Project_ERA](https://user-images.githubusercontent.com/61590027/126403863-f651fecd-a12d-4b04-8d5f-654690993977.png)

Model se sastoji od 10 entiteta koji se koriste za uspješno vođenje skladišta autodijelova. 



**Autodijelovi** 

Predstavlja središte modela i u njoj se spremaju sve informacije vezano uz neki dio kao što su šifra pod kojom se vodi dio, naziv, minimalna količina, cijena i tako dalje. Prema tome, ova tablica sadrži jedinstveni brojačnu vrijednost {sifra} koja predstavlja jedan autodio. Atributi koji dodatno opisuju pojedini autodio su {naziv}, {narucena\_kolicina}, {minimalna\_kolicina}, {cijena}, {vrijedi\_od} i {ne\_vrijedi\_ od}. Tablica "Autodijelovi" sastoji se također od vanjskih ključeva koji su povezani sa tablicom {Auto}, {Vrsta}, {Proizvodac} i {Karakteristike}. 
Vrijednost atributa "{minimalna\_kolicina}" bitna je kod automatskog vođenja skladišta gdje se ova vrijedost uzima za usporedbu sa trenutnom količinom koja se nalazi na skladištu. U slučaju da trenutna količina skladišta padne ispod minimalne vrijednosti, automatski se naručuje novi proizvod. Ovu vrijednost korisnik unosi posebno za svaki automobil i to pri unosu automobila u bazu podataka.



**Proizvođač** 

U ovoj tablici spremaju se podaci o mogućim proizvođačima određenog prozivoda. Svaki autodio ima svog proizvođača. Kako bi znali identificirati jednog proizvođača od drugog koristimo vrijednost \bf{id}. Tablica "Proizvodac" sadrži {naziv} i {info} u kojem dodjeljujemo svakom proizvođaču određen opis prepoznatljiv za njegov brend.
 
 
 
**Auto**

Autodijelovi se proizvode po pricnipu gdje svaki dio ima svrhu za određenu marku automobila, odnosno propisano je koji dio je prikladan za koji automobil. Zbog toga imamo tablicu {Auto} pomoću koje dodatno opisujemo svaki autodio. Atribut "marka\_automobila" predstavlja naziv automobila za koji je namjenjen dio. 
 
 
 
**Vrsta**

Kako svaki autodio spada u neku određenu vrstu ili kategoriju moramo napraviti i tablicu "Vrsta" koja sadrži jedinstveni ključ {id} prema kojemu možemo identificirati o kojoj se vrsti autodijlova radi. Neke moguće vrste autodijelova su: {rasvjeta}, {karoserija}, {unutrašnjost}, {dodaci} i tako dalje. Svaka vrsta ima svoj opis koji korisniku daje uvid što pod koju vrstu spada. 
  
  
  
**Karakteristike** 

Sve ima svoje karakteristike, pa tako i autodijelovi, a neke osnovne karakteristike koje mogu biti  korisne kod kupovine autodijelova su njihove dimenzije pa tako tablica "Karakteristike" sadrži atribute poput {namjena}, {pakiranje}, {boja}, {duzina} i {sirina}. Svaka od karakteristika jedinstvena je po svom primarnom ključu {id}.
   

**Stanje na skladištu** 

Jedna od glavnih svojstva ove aplikacije je uvid u stanje skladišta pa radi toga možemo i pronaći ovu tablicu u ERA modelu. U ovoj tablici sprema se trenutna količina autodijelova na skladištu, kao i njihova pozicija u skladištu. Ovi su podaci zapisani u atributima {kolicina}, {red}, {dio}. Ova tablica se sastoji od primarnog, ali ujedno i vanjskog ključa na tablicu "Autodijelovi". Ovo je {nužno} zbog toga što se ne smije desiti da u skladištu postoje dva identična autodijela koji svaki za sebe ima određenu količinu ili različito mjesto skladištenja po atributu "red" i atributu "dio". Vanjski ključ "povijestNarudzba\_id" nam je potreban kako bi se upotpunio proces narudžbe proizvoda. Taj dio biti će objašnjen u kasnijim poglavljima. Atribut naziva "za\_sortiranje" slobodno zanemarimo, njega sam iskoristio kako bi dobio ljepši prikaz podataka u samoj aplikaciji.
 
 
 
**Informacije skladišta** 

Nakon svake izmjene u tablcii "Stanje\_Skladista" vodi se evidencija koja se zapisuje u tablicu "{Informacije\_Skladista}. Ova tablica se sastoji od osnovnih informacijama o proizvodu koji prolazi skladištem, a neki od podataka koji se bilježe u ovoj tablici su: {datum\_evidencije}, {stara\_kolicina}, {nova\_kolicina}, {autodijelovi\_id}, i {opis}. Svaka promjena u skladištu se bilježi automatski preko okidača i funkcije koja upisuje podatke u tablicu.
 
 
 
**Narudžba**

U ovoj tablici korisniku su vidljive sve aktivne narudžbe koje je kreirao on sam ili koje su automatski aktivirane preko okidača. Ukoliko zadana minimalna količina padne ispod trenutne količine na skladištu, automatski se dodaje nova nardužba. Korisnik također ima mogućnost unosa narudžbe u slučaju kada je to potrebno. Nakon što se naruči novi proizvod, taj podatak se bilježi u tablicu narudžba sa atributima kao što su datum\_narucivanja, kolicina\_narucivanja, opis te atributom narudzba\_zaprimljena. Ukoliko narudžba nije zaprimljena, količina na stanju skladišta se {ne} ažurira. Narudžba se može obaviti i prilikom unosa novog autodijela u bazu podataka preko tablice "Autodijelovi" stoga u je u tablici "Narudzba" potrebno referencirati vanjski ključ prema tablici "Autodijelovi". 
 
 
 
**Povijest narudžbi** 

Ova tablica ima funkciju bilježenja svih narudžbi koje su se izvršile nad bazom podataka. Narudžbe mogu imati {tri stanja}, a to su: "U obradi", "Da", "Ne". Stanje "U obradi" znači da je narudžba još uvijek u tijeku te da korisnik još uvijek nije dobio narudžbu na adresu. Ukoliko narudžba stigne na adresu tada korisnik potvrdi primitak narudžbe čime narudžba prelazi u stanje "Da". Ukoliko narudžba nije stigla na adresu u nekom očekivanom periodu vremena, korisnik potvrđuje da narudžba {nije} stigla te narudžba prelazi u stanje "Ne". Podaci koje tablica "PovijestNarudzbi" pohranjuje o svakoj narudžbi su datum naručivanja, datum primitka, količina naručivanja te opis narudžbe u kojoj se sprema podatak o tome tko je izvršio narudžbu, korisnik ili neka od okidačkih funkcija. 
  
  
  
**Popusti** 

U tablici popusti korisnik ima mogućnost postavljanja određnog proizvoda na popust. U ovoj tablici spremaju se podaci o trajanju popusta te koji je proizvod na popustu. Također, korisnik unosi podatak o novoj cijenu proizvoda koja se zapisuje u atribut {nova\_cijena}. Korisnik ima uvid u proizvode koji su trenutno na popustu, koji nisu na popustu te u sve popuste koji su ikad zabilježeni u bazi. 


# Implementacija

U izradi baze podataka koristio sam alat pgAdmin 4 i Navicat 15 koji su dosta jednostavni za korištenje. Samu bazu kreirao sam u alatu pgAdmin 4 i nakon toga sam se spojio preko alata Navicat 15 na kreiranu bazu podataka. Većinu vremena sam proveo koristeći alat Navicat 15 pri čemu sam upoznao njegove prednosti i mane. Preko njegovih funkcija moguće je kreirati tablice, povezati ih, unijeti podatke u tablice te kreirati razne funkcije i okidače. Tablice se mogu kreirati preko grafičkog sučelja bez pretjeranog tipkanja. Izrada funkcija u alatu Navicat 15 nije najbolja opcija ukoliko u različitim tablicama koristite ista imena određenih atributa, ovdje je često nastajo problem gdje Navicat pri unosu imena atributa nudi isti taj atribut, ali iz druge tablice, što rezultira funkcijom koja ne radi onako kako ste zamislili. Zbog toga sam funkcije pretežito kreirao u alatu pgAdmin 4. 

# Kreiranje tablica


## Proizvodač

 {id} - Primarni ključ ;
 {naziv} - Naziv proizvođača;
 {info} - Nešto više o proizvođaču;
    
      
       CREATE TABLE "public"."Proizvodac" (
       "id" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
       INCREMENT 1
      MINVALUE  1
       MAXVALUE 2147483647
        START 1
        ),
        "naziv" varchar(255) COLLATE "pg_catalog"."default",
        "info" text COLLATE "pg_catalog"."default",
        CONSTRAINT "Proizvodac_pkey" PRIMARY KEY ("id"));


## Auto 

 {id} - Primarni ključ;
 {marka\_automobila} - Naziv automobila;
    
        
        CREATE TABLE "public"."Auto" (
        "id" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
        INCREMENT 1
        MINVALUE  1
        MAXVALUE 2147483647
        START 1
        ),
        "marka_automobila" varchar(255) COLLATE     "pg_catalog"."default",
        CONSTRAINT "Auto_pkey" PRIMARY KEY ("id"));
        
        
## Vrsta

{id} - Primarni ključ;
{naziv} - Naziv automobila;
{info} - Nešto više o vrsti autodijelova;
        
        
        CREATE TABLE "public"."Vrsta" (
        "id" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
        INCREMENT 1
        MINVALUE  1
        MAXVALUE 2147483647
        START 1 
        ),
        "naziv" varchar(255) COLLATE "pg_catalog"."default",
        "info" text COLLATE "pg_catalog"."default", 
        CONSTRAINT "Vrsta_pkey" PRIMARY KEY ("id"));
        
        
## Karakteristike 

{id} - Primarni ključ;
 {namjena} - Opisuje za što je autodio namjenjen, koja mu je svrha;
{pakiranje} - Opis o pakiranju;
{boja} - Boja autodijela;
{duzina} - Dimenzija dužine(mm);
{sirina} - Dimenzija širine(mm);
        
        
        CREATE TABLE "public"."Karakteristike" (
        "id" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
        INCREMENT 1
        MINVALUE  1
        MAXVALUE 2147483647
        START 1
        ),
        "namjena" varchar(255) COLLATE "pg_catalog"."default",
        "pakiranje" varchar(255) COLLATE "pg_catalog"."default",
        "boja" varchar(255) COLLATE "pg_catalog"."default",
        "duzina" varchar(255) COLLATE "pg_catalog"."default",
        "sirina" varchar(255) COLLATE "pg_catalog"."default",
        CONSTRAINT "Karakteristike_pkey" PRIMARY KEY ("id"));
        
        
## Autodijelovi

{sifra} - Primarni ključ;
{naziv} - Naziv autodijela;
{narucena\_kolicina} - Količina koja se naručuje pri unosu novog dijela u bazu podataka; 
{minimalna\_kolicina} - Količina koja se unosi za svaki dio pojedinačno i predstavlja minimalnu količinu proizvoda na skladištu;
{cijena} - Cijena autodijela;
{vrijedi\_od} - Ovdje se sprema datum kada je neki autodio unesen u bazu podataka.     Označava da je proizvod u prodaji od određenog datuma;
{ne\_vrijedi\_od} - Ovdje se sprema datum kada neki autodio prestane biti u prodaji;
{karakteristike\_id} - Vanjski ključ na tablicu "Karakteristike";
{vrsta\_id} - Vanjski ključ na tablicu "Vrsta";
{proizvodac\_id} - Vanjski ključ na tablicu "Proizvodac";
{auto\_id} - Vanjski ključ na tablicu "Auto";

       
        CREATE TABLE "public"."Autodijelovi" (
        "sifra" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
        INCREMENT 1
        MINVALUE  1
        MAXVALUE 2147483647
        START 1
        ),
        "naziv" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
        "narucena_kolicina" int2 NOT NULL,  
       "minimalna_kolicina" int2 NOT NULL,
       "cijena" numeric,
        "karakteristike_id" int4,
       "vrsta_id" int4,
        "proizvodac_id" int4,
          "auto_id" int4,
       "vrijedi_od" timestamp(6),
       "ne_vrijedi_od" timestamp(6),
        CONSTRAINT "Autodijelovi_pkey" PRIMARY KEY ("sifra"),
        CONSTRAINT "vk_auto" FOREIGN KEY ("auto_id") REFERENCES "public"."Auto" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION,
        CONSTRAINT "vk_karakteristike" FOREIGN KEY ("karakteristike_id") REFERENCES "public"."Karakteristike" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION,
        CONSTRAINT "vk_proizvodac" FOREIGN KEY ("proizvodac_id") REFERENCES "public"."Proizvodac" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION,
        CONSTRAINT "vk_vrsta" FOREIGN KEY ("vrsta_id") REFERENCES "public"."Vrsta" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION);
        
        
## Stanje skladišta

{autodijelovi\_id} - Primarni i ujedno vanjski ključ na tablicu "Autodijelovi". Ni u jednom trenutku se ne može desiti da jedno te isti autodio bude spremljen na dva mjesta u skladištu.;
{kolicina} - Trenutna količina pojedinog autodijela na skladištu;
{red} - oznaka za lokacija autodijela u skladištu;
{dio} - oznaka za lokacija autodijela u skladištu;
{skladiste\_minimalna\_kolicina} - U slučaju da se želi promijeniti minimalna količina koju smo definirali za svaki proizvod na početku;
{povijestNarudzbi\_id} - Vanjski ključ na tablicu "PovijestNarudzbi". U slučaju da je narudžba provedena i zaprimljena, ažurira se količina u tablici "Stanje\_Skladista". U slučaju da narudžba nije zaprimljena količina u tablici "Stanje\_Skladista" ostaje nepromjenjena;

    
        
        CREATE TABLE "public"."Stanje_Skladista" (
        "autodijelovi_id" int4 NOT NULL,
        "kolicina" int4,
        "red" varchar(16) COLLATE "pg_catalog"."default", 
        "dio" int4,
        "povijestNarudzba_id" int4,
        "skladiste_minimalna_kolicina" int4,
        "za_sortiranje" int4 NOT NULL GENERATED ALWAYS AS        IDENTITY (
        INCREMENT 1
        MINVALUE  1
        MAXVALUE 2147483647
        START 1
        ),
        CONSTRAINT "Stanje_Skladista_pkey" PRIMARY KEY     ("autodijelovi_id"),
        CONSTRAINT "vk_autodijelovi" FOREIGN KEY ("autodijelovi_id") REFERENCES "public"."Autodijelovi" ("sifra") ON DELETE NO ACTION ON UPDATE NO ACTION,
        CONSTRAINT "vk_povijestNarudzbi" FOREIGN KEY ("povijestNarudzba_id") REFERENCES "public"."PovijestNarudzbi" ("id_povijestNarudzbi") ON DELETE NO ACTION ON UPDATE NO ACTION);
        
## Narudžba
        
{id\_narudzba} -Primarni ključ;
{datum\_narucivanja} - Datum kada je naručen autodio;
{kolicina\_narucivanja} - Koliko je autodijelova naručeno;
{opis} - Sadrži infomraciju o tome tko je narudžbu proveo. Narudžbu može provesti ili korisnik ili funkcija preko okidača;
{narudzba\_zaprimljena} - Sadrži podatak o stanju narudžbe. Narudžba može imati tri stanja: "O obradi", "Da", "Ne". Status "U obradi" znači da narudžba još nije stigla na odredište. Stanje "Da" znači da je narudžba stigla i da smo je preuzeli. Stanje "Ne" označava da narudžba nije stigla nakon očekivanog vremena.;
{stanje\_skladista\_id} - Vanjski ključ na tablicu "Stanje\_Skladista". Preko ovog ključa se odvijaju narudžbe koje doalze iz tablice "Stanje\_Skladista". Narudžbu može naručiti korisnik i okidačka funkcija.;
{narudzbaAutodijelova\_id} - Vanjski ključ na tablicu autodijelovi. Ova veza postoji jer se pri unosu autodijelova u bazu podataka automatski naručuje količina koja je unesena;

        
        CREATE TABLE "public"."Narudzba" (
        "id_narudzba" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
        INCREMENT 1
        MINVALUE  1
        MAXVALUE 2147483647
        START 1
        ),
        "datum_narucivanja" date,
        "kolicina_narucivanja" int4,
        "opis" varchar(255) COLLATE "pg_catalog"."default",
        "narudzbaAutodijelovi_id" int4,
        "narudzba_zaprimljena" varchar(255) COLLATE     "pg_catalog"."default",
        "stanje_skladista_id" int4,
        CONSTRAINT "Narudzba_pkey" PRIMARY KEY     ("id_narudzba"),
        CONSTRAINT "vk_autodijelovi" FOREIGN KEY ("narudzbaAutodijelovi_id") REFERENCES     "public"."Autodijelovi" ("sifra") ON DELETE NO ACTION ON UPDATE NO ACTION,
        CONSTRAINT "vk_stanje_skladista" FOREIGN KEY ("stanje_skladista_id") REFERENCES     "public"."Stanje_Skladista" ("autodijelovi_id") ON DELETE NO ACTION ON UPDATE NO ACTION);        


## Povijest narudžbi

{id\_povijestNarudzbi} - Primarni ključ;
{pdatum\_narucivanja} - Datum kada je proizvod naručen;
{pdatum\_primitka} - Datum koji predstavlja kada je autodio zaprimljen u skladište. Također predstavlja datum kada je korisnik označio da proizvod nije stigao na skladište čime se narudžba završava;
{pkolicina\_narucivanja} - Koliko je autodijelova naručeno;
{popis} - Sadrži informaciju o tome tko je narudžbu proveo. Narudžbu može provesti     ili korisnik ili funkcija preko okidača;
{pnarudzba\_zaprimljena} - Sadrži podatak o stanju narudžbe. Narudžba može imati tri stanja: "O obradi", "Da", "Ne". Status "U obradi" znači da narudžba još nije stigla na     odredište. Stanje "Da" znači da je narudžba stigla i da smo je preuzeli. Stanje "Ne"     označava da narudžba nije stigla nakon očekivanog vremena. ;
{pautodijelovi\_id} - Vanjski ključ na tablicu "Autodijelovi";
     
       
        CREATE TABLE "public"."PovijestNarudzbi" (
        "id_povijestNarudzbi" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
        INCREMENT 1
        MINVALUE  1
        MAXVALUE 2147483647
        START 1
        ),
        "pdatum_narucivanja" date,
        "pdatum_primitka" date,
        "pkolicina_narucivanja" int4,
        "popis" varchar(255) COLLATE "pg_catalog"."default",    
        "pnarudzba_zaprimljena" varchar(255) COLLATE     "pg_catalog"."default",
        "pautodijelovi_id" int4,
        CONSTRAINT "PovijestNarudzbi_pkey" PRIMARY KEY     ("id_povijestNarudzbi"),
        CONSTRAINT "vk_autodijelovi_Id" FOREIGN KEY ("pautodijelovi_id") REFERENCES "public"."Autodijelovi" ("sifra") ON DELETE NO ACTION ON UPDATE NO ACTION);
        
        
## Popusti
        
{id} - Primarni ključ;
{pocinje} - Datum početka popusta. Unosi ga korisnik.;
{zavrsava} -Datum završetka popusta. Unosi ga korisnik.;
{nova\_cijena} - Cijena proizvoda na popustu;    
{autodijelovi\_id} - Vanjski ključ na tablicu "Autodijelovi". Označava koji autodio je na popustu. ;
        
        
        CREATE TABLE "public"."PovijestNarudzbi" (
        "id_povijestNarudzbi" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
        INCREMENT 1
        MINVALUE  1
        MAXVALUE 2147483647
        START 1
        ),
        "pdatum_narucivanja" date,
        "pdatum_primitka" date,
        "pkolicina_narucivanja" int4,
        "popis" varchar(255) COLLATE "pg_catalog"."default",
        "pnarudzba_zaprimljena" varchar(255) COLLATE     "pg_catalog"."default",
        "pautodijelovi_id" int4,
        CONSTRAINT "PovijestNarudzbi_pkey" PRIMARY KEY     ("id_povijestNarudzbi"),
        CONSTRAINT "vk_autodijelovi_Id" FOREIGN KEY ("pautodijelovi_id") REFERENCES "public"."Autodijelovi" ("sifra") ON DELETE NO ACTION ON UPDATE NO ACTION);
        

## Informacije skladišta
        
{id} - Primarni ključ;
{datum\_evidencije} - Datum koji označava kada se desila neka promjena u skladištu;
{stara\_kolicina} - Predstavlja količinu koja je bila prije nego se dogodila neka     nova promjena u skladištu;
{nova\_kolicina} - Predstavlja trenutnu količinu na skladištu;
{opis} - Na ovo se mjesto unosi podatak o tome je li dodana nova količina, oduzeta količina ili je li dodan novi proizvod u skladište;
{autodijelovi\_id} - Vanjski ključ na tablicu "Autodijelovi". Preko ovog ključa znamo koji je proizvod izmjenjen u skladištu;
    
        \begin{lstlisting}[language=SQL]
        CREATE TABLE "public"."Karakteristike" (
        "id" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
        INCREMENT 1
        MINVALUE  1
        MAXVALUE 2147483647
        START 1
        ),
        "namjena" varchar(255) COLLATE "pg_catalog"."default",
        "pakiranje" varchar(255) COLLATE "pg_catalog"."default",
        "boja" varchar(255) COLLATE "pg_catalog"."default",
        "duzina" varchar(255) COLLATE "pg_catalog"."default",
        "sirina" varchar(255) COLLATE "pg_catalog"."default",
        CONSTRAINT "Karakteristike_pkey" PRIMARY KEY ("id"));
        
        
# Okidači i funkcije

Nakon kreiranja tablica slijedi kreiranje okidača. Okidači služe kako bi samom korisniku aplikacije olakšali rad sa podacima. Poželjno je automatizirati one dijelove koji ne zahtijevaju korisnikov unos podataka. To su najčešće neki rutinski poslovi. Kreirao sam par okidačkih funkcija koje su vezane za upravljanje narudžbama u skladištu te ću prikazati njihovu implementaciju.

## Opis funkcije "dodaj_dio_u_narudzbu"

Okidač koji nakon unosa novog autodijela u bazu poziva funkciju koja automatski naručuje uneseni autodio. Korisnik pri unosu određuje minimalnu količinu autodijelova te količinu naručivanja, naziv autodijela i ostale parametre. Funkcija ima zadaću unesti sve informacije vezano  za narudžbu u tablicu "Narudžba". U tablicu "Narudžba" funkcija unosi identifikacijski broj narudžbe, datum naručivanja, opis narudžbe te status narudžbe. 

### Okidač na funkciju "dodaj_dio_u_narudzbu"

    CREATE TRIGGER "okidac_dodaj_dio_u_narudzbu" AFTER INSERT ON "public"."Autodijelovi"
    FOR EACH ROW
    EXECUTE PROCEDURE "public"."dodaj_dio_u_narudzbu"();
    
    
    
### Funkcija "dodaj\_dio\_u\_narudzbu"}

    CREATE OR REPLACE FUNCTION "public"."dodaj_dio_u_narudzbu"()
    RETURNS "pg_catalog"."trigger" AS $BODY$
    BEGIN
    INSERT INTO "Narudzba"(id_narudzba, datum_narucivanja, kolicina_narucivanja , opis, "narudzbaAutodijelovi_id", narudzba_zaprimljena) VALUES(DEFAULT, CURRENT_DATE, new.narucena_kolicina,'Automatska narudžba', new.sifra, 'U obradi');
    RETURN NEW;

    END;
    $BODY$
    LANGUAGE plpgsql VOLATILE
    COST 100
    
    
## Opis funkcije "evidentiraj_promjene_PovijestNarudzbi"

Kada korisnik pritisne da je narudžba stigla na odredište promijeni se vrijednost atributa "U obradi" iz tablice "Narudžba" u vrijednost "Da". Nakon ažuriranja tablice "Narudžba", okidač poziva funkciju koja unosi podatke obrađene narudžbe u tablicu "PovijestNarudzbi". Ovisno o promjeni vrijednosti atributa "narudzba\_zaprimljena" iz tablice "Narudzba" izvršava se unos u tablicu "PovijestNarudzbi". Nakon unosa podataka u tablicu "PovijestNarudžbi" briše se trenutna narudžba iz tablice "Narudžba" jer nam taj podatak tamo više ne treba. 

### Okidač na funkciju "evidentiraj_promjene_PovijestNarudzbi"

    CREATE TRIGGER "okidac_evidentiraj_promjenePovijestNarudzbe" AFTER UPDATE ON "public"."Narudzba"
    FOR EACH ROW
    EXECUTE PROCEDURE "public"."evidentiraj_promjenePovijestNarudzbi"();
   
   
### Funkcija "evidentiraj_promjene_PovijestNarudzbi

    CREATE OR REPLACE FUNCTION "public"."evidentiraj_promjenePovijestNarudzbi"()
    RETURNS "pg_catalog"."trigger" AS $BODY$BEGIN
  	
	    IF old.narudzba_zaprimljena = 'U obradi' THEN
	        IF (new.narudzba_zaprimljena = 'Da') THEN
	            INSERT INTO "PovijestNarudzbi"("id_povijestNarudzbi", pdatum_narucivanja, pdatum_primitka, pkolicina_narucivanja, popis, pnarudzba_zaprimljena, pautodijelovi_id) VALUES
	            (DEFAULT, old.datum_narucivanja, CURRENT_DATE, old.kolicina_narucivanja , old.opis, 'Da', old."narudzbaAutodijelovi_id");
	        ELSE IF(new.narudzba_zaprimljena = 'Ne') THEN
	            INSERT INTO "PovijestNarudzbi"("id_povijestNarudzbi", pdatum_narucivanja, pdatum_primitka, pkolicina_narucivanja, popis, pnarudzba_zaprimljena, pautodijelovi_id) VALUES
	            (DEFAULT, old.datum_narucivanja, CURRENT_DATE,old.kolicina_narucivanja, old.opis, 'Ne', old."narudzbaAutodijelovi_id");
	        END IF;
	    END IF;
    END IF;
    DELETE FROM "Narudzba" where narudzba_zaprimljena = 'Da' OR narudzba_zaprimljena = 'Ne'; 
	RETURN NEW;
    END$BODY$
    LANGUAGE plpgsql VOLATILE
    COST 100  


## Opis funkcije "dodaj_narudzbu_iz_Stanje_Skladista"

Ova funkcija ima jednostavnu zadaću. Potrebno je svaki put nakon što se ažurira tablica "Stanje\_Skladista" usporediti trenutnu količinu autodijelova na skladištu sa minimalnom količinom autodijelova koju smo zadali. U slučaju da je trenutna količina autodijelova pala ispod minimalne razine tada se automatski naručuje nova količina autodijelova. Naručuje se količina jednaka minimalnoj količini dijelova za taj proizvod. 


### Okidač na funkciju "dodaj_narudzbu_iz_Stanje_Skladista"

        CREATE TRIGGER "okidac_dodaj_narudzbu" AFTER INSERT OR UPDATE ON "public"."Stanje_Skladista"
        FOR EACH ROW
        EXECUTE PROCEDURE "public"."dodaj_dio_u_narudzbu_iz_StanjeSkladista"();

### Funkcija "dodaj_narudzbu_iz_Stanje_Skladista"

    CREATE OR REPLACE FUNCTION "public"."dodaj_dio_u_narudzbu_iz_StanjeSkladista"()
    RETURNS "pg_catalog"."trigger" AS $BODY$BEGIN
	
    BEGIN
        IF(new.kolicina < new.skladiste_minimalna_kolicina) THEN
            INSERT INTO "Narudzba"(id_narudzba, datum_narucivanja, kolicina_narucivanja , opis, "narudzbaAutodijelovi_id", narudzba_zaprimljena) VALUES(DEFAULT, CURRENT_DATE, new.skladiste_minimalna_kolicina, 'Minimalna kolicina', new.autodijelovi_id , 'U obradi');
        END IF;
    RETURN NEW;
    END;
    END$BODY$
  	LANGUAGE plpgsql VOLATILE
 	 COST 100

# Aplikacija

Nakon kreiranja tablica baze podataka, okidača i funkcija potrebno je izraditi grafičko sučelje same aplikacije i implementirati određene funkcionalnosti kako bi aplikacija funkcionirala onako kako treba. Za izradu dizajna aplikacije koristit ćemo se jednostavnim C sharp form-ama na kojima će se nalaziti objekti u koje će korisnik moći upisivati podatke. Taj dio biti će objašnjen u sljedećem poglavlju. Spajanjem na bazu dobit ćemo mogućnost upravljanjem podacima baze podataka koristeći aplikaciju. Na taj način se olakšava korištenje baze podataka i obavljanja osnovnih operacija unosa, ažuriranja i brisanja podataka iz baze. Za početak potrebno je spojiti se na bazu podataka. 

## Povezivanje sa bazom

Kako bi se povezali sa bazom podataka koristimo {Npgsql} dodatak koji upravlja konekcijom između baze podataka i aplikacije. Na samom početku potrebno je kreirati klasu "Povezivanje\_na\_bazu.cs" pomoću koje ćemo uspostavljati konekciju sa bazom svaki put kada budemo trebali dohvatiti ili pohraniti podatke u bazu podataka. Unutar te klase se nalaze dvije osnovne funkcije, a to su funkcija "Spoji()" i funkcija "prekiniKonekciju()". Za uspostavljanje konekcije koristi ćemo Npgsql ( https://www.npgsql.org/doc/installation.html) dodatak. Kako bi uspostavili konekciju, potrebno je unesti odreeđene parametre kao što su server, port, korisnika, lozinku korisnika te naziv baze podataka. 

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404180-39d05204-6dba-469c-bd51-305d5326f43d.png">
</p>



## Učitavanje podataka iz baze

Kako bi učitali podatke koji su zapisani u bazi i prikazali ih u našoj aplikaciji, moramo zadati upit nad bazom. Upit koji je vidljiv sa slike dohvaća sve autodijelove iz baze podataka te prikazuje šifru autodijelova, naziv, naziv proizvođača, naziv autumobila za kojeg je dio namijenjen, vrstu autodijela, karakteristike poput namjene i pakiranja, cijene autodijelova, te podatak o tome je li proizvod u prodaji ili ne. Nakon što smo postavili željeni upit potrebno ga je provesti nad bazom i to izvršavamo pomoću funkcije {NpgsqlDataAdapter}. Funkciji prosljeđujemo željeni upit kao prvi parametar, a u drugi parametar unosimo konekciju nad bazom. Nakon što smo dohvatili podatke iz baze potrebno ih je pridružiti u određen "DataSet" pomoću kojeg dohvaćene podatke možemo isčitati, odnosno prikazati.

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404189-7ecf9a27-2d03-41ff-961c-3095d1ac7c0f.png">
</p>

## Unos novog podatka u bazu

U slučaju unosa autodijela u bazu potrebno je bazi dati sve potrebne informacije kako bi ona mogla taj podatak zapisati u željenu tablicu. Na slici ispod nalazi se primjer unosa novog popusta u tablicu "Popusti". Za početak potrebno je ostvariti konekciju sa bazom pomoću funkcije "database.Spoji();".Ta funkcija se nalazi u klasi koju smo kreirali u prvom koraku naše aplikacije. Nakon spajanja na bazu koristimo {INSERT INTO} naredbu za unos svih željenih vrijednosti u bazu podataka. Vrijednosti koje želimo unijeti u bazu su zapisane u varijablama "pocetni\_datum", "zavrsni\_datum", "txtCijena", "idOdabranog". Te vrijednosti je korisnik samostalno unio koristeći aplikaciju, gdje je pri odabiru autodijela koji će biti na popustu morao upisati novu cijenu, datum od kada vrijedi popust te datum do kada vrijedi popust. Nakon toga, izvršavamo naredbu nad bazom te na taj način unosimo podatke u bazu. Nakon unosa, prekidamo konekciju sa bazom pomoću naredbe "database.prekiniKonekciju();".

<p align="center">
  <img  src="https://user-images.githubusercontent.com/61590027/126404233-24de6948-f445-4226-aede-dd5b25dd6c1e.png">
</p>


## Ažuriranje i brisanje podataka

Ažuriranje baze se odvija na isti način kao i unos. Jedina razlika je u naredbi koja se provodi nad bazom podataka. Na slici ispod nalazi se naredba koja u tablici "Narudžba" ažurira onu narudžbu koju je korisnik odabrao. Nakon što je korisnik pritisnuo tipku "Zaprimljena narudžba" time je označio da je narudžba stigla u skladište. Nakon ažuriranja tablice "Narudžba" odaziva se okidač koji pokreće odgovarajuću funkciju te se proces narudžbe automatski nastavlja.

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404276-6ce135e1-4cfa-42e8-b9d6-cc775a323edc.png">
</p>


Brisanje se provodi na isti način kao i ažuriranje i unos u bazu osim razlike u korištenoj naredbi, "DELETE".

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404294-397c8ec8-5bcf-448a-8fe7-6e213af1e132.png">
</p>



# Primjeri korištenja

Nakon završetka implementacije dobili smo finalnu aplikaciju koja ima mogućnosti upravljanja podacima iz baze podataka. U poglavljima iznad objašnjene su neke osnove operacije nad bazom kao što su unosi, ažuriranja i brisanja. Nakon objašnjenog programskog dijela slijedi objašnjavanje svih mogućnosti koje aplikacija ima. Dakle, u ovom poglavlju biti će objašnjene sve forme sa kojima se korisnik može susresti u radu sa aplikacijom. Biti će objašnjeno kada se koja forma pojavljuje, što se u koju formu unosi, čemu određena forma služi i tako dalje. 


## Glavni izbornik

Nakon pokretanja programa pomoću tipke "F5" otvara se početna forma koja predstavlja glavni izbornik aplikacije. Korisnik u ovoj formi nema puno mogućnosti te ova forma služi isključivo za pristup drugim formama. Dakle, korisnik može pristupiti formi {Autodijelovi}, {Trenutno stanje}, {Popusti proizvoda}, {Narudžbe}, {Povijest evidencije skladišta} i formi {Povijest narudžbi autodijelova}. Dakle, klikon na neku od ponuđenih opcija otvara se nova forma.!

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404927-57adc34d-55f6-44f9-a6d1-bb63e8e2e95c.png">
</p>


## Autodijelovi

Nakon što smo u formi "Glavni izbornik" kliknuli na tipku "Autodijelovi" otvara se forma koja je vidljiva na slici ispod. U ovoj formi korisniku je omogućen uvid u sve autodijelove koji su zapisani u bazi podataka. Autodijelovi se prikazuju u data grid pogledu, odnosno tablici. Tablica se sastoji od stupaca koji pobliže opisuju svaki autodio koji je zapisan u bazu. Svaki autodio ima svoju identifikaciju a to je prvi stupac naziva "Šifra". Također, svaki autodio ima i ostale karakteristike poput kojoj marki automobila dio pripada, naziv, proizvođač autodijela, je li autodio u prodaji i tako dalje. Korisnik ima mogućnost odabira određenog autodijela te mu promijeniti vrijednost stupca "U prodaji" i stupca "Nije u prodaji". Isti proizvod ne može imati u isto vrijeme i vrijednost "U prodaji" i vrijednost "Nije u prodaji". 

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404461-176c5291-f7ec-45b2-b2ea-6f018b559d05.png">
</p>


 Kako bi se korisnik lakše snalazio sa sveukupnim podacima omogućeno mu je filtriranje autodijelova po određenim parametrima kao što su vrsta autodijela, proizvođač, te kojoj je marki automobila dio namjenjen. Također, korisnik može autodio pretražiti po imenu autodijela gdje korisnik upisuje naziv autodijela i dobiva filtirani rezultat svih onih dijelova kojima se ima poklapa sa korisnikovim upisom. 
 Ako na primjer korisnik želi pretražiti sve autodijelove kojima je proizvođač "Bottari" klikom na izbornik izlastava se popis svih proizvođača koji su dostupni iz baze podataka, te odabire traženi naziv, "Bottari", pri čemu se redovi u tablici autodijelova filtiraju. 

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404484-1fe5584a-034e-4f15-97bc-60986d9190a0.png">
</p>



Ukoliko korisnik pritisne na tipku "Dodaj novi dio u bazu" koja se vidi na Slici 8, tada se otvara novi prozor u kojem korisnik ima mogućnost dodati novi proizvod u bazu podataka pri čemu je potrebno unesti određene parametre za svaki autodio. Kako bi unos bio još lakši, kada korisnik krene pisati naziv vrste autodijela, proizvođača i marke automobila, automatski mu se ponude već one vrste, proizvođači i marke automobila koji su već zapisani u bazi podataka.

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404524-090af612-0bf3-44be-9291-a5757541434c.png">
</p>


Nakon klika na tipku "Dodaj novi dio u bazu"(Slika 10) zapis se unosi u bazu podataka te u obliku iskočnog prozora ispisuje se informacija o uspješnom unosu. Ukoliko proizvođač ili vrsta ili marka automobila kojeg je korisnik unio ne postoji zapisan u bazi podataka, korisniku se prikazuje prozor koji je vidljiv na slici 11. Korisnik u tom trenutku ima opciju unosa novog proizvođača u bazu ili opciju "Izađi" pri kojoj se novi zapis {ne dodaje u bazu}.

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404543-561ea2f1-e1ea-412e-9430-f5392112364b.png">
</p>


# Narudžba

U ovoj formi (slika 12) korisniku je omogućen prikaz svih narudžbi koje do sada nisu obrađene. Ove narudžbe su vidljive u prvoj tablici sa slike 12. One mogu imati tri statusa, a to su "U obradi", "Da" i status "Ne" pri čemu status "U obradi" označava da narudžba još nije stigla na odredište. U slučaju da je narudžba fizički stigla na odrediše tada korisnik pritišće tipku "Narudžba stigla" i time narudžba mijenja svoj status u "Da", te u slučaju da narudžba nije stigla u očekivanom vremenu, korisnik pritišće tipku "Narudžba nije stigla" te se time postavlja status odabrane narudžbe na "Ne". Autodio se može naručiti na dva načina:

1. način: Narudžba se izrađuje odmah pri unosu novog autodijela u bazu podataka

2. način: Narudžba se izrađuje onda kada trenutna količina dijelova padne ispod zadane minimalne količine autodijelova

Nakon što korisnik potvrdi primitak/ne primitak narudžbe, tada se odazove okidač koji poziva odgovarajuću funkciju koja sprema podatke u tablicu "PovijestNarudžbi". Povijest svih narudžbi mogu se vidjeti odmah u drugoj tablici, a podaci koji se spremaju su datum stvaranja narudžbe,  datum primitka proizvoda, koja je količina naručena i tako dalje. 

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404580-42683dfc-f861-4776-840c-723ae9192a35.png">
</p>


# Stanje skladišta

Nakon narudžbi autodijelova, podaci se spremaju u tablicu "Stanje\_Skladista", a podaci iz te tablice mogu se vidjeti u tablici sa slike 13. U ovoj tablici vidljivi su svi oni autodijelovi koji su trenutno dostupni u nekoj količini u skladištu. Tablica prikazuje osnovne informacije o autodijelovima kao što su trenutna količina autodijelova na skladištu, minimalna količina, te njihovu poziciju unutar skladišta, koja je zabilježena pomoću podatka o redu i dijelu na kojem se skladišti proizvod. Korisniku se daje na mogućnost brisanja određene stavke iz skladišta, te isto tako i unos nove stavke u stanje skladišta. 
Ukoliko korisnik želi unijeti novi autodio u skladište, prvo mora odabrati koji točno proizvod želi unijeti. Svi autodijelovi koji su zapisani u bazi podataka su vidljivi iz padajućeg izbornika. Dakle, nakon što korisnik pritisne na padajući izbornik, odabire proizvod koji želi unijeti, određuje mu lokaciju sa parametrima "Red" i "Dio" i pritišće gumb "Evidentiraj u skladište". Nakon toga, automatski se stvara nova narudžba koja će biti vidljiva u aplikaciji. Korisnik ima mogućnost ažuriranja trenutne količine odabranog autodijela. Novu količinu može unijeti u polje iza opisa "Količina nakon prodaje". Nakon unosa, količina se ažurira. 

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404608-c8866ee1-a33c-4c33-b9cc-3fcb2124c976.png">
</p>


# Evidencija skladišta

Dakle, sve promjene u skladištu bilježe se u posebnu tablicu "Informacije\_skladišta". U aplikaciji je prikaz povijesti skladišta dostupan nakon klika na tipku "Povijest evidencije skladišta". Prikaz povijesti stanj skladišta vidljiv je na slici 14. Korisnik u ovoj tablici ima prikaz svih promjena koje su se dešavale u skladištu. 

Mi ćemo za primjer objašnjavanja uzeti prva dva reda tablice te pomoću njih objasniti kako povijest funkcionira. Dakle,  gledamo red u kojemu je vrijednost "ID" stupca jednaka 296. Ako pogledamo staru i novu količinu tog autodijela, primjetit ćemo da ona iznosi 0 i to nam govori da taj dio još nikada nije bio zabilježen u stanju skladišta, odnosno to nam govori da je taj autodio {novi} zapis autodijelova u bazi podataka. Prisjetimo se kako funkcionira dodavanje novog zapisa. U prvom koraku upisujemo parametre za određeni autodio, parametri su naziv, vrsta proizvoda, proizvođač, cijena, minimalna količina i tako dalje. Nakon što smo potvrdili unos, automatski se stvara narudžba novounesenog autodijela. Nakon što je korisnik potvrdio {primitak} narudžbe, autodio se sprema u stanje skladišta. Ako pogledamo prvi redak(ID=297) tablice sa slike 14, primjetit ćemo da je vrijednost "Stara količina" = 0 i vrijednost "Nova količina" = 10. Ovaj podatak nam govori da je autodio zabilježen u trenutnom stanju skladišta i time mu se pripisuje opis "dodan je dio u skladište." Ukoliko se količina autodijelova smanji, podatak će se bilježiti u povijest evidencije skladišta sa opisom "Oduzeta je količina sa skladišta". Dakle, tablica je vrlo jednostavna i pruža nam sve informacije vezane za promjene u skladištu. 

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404667-07a5bb03-5b94-494f-a4ff-f0b5a2ea98e5.png">
</p>

# Povijest narudžbi

U ovom prozoru (slika 15) korisniku je omogućen prikaz u povijest svih narudžbi koje su se provele u skladištu autodijelova. Ova forma pokazuje podatke temeljen na istom principu kao i u prethodno objašnjenom poglavlju "Evidencija skladišta". 

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404702-361f11ba-119b-4f8d-bda8-7e2d5dc2dab4.png">
</p>


# Popusti 

Ukoliko korisnik želi odrediti koji će proizvod bit na popustu u tome će mu pomoću sljedeći prozor(slika 16). U ovoj formi korisnik ima prikaz svih autodijelova koji su trenutno zabilježeni u bazi podataka. Ima mogućnost odabira pojedinog autodijela te mu se nudi mogućnost odabira početnog datuma popusta i završnnog datuma popusta. Nakon toga, sve što treba je unijeti novu popust cijenu i potvrditi unos. Novi unos biti će mu prikazan u drugoj tablici na istoj formi. Kako bi se lakše snašao u hrpi podataka, nudi mu se opcija filtriranja proizvoda po kriterijima "Na popustu", "Nije na popustu" i po kriteriju "Prikaži sve". Također, u slučaju krivo unesenog popusta, može obrisati određenu stavku tipkom "Obriši".

<p align="center">
  <img src="https://user-images.githubusercontent.com/61590027/126404737-3c5608c9-ef96-40ce-8760-413da8a40f65.png">
</p>


# Zaključak

Cijeli proces od postavljanje servera i izrade baze, pa do programiranja samog sučelja aplikacije bio je vrlo zanimljiv i koristan. Cilj je bio izraditi bazu podataka koja će imati karakeristike aktivnih i temporalnih baza podataka. Savršen primjer za izradu takvih baza su skladišta određenih proizvoda, u ovom slučaju autodijelova. U izradi baze podatak bili su korišteni i temporalni elementi baze podataka isto kao i aktivni komponenti. Za temporalne baze podataka specifična je prisutnost vremenske komponente koja se dijeli na stvarno vrijeme i transakcijsko vrijeme. Stvarno vrijeme označava "vremenski žig" nekog događaja dok tansakcijsko vrijeme predstavlja interval između neka dva događaja. Temporalni dio baza podataka je u ovom primjeru pretežito bio korišten u nekakvoj okolini koja je pohranjivala podatke o "povijesti" izvođena pojedine aktivnosti. Također, kod određivanja trajanja popusta za određen autodio prisutna je i vremenska komponenta "budućnosti", odnosno korisnik ima mogućnost odabira trajanja popusta koji će biti za npr. mjesec dana. Aktivne baze podataka su veoma korisne i mislim da je u današnje vrijeme rijetkost da baze podataka {ne} koriste aktivnu komponentu, odnosno okidače i okidačke funkcije. One uvelike olakšavaju održavanje baze podataka, pri čemu se štedi vrijeme, ali i čuva preciznost, odnosno smanjuje se mogućnost pogreške zbog toga što računalo izvšrava određene funkcije, a ne čovjek. 

