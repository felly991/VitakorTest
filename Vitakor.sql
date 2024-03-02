--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

-- Started on 2024-03-01 17:07:36

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 219 (class 1259 OID 27713)
-- Name: bet; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.bet (
    id integer NOT NULL,
    usersid integer,
    lotid integer,
    salary integer
);


ALTER TABLE public.bet OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 27712)
-- Name: bet_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.bet_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.bet_id_seq OWNER TO postgres;

--
-- TOC entry 3364 (class 0 OID 0)
-- Dependencies: 218
-- Name: bet_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.bet_id_seq OWNED BY public.bet.id;


--
-- TOC entry 217 (class 1259 OID 27701)
-- Name: lot; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.lot (
    id integer NOT NULL,
    name text NOT NULL,
    start_bet integer DEFAULT 500,
    alive boolean DEFAULT true,
    date_created timestamp with time zone DEFAULT now()
);


ALTER TABLE public.lot OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 27700)
-- Name: lot_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.lot_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.lot_id_seq OWNER TO postgres;

--
-- TOC entry 3365 (class 0 OID 0)
-- Dependencies: 216
-- Name: lot_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.lot_id_seq OWNED BY public.lot.id;


--
-- TOC entry 215 (class 1259 OID 27691)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id integer NOT NULL,
    name text NOT NULL,
    surname text NOT NULL,
    email text NOT NULL,
    password text NOT NULL,
    birthday date DEFAULT now()
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 27690)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_id_seq OWNER TO postgres;

--
-- TOC entry 3366 (class 0 OID 0)
-- Dependencies: 214
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- TOC entry 220 (class 1259 OID 27729)
-- Name: userslot; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.userslot (
    usersid integer NOT NULL,
    lotid integer NOT NULL
);


ALTER TABLE public.userslot OWNER TO postgres;

--
-- TOC entry 3193 (class 2604 OID 27716)
-- Name: bet id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bet ALTER COLUMN id SET DEFAULT nextval('public.bet_id_seq'::regclass);


--
-- TOC entry 3189 (class 2604 OID 27704)
-- Name: lot id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lot ALTER COLUMN id SET DEFAULT nextval('public.lot_id_seq'::regclass);


--
-- TOC entry 3187 (class 2604 OID 27694)
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- TOC entry 3357 (class 0 OID 27713)
-- Dependencies: 219
-- Data for Name: bet; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.bet (id, usersid, lotid, salary) VALUES (1, 1, 1, 600);
INSERT INTO public.bet (id, usersid, lotid, salary) VALUES (2, 2, 58, 900);


--
-- TOC entry 3355 (class 0 OID 27701)
-- Dependencies: 217
-- Data for Name: lot; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (1, 'Мандарин', 500, false, '2024-02-29 14:40:33.4014+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (2, 'Мандарин', 500, false, '2024-02-29 14:43:53.173295+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (3, 'Мандарин', 500, false, '2024-02-29 14:45:58.670449+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (4, 'Мандарин', 500, false, '2024-02-29 14:46:16.692026+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (5, 'Мандарин', 500, false, '2024-02-29 14:48:54.834279+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (6, 'Мандарин', 500, false, '2024-02-29 14:50:16.898275+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (7, 'Мандарин', 500, false, '2024-02-29 14:52:17.040925+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (8, 'Мандарин', 500, false, '2024-02-29 14:54:21.775944+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (9, 'Мандарин', 500, false, '2024-02-29 14:56:23.363104+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (10, 'Мандарин', 500, false, '2024-02-29 15:04:57.522935+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (11, 'Мандарин', 500, false, '2024-02-29 15:09:35.352358+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (12, 'Мандарин', 500, false, '2024-02-29 15:11:22.158886+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (13, 'Мандарин', 500, false, '2024-02-29 15:21:42.900159+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (14, 'Мандарин', 500, false, '2024-02-29 15:23:27.953607+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (15, 'Мандарин', 500, false, '2024-02-29 15:36:37.456447+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (16, 'Мандарин', 500, false, '2024-02-29 15:38:33.537213+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (17, 'Мандарин', 500, false, '2024-02-29 15:39:23.050462+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (18, 'Мандарин', 500, false, '2024-02-29 15:40:54.803574+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (19, 'Мандарин', 500, false, '2024-02-29 15:43:57.91285+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (20, 'Мандарин', 500, false, '2024-02-29 15:46:56.690341+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (21, 'Мандарин', 500, false, '2024-02-29 15:53:17.114692+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (22, 'Мандарин', 500, false, '2024-02-29 15:55:11.678412+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (23, 'Мандарин', 500, false, '2024-02-29 16:48:55.311463+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (24, 'Мандарин', 500, false, '2024-02-29 16:51:56.775897+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (25, 'Мандарин', 500, false, '2024-02-29 16:56:41.37517+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (26, 'Мандарин', 500, false, '2024-03-01 11:38:14.458966+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (27, 'Мандарин', 500, false, '2024-03-01 11:38:54.53867+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (28, 'Мандарин', 500, false, '2024-03-01 11:39:44.08143+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (29, 'Мандарин', 500, false, '2024-03-01 11:48:28.506468+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (30, 'Мандарин', 500, false, '2024-03-01 11:52:07.135942+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (31, 'Мандарин', 500, false, '2024-03-01 11:56:09.399468+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (32, 'Мандарин', 500, false, '2024-03-01 12:07:09.460385+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (33, 'Мандарин', 500, false, '2024-03-01 12:08:10.237582+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (34, 'Мандарин', 500, false, '2024-03-01 12:08:59.911452+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (35, 'Мандарин', 500, false, '2024-03-01 12:09:31.356772+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (36, 'Мандарин', 500, false, '2024-03-01 12:11:44.250716+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (37, 'Мандарин', 500, false, '2024-03-01 12:16:39.408649+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (38, 'Мандарин', 500, false, '2024-03-01 12:20:31.916561+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (39, 'Мандарин', 500, false, '2024-03-01 12:21:07.806862+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (40, 'Мандарин', 500, false, '2024-03-01 12:24:13.429739+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (41, 'Мандарин', 500, false, '2024-03-01 12:25:06.530034+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (42, 'Мандарин', 500, false, '2024-03-01 12:55:16.045834+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (43, 'Мандарин', 500, false, '2024-03-01 12:58:34.66466+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (44, 'Мандарин', 500, false, '2024-03-01 13:03:13.838759+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (45, 'Мандарин', 500, false, '2024-03-01 13:05:23.141746+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (58, 'Мандарин', 500, true, '2024-03-01 14:39:48.488772+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (46, 'Мандарин', 500, false, '2024-03-01 13:28:38.556439+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (47, 'Мандарин', 500, false, '2024-03-01 13:30:45.763217+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (48, 'Мандарин', 500, false, '2024-03-01 13:33:09.335922+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (49, 'Мандарин', 500, false, '2024-03-01 13:35:27.140438+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (50, 'Мандарин', 500, false, '2024-03-01 13:40:32.180955+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (51, 'Мандарин', 500, false, '2024-03-01 13:42:23.456147+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (52, 'Мандарин', 500, false, '2024-03-01 13:43:05.747168+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (53, 'Мандарин', 500, false, '2024-03-01 13:44:06.159462+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (54, 'Мандарин', 500, false, '2024-03-01 13:45:27.329796+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (55, 'Мандарин', 500, false, '2024-03-01 13:46:31.33214+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (56, 'Мандарин', 500, false, '2024-03-01 13:48:20.453562+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (57, 'Мандарин', 500, false, '2024-03-01 13:48:37.280536+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (59, 'Мандарин', 500, true, '2024-03-01 14:48:05.894707+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (60, 'Мандарин', 500, true, '2024-03-01 14:49:12.683582+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (61, 'Мандарин', 500, true, '2024-03-01 14:50:00.375893+03');
INSERT INTO public.lot (id, name, start_bet, alive, date_created) VALUES (62, 'Мандарин', 500, true, '2024-03-01 14:54:25.491976+03');


--
-- TOC entry 3353 (class 0 OID 27691)
-- Dependencies: 215
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.users (id, name, surname, email, password, birthday) VALUES (1, 'Данила', 'Денисенко', 'felly991@mail.ru', '12345', '2003-04-09');
INSERT INTO public.users (id, name, surname, email, password, birthday) VALUES (2, 'd', 'd', '12345@mail.ru', '12345', '2024-02-29');
INSERT INTO public.users (id, name, surname, email, password, birthday) VALUES (3, 'string', 'string', 'string', 'string', '2024-02-29');


--
-- TOC entry 3358 (class 0 OID 27729)
-- Dependencies: 220
-- Data for Name: userslot; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 3367 (class 0 OID 0)
-- Dependencies: 218
-- Name: bet_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.bet_id_seq', 2, true);


--
-- TOC entry 3368 (class 0 OID 0)
-- Dependencies: 216
-- Name: lot_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.lot_id_seq', 62, true);


--
-- TOC entry 3369 (class 0 OID 0)
-- Dependencies: 214
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 3, true);


--
-- TOC entry 3201 (class 2606 OID 27718)
-- Name: bet bet_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bet
    ADD CONSTRAINT bet_pkey PRIMARY KEY (id);


--
-- TOC entry 3197 (class 2606 OID 27711)
-- Name: lot lot_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lot
    ADD CONSTRAINT lot_pkey PRIMARY KEY (id);


--
-- TOC entry 3205 (class 2606 OID 27733)
-- Name: userslot pk_users_lot; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.userslot
    ADD CONSTRAINT pk_users_lot PRIMARY KEY (usersid, lotid);


--
-- TOC entry 3195 (class 2606 OID 27699)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 3198 (class 1259 OID 27747)
-- Name: IX_bet_lotId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_bet_lotId" ON public.bet USING btree (lotid);


--
-- TOC entry 3199 (class 1259 OID 27746)
-- Name: IX_bet_usersId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_bet_usersId" ON public.bet USING btree (usersid);


--
-- TOC entry 3202 (class 1259 OID 27745)
-- Name: IX_usersLot_lot; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_usersLot_lot" ON public.userslot USING btree (lotid);


--
-- TOC entry 3203 (class 1259 OID 27744)
-- Name: IX_usersLot_users; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_usersLot_users" ON public.userslot USING btree (usersid);


--
-- TOC entry 3206 (class 2606 OID 27724)
-- Name: bet fk_lot; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bet
    ADD CONSTRAINT fk_lot FOREIGN KEY (lotid) REFERENCES public.lot(id) ON DELETE CASCADE;


--
-- TOC entry 3208 (class 2606 OID 27739)
-- Name: userslot fk_lot; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.userslot
    ADD CONSTRAINT fk_lot FOREIGN KEY (lotid) REFERENCES public.lot(id) ON DELETE CASCADE;


--
-- TOC entry 3207 (class 2606 OID 27719)
-- Name: bet fk_users; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bet
    ADD CONSTRAINT fk_users FOREIGN KEY (usersid) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- TOC entry 3209 (class 2606 OID 27734)
-- Name: userslot fk_users; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.userslot
    ADD CONSTRAINT fk_users FOREIGN KEY (usersid) REFERENCES public.users(id) ON DELETE CASCADE;


-- Completed on 2024-03-01 17:07:36

--
-- PostgreSQL database dump complete
--

