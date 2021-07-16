--
-- PostgreSQL database dump
--

-- Dumped from database version 13.1
-- Dumped by pg_dump version 13.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: dodaj_dio_u_narudzbu(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.dodaj_dio_u_narudzbu() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN

INSERT INTO "Narudzba"(id_narudzba, datum_narucivanja, kolicina_narucivanja , opis, "narudzbaAutodijelovi_id", narudzba_zaprimljena) VALUES(DEFAULT, CURRENT_DATE, new.narucena_kolicina,'Automatska narudžba', new.sifra, 'U obradi');

RETURN NEW;

END;


$$;


ALTER FUNCTION public.dodaj_dio_u_narudzbu() OWNER TO postgres;

--
-- Name: dodaj_dio_u_narudzbu_iz_StanjeSkladista(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."dodaj_dio_u_narudzbu_iz_StanjeSkladista"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$BEGIN
	-- Routine body goes here...

BEGIN

IF(new.kolicina < new.skladiste_minimalna_kolicina) THEN

INSERT INTO "Narudzba"(id_narudzba, datum_narucivanja, kolicina_narucivanja , opis, "narudzbaAutodijelovi_id", narudzba_zaprimljena) VALUES(DEFAULT, CURRENT_DATE, new.skladiste_minimalna_kolicina, 'Minimalna kolicina', new.autodijelovi_id , 'U obradi');


END IF;
RETURN NEW;

END;

	RETURN NEW;
END$$;


ALTER FUNCTION public."dodaj_dio_u_narudzbu_iz_StanjeSkladista"() OWNER TO postgres;

--
-- Name: duplikat_dodaj_u_skladiste(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.duplikat_dodaj_u_skladiste() RETURNS trigger
    LANGUAGE plpgsql
    AS $$BEGIN
	-- Routine body goes here...

	if new."Stanje_Skladista".autodijelovi_id = "Stanje_Skladista".autodijelovi_id THEN
  UPDATE "Stanje_Skladista" SET kolicina = new.kolicina where autodijelovi_id=new.autodijelovi_id;
	UPDATE "Stanje_Skladista" SET red = new.red where autodijelovi_id=new.autodijelovi_id;
	UPDATE "Stanje_Skladista" SET dio = new.dio where autodijelovi_id=new.autodijelovi_id;
	
	end if;


	RETURN NEW;
END$$;


ALTER FUNCTION public.duplikat_dodaj_u_skladiste() OWNER TO postgres;

--
-- Name: evidentiraj_promjene(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.evidentiraj_promjene() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
	
	BEGIN
		
	IF NEW.kolicina < 0 THEN
	RAISE EXCEPTION 'Unesite ispravnu vrijednost za kolicinu';
	
	ELSE
	IF(NEW.kolicina < OLD.kolicina) THEN
	
	INSERT INTO "Informacije_Skladista"(autodijelovi_id, datum_evidencije, stara_kolicina, nova_kolicina, opis) VALUES(old.autodijelovi_id,CURRENT_TIMESTAMP, old.kolicina, new.kolicina, 'Oduzeta je kolicina sa skladista');
	
	else 
	IF(NEW.kolicina > OLD.kolicina) THEN
	
	INSERT INTO "Informacije_Skladista"(autodijelovi_id,datum_evidencije, stara_kolicina, nova_kolicina, opis)
	VALUES(old.autodijelovi_id, CURRENT_TIMESTAMP, old.kolicina, new.kolicina, 'Dodan je dio u skladiste');
	
	END IF;
	
	END IF;
 
END IF;

	RETURN NEW;
END
$$;


ALTER FUNCTION public.evidentiraj_promjene() OWNER TO postgres;

--
-- Name: evidentiraj_promjenePovijestNarudzbi(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."evidentiraj_promjenePovijestNarudzbi"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$BEGIN
	-- Routine body goes here...

	IF old.narudzba_zaprimljena = 'U obradi' THEN
	
	IF (new.narudzba_zaprimljena = 'Da') THEN
	
	INSERT INTO "PovijestNarudzbi"("id_povijestNarudzbi", pdatum_narucivanja, pdatum_primitka, pkolicina_narucivanja, popis, pnarudzba_zaprimljena, pautodijelovi_id) VALUES
	(DEFAULT, old.datum_narucivanja, CURRENT_DATE, old.kolicina_narucivanja , old.opis, 'Da', old."narudzbaAutodijelovi_id");
	
	ELSE 
	IF(new.narudzba_zaprimljena = 'Ne') THEN
	
	INSERT INTO "PovijestNarudzbi"("id_povijestNarudzbi", pdatum_narucivanja, pdatum_primitka, pkolicina_narucivanja, popis, pnarudzba_zaprimljena, pautodijelovi_id) VALUES
	(DEFAULT, old.datum_narucivanja, CURRENT_DATE,old.kolicina_narucivanja, old.opis, 'Ne', old."narudzbaAutodijelovi_id");
	
	END IF;
	
	END IF;
 
END IF;

DELETE FROM "Narudzba" where narudzba_zaprimljena = 'Da' OR narudzba_zaprimljena = 'Ne'; 

	RETURN NEW;
END$$;


ALTER FUNCTION public."evidentiraj_promjenePovijestNarudzbi"() OWNER TO postgres;

--
-- Name: ne_vrijedi_od(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.ne_vrijedi_od() RETURNS trigger
    LANGUAGE plpgsql
    AS $$BEGIN

	if new.vrijedi_od is null then
  UPDATE "Autodijelovi" SET ne_vrijedi_od = CURRENT_TIMESTAMP WHERE sifra = new.sifra;
	
	end if;

	RETURN NEW;

END;
$$;


ALTER FUNCTION public.ne_vrijedi_od() OWNER TO postgres;

--
-- Name: nova_narudzba_iz_skladista(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.nova_narudzba_iz_skladista() RETURNS trigger
    LANGUAGE plpgsql
    AS $$BEGIN
	-- Routine body goes here...

INSERT INTO "Narudzba"(id_narudzba, datum_narucivanja, datum_primitka, kolicina_narucivanja , opis, "narudzbaAutodijelovi_id", narudzba_zaprimljena) VALUES(DEFAULT, CURRENT_DATE, null, new.skladiste_minimalna_kolicina ,'Automatska narudžba', new.autodijelovi_id, 'U obradi');

RETURN NEW;

END$$;


ALTER FUNCTION public.nova_narudzba_iz_skladista() OWNER TO postgres;

--
-- Name: unesi_novi_dio_u_skladiste(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.unesi_novi_dio_u_skladiste() RETURNS trigger
    LANGUAGE plpgsql
    AS $$BEGIN

INSERT INTO "Informacije_Skladista"(datum_evidencije, stara_kolicina,nova_kolicina, autodijelovi_id, opis) VALUES (CURRENT_TIMESTAMP, new.kolicina, new.kolicina, new.autodijelovi_id, 'Novi dio zabilježen');

RETURN NEW;
END;
$$;


ALTER FUNCTION public.unesi_novi_dio_u_skladiste() OWNER TO postgres;

--
-- Name: unesi_stanje_skladista_iz_PovijestiNarudzbi(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."unesi_stanje_skladista_iz_PovijestiNarudzbi"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE
    
	skladiste_autodijelovi_id INTEGER;
	nova_kolicina_zbroj INTEGER; 	
  
	BEGIN

  
	select autodijelovi_id into skladiste_autodijelovi_id 
	from "Stanje_Skladista" where autodijelovi_id = new.pautodijelovi_id and kolicina = 0;
	
	select kolicina into nova_kolicina_zbroj
	from "Stanje_Skladista" WHERE autodijelovi_id = new.pautodijelovi_id;
	

	nova_kolicina_zbroj = nova_kolicina_zbroj+ new.pkolicina_narucivanja;
	
	IF (new.pnarudzba_zaprimljena = 'Da') THEN
		
		IF (skladiste_autodijelovi_id != NULL) THEN
		
		INSERT INTO "Stanje_Skladista"(autodijelovi_id, kolicina, red, dio, "povijestNarudzba_id", skladiste_minimalna_kolicina) VALUES (new.pautodijelovi_id, new.pkolicina_narucivanja, 'Nije odabrano', 0, new.     "id_povijestNarudzbi",new.pkolicina_narucivanja);

	ELSE
		UPDATE "Stanje_Skladista" SET kolicina = nova_kolicina_zbroj WHERE autodijelovi_id = new.pautodijelovi_id;
		
		UPDATE "Stanje_Skladista" SET "povijestNarudzba_id" = new."id_povijestNarudzbi" WHERE autodijelovi_id = new.pautodijelovi_id;


	END IF;
END IF;

RETURN NEW;
END;
$$;


ALTER FUNCTION public."unesi_stanje_skladista_iz_PovijestiNarudzbi"() OWNER TO postgres;

--
-- Name: vrijedi_od(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.vrijedi_od() RETURNS trigger
    LANGUAGE plpgsql
    AS $$BEGIN

	if new.ne_vrijedi_od is null then
  UPDATE "Autodijelovi" SET vrijedi_od = CURRENT_TIMESTAMP WHERE sifra = new.sifra;
	end if;

	RETURN NEW;

END;
$$;


ALTER FUNCTION public.vrijedi_od() OWNER TO postgres;

--
-- Name: vrijedi_od_INSERT(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."vrijedi_od_INSERT"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
	
	BEGIN

  UPDATE "Autodijelovi" SET vrijedi_od= CURRENT_TIMESTAMP WHERE sifra = new.sifra;

	RETURN NEW;
	
	
  END;

$$;


ALTER FUNCTION public."vrijedi_od_INSERT"() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Auto; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Auto" (
    id integer NOT NULL,
    marka_automobila character varying(255)
);


ALTER TABLE public."Auto" OWNER TO postgres;

--
-- Name: Auto_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Auto" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Auto_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Autodijelovi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Autodijelovi" (
    sifra integer NOT NULL,
    naziv character varying(255) NOT NULL,
    narucena_kolicina smallint NOT NULL,
    minimalna_kolicina smallint NOT NULL,
    cijena numeric,
    karakteristike_id integer,
    vrsta_id integer,
    proizvodac_id integer,
    auto_id integer,
    vrijedi_od timestamp without time zone,
    ne_vrijedi_od timestamp without time zone
);


ALTER TABLE public."Autodijelovi" OWNER TO postgres;

--
-- Name: Autodijelovi_sifra_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Autodijelovi" ALTER COLUMN sifra ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Autodijelovi_sifra_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Informacije_Skladista; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Informacije_Skladista" (
    id integer NOT NULL,
    datum_evidencije timestamp without time zone,
    stara_kolicina integer,
    nova_kolicina integer,
    autodijelovi_id integer,
    opis character varying(255)
);


ALTER TABLE public."Informacije_Skladista" OWNER TO postgres;

--
-- Name: Informacije_Skladista_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Informacije_Skladista" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Informacije_Skladista_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Karakteristike; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Karakteristike" (
    id integer NOT NULL,
    namjena character varying(255),
    pakiranje character varying(255),
    boja character varying(255),
    duzina character varying(255),
    sirina character varying(255)
);


ALTER TABLE public."Karakteristike" OWNER TO postgres;

--
-- Name: Karakteristike_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Karakteristike" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Karakteristike_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Narudzba; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Narudzba" (
    id_narudzba integer NOT NULL,
    datum_narucivanja date,
    kolicina_narucivanja integer,
    opis character varying(255),
    "narudzbaAutodijelovi_id" integer,
    narudzba_zaprimljena character varying(255),
    stanje_skladista_id integer
);


ALTER TABLE public."Narudzba" OWNER TO postgres;

--
-- Name: Narudzba_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Narudzba" ALTER COLUMN id_narudzba ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Narudzba_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Popusti; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Popusti" (
    id integer NOT NULL,
    pocinje date,
    zavrsava date,
    nova_cijena numeric,
    autodijelovi_id integer
);


ALTER TABLE public."Popusti" OWNER TO postgres;

--
-- Name: Popusti_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Popusti" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Popusti_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: PovijestNarudzbi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PovijestNarudzbi" (
    "id_povijestNarudzbi" integer NOT NULL,
    pdatum_narucivanja date,
    pdatum_primitka date,
    pkolicina_narucivanja integer,
    popis character varying(255),
    pnarudzba_zaprimljena character varying(255),
    pautodijelovi_id integer
);


ALTER TABLE public."PovijestNarudzbi" OWNER TO postgres;

--
-- Name: PovijestNarudzbi_id_povijestNarudzbi_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."PovijestNarudzbi" ALTER COLUMN "id_povijestNarudzbi" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."PovijestNarudzbi_id_povijestNarudzbi_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Proizvodac; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Proizvodac" (
    id integer NOT NULL,
    naziv character varying(255),
    info text
);


ALTER TABLE public."Proizvodac" OWNER TO postgres;

--
-- Name: Proizvodac_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Proizvodac" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Proizvodac_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Stanje_Skladista; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Stanje_Skladista" (
    autodijelovi_id integer NOT NULL,
    kolicina integer,
    red character varying(16),
    dio integer,
    "povijestNarudzba_id" integer,
    skladiste_minimalna_kolicina integer,
    za_sortiranje integer NOT NULL
);


ALTER TABLE public."Stanje_Skladista" OWNER TO postgres;

--
-- Name: Stanje_Skladista_za_sortiranje_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Stanje_Skladista" ALTER COLUMN za_sortiranje ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Stanje_Skladista_za_sortiranje_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Vrsta; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Vrsta" (
    id integer NOT NULL,
    naziv character varying(255),
    info text
);


ALTER TABLE public."Vrsta" OWNER TO postgres;

--
-- Name: Vrsta_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Vrsta" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Vrsta_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Data for Name: Auto; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Auto" (id, marka_automobila) FROM stdin;
1	Audi
2	VW
3	Mercedes
4	Ford
43	Univerzalno
44	BMW
45	Kia
52	Škoda
53	Ferrari
54	Lamborghini
55	Opel
56	Citroen
57	Dacia
58	Nissan
59	Subaru
60	Renault
61	Toyota
62	Smart
63	Honda
\.


--
-- Data for Name: Autodijelovi; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Autodijelovi" (sifra, naziv, narucena_kolicina, minimalna_kolicina, cijena, karakteristike_id, vrsta_id, proizvodac_id, auto_id, vrijedi_od, ne_vrijedi_od) FROM stdin;
120	3D Karbonska folija 	50	50	62.00	1	17	19	43	2021-01-22 14:21:44.93087	\N
121	Mreža prtljažnika Silux Parts	45	45	105.00	1	17	19	43	2021-01-22 14:23:09.871101	\N
132	Kuka za VW	20	15	400.00	1	18	1	2	\N	2021-01-23 19:06:52.227294
123	Univerzalni štitnik odbojnika	20	20	70.00	1	17	19	43	2021-01-22 14:24:37.695674	\N
125	Kada prtljažnika	30	30	120.00	1	17	20	3	2021-01-22 14:25:49.611327	\N
126	Kada prtljažnika Ford	15	15	150.00	1	17	20	4	2021-01-22 14:26:11.909477	\N
127	Kada prtljažnika BMW	10	10	115.00	1	17	20	44	2021-01-22 14:26:37.083164	\N
128	Kada prtljažnika Kia	20	20	200.00	1	17	20	45	2021-01-22 14:27:15.89338	\N
129	Univerzalna ručica mjenjača	40	40	120.00	1	17	21	43	2021-01-22 14:28:28.991421	\N
122	Poklon set 5v1:držač telefona, adapter + kabal za punjenje, osvježivač zraka, sat za parkiranje	100	100	90.00	1	17	19	43	\N	2021-01-22 17:24:28.86692
130	Auto tepisi Audi	15	14	30.00	1	17	20	1	\N	2021-01-22 17:30:19.152582
158	Auspuh za Mercedes	15	15	999.99	1	18	1	3	2021-01-23 19:40:38.187626	\N
159	Auspuh za Kia	30	30	899.99	1	18	1	45	2021-01-23 19:42:47.585979	\N
119	Auto tepisi Audi	25	25	288.40	1	17	18	1	\N	2021-01-23 20:09:22.460422
124	Grijani jastuk	10	10	120.00	1	17	19	43	2021-01-23 20:09:23.610857	\N
160	Brava za Škodu	25	25	1329.99	1	27	21	52	2021-01-24 00:03:06.981658	\N
\.


--
-- Data for Name: Informacije_Skladista; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Informacije_Skladista" (id, datum_evidencije, stara_kolicina, nova_kolicina, autodijelovi_id, opis) FROM stdin;
251	2021-01-24 02:27:42.681683	0	0	129	Novi dio zabilježen
252	2021-01-24 02:27:51.069534	0	0	122	Novi dio zabilježen
253	2021-01-24 02:27:55.532405	0	0	119	Novi dio zabilježen
254	2021-01-24 02:28:00.12332	0	0	160	Novi dio zabilježen
255	2021-01-24 02:28:07.693481	0	0	120	Novi dio zabilježen
256	2021-01-24 02:29:34.876035	0	0	124	Novi dio zabilježen
257	2021-01-24 02:29:39.269279	0	0	125	Novi dio zabilježen
258	2021-01-24 02:29:46.008351	0	0	159	Novi dio zabilježen
259	2021-01-24 02:29:52.903423	0	0	132	Novi dio zabilježen
260	2021-01-24 02:30:04.695471	0	0	121	Novi dio zabilježen
261	2021-01-24 02:30:18.750594	0	45	121	Dodan je dio u skladiste
262	2021-01-24 02:30:19.659117	0	15	132	Dodan je dio u skladiste
263	2021-01-24 02:30:20.148981	0	30	159	Dodan je dio u skladiste
264	2021-01-24 02:30:20.551182	0	30	125	Dodan je dio u skladiste
265	2021-01-24 02:30:20.984308	0	10	124	Dodan je dio u skladiste
266	2021-01-24 02:30:21.342198	0	50	120	Dodan je dio u skladiste
267	2021-01-24 02:30:21.98525	0	25	160	Dodan je dio u skladiste
268	2021-01-24 02:30:22.380249	0	25	119	Dodan je dio u skladiste
269	2021-01-24 02:30:22.767287	0	100	122	Dodan je dio u skladiste
270	2021-01-24 02:30:23.148209	0	40	129	Dodan je dio u skladiste
271	2021-01-24 02:30:38.876701	25	23	160	Oduzeta je kolicina sa skladista
272	2021-01-24 02:30:45.014272	30	14	125	Oduzeta je kolicina sa skladista
273	2021-01-24 02:30:49.318406	100	45	122	Oduzeta je kolicina sa skladista
274	2021-01-24 02:30:54.131349	45	41	122	Oduzeta je kolicina sa skladista
275	2021-01-24 02:31:00.694633	25	23	119	Oduzeta je kolicina sa skladista
276	2021-01-24 02:31:04.707426	10	7	124	Oduzeta je kolicina sa skladista
277	2021-01-24 02:31:10.052223	40	33	129	Oduzeta je kolicina sa skladista
278	2021-01-24 02:31:14.806598	50	11	120	Oduzeta je kolicina sa skladista
279	2021-01-24 02:31:19.460516	30	4	159	Oduzeta je kolicina sa skladista
280	2021-01-24 02:31:35.731374	4	34	159	Dodan je dio u skladiste
281	2021-01-24 02:31:35.973217	11	61	120	Dodan je dio u skladiste
282	2021-01-24 02:31:36.428345	33	73	129	Dodan je dio u skladiste
283	2021-01-24 02:31:37.021243	23	48	119	Dodan je dio u skladiste
284	2021-01-24 02:31:37.788388	14	44	125	Dodan je dio u skladiste
285	2021-01-24 02:38:33.912267	45	43	121	Oduzeta je kolicina sa skladista
286	2021-01-24 02:38:41.453238	43	88	121	Dodan je dio u skladiste
287	2021-01-24 02:39:23.971692	48	21	119	Oduzeta je kolicina sa skladista
288	2021-01-24 02:39:29.397682	7	6	124	Oduzeta je kolicina sa skladista
289	2021-01-24 02:39:35.314793	21	46	119	Dodan je dio u skladiste
290	2021-01-24 02:39:36.249534	6	16	124	Dodan je dio u skladiste
291	2021-01-24 02:40:14.336895	41	99	122	Dodan je dio u skladiste
292	2021-01-24 02:40:25.737122	99	199	122	Dodan je dio u skladiste
293	2021-01-24 02:40:38.595884	199	96	122	Oduzeta je kolicina sa skladista
294	2021-01-24 02:41:01.568509	44	13	125	Oduzeta je kolicina sa skladista
295	2021-01-24 02:41:05.384823	13	43	125	Dodan je dio u skladiste
\.


--
-- Data for Name: Karakteristike; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Karakteristike" (id, namjena, pakiranje, boja, duzina, sirina) FROM stdin;
1	Dijelovi za automobil 	Zasticeno	Crna	10	23
\.


--
-- Data for Name: Narudzba; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Narudzba" (id_narudzba, datum_narucivanja, kolicina_narucivanja, opis, "narudzbaAutodijelovi_id", narudzba_zaprimljena, stanje_skladista_id) FROM stdin;
\.


--
-- Data for Name: Popusti; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Popusti" (id, pocinje, zavrsava, nova_cijena, autodijelovi_id) FROM stdin;
25	2021-01-22	2021-01-31	75.00	122
26	2021-01-22	2021-01-24	240.88	119
27	2021-01-22	2021-01-24	100.00	124
28	2021-01-22	2021-01-31	99.99	126
29	2021-01-28	2021-01-31	100.00	127
31	2021-01-23	2021-01-23	24.00	129
32	2021-01-23	2021-01-23	120.00	126
\.


--
-- Data for Name: PovijestNarudzbi; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PovijestNarudzbi" ("id_povijestNarudzbi", pdatum_narucivanja, pdatum_primitka, pkolicina_narucivanja, popis, pnarudzba_zaprimljena, pautodijelovi_id) FROM stdin;
78	2021-01-24	2021-01-24	100	Minimalna kolicina	Da	122
79	2021-01-24	2021-01-24	10	Minimalna kolicina	Da	124
80	2021-01-24	2021-01-24	45	Minimalna kolicina	Da	121
81	2021-01-24	2021-01-24	15	Minimalna kolicina	Da	132
82	2021-01-24	2021-01-24	30	Minimalna kolicina	Da	159
83	2021-01-24	2021-01-24	30	Minimalna kolicina	Da	125
84	2021-01-24	2021-01-24	10	Minimalna kolicina	Da	124
85	2021-01-24	2021-01-24	50	Minimalna kolicina	Da	120
86	2021-01-24	2021-01-24	25	Minimalna kolicina	Da	160
87	2021-01-24	2021-01-24	25	Minimalna kolicina	Da	119
88	2021-01-24	2021-01-24	100	Minimalna kolicina	Da	122
89	2021-01-24	2021-01-24	40	Minimalna kolicina	Da	129
90	2021-01-24	2021-01-24	30	Minimalna kolicina	Da	159
91	2021-01-24	2021-01-24	50	Minimalna kolicina	Da	120
92	2021-01-24	2021-01-24	40	Minimalna kolicina	Da	129
93	2021-01-24	2021-01-24	10	Minimalna kolicina	Ne	124
94	2021-01-24	2021-01-24	25	Minimalna kolicina	Da	119
95	2021-01-24	2021-01-24	100	Minimalna kolicina	Ne	122
96	2021-01-24	2021-01-24	100	Minimalna kolicina	Ne	122
97	2021-01-24	2021-01-24	30	Minimalna kolicina	Da	125
98	2021-01-24	2021-01-24	25	Minimalna kolicina	Ne	160
99	2021-01-24	2021-01-24	45	Minimalna kolicina	Da	121
100	2021-01-24	2021-01-24	25	Minimalna kolicina	Da	119
101	2021-01-24	2021-01-24	10	Minimalna kolicina	Da	124
102	2021-01-24	2021-01-24	100	Minimalna kolicina	Da	122
103	2021-01-24	2021-01-24	100	Minimalna kolicina	Ne	122
104	2021-01-24	2021-01-24	30	Minimalna kolicina	Da	125
74	2021-01-24	2021-01-24	10	Minimalna kolicina	Da	124
75	2021-01-24	2021-01-24	10	Minimalna kolicina	Da	124
76	2021-01-24	2021-01-24	100	Minimalna kolicina	Ne	122
77	2021-01-24	2021-01-24	10	Minimalna kolicina	Ne	124
\.


--
-- Data for Name: Proizvodac; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Proizvodac" (id, naziv, info) FROM stdin;
1	BOSCH	Bla bla
2	Valeo	Valeo bla bla
18	Geyer & Hosaja	Jako dobro znamo da su kvalitetne gume jedan od najvažnijih faktora sigurnosti na svakom vozilu. Stoga, kada kupujemo gume, moram birati samo najbolje. Jedan od najpoznatijih i najboljih brandova guma za vozila, ali i mnogih drugih dijelova koja su potrebna svakom vozaču dolaze nam iz poljske tvornice Geyer & Hosaja.\n\nOva tvrtka na poljskom je i europskom tržištu poznata več 25 godina, što govori o kvaliteti proizvoda i zadovoljstvu korisnika. Tvrtka radi s največim i najpoznatijim korporacijama koje se bave proizvodnjom automobila i to ne samo u Europi več i šire. Trenutno imaju dva proizvodna pogona u kojem zapošljavaju preko 700 ljudi. Osim guma za automobile, proizvode i gume za kamione, prikolice, autobuse, poluprikolice te građevinske strojeve kao što su bageri, utovarivači, demperi  i slično. U ponudi imaju i gumene tepihe  za vozila te razne gumene dijelove potrebne za željeznički promet. Ono što če mnoge iznenaditi jest sljedeča informacija – tvrtka Geyer & Hosaja proizvodi i gumene pokrivke za staje na kojima se uzgajaju goveda, a sve kako bi se kod životinja smanjile ozljede te im život bio ugodniji.  Njihovi proizvodi su napravljeni poštujuči najpoznatije svjetske certifikate kvalitete. Geyer & Hosaja – tvrtka s budučnošću! 
19	Silux Parts	Osnovali smo marku Silux Parts gdje nudimo široku paletu proizvoda iz kategorije dodatne opreme. Najuspješniji smo u prodaji žarulja i metlica brisača, gdje jamčimo najbolju kvalitetu uz 12-mjesečno jamstvo.\n\nNudimo niz proizvoda od karbonskih folija, pametnih pokrivala za glavu do organizatora za prtljažni prostor.
20	Polcar	Jedan od največih proizvođača najrazličitijih dijelova za automobile svakako je kompanija Polcar. Smještena je u Varšavi u Poljskoj te je na tržištu prisutna gotovo 30 godina. Proizvodnja je bazirana mahom u matičnoj državi, ali postoje postrojenja i u drugim dijelovima svijeta. Počela je kao kompanija koja je proizvodila termalne dijelove i svjetla, a kasnije se proširila na sve auto dijelove. Zanimljivo je da koriste isključiva svoja novčana sredstva, bez pomoči države i slično, a također ima oko 61,000 metara kvadratnih skladišnog prostora.\n \nZa firmu radi oko tri stotine dobavljača. Ističu kako im je glavna odlika ta da kupcima ponude različite kvalitativne i novčane rangove dijelova pa tako se kod njih mogu pronači originalni dijelovi za vozila koji su ujedno i skuplji, te zamjenski dijelovi koji su znatno jeftiniji. S obzirom na ovo, trenutno nude največi izbor rezervnih auto dijelova na tržištu. Posebno su ponosni na svoj katalog nazvan eCar u kojem kupac može birati dio s obzirom na cijenu te starost vlastitog vozila.\n \nTrenutno je oko 60,000 proizvoda u tom katalogu koji su zorno prikazani fotografijama i nacrtima.  Kompanija suračuje s poznatim lokalnim dobavljačima auto dijelova u cijelom svijetu koji naručuju dijelove s obzirom na potražnju na tržištu. 
21	Bottari	Carlo Bottari osnovao je tvrtku sa suprugom Demicheli Cesiro. U početku su izrađivali auto dijelove i prodavali prirodne spužve, presvlake za sjedala i navlake za volane.\n\nTvrtka se u narednim godinama proširila i postala međunarodno priznata u 1980-ima. Od 2010. godine ponosno sponzoriraju i tim Rugby Viadana iz 1970. godine.\n\nDanas je Bottari velika i priznata međunarodna tvrtka koja nudi vrlo široku paletu proizvoda. U dizajniranju i pakiranju proizvoda uzima u obzir globalne trendove dizajna i brige o okolišu, kao i cijene. Zato su njihovi proizvodi uvijek u trendu i nude izvrsan odnos novca i kvalitete.\n\nBottari također osigurava zadovoljstvo krajnjih kupaca isporukom naručenih dijelova sigurno i na vrijeme. Također pružaju sigurno i živopisno pakiranje.\n\nTvrtka se brine i za ekološki aspekt poslovanja, vodeći računa o odgovornim poslovnim praksama, osiguravajući dobre radne uvjete i brinući o okolišu. Pri dizajniranju proizvoda vode računa o organskom aspektu i poboljšavaju ambalažu kako bi bila što više ekološka.
30	Hagus	Opis1
31	Prasco	Opis2
32	Depo	Opis3
33	Hella	Opis4
34	AL	Opis5
35	CN360LED	Opis6
36	Equipart	Opis7
37	OEM / Original	Opis8
38	SW-Stahl	Opis9
39	Carpriss	Opis10
40	Select	Opis11
41	Select	Opis11
\.


--
-- Data for Name: Stanje_Skladista; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Stanje_Skladista" (autodijelovi_id, kolicina, red, dio, "povijestNarudzba_id", skladiste_minimalna_kolicina, za_sortiranje) FROM stdin;
132	15	D	5	81	15	2
160	23	B	1	86	25	3
129	73	A	1	92	40	8
121	88	C	9	99	45	1
159	34	C	1	90	30	6
120	61	B	2	91	50	7
119	46	A	3	100	25	9
124	16	B	3	101	10	5
122	96	A	2	102	100	4
125	43	B	3	104	30	10
\.


--
-- Data for Name: Vrsta; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Vrsta" (id, naziv, info) FROM stdin;
17	Unutrašnjost	Unutrašnjost vozila obuhvaća područja sjedala, područja za noge, kokpit, volan, mjenjač, radijski prijemnik, zvučnike, spremnik stvari u obliku kutije, obično ispred suvozača. Kao što se i može zaključiti, ovo je poprilično veliko područje kada govorimo o njemu, ali kada koristimo vozilo obično nam je premaleno te bismo uvijek željeli da je barem malo veće i komfornije, posebice kada se radi oo sjedalima te prostoru za noge. Unutrašnjost vozila mora se redovno održavati i čistiti kako bi nam svaka vožnja bila što udobnija, ali i sigurnija. Za čišćenje unutrašnjosti vozila postoji niz sredstava i veliki izbor pa je jedino pravo pitanje – što ćete vi izabrati za to?
18	Dodaci	Sve od dodataka za Vaše vozilo.
27	Kaorserija	Vanjski izgled vašeg auta
28	Rasvjeta	Najbolja rasvjeta za vaš automobil. Farovi, žmigavci itd.
29	Rashladni sustavi	Održite svoj automobil hladnim
30	Motor	Sve za motor vašeg vozila
31	Stakla	Sva stakla na automobilu
32	Ovjes i pogon	Pokretanje automobila
\.


--
-- Name: Auto_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Auto_id_seq"', 63, true);


--
-- Name: Autodijelovi_sifra_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Autodijelovi_sifra_seq"', 160, true);


--
-- Name: Informacije_Skladista_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Informacije_Skladista_id_seq"', 295, true);


--
-- Name: Karakteristike_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Karakteristike_id_seq"', 1, false);


--
-- Name: Narudzba_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Narudzba_id_seq"', 1082, true);


--
-- Name: Popusti_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Popusti_id_seq"', 32, true);


--
-- Name: PovijestNarudzbi_id_povijestNarudzbi_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PovijestNarudzbi_id_povijestNarudzbi_seq"', 104, true);


--
-- Name: Proizvodac_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Proizvodac_id_seq"', 41, true);


--
-- Name: Stanje_Skladista_za_sortiranje_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Stanje_Skladista_za_sortiranje_seq"', 11, true);


--
-- Name: Vrsta_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Vrsta_id_seq"', 32, true);


--
-- Name: Auto Auto_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Auto"
    ADD CONSTRAINT "Auto_pkey" PRIMARY KEY (id);


--
-- Name: Autodijelovi Autodijelovi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autodijelovi"
    ADD CONSTRAINT "Autodijelovi_pkey" PRIMARY KEY (sifra);


--
-- Name: Informacije_Skladista Informacije_Skladista_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Informacije_Skladista"
    ADD CONSTRAINT "Informacije_Skladista_pkey" PRIMARY KEY (id);


--
-- Name: Karakteristike Karakteristike_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Karakteristike"
    ADD CONSTRAINT "Karakteristike_pkey" PRIMARY KEY (id);


--
-- Name: Narudzba Narudzba_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Narudzba"
    ADD CONSTRAINT "Narudzba_pkey" PRIMARY KEY (id_narudzba);


--
-- Name: Popusti Popusti_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Popusti"
    ADD CONSTRAINT "Popusti_pkey" PRIMARY KEY (id);


--
-- Name: PovijestNarudzbi PovijestNarudzbi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PovijestNarudzbi"
    ADD CONSTRAINT "PovijestNarudzbi_pkey" PRIMARY KEY ("id_povijestNarudzbi");


--
-- Name: Proizvodac Proizvodac_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Proizvodac"
    ADD CONSTRAINT "Proizvodac_pkey" PRIMARY KEY (id);


--
-- Name: Stanje_Skladista Stanje_Skladista_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Stanje_Skladista"
    ADD CONSTRAINT "Stanje_Skladista_pkey" PRIMARY KEY (autodijelovi_id);


--
-- Name: Vrsta Vrsta_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Vrsta"
    ADD CONSTRAINT "Vrsta_pkey" PRIMARY KEY (id);


--
-- Name: Autodijelovi okidac_dodaj_dio_u_narudzbu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER okidac_dodaj_dio_u_narudzbu AFTER INSERT ON public."Autodijelovi" FOR EACH ROW EXECUTE FUNCTION public.dodaj_dio_u_narudzbu();


--
-- Name: Stanje_Skladista okidac_dodaj_narudzbu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER okidac_dodaj_narudzbu AFTER INSERT OR UPDATE ON public."Stanje_Skladista" FOR EACH ROW EXECUTE FUNCTION public."dodaj_dio_u_narudzbu_iz_StanjeSkladista"();


--
-- Name: Stanje_Skladista okidac_evidentiraj_novu_robu_na_skladiste; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER okidac_evidentiraj_novu_robu_na_skladiste AFTER INSERT ON public."Stanje_Skladista" FOR EACH ROW EXECUTE FUNCTION public.unesi_novi_dio_u_skladiste();


--
-- Name: Stanje_Skladista okidac_evidentiraj_promjene; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER okidac_evidentiraj_promjene AFTER UPDATE ON public."Stanje_Skladista" FOR EACH ROW EXECUTE FUNCTION public.evidentiraj_promjene();


--
-- Name: Narudzba okidac_evidentiraj_promjenePovijestNarudzbe; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "okidac_evidentiraj_promjenePovijestNarudzbe" AFTER UPDATE ON public."Narudzba" FOR EACH ROW EXECUTE FUNCTION public."evidentiraj_promjenePovijestNarudzbi"();


--
-- Name: Autodijelovi okidac_ne_vrijedi_od; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER okidac_ne_vrijedi_od AFTER UPDATE OF vrijedi_od ON public."Autodijelovi" FOR EACH ROW EXECUTE FUNCTION public.ne_vrijedi_od();


--
-- Name: PovijestNarudzbi okidac_unesi_stanje_skladista_iz_PovijestNarudzbi; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "okidac_unesi_stanje_skladista_iz_PovijestNarudzbi" AFTER INSERT ON public."PovijestNarudzbi" FOR EACH ROW EXECUTE FUNCTION public."unesi_stanje_skladista_iz_PovijestiNarudzbi"();


--
-- Name: Autodijelovi okidac_vrijedi_od; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER okidac_vrijedi_od AFTER UPDATE OF ne_vrijedi_od ON public."Autodijelovi" FOR EACH ROW EXECUTE FUNCTION public.vrijedi_od();


--
-- Name: Autodijelovi okidac_vrijedi_od_INSERT; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "okidac_vrijedi_od_INSERT" AFTER INSERT ON public."Autodijelovi" FOR EACH ROW EXECUTE FUNCTION public."vrijedi_od_INSERT"();


--
-- Name: Autodijelovi vk_auto; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autodijelovi"
    ADD CONSTRAINT vk_auto FOREIGN KEY (auto_id) REFERENCES public."Auto"(id);


--
-- Name: Stanje_Skladista vk_autodijelovi; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Stanje_Skladista"
    ADD CONSTRAINT vk_autodijelovi FOREIGN KEY (autodijelovi_id) REFERENCES public."Autodijelovi"(sifra);


--
-- Name: Informacije_Skladista vk_autodijelovi; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Informacije_Skladista"
    ADD CONSTRAINT vk_autodijelovi FOREIGN KEY (autodijelovi_id) REFERENCES public."Autodijelovi"(sifra);


--
-- Name: Popusti vk_autodijelovi; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Popusti"
    ADD CONSTRAINT vk_autodijelovi FOREIGN KEY (autodijelovi_id) REFERENCES public."Autodijelovi"(sifra);


--
-- Name: Narudzba vk_autodijelovi; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Narudzba"
    ADD CONSTRAINT vk_autodijelovi FOREIGN KEY ("narudzbaAutodijelovi_id") REFERENCES public."Autodijelovi"(sifra);


--
-- Name: PovijestNarudzbi vk_autodijelovi_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PovijestNarudzbi"
    ADD CONSTRAINT "vk_autodijelovi_Id" FOREIGN KEY (pautodijelovi_id) REFERENCES public."Autodijelovi"(sifra);


--
-- Name: Autodijelovi vk_karakteristike; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autodijelovi"
    ADD CONSTRAINT vk_karakteristike FOREIGN KEY (karakteristike_id) REFERENCES public."Karakteristike"(id);


--
-- Name: Stanje_Skladista vk_povijestNarudzbi; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Stanje_Skladista"
    ADD CONSTRAINT "vk_povijestNarudzbi" FOREIGN KEY ("povijestNarudzba_id") REFERENCES public."PovijestNarudzbi"("id_povijestNarudzbi");


--
-- Name: Autodijelovi vk_proizvodac; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autodijelovi"
    ADD CONSTRAINT vk_proizvodac FOREIGN KEY (proizvodac_id) REFERENCES public."Proizvodac"(id);


--
-- Name: Narudzba vk_stanje_skladista; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Narudzba"
    ADD CONSTRAINT vk_stanje_skladista FOREIGN KEY (stanje_skladista_id) REFERENCES public."Stanje_Skladista"(autodijelovi_id);


--
-- Name: Autodijelovi vk_vrsta; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autodijelovi"
    ADD CONSTRAINT vk_vrsta FOREIGN KEY (vrsta_id) REFERENCES public."Vrsta"(id);


--
-- PostgreSQL database dump complete
--

