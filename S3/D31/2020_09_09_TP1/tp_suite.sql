CREATE TABLE mespays (country_id char(3) NOT NULL, name varchar2(52) NOT NULL, continent varchar2(14) NOT NULL, region varchar2(26) NOT NULL, surface_area number(10,2) NOT NULL, independence_year number(6), population number(11), life_expectancy number(3,1), gnp number(10,2), gnp_old number(10,2), local_name varchar2(60),  government_form varchar2(45) NOT NULL, head_of_state varchar2(60), capital number(11), code2 char(2) NOT NULL );

CREATE TABLE mesvilles (city_id number(11) NOT NULL, name varchar2(60) NOT NULL, country_id char(3) NOT NULL, district varchar2(60), population number(11));

CREATE TABLE meslangues (country_code char(3) NOT NULL, language varchar2(30) NOT NULL, official char(1) NOT NULL, percentage number(4,1));

-- ==================================
-- mespays

ALTER TABLE mespays ADD CONSTRAINT PK_COUNTRY_ID PRIMARY KEY (country_id);
ALTER TABLE mespays ADD CONSTRAINT CK_CONTINENT CHECK (INITCAP(continent) IN ('Asia','Europe','North America','Africa','Oceania','Antarctica','South America'));
ALTER TABLE mespays ADD CONSTRAINT FK_CAPITAL FOREIGN KEY (capital) REFERENCES mesvilles (city_id);

-- ==================================
-- mesvilles

ALTER TABLE mesvilles ADD CONSTRAINT PK_CITY_ID PRIMARY KEY (city_id);
ALTER TABLE mesvilles ADD CONSTRAINT FK_COUNTRY_ID FOREIGN KEY (country_id) REFERENCES mespays (country_id);

-- ==================================
-- meslangues

ALTER TABLE meslangues ADD CONSTRAINT PK_COUNTRY_CODE_LANGUAGE PRIMARY KEY (country_code, language);
ALTER TABLE meslangues ADD CONSTRAINT FK_COUNTRY_CODE FOREIGN KEY (country_code) REFERENCES mespays (country_id);
ALTER TABLE meslangues ADD CONSTRAINT CK_OFFICIAL CHECK (upper(official) in ('T','F'));

--===================================
--ajouter données

ALTER TABLE mespays DISABLE CONSTRAINT FK_CAPITAL;

ALTER TABLE mesvilles DISABLE CONSTRAINT FK_COUNTRY_ID;

ALTER TABLE meslangues DISABLE CONSTRAINT FK_COUNTRY_CODE;


INSERT INTO mesvilles VALUES(2974, 'Paris', 'FRA', 'île-de-France', 2125246);
INSERT INTO mespays VALUES ('FRA', 'France', 'Europe', 'Western Europe', 551500.00, 846, 59225700, 78.8, 1424285.00, 1392448.00, 'France', 'Republic', 'Jacques Chirac', 2974, 'FR');
START script_prof.sql;

ALTER TABLE mespays ENABLE CONSTRAINT FK_CAPITAL;

ALTER TABLE mesvilles ENABLE CONSTRAINT FK_COUNTRY_ID;

ALTER TABLE meslangues ENABLE CONSTRAINT FK_COUNTRY_CODE;
