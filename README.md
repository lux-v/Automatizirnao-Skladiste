# Automatizirnao-Skladiste

## Sažetak 

Cilj ovog projekta je izraditi bazu podataka kojoj je glavni fokus na automatizaciju aktivnosti koje se trebaju odvijati kako bi se uspješno vodilo skladište proizvoda. Dakla, na neki način se želi smanjiti opseg poslova koje korisnik treba izvršiti kako bi upravljao podacima skladišta. Naziv teme je: "Aplikacija za vođenje statistike skladišta i planiranje zaliha (strategije upravljanja zalihama - minimalne/maksimalne količine, vremena između nabavki itd. - obavezna implementacija strategije upravljanja zalihama) - Aktivne + Temporalne baze podataka - PostgreSQL + Desktop grafičko sučelje sučelje po želji". Vrstu skladišta koje sam odabrao je skladište autodijelova. Korisnik aplikacije imat će uvid u neke aktivnosti koje su se odvijale nad skladištem i ti podaci biti će trajno spremljeni kako bi korisnik u svakom trenutku mogao imati ispis svih aktivnosti provedenih nad bazom kao što su povijest narudžbi i slično. Temporalni dio baze podataka upotpunit će i aktivne baze podataka koje će automatski provoditi neke od aktivnosti nad bazom koristeći okidače. Za izradu grafičkog sučelja koristio sam Visual Studio jer sam sa ovim alatom najviše upoznat, a baza podataka se sastoji od PostgreSQL-a te alati koje sam koristio su su pgAdmin4 i Navicat 15.



## Model baze podataka 

Na fotografiji ispod prikazan je model baze podataka **ERA** koji je korišten kako bi se izradila baza podataka, odnosno cjelokupna aplikacija. Za izradu modela korišten je alat Navicat 15 koji omogućava grafičko sučelje pri kreiranju baze.

Model se sastoji od 10 entiteta koji se koriste za uspješno vođenje skladišta autodijelova. 



**Autodijelovi** 

Predstavlja središte modela i u njoj se spremaju sve informacije vezano uz neki dio kao što su šifra pod kojom se vodi dio, naziv, minimalna količina, cijena i tako dalje. Prema tome, ova tablica sadrži jedinstveni brojačnu vrijednost {sifra} koja predstavlja jedan autodio. Atributi koji dodatno opisuju pojedini autodio su {naziv}, {narucena\_kolicina}, {minimalna\_kolicina}, {cijena}, {vrijedi\_od} i {ne\_vrijedi\_ od}. Tablica "Autodijelovi" sastoji se također od vanjskih ključeva koji su povezani sa tablicom {Auto}, {Vrsta}, {Proizvodac} i {Karakteristike}. 
Vrijednost atributa "{minimalna\_kolicina}" bitna je kod automatskog vođenja skladišta gdje se ova vrijedost uzima za usporedbu sa trenutnom količinom koja se nalazi na skladištu. U slučaju da trenutna količina skladišta padne ispod minimalne vrijednosti, automatski se naručuje novi proizvod. Ovu vrijednost korisnik unosi posebno za svaki automobil i to pri unosu automobila u bazu podataka.



**Proizvodac** 

U ovoj tablici spremaju se podaci o mogućim proizvođačima određenog prozivoda. Svaki autodio ima svog proizvođača. Kako bi znali identificirati jednog proizvođača od drugog koristimo vrijednost \bf{id}. Tablica "Proizvodac" sadrži {naziv} i {info} u kojem dodjeljujemo svakom proizvođaču određen opis prepoznatljiv za njegov brend.
 
 
 
**Auto**

Autodijelovi se proizvode po pricnipu gdje svaki dio ima svrhu za određenu marku automobila, odnosno propisano je koji dio je prikladan za koji automobil. Zbog toga imamo tablicu {Auto} pomoću koje dodatno opisujemo svaki autodio. Atribut "marka\_automobila" predstavlja naziv automobila za koji je namjenjen dio. 
 
 
 
**Vrsta**

Kako svaki autodio spada u neku određenu vrstu ili kategoriju moramo napraviti i tablicu "Vrsta" koja sadrži jedinstveni ključ {id} prema kojemu možemo identificirati o kojoj se vrsti autodijlova radi. Neke moguće vrste autodijelova su: {rasvjeta}, {karoserija}, {unutrašnjost}, {dodaci} i tako dalje. Svaka vrsta ima svoj opis koji korisniku daje uvid što pod koju vrstu spada. 
  
  
  
**Karakteristike** 

Sve ima svoje karakteristike, pa tako i autodijelovi, a neke osnovne karakteristike koje mogu biti  korisne kod kupovine autodijelova su njihove dimenzije pa tako tablica "Karakteristike" sadrži atribute poput {namjena}, {pakiranje}, {boja}, {duzina} i {sirina}. Svaka od karakteristika jedinstvena je po svom primarnom ključu {id}.
   

**Stanje\_na\_skladistu** 

Jedna od glavnih svojstva ove aplikacije je uvid u stanje skladišta pa radi toga možemo i pronaći ovu tablicu u ERA modelu. U ovoj tablici sprema se trenutna količina autodijelova na skladištu, kao i njihova pozicija u skladištu. Ovi su podaci zapisani u atributima {kolicina}, {red}, {dio}. Ova tablica se sastoji od primarnog, ali ujedno i vanjskog ključa na tablicu "Autodijelovi". Ovo je {nužno} zbog toga što se ne smije desiti da u skladištu postoje dva identična autodijela koji svaki za sebe ima određenu količinu ili različito mjesto skladištenja po atributu "red" i atributu "dio". Vanjski ključ "povijestNarudzba\_id" nam je potreban kako bi se upotpunio proces narudžbe proizvoda. Taj dio biti će objašnjen u kasnijim poglavljima. Atribut naziva "za\_sortiranje" slobodno zanemarimo, njega sam iskoristio kako bi dobio ljepši prikaz podataka u samoj aplikaciji.
 
 
 
**Informacije skladišta** 

Nakon svake izmjene u tablcii "Stanje\_Skladista" vodi se evidencija koja se zapisuje u tablicu "{Informacije\_Skladista}. Ova tablica se sastoji od osnovnih informacijama o proizvodu koji prolazi skladištem, a neki od podataka koji se bilježe u ovoj tablici su: {datum\_evidencije}, {stara\_kolicina}, {nova\_kolicina}, {autodijelovi\_id}, i {opis}. Svaka promjena u skladištu se bilježi automatski preko okidača i funkcije koja upisuje podatke u tablicu.
 
 
 
**Narudzba**

U ovoj tablici korisniku su vidljive sve aktivne narudžbe koje je kreirao on sam ili koje su automatski aktivirane preko okidača. Ukoliko zadana minimalna količina padne ispod trenutne količine na skladištu, automatski se dodaje nova nardužba. Korisnik također ima mogućnost unosa narudžbe u slučaju kada je to potrebno. Nakon što se naruči novi proizvod, taj podatak se bilježi u tablicu narudžba sa atributima kao što su datum\_narucivanja, kolicina\_narucivanja, opis te atributom narudzba\_zaprimljena. Ukoliko narudžba nije zaprimljena, količina na stanju skladišta se {ne} ažurira. Narudžba se može obaviti i prilikom unosa novog autodijela u bazu podataka preko tablice "Autodijelovi" stoga u je u tablici "Narudzba" potrebno referencirati vanjski ključ prema tablici "Autodijelovi". 
 
 
 
**PovijestNarudzbi** 

Ova tablica ima funkciju bilježenja svih narudžbi koje su se izvršile nad bazom podataka. Narudžbe mogu imati {tri stanja}, a to su: "U obradi", "Da", "Ne". Stanje "U obradi" znači da je narudžba još uvijek u tijeku te da korisnik još uvijek nije dobio narudžbu na adresu. Ukoliko narudžba stigne na adresu tada korisnik potvrdi primitak narudžbe čime narudžba prelazi u stanje "Da". Ukoliko narudžba nije stigla na adresu u nekom očekivanom periodu vremena, korisnik potvrđuje da narudžba {nije} stigla te narudžba prelazi u stanje "Ne". Podaci koje tablica "PovijestNarudzbi" pohranjuje o svakoj narudžbi su datum naručivanja, datum primitka, količina naručivanja te opis narudžbe u kojoj se sprema podatak o tome tko je izvršio narudžbu, korisnik ili neka od okidačkih funkcija. 
  
  
  
**Popusti** 

U tablici popusti korisnik ima mogućnost postavljanja određnog proizvoda na popust. U ovoj tablici spremaju se podaci o trajanju popusta te koji je proizvod na popustu. Također, korisnik unosi podatak o novoj cijenu proizvoda koja se zapisuje u atribut {nova\_cijena}. Korisnik ima uvid u proizvode koji su trenutno na popustu, koji nisu na popustu te u sve popuste koji su ikad zabilježeni u bazi. 


# Implementacija

U izradi baze podataka koristio sam alat pgAdmin 4 i Navicat 15 koji su dosta jednostavni za korištenje. Samu bazu kreirao sam u alatu pgAdmin 4 i nakon toga sam se spojio preko alata Navicat 15 na kreiranu bazu podataka. Većinu vremena sam proveo koristeći alat Navicat 15 pri čemu sam upoznao njegove prednosti i mane. Preko njegovih funkcija moguće je kreirati tablice, povezati ih, unijeti podatke u tablice te kreirati razne funkcije i okidače. Tablice se mogu kreirati preko grafičkog sučelja bez pretjeranog tipkanja. Izrada funkcija u alatu Navicat 15 nije najbolja opcija ukoliko u različitim tablicama koristite ista imena određenih atributa, ovdje je često nastajo problem gdje Navicat pri unosu imena atributa nudi isti taj atribut, ali iz druge tablice, što rezultira funkcijom koja ne radi onako kako ste zamislili. Zbog toga sam funkcije pretežito kreirao u alatu pgAdmin 4. 

# Kreiranje tablica


## Proizvodac 

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
        
        
## Stanje Skladista

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
        
## Narudzba
        
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


## Povijest narudzbi

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
        

## Informacije Skladista
        
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


